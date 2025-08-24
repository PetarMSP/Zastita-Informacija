using CryptoFileTransferApp.Core;
using CryptoFileTransferApp.Crypto;
using CryptoFileTransferApp.Networking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;

namespace CryptoFileTransferApp
{
    public partial class MainForm : Form
    {
        bool isRC6 = false;
        private Server server;  
        private CancellationTokenSource cts; 
        private string selectedTextBox = "None";
        private WatcherService watcherService;
        private string targetFolder = @"F:\\FAKS\IV godina\\Zastita informacija\\Projekat2025\\CryptoFileTransferApp\\CryptoTarget";
        private string encryptedFolderX = @"F:\\FAKS\IV godina\\Zastita informacija\\Projekat2025\\CryptoFileTransferApp\\CryptoEncryptedX";

        public MainForm()
        {
            InitializeComponent();
            Visibility(false,false);
            watcherService = new WatcherService(targetFolder);
            watcherService.FileCreated += OnFileCreated;
            SetSize(540, 480);
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                isRC6 = false;
                Visibility(false, false);
            }
            else if(tabControl1.SelectedIndex == 1)
            {
                isRC6 = true;
                Visibility(false, false);
            }
        }
        private void SetSize(int formHeight, int tabHeight)
        {
            this.Size = new Size(this.Size.Width, formHeight);
            tabControl1.Size = new Size(tabControl1.Size.Width, tabHeight);
        }
        private void Visibility(bool state, bool TCP)
        {
            if (isRC6)
            {
                lblListFSWRC6.Visible = state;
                listViewFSWRC6.Visible = state;
                tabControlTCPforRC6.Visible = TCP;

            }else{

                lblListFSWPlayFair.Visible = state;
                listViewFSWPlayFair.Visible = state;
                tabControlTCPforPC.Visible = TCP;
            }
        }
        private void LoadExistingFiles()
        {
            if (!Directory.Exists(targetFolder)) return;

            string[] files = Directory.GetFiles(targetFolder, "*.txt");

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);

