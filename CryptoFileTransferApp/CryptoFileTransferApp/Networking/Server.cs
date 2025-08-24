using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptoFileTransferApp.Crypto; 

namespace CryptoFileTransferApp.Networking
{
    public class Server
    {
        private Socket serverSocket;
        private bool isRunning;
        private bool stopping;
        private readonly string targetFolder =
            @"F:\\FAKS\\IV godina\\Zastita informacija\\Projekat2025\\CryptoFileTransferApp\\CryptoTarget";

        public async Task StartAsync(int port, Action<string> statusCallback)
        {
            if (isRunning) { statusCallback?.Invoke("Server je vec pokrenut."); return; }

            if (!Directory.Exists(targetFolder))
                Directory.CreateDirectory(targetFolder);

            stopping = false;
            isRunning = true;

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
                serverSocket.Listen(10);
                statusCallback?.Invoke($"Server osluskuje na portu {port}");

                while (isRunning)
                {
                    Socket clientSocket = null;
                    try
                    {
                        clientSocket = await serverSocket.AcceptAsync().ConfigureAwait(false);
                    }
                    catch (ObjectDisposedException)
                    {
                        if (stopping) break;
                        throw;
                    }
                    catch (SocketException ex)
                    {
                        if (stopping) break;
                        statusCallback?.Invoke("Greska Accept: " + ex.Message);
                        continue;
                    }

                    if (clientSocket != null)
                        _ = Task.Run(() => HandleClientAsync(clientSocket, statusCallback));
                }
            }
            catch (Exception ex)
            {
                if (!stopping)
                    statusCallback?.Invoke("Greska servera: " + ex.Message);
            }
            finally
            {
                try { serverSocket?.Close(); } catch { }
                serverSocket = null;
                isRunning = false;
                if (stopping)
                    statusCallback?.Invoke("Server zaustavljen.");
            }
        }

        public void Stop(Action<string> statusCallback)
        {
            if (!isRunning && serverSocket == null)
            {
                statusCallback?.Invoke("Server je već zaustavljen.");
                return;
            }

            stopping = true;
            isRunning = false;

            try { serverSocket?.Close(); } catch { }
            serverSocket = null;

            statusCallback?.Invoke("Server zaustavljen.");
        }

        private async Task HandleClientAsync(Socket clientSocket, Action<string> statusCallback)
        {
            try
            {
                using (clientSocket)
                using (NetworkStream networkStream = new NetworkStream(clientSocket))
                using (BinaryReader reader = new BinaryReader(networkStream))
                using (BinaryWriter writer = new BinaryWriter(networkStream))
                {
                    
                    string fileName = reader.ReadString();
                    long fileSize = reader.ReadInt64();
                    int hashSize = reader.ReadInt32();
                    string algorithm = reader.ReadString();

                    statusCallback?.Invoke($"Primam fajl: {fileName} ({fileSize} bajtova kodiran sa {algorithm})");

                    byte[] sentHash = reader.ReadBytes(hashSize);

                    string savePath = Path.Combine(targetFolder, "Received_" + Path.GetFileName(fileName));
                    byte[] keyBytes = null;

                    if (algorithm == "RC6")
                    {
                        int keyLength = reader.ReadInt32();
                        keyBytes = reader.ReadBytes(keyLength); 
                    }
                    long totalRead = 0;
                    byte[] buffer = new byte[8192];

                    using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        while (totalRead < fileSize)
                        {
                            
                            int read = await networkStream.ReadAsync(buffer, 0, (int)Math.Min(buffer.Length, fileSize - totalRead)).ConfigureAwait(false);
                            if (read == 0) break;

                            await fs.WriteAsync(buffer, 0, read).ConfigureAwait(false);
                            totalRead += read;
                        }
                    }

                    //Uporedi hash
                    string computedHash;
                    using (FileStream fs = new FileStream(savePath, FileMode.Open, FileAccess.Read))
                        computedHash = SHA1Helper.Hash(fs);

                    string sentHashStr = System.Text.Encoding.UTF8.GetString(sentHash);

                    if (computedHash == sentHashStr)
                    {
                        statusCallback?.Invoke($"Fajl {fileName} uspesno primljen i verifikovan.");
                        writer.Write("Fajl uspesno primljen i verifikovan.");

                        try
                        {

                            if (algorithm == "PlayfairCipher")
                            {
                                string[] lines = File.ReadAllLines(savePath);

                                if (lines.Length < 2)
                                {
                                    statusCallback?.Invoke("Fajl nema dovoljno podataka za dekripciju!");
                                }
                                else
                                {
                                    string key = lines[0];
                                    string encryptedText = string.Join(Environment.NewLine, lines.Skip(1));

                                    string decodedText = PlayfairCipher.Decrypt(encryptedText, key);

                                    string decodedPath = Path.Combine(
                                        Path.GetDirectoryName(savePath),
                                        Path.GetFileNameWithoutExtension(savePath) + "_decoded.txt"
                                    );

                                    File.WriteAllText(decodedPath, decodedText);

                                    statusCallback?.Invoke($"Dekodirano i sacuvano u {decodedPath}");
                                }
                            }
                            else if (algorithm == "RC6")
                            {
                                statusCallback?.Invoke("Pokusavam da dekriptujem RC6 fajl...");

                                byte[] encrypted = File.ReadAllBytes(savePath);
                                byte[] decryptedBytes = null;

                                if (savePath.EndsWith(".rc6mod", StringComparison.OrdinalIgnoreCase))
                                {
                                    statusCallback?.Invoke("Prepoznat .rc6mod fajl (PCBC mod).");

                                    if (encrypted.Length < 16)
                                        throw new Exception("Fajl je previse mali da bi imao IV i podatke.");

                                    byte[] iv = new byte[16];
                                    byte[] cipher = new byte[encrypted.Length - 16];
                                    Buffer.BlockCopy(encrypted, 0, iv, 0, 16);
                                    Buffer.BlockCopy(encrypted, 16, cipher, 0, cipher.Length);

                                    decryptedBytes = PCBC.Decrypt(cipher, keyBytes, iv);
                                }
                                else if (savePath.EndsWith(".rc6", StringComparison.OrdinalIgnoreCase))
                                {
                                    statusCallback?.Invoke("Prepoznat .rc6 fajl (obicni RC6).");

                                    RC6 rc6 = new RC6(keyBytes);
                                    decryptedBytes = rc6.Decrypt(encrypted);
                                }
                                else
                                {
                                    statusCallback?.Invoke("Ekstenzija fajla nije .rc6 ni .rc6mod!");
                                }

                                if (decryptedBytes != null)
                                {
                                    string decryptedPath = Path.Combine(targetFolder, "Decrypted_" + Path.GetFileNameWithoutExtension(fileName));
                                    File.WriteAllBytes(decryptedPath, decryptedBytes);
                                    statusCallback?.Invoke($"RC6 fajl {fileName} dekriptovan u {decryptedPath}");
                                }
                                else
                                {
                                    statusCallback?.Invoke("Dekriptovanje nije uspelo jer decryptedBytes == null.");
                                }
                            }
                        }
                        catch (Exception dex)
                        {
                            statusCallback?.Invoke($"Greska pri dekodiranju fajla {fileName}: {dex.Message}");
                        }
                    }
                    else
                    {
                        statusCallback?.Invoke($"Fajl {fileName} primljen, ali nije prosao verifikaciju!");
                        writer.Write("Greska: Validacija neuspesna!");
                    }
                }
            }
            catch (Exception ex)
            {
                if (!stopping)
                    statusCallback?.Invoke("Greska pri obradi klijenta: " + ex.Message);
            }
        }
    }
}