                var item = new ListViewItem(fileName)
                {
                    Tag = file 
                };
                if (isRC6)
                {
                    listViewFSWRC6.Items.Add(item);
                }
                else
                {
                    listViewFSWPlayFair.Items.Add(item);
                }
            }
        }
        private void OnFileCreated(string path)
        {
            string fileName = Path.GetFileName(path);
            Invoke(new Action(() =>
            {
                if (isRC6)
                    listViewFSWRC6.Items.Add(fileName);
                else
                    listViewFSWPlayFair.Items.Add(fileName);
            }));

            Thread t = new Thread(() =>
            {
                Thread.Sleep(200); 

                try
                {
                    if (isRC6)
                    {

                        string key = (string)txtBoxRC6Key.Invoke(new Func<string>(() => txtBoxRC6Key.Text));

                        if (string.IsNullOrWhiteSpace(key))
                        {
                            // Generise random kljuc 16 bajtova = 128-bitni
                            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
                            {
                                byte[] randomKey = new byte[16];
                                rng.GetBytes(randomKey);
                                key = Convert.ToBase64String(randomKey);

                                
                                Invoke(new Action(() =>
                                {
                                    txtBoxRC6Key.Text = key;
                                }));
                            }
                        }

                        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                        bool pcbcChecked = (bool)checkBoxPCBC.Invoke(new Func<bool>(() => checkBoxPCBC.Checked));

                        byte[] data = File.ReadAllBytes(path);
                        byte[] encrypted;
                        byte[] iv = null;

                        if (pcbcChecked)
                        {
                            (encrypted, iv) = PCBC.Encrypt(data, keyBytes);

                            byte[] finalData = new byte[iv.Length + encrypted.Length];
                            Buffer.BlockCopy(iv, 0, finalData, 0, iv.Length);
                            Buffer.BlockCopy(encrypted, 0, finalData, iv.Length, encrypted.Length);
                            encrypted = finalData;
                        }
                        else
                        {
                            RC6 rc6 = new RC6(keyBytes);
                            encrypted = rc6.Encrypt(data);
                        }

                        string nameOnly = Path.GetFileNameWithoutExtension(path);
                        string extension = Path.GetExtension(path);

                        string encryptedPath;
                        if (pcbcChecked)
                            encryptedPath = Path.Combine(encryptedFolderX, $"{nameOnly}{extension}.rc6mod");
                        else
                            encryptedPath = Path.Combine(encryptedFolderX, $"{nameOnly}{extension}.rc6");

                        File.WriteAllBytes(encryptedPath, encrypted);

                      
                        string keyPath = Path.Combine(encryptedFolderX, $"{nameOnly}.key");
                        File.WriteAllText(keyPath, key);

                        Invoke(new Action(() =>
                        {
                            statusLabelRC6.Text = $"RC6 fajl {fileName} uspešno enkriptovan i sačuvan kao {encryptedPath}\nKljuc sacuvan u {keyPath}";
                        }));
                    }
                    else
                    {
                        string content = File.ReadAllText(path);
                        string key = (string)txtBoxPFCKey.Invoke(new Func<string>(() => txtBoxPFCKey.Text));
                        string encrypted = PlayfairCipher.Encrypt(content, key);

                        string outputPath = Path.Combine(encryptedFolderX, fileName);
                        File.WriteAllText(outputPath, key + Environment.NewLine + encrypted);

                        Invoke(new Action(() =>
                        {
                            statusLabelRC6.Text = $"Playfair fajl {fileName} uspešno enkriptovan i sačuvan kao {outputPath}";
                        }));
                    }
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show("Greška prilikom obrade fajla: " + ex.Message,
                            "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
            });
            t.Start();
        }


        // Postavi selectedTextBox kada TextBox dobije fokus
        private void txtBoxPlain_Enter(object sender, EventArgs e) => selectedTextBox = "Plain";
        private void txtBoxEncrypted_Enter(object sender, EventArgs e) => selectedTextBox = "Encrypted";

        // Ako se napusti neki TextBox i aktivna kontrola nije nijedan TextBox promeljivu postavi na "None"
        private void AnyTextBox_Leave()
        {
            // Ako ni jedan textbox više nije aktivan (fokusiran)
            if (this.ActiveControl != txtBoxPlain &&
                this.ActiveControl != txtBoxEncrypted)
            {
                selectedTextBox = "None";
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtBoxPlain.Text != "")
            {
                if (string.IsNullOrWhiteSpace(txtBoxPFCKey.Text))
                {
                    MessageBox.Show("Niste uneli kljuc!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Thread t = new Thread(() =>
                {
                    string key = txtBoxPFCKey.Invoke(new Func<string>(() => txtBoxPFCKey.Text)) as string;
                    string plain = txtBoxPlain.Invoke(new Func<string>(() => txtBoxPlain.Text)) as string;
                    string result = PlayfairCipher.Encrypt(plain, key);
                    txtBoxEncrypted.Invoke(new Action(() => txtBoxEncrypted.Text = result));
                });
                t.Start();
            }
            else
            {
                MessageBox.Show("Niste uneli nikakav tekst za sifrovanje!", "Greska !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (txtBoxEncrypted.Text != "")
            {
                if (string.IsNullOrWhiteSpace(txtBoxPFCKey.Text))
                {
                    MessageBox.Show("Niste uneli kljuc!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Thread t = new Thread(() =>
                {
                    string key = txtBoxPFCKey.Invoke(new Func<string>(() => txtBoxPFCKey.Text)) as string;
                    string cipher = txtBoxEncrypted.Invoke(new Func<string>(() => txtBoxEncrypted.Text)) as string;
                    string result = PlayfairCipher.Decrypt(cipher, key);
                    txtBoxPlain.Invoke(new Action(() => txtBoxPlain.Text = result));
                });
                t.Start();
            }
            else
            {
                MessageBox.Show("Niste uneli nikakav tekst za desifrovanje!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            if (selectedTextBox != "None")
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string content = File.ReadAllText(ofd.FileName);

                        string fileNameOnly = Path.GetFileName(ofd.FileName);

                        if (selectedTextBox == "Plain")
                        {
                            txtBoxPlain.Text = content;
                            lblFileNamePFC.Text = "Ime fajla:" + fileNameOnly;
                        }
                        else
                        {
                            txtBoxEncrypted.Text = content;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Niste selektovali polje teksta koji zelite da sacuvate!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AnyTextBox_Leave();
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            if (selectedTextBox != "None")
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (selectedTextBox == "Plain") File.WriteAllText(sfd.FileName, txtBoxPlain.Text);
                        else File.WriteAllText(sfd.FileName, txtBoxEncrypted.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("Niste selektovali polje teksta koji zelite da sacuvate!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AnyTextBox_Leave();
        }

        private async void btnStartListening_Click(object sender, EventArgs e)
        {
            try
            {
                int port = 0;
                if (isRC6)
                {
                    port = int.Parse(txtBoxPortServerRC6.Text);
                }
                else
                {
                    port = int.Parse(txtBoxPortServerPFC.Text);
                }
                server = new Server();
                cts = new CancellationTokenSource();

                // Pokretanje servera asinhrono
                _ = Task.Run(() => server.StartAsync(port, msg =>
                {                 
                    this.Invoke(new Action(() =>
                    {
                        if (isRC6)
                        {
                            statusLabelRC6.Text = msg;
                        }
                        else
                        {
                            statusLabelPFC.Text = msg;
                        }
                        
                    }));
                }), cts.Token);

                if (isRC6)
                {
                    statusLabelRC6.Text = $"Server pokrenut na portu {port}";
                }
                else
                {
                    statusLabelPFC.Text = $"Server pokrenut na portu {port}";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri pokretanju servera: " + ex.Message,"Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStopListening_Click(object sender, EventArgs e)
        {
            try
            {
                cts?.Cancel();
                server?.Stop(msg =>
                {
                    this.Invoke(new Action(() =>
                    {
                        if (isRC6)
                        {
                            statusLabelRC6.Text = msg;
                        }
                        else
                        {
                            statusLabelPFC.Text = msg;
                        }
                    }));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri zaustavljanju servera: " + ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSendPlayfairCipher_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxPlain.Text))
            {
                MessageBox.Show("Nema podataka za slanje!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtBoxPFCKey.Text))
            {
                MessageBox.Show("Niste uneli kljuc!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string key = txtBoxPFCKey.Invoke(new Func<string>(() => txtBoxPFCKey.Text)) as string;
            string plain = txtBoxPlain.Invoke(new Func<string>(() => txtBoxPlain.Text)) as string;
            string result = PlayfairCipher.Encrypt(plain, key);

            // Generisanje imena fajla
            string fileName;
            if (!string.IsNullOrWhiteSpace(lblFileNamePFC.Text) && lblFileNamePFC.Text.Contains(":"))
            {
                try
                {
                    string[] nameOnly = lblFileNamePFC.Text.Split(':');
                    string originalFullName = nameOnly[1].Trim();

                    string originalFileName = Path.GetFileNameWithoutExtension(originalFullName);
                    string extension = Path.GetExtension(originalFullName);

                    fileName = $"{originalFileName}_{DateTime.Now:yyyyMMdd_HHmmss}{extension}";
                }
                catch
                {
                    fileName = $"encrypted_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                }
            }
            else
            {
                fileName = $"encrypted_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            }

            // Privremeni fajl koji se salje
            string tempFolder = Path.GetTempPath();
            string tempPath = Path.Combine(tempFolder, fileName);
            File.WriteAllText(tempPath, key + Environment.NewLine + result);

            // Slanje fajla asinhrono
            Task.Run(async () =>
            {
                var client = new Client();
                await client.SendFileAsync(txtBoxIPAdrPFC.Text, int.Parse(txtBoxPortClientPFC.Text), tempPath, "PlayfairCipher",null, (msg) =>
                {
                    this.Invoke((MethodInvoker)(() => 
                    {
                        MessageBox.Show(msg, "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        statusLabelPFC.Text = msg;
                    }));
                });
            });
        }


        private void checkBoxFileTPlayFC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFileTPlayFC.Checked && !checkBoxFSWPlayFC.Checked)
            {
                Visibility(false, true);
                SetSize(700, 870);
            }
            else if (checkBoxFileTPlayFC.Checked && checkBoxFSWPlayFC.Checked)
            {
                Visibility(true, true);
                SetSize(700, 870);
            }
            else if (!checkBoxFileTPlayFC.Checked && checkBoxFSWPlayFC.Checked)
            {
                Visibility(true, false);
                SetSize(700, 870);
            }
            else
            {
                Visibility(false, false);
                SetSize(540, 480);
            }
        }
        private void checkBoxFSW_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFSWPlayFC.Checked && !checkBoxFileTPlayFC.Checked)
            {
                LoadExistingFiles();
                watcherService.Start();
                Visibility(true,false);
                SetSize(700, 870);
            }
            else if (checkBoxFSWPlayFC.Checked && checkBoxFileTPlayFC.Checked)
            {
                LoadExistingFiles();
                watcherService.Start();
                Visibility(true, true);
                SetSize(700, 870);
            }
            else if (!checkBoxFSWPlayFC.Checked && checkBoxFileTPlayFC.Checked)
            {
                watcherService.Stop();
                listViewFSWPlayFair.Items.Clear();
                Visibility(false, true);
                SetSize(700, 870);
            }
            else
            {
                watcherService.Stop();
                listViewFSWPlayFair.Items.Clear();
                Visibility(false,false);
                SetSize(540, 480);
            }
        }


        //private void listViewFWSPlayFair_DoubleClick(object sender, EventArgs e)
        //{
        //    if (listViewFWSPlayFair.SelectedItems.Count == 0) return;
        //    string path = listViewFWSPlayFair.SelectedItems[0].Text;
        //    Thread t = new Thread(() =>
        //    {
        //        string[] lines = File.ReadAllLines(targetFolder + "\\" + path);
        //        string key = lines[0];
        //        string encrypted = string.Join(Environment.NewLine, lines.Skip(1));
        //        string decrypted = PlayfairCipher.Decrypt(encrypted, key);
        //        txtBoxDecrypted.Invoke(new Action(() => txtBoxDecrypted.Text = decrypted));
        //    });
        //    t.Start();
        //}
        //#endregion
        #region RC6
        private void btnEncryptRC6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxRC6Key.Text))
            {
                MessageBox.Show("Niste uneli kljuc!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Izaberite fajl za enkripciju";
            ofd.Filter = "Svi fajlovi (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] data = File.ReadAllBytes(ofd.FileName);

                    string key = txtBoxRC6Key.Text;
                    byte[] keyBytes = Encoding.UTF8.GetBytes(key);

                    byte[] encrypted;
                    byte[] iv = null;

                    if (checkBoxPCBC.Checked)
                    {
                        // PCBC mod → vraca cipher i iv
                        (encrypted, iv) = PCBC.Encrypt(data, keyBytes);

                        // spojimo iv + cipher u jedan fajl
                        byte[] finalData = new byte[iv.Length + encrypted.Length];
                        Buffer.BlockCopy(iv, 0, finalData, 0, iv.Length);
                        Buffer.BlockCopy(encrypted, 0, finalData, iv.Length, encrypted.Length);

                        encrypted = finalData;
                    }
                    else
                    {
                        RC6 rc6 = new RC6(keyBytes);
                        encrypted = rc6.Encrypt(data);
                    }

                    string folder = Path.GetDirectoryName(ofd.FileName);
                    string nameOnly = Path.GetFileNameWithoutExtension(ofd.FileName);
                    string extension = Path.GetExtension(ofd.FileName);
                    string encryptedPath = null;
                    if (checkBoxPCBC.Checked)
                    {
                         encryptedPath = Path.Combine(folder, $"{nameOnly}{extension}.rc6mod");
                    }
                    else
                    {
                         encryptedPath = Path.Combine(folder, $"{nameOnly}{extension}.rc6");
                    }
                    File.WriteAllBytes(encryptedPath, encrypted);

                    string keyPath = Path.Combine(folder, $"{nameOnly}.key");
                    File.WriteAllText(keyPath, key);

                    MessageBox.Show($"Fajl uspesno enkriptovan!\nSacuvan kao: {encryptedPath}\nKljuc sacuvan u: {keyPath}",
                                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska pri enkripciji: " + ex.Message);
                }
            }
        }

        private void btnDecryptRC6_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "RC6Mod fajlovi (*.rc6mod)|*.rc6mod|RC6 fajlovi (*.rc6)|*.rc6|Svi fajlovi (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] encrypted = File.ReadAllBytes(ofd.FileName);
                    string folder = Path.GetDirectoryName(ofd.FileName);   

                    string keyPath = Path.GetFileNameWithoutExtension(ofd.FileName); //Skida .rc6 ili .rc6mod ekstezija
                    keyPath = Path.GetFileNameWithoutExtension(keyPath);  //Skida se ekstezija orginalnog fajla
                    keyPath = Path.Combine(folder, $"{keyPath}.key");
                    string key;

                    if (File.Exists(keyPath))
                    {
                        key = File.ReadAllText(keyPath).Trim();
                        txtBoxRC6Key.Text = key;
                    }
                    else
                    {
                        key = txtBoxRC6Key.Text;
                    }

                    byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                    byte[] decryptedBytes;

                    if (checkBoxPCBC.Checked)
                    {
                        if (encrypted.Length < 16)
                            throw new Exception("Fajl je previse mali da bi imao IV i podatke.");

                        byte[] iv = new byte[16];
                        byte[] cipher = new byte[encrypted.Length - 16];
                        Buffer.BlockCopy(encrypted, 0, iv, 0, 16);
                        Buffer.BlockCopy(encrypted, 16, cipher, 0, cipher.Length);

                        decryptedBytes = PCBC.Decrypt(cipher, keyBytes, iv);
                    }
                    else
                    {
                        RC6 rc6 = new RC6(keyBytes);
                        decryptedBytes = rc6.Decrypt(encrypted);
                    }

                    string decryptedPath = ofd.FileName;
                    if (decryptedPath.EndsWith(".rc6", StringComparison.OrdinalIgnoreCase))
                    {
                        decryptedPath = decryptedPath.Substring(0, decryptedPath.Length - 4);
                    }
                    else if (decryptedPath.EndsWith(".rc6mod", StringComparison.OrdinalIgnoreCase))
                    {
                        decryptedPath = decryptedPath.Substring(0, decryptedPath.Length - 7);
                    }

                    MessageBox.Show($"Fajl uspešno dekriptovan!",
                                     "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SaveFileDialog sfd = new SaveFileDialog();

                    sfd.Filter = "Svi fajlovi (*.*)|*.*";
                    sfd.FileName = Path.GetFileName(decryptedPath);

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(sfd.FileName, decryptedBytes);
                        MessageBox.Show($"Sacuvan kao: {sfd.FileName}",
                                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska pri dekriptovanju: " + ex.Message);
                }
            }
        }

        private void checkBoxTCPRC6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTCPRC6.Checked && !checkBoxFSWRC6.Checked)
            {
                Visibility(false, true);
                SetSize(700, 870);
            }
            else if (checkBoxTCPRC6.Checked && checkBoxFSWRC6.Checked)
            {
                Visibility(true, true);
                SetSize(700, 870);
            }
            else if (!checkBoxTCPRC6.Checked && checkBoxFSWRC6.Checked)
            {
                Visibility(true, false);
                SetSize(700, 870);
            }
            else
            {
                Visibility(false, false);
                SetSize(420, 400);
            }
        }
        private void checkBoxFSWRC6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFSWRC6.Checked && !checkBoxTCPRC6.Checked)
            {
                LoadExistingFiles();
                watcherService.Start();
                Visibility(true, false);
                SetSize(700, 870);
            }
            else if (checkBoxFSWRC6.Checked && checkBoxTCPRC6.Checked)
            {
                LoadExistingFiles();
                watcherService.Start();
                Visibility(true, true);
                SetSize(700, 870);
            }
            else if (!checkBoxFSWRC6.Checked && checkBoxTCPRC6.Checked)
            {
                watcherService.Stop();
                listViewFSWRC6.Items.Clear();
                Visibility(false, true);
                SetSize(700, 870);
            }
            else
            {
                watcherService.Stop();
                listViewFSWRC6.Items.Clear();
                Visibility(false, false);
                SetSize(420, 400);
            }
        }

        private void btnSendRC6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxRC6Key.Text))
            {
                MessageBox.Show("Niste uneli kljuc!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string key = txtBoxRC6Key.Invoke(new Func<string>(() => txtBoxRC6Key.Text)) as string;
            byte[] encrypted = null;
            byte[] keyBytes = null;
            string tempPath = null;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Izaberite fajl za enkripciju";
            ofd.Filter = "Svi fajlovi (*.*)|*.*";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                byte[] data = File.ReadAllBytes(ofd.FileName);
                keyBytes = Encoding.UTF8.GetBytes(key);

                byte[] iv = null;

                if (checkBoxPCBC.Checked)
                {
                    (encrypted, iv) = PCBC.Encrypt(data, keyBytes);
                    byte[] finalData = new byte[iv.Length + encrypted.Length];
                    Buffer.BlockCopy(iv, 0, finalData, 0, iv.Length);
                    Buffer.BlockCopy(encrypted, 0, finalData, iv.Length, encrypted.Length);
                    encrypted = finalData;
                }
                else
                {
                    RC6 rc6 = new RC6(keyBytes);
                    encrypted = rc6.Encrypt(data);
                }

                string nameOnly = Path.GetFileNameWithoutExtension(ofd.FileName);
                string extension = Path.GetExtension(ofd.FileName);

                string tempFolder = Path.GetTempPath();
                string suffix = checkBoxPCBC.Checked ? ".rc6mod" : ".rc6";
                tempPath = Path.Combine(tempFolder, $"{nameOnly}_{DateTime.Now:yyyyMMdd_HHmmss}{extension}{suffix}");

                File.WriteAllBytes(tempPath, encrypted);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri enkripciji: " + ex.Message);
                return;
            }

            // Slanje fajla asinhrono
            Task.Run(async () =>
            {
                var client = new Client();
                await client.SendFileAsync(txtBoxIPAdrRC6.Text, int.Parse(txtBoxPortClientRC6.Text), tempPath, "RC6", keyBytes, (msg) =>
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        MessageBox.Show(msg, "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        statusLabelPFC.Text = msg;
                    }));
                });
            });
        }

        #endregion
    }
}
