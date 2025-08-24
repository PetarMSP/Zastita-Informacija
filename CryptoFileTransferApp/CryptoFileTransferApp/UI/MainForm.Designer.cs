namespace CryptoFileTransferApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPagePlayfairCipher = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabelPFC = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlTCPforPC = new System.Windows.Forms.TabControl();
            this.ClientforPC = new System.Windows.Forms.TabPage();
            this.Napomena = new System.Windows.Forms.Label();
            this.txtBoxPortClientPFC = new System.Windows.Forms.TextBox();
            this.txtBoxIPAdrPFC = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lbIPadress = new System.Windows.Forms.Label();
            this.btnSendPlayfairCipher = new System.Windows.Forms.Button();
            this.ServerforPC = new System.Windows.Forms.TabPage();
            this.txtBoxPortServerPFC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStopListening = new System.Windows.Forms.Button();
            this.btnStartListening = new System.Windows.Forms.Button();
            this.lblFileNamePFC = new System.Windows.Forms.Label();
            this.checkBoxFileTPlayFC = new System.Windows.Forms.CheckBox();
            this.lblListFSWPlayFair = new System.Windows.Forms.Label();
            this.listViewFSWPlayFair = new System.Windows.Forms.ListView();
            this.checkBoxFSWPlayFC = new System.Windows.Forms.CheckBox();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.btnLoadFromFile = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txtBoxEncrypted = new System.Windows.Forms.TextBox();
            this.lblEncrypted = new System.Windows.Forms.Label();
            this.txtBoxPlain = new System.Windows.Forms.TextBox();
            this.lblPlainTxt = new System.Windows.Forms.Label();
            this.txtBoxPFCKey = new System.Windows.Forms.TextBox();
            this.lblKEY = new System.Windows.Forms.Label();
            this.tabPageRC6 = new System.Windows.Forms.TabPage();
            this.checkBoxPCBC = new System.Windows.Forms.CheckBox();
            this.btnEncryptRC6 = new System.Windows.Forms.Button();
            this.btnDecryptRC6 = new System.Windows.Forms.Button();
            this.txtBoxRC6Key = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControlTCPforRC6 = new System.Windows.Forms.TabControl();
            this.tabClinet = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxPortClientRC6 = new System.Windows.Forms.TextBox();
            this.txtBoxIPAdrRC6 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSendRC6 = new System.Windows.Forms.Button();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.txtBoxPortServerRC6 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStopListeningRC6 = new System.Windows.Forms.Button();
            this.btnStartListeningRC6 = new System.Windows.Forms.Button();
            this.checkBoxTCPRC6 = new System.Windows.Forms.CheckBox();
            this.lblListFSWRC6 = new System.Windows.Forms.Label();
            this.listViewFSWRC6 = new System.Windows.Forms.ListView();
            this.checkBoxFSWRC6 = new System.Windows.Forms.CheckBox();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.statusLabelRC6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabPagePlayfairCipher.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControlTCPforPC.SuspendLayout();
            this.ClientforPC.SuspendLayout();
            this.ServerforPC.SuspendLayout();
            this.tabPageRC6.SuspendLayout();
            this.tabControlTCPforRC6.SuspendLayout();
            this.tabClinet.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPagePlayfairCipher);
            this.tabControl1.Controls.Add(this.tabPageRC6);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1248, 1046);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPagePlayfairCipher
            // 
            this.tabPagePlayfairCipher.Controls.Add(this.statusStrip1);
            this.tabPagePlayfairCipher.Controls.Add(this.tabControlTCPforPC);
            this.tabPagePlayfairCipher.Controls.Add(this.lblFileNamePFC);
            this.tabPagePlayfairCipher.Controls.Add(this.checkBoxFileTPlayFC);
            this.tabPagePlayfairCipher.Controls.Add(this.lblListFSWPlayFair);
            this.tabPagePlayfairCipher.Controls.Add(this.listViewFSWPlayFair);
            this.tabPagePlayfairCipher.Controls.Add(this.checkBoxFSWPlayFC);
            this.tabPagePlayfairCipher.Controls.Add(this.btnSaveToFile);
            this.tabPagePlayfairCipher.Controls.Add(this.btnLoadFromFile);
            this.tabPagePlayfairCipher.Controls.Add(this.btnEncrypt);
            this.tabPagePlayfairCipher.Controls.Add(this.btnDecrypt);
            this.tabPagePlayfairCipher.Controls.Add(this.txtBoxEncrypted);
            this.tabPagePlayfairCipher.Controls.Add(this.lblEncrypted);
            this.tabPagePlayfairCipher.Controls.Add(this.txtBoxPlain);
            this.tabPagePlayfairCipher.Controls.Add(this.lblPlainTxt);
            this.tabPagePlayfairCipher.Controls.Add(this.txtBoxPFCKey);
            this.tabPagePlayfairCipher.Controls.Add(this.lblKEY);
            this.tabPagePlayfairCipher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPagePlayfairCipher.Location = new System.Drawing.Point(4, 25);
            this.tabPagePlayfairCipher.Name = "tabPagePlayfairCipher";
            this.tabPagePlayfairCipher.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePlayfairCipher.Size = new System.Drawing.Size(1240, 1017);
            this.tabPagePlayfairCipher.TabIndex = 0;
            this.tabPagePlayfairCipher.Text = "Playfair Cipher";
            this.tabPagePlayfairCipher.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelPFC});
            this.statusStrip1.Location = new System.Drawing.Point(3, 988);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1234, 26);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelPFC
            // 
            this.statusLabelPFC.Name = "statusLabelPFC";
            this.statusLabelPFC.Size = new System.Drawing.Size(52, 20);
            this.statusLabelPFC.Text = "Status:";
            // 
            // tabControlTCPforPC
            // 
            this.tabControlTCPforPC.Controls.Add(this.ClientforPC);
            this.tabControlTCPforPC.Controls.Add(this.ServerforPC);
            this.tabControlTCPforPC.Location = new System.Drawing.Point(549, 529);
            this.tabControlTCPforPC.Name = "tabControlTCPforPC";
            this.tabControlTCPforPC.SelectedIndex = 0;
            this.tabControlTCPforPC.Size = new System.Drawing.Size(676, 455);
            this.tabControlTCPforPC.TabIndex = 22;
            // 
            // ClientforPC
            // 
            this.ClientforPC.Controls.Add(this.Napomena);
            this.ClientforPC.Controls.Add(this.txtBoxPortClientPFC);
            this.ClientforPC.Controls.Add(this.txtBoxIPAdrPFC);
            this.ClientforPC.Controls.Add(this.lblPort);
            this.ClientforPC.Controls.Add(this.lbIPadress);
            this.ClientforPC.Controls.Add(this.btnSendPlayfairCipher);
            this.ClientforPC.Location = new System.Drawing.Point(4, 27);
            this.ClientforPC.Name = "ClientforPC";
            this.ClientforPC.Padding = new System.Windows.Forms.Padding(3);
            this.ClientforPC.Size = new System.Drawing.Size(668, 424);
            this.ClientforPC.TabIndex = 0;
            this.ClientforPC.Text = "Send";
            this.ClientforPC.UseVisualStyleBackColor = true;
            // 
            // Napomena
            // 
            this.Napomena.AutoSize = true;
            this.Napomena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.Napomena.Location = new System.Drawing.Point(52, 197);
            this.Napomena.Name = "Napomena";
            this.Napomena.Size = new System.Drawing.Size(551, 100);
            this.Napomena.TabIndex = 18;
            this.Napomena.Text = resources.GetString("Napomena.Text");
            // 
            // txtBoxPortClientPFC
            // 
            this.txtBoxPortClientPFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtBoxPortClientPFC.Location = new System.Drawing.Point(142, 130);
            this.txtBoxPortClientPFC.Name = "txtBoxPortClientPFC";
            this.txtBoxPortClientPFC.Size = new System.Drawing.Size(186, 30);
            this.txtBoxPortClientPFC.TabIndex = 17;
            // 
            // txtBoxIPAdrPFC
            // 
            this.txtBoxIPAdrPFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtBoxIPAdrPFC.Location = new System.Drawing.Point(191, 71);
            this.txtBoxIPAdrPFC.Name = "txtBoxIPAdrPFC";
            this.txtBoxIPAdrPFC.Size = new System.Drawing.Size(394, 30);
            this.txtBoxIPAdrPFC.TabIndex = 16;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lblPort.Location = new System.Drawing.Point(52, 134);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(63, 26);
            this.lblPort.TabIndex = 15;
            this.lblPort.Text = "Port:";
            // 
            // lbIPadress
            // 
            this.lbIPadress.AutoSize = true;
            this.lbIPadress.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lbIPadress.Location = new System.Drawing.Point(52, 71);
            this.lbIPadress.Name = "lbIPadress";
            this.lbIPadress.Size = new System.Drawing.Size(120, 26);
            this.lbIPadress.TabIndex = 14;
            this.lbIPadress.Text = "IP adress:";
            // 
            // btnSendPlayfairCipher
            // 
            this.btnSendPlayfairCipher.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnSendPlayfairCipher.Location = new System.Drawing.Point(172, 338);
            this.btnSendPlayfairCipher.Name = "btnSendPlayfairCipher";
            this.btnSendPlayfairCipher.Size = new System.Drawing.Size(317, 47);
            this.btnSendPlayfairCipher.TabIndex = 13;
            this.btnSendPlayfairCipher.Text = "Send";
            this.btnSendPlayfairCipher.UseVisualStyleBackColor = true;
            this.btnSendPlayfairCipher.Click += new System.EventHandler(this.btnSendPlayfairCipher_Click);
            // 
            // ServerforPC
            // 
            this.ServerforPC.Controls.Add(this.txtBoxPortServerPFC);
            this.ServerforPC.Controls.Add(this.label1);
            this.ServerforPC.Controls.Add(this.btnStopListening);
            this.ServerforPC.Controls.Add(this.btnStartListening);
            this.ServerforPC.Location = new System.Drawing.Point(4, 27);
            this.ServerforPC.Name = "ServerforPC";
            this.ServerforPC.Padding = new System.Windows.Forms.Padding(3);
            this.ServerforPC.Size = new System.Drawing.Size(668, 424);
            this.ServerforPC.TabIndex = 1;
            this.ServerforPC.Text = "Recive";
            this.ServerforPC.UseVisualStyleBackColor = true;
            // 
            // txtBoxPortServerPFC
            // 
            this.txtBoxPortServerPFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtBoxPortServerPFC.Location = new System.Drawing.Point(258, 69);
            this.txtBoxPortServerPFC.Name = "txtBoxPortServerPFC";
            this.txtBoxPortServerPFC.Size = new System.Drawing.Size(216, 30);
            this.txtBoxPortServerPFC.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(180, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 26);
            this.label1.TabIndex = 18;
            this.label1.Text = "Port:";
            // 
            // btnStopListening
            // 
            this.btnStopListening.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnStopListening.Location = new System.Drawing.Point(360, 140);
            this.btnStopListening.Name = "btnStopListening";
            this.btnStopListening.Size = new System.Drawing.Size(264, 47);
            this.btnStopListening.TabIndex = 15;
            this.btnStopListening.Text = "Stop Listening";
            this.btnStopListening.UseVisualStyleBackColor = true;
            this.btnStopListening.Click += new System.EventHandler(this.btnStopListening_Click);
            // 
            // btnStartListening
            // 
            this.btnStartListening.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnStartListening.Location = new System.Drawing.Point(39, 140);
            this.btnStartListening.Name = "btnStartListening";
            this.btnStartListening.Size = new System.Drawing.Size(264, 47);
            this.btnStartListening.TabIndex = 14;
            this.btnStartListening.Text = "Start Listening";
            this.btnStartListening.UseVisualStyleBackColor = true;
            this.btnStartListening.Click += new System.EventHandler(this.btnStartListening_Click);
            // 
            // lblFileNamePFC
            // 
            this.lblFileNamePFC.AutoSize = true;
            this.lblFileNamePFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileNamePFC.Location = new System.Drawing.Point(372, 69);
            this.lblFileNamePFC.Name = "lblFileNamePFC";
            this.lblFileNamePFC.Size = new System.Drawing.Size(0, 18);
            this.lblFileNamePFC.TabIndex = 21;
            // 
            // checkBoxFileTPlayFC
            // 
            this.checkBoxFileTPlayFC.AutoSize = true;
            this.checkBoxFileTPlayFC.Location = new System.Drawing.Point(651, 452);
            this.checkBoxFileTPlayFC.Name = "checkBoxFileTPlayFC";
            this.checkBoxFileTPlayFC.Size = new System.Drawing.Size(163, 22);
            this.checkBoxFileTPlayFC.TabIndex = 19;
            this.checkBoxFileTPlayFC.Text = "File Transfer TCP";
            this.checkBoxFileTPlayFC.UseVisualStyleBackColor = true;
            this.checkBoxFileTPlayFC.CheckedChanged += new System.EventHandler(this.checkBoxFileTPlayFC_CheckedChanged);
            // 
            // lblListFSWPlayFair
            // 
            this.lblListFSWPlayFair.AutoSize = true;
            this.lblListFSWPlayFair.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListFSWPlayFair.Location = new System.Drawing.Point(16, 506);
            this.lblListFSWPlayFair.Name = "lblListFSWPlayFair";
            this.lblListFSWPlayFair.Size = new System.Drawing.Size(391, 20);
            this.lblListFSWPlayFair.TabIndex = 17;
            this.lblListFSWPlayFair.Text = "Lista primljenih fajlova u direkorijumu Target:";
            // 
            // listViewFSWPlayFair
            // 
            this.listViewFSWPlayFair.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewFSWPlayFair.HideSelection = false;
            this.listViewFSWPlayFair.Location = new System.Drawing.Point(20, 529);
            this.listViewFSWPlayFair.Name = "listViewFSWPlayFair";
            this.listViewFSWPlayFair.Size = new System.Drawing.Size(492, 455);
            this.listViewFSWPlayFair.TabIndex = 17;
            this.listViewFSWPlayFair.UseCompatibleStateImageBehavior = false;
            this.listViewFSWPlayFair.View = System.Windows.Forms.View.List;
            // 
            // checkBoxFSWPlayFC
            // 
            this.checkBoxFSWPlayFC.AutoSize = true;
            this.checkBoxFSWPlayFC.Location = new System.Drawing.Point(410, 452);
            this.checkBoxFSWPlayFC.Name = "checkBoxFSWPlayFC";
            this.checkBoxFSWPlayFC.Size = new System.Drawing.Size(186, 22);
            this.checkBoxFSWPlayFC.TabIndex = 15;
            this.checkBoxFSWPlayFC.Text = "File System Watcher";
            this.checkBoxFSWPlayFC.UseVisualStyleBackColor = true;
            this.checkBoxFSWPlayFC.CheckedChanged += new System.EventHandler(this.checkBoxFSW_CheckedChanged);
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(903, 442);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(284, 40);
            this.btnSaveToFile.TabIndex = 14;
            this.btnSaveToFile.Text = "Save To File";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // btnLoadFromFile
            // 
            this.btnLoadFromFile.Location = new System.Drawing.Point(51, 442);
            this.btnLoadFromFile.Name = "btnLoadFromFile";
            this.btnLoadFromFile.Size = new System.Drawing.Size(284, 40);
            this.btnLoadFromFile.TabIndex = 12;
            this.btnLoadFromFile.Text = "Load From File";
            this.btnLoadFromFile.UseVisualStyleBackColor = true;
            this.btnLoadFromFile.Click += new System.EventHandler(this.btnLoadFromFile_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(77, 382);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(436, 37);
            this.btnEncrypt.TabIndex = 11;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(725, 382);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(438, 37);
            this.btnDecrypt.TabIndex = 10;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txtBoxEncrypted
            // 
            this.txtBoxEncrypted.Location = new System.Drawing.Point(631, 100);
            this.txtBoxEncrypted.Multiline = true;
            this.txtBoxEncrypted.Name = "txtBoxEncrypted";
            this.txtBoxEncrypted.Size = new System.Drawing.Size(585, 276);
            this.txtBoxEncrypted.TabIndex = 5;
            this.txtBoxEncrypted.Enter += new System.EventHandler(this.txtBoxEncrypted_Enter);
            // 
            // lblEncrypted
            // 
            this.lblEncrypted.AutoSize = true;
            this.lblEncrypted.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncrypted.Location = new System.Drawing.Point(627, 65);
            this.lblEncrypted.Name = "lblEncrypted";
            this.lblEncrypted.Size = new System.Drawing.Size(146, 22);
            this.lblEncrypted.TabIndex = 4;
            this.lblEncrypted.Text = "Sifrovan Tekst:";
            // 
            // txtBoxPlain
            // 
            this.txtBoxPlain.Location = new System.Drawing.Point(30, 100);
            this.txtBoxPlain.Multiline = true;
            this.txtBoxPlain.Name = "txtBoxPlain";
            this.txtBoxPlain.Size = new System.Drawing.Size(585, 276);
            this.txtBoxPlain.TabIndex = 3;
            this.txtBoxPlain.Enter += new System.EventHandler(this.txtBoxPlain_Enter);
            // 
            // lblPlainTxt
            // 
            this.lblPlainTxt.AutoSize = true;
            this.lblPlainTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlainTxt.Location = new System.Drawing.Point(26, 65);
            this.lblPlainTxt.Name = "lblPlainTxt";
            this.lblPlainTxt.Size = new System.Drawing.Size(188, 22);
            this.lblPlainTxt.TabIndex = 2;
            this.lblPlainTxt.Text = "Tekst za Sifrovanje:";
            // 
            // txtBoxPFCKey
            // 
            this.txtBoxPFCKey.Location = new System.Drawing.Point(160, 24);
            this.txtBoxPFCKey.Name = "txtBoxPFCKey";
            this.txtBoxPFCKey.Size = new System.Drawing.Size(278, 24);
            this.txtBoxPFCKey.TabIndex = 1;
            // 
            // lblKEY
            // 
            this.lblKEY.AutoSize = true;
            this.lblKEY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKEY.Location = new System.Drawing.Point(26, 24);
            this.lblKEY.Name = "lblKEY";
            this.lblKEY.Size = new System.Drawing.Size(117, 22);
            this.lblKEY.TabIndex = 0;
            this.lblKEY.Text = "Unesi Kljuc:";
            // 
            // tabPageRC6
            // 
            this.tabPageRC6.Controls.Add(this.checkBoxPCBC);
            this.tabPageRC6.Controls.Add(this.btnEncryptRC6);
            this.tabPageRC6.Controls.Add(this.btnDecryptRC6);
            this.tabPageRC6.Controls.Add(this.txtBoxRC6Key);
            this.tabPageRC6.Controls.Add(this.label7);
            this.tabPageRC6.Controls.Add(this.tabControlTCPforRC6);
            this.tabPageRC6.Controls.Add(this.checkBoxTCPRC6);
            this.tabPageRC6.Controls.Add(this.lblListFSWRC6);
            this.tabPageRC6.Controls.Add(this.listViewFSWRC6);
            this.tabPageRC6.Controls.Add(this.checkBoxFSWRC6);
            this.tabPageRC6.Controls.Add(this.statusStrip2);
            this.tabPageRC6.Location = new System.Drawing.Point(4, 25);
            this.tabPageRC6.Name = "tabPageRC6";
            this.tabPageRC6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRC6.Size = new System.Drawing.Size(1240, 1017);
            this.tabPageRC6.TabIndex = 1;
            this.tabPageRC6.Text = "RC6";
            this.tabPageRC6.UseVisualStyleBackColor = true;
            // 
            // checkBoxPCBC
            // 
            this.checkBoxPCBC.AutoSize = true;
            this.checkBoxPCBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPCBC.Location = new System.Drawing.Point(572, 211);
            this.checkBoxPCBC.Name = "checkBoxPCBC";
            this.checkBoxPCBC.Size = new System.Drawing.Size(82, 44);
            this.checkBoxPCBC.TabIndex = 34;
            this.checkBoxPCBC.Text = " Mod:\r\nPCBC";
            this.checkBoxPCBC.UseVisualStyleBackColor = true;
            // 
            // btnEncryptRC6
            // 
            this.btnEncryptRC6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncryptRC6.Location = new System.Drawing.Point(34, 211);
            this.btnEncryptRC6.Name = "btnEncryptRC6";
            this.btnEncryptRC6.Size = new System.Drawing.Size(436, 37);
            this.btnEncryptRC6.TabIndex = 33;
            this.btnEncryptRC6.Text = "Encrypt";
            this.btnEncryptRC6.UseVisualStyleBackColor = true;
            this.btnEncryptRC6.Click += new System.EventHandler(this.btnEncryptRC6_Click);
            // 
            // btnDecryptRC6
            // 
            this.btnDecryptRC6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecryptRC6.Location = new System.Drawing.Point(755, 211);
            this.btnDecryptRC6.Name = "btnDecryptRC6";
            this.btnDecryptRC6.Size = new System.Drawing.Size(438, 37);
            this.btnDecryptRC6.TabIndex = 32;
            this.btnDecryptRC6.Text = "Decrypt";
            this.btnDecryptRC6.UseVisualStyleBackColor = true;
            this.btnDecryptRC6.Click += new System.EventHandler(this.btnDecryptRC6_Click);
            // 
            // txtBoxRC6Key
            // 
            this.txtBoxRC6Key.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxRC6Key.Location = new System.Drawing.Point(182, 78);
            this.txtBoxRC6Key.Name = "txtBoxRC6Key";
            this.txtBoxRC6Key.Size = new System.Drawing.Size(431, 27);
            this.txtBoxRC6Key.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(46, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 25);
            this.label7.TabIndex = 30;
            this.label7.Text = "Unesi Kljuc:";
            // 
            // tabControlTCPforRC6
            // 
            this.tabControlTCPforRC6.Controls.Add(this.tabClinet);
            this.tabControlTCPforRC6.Controls.Add(this.tabServer);
            this.tabControlTCPforRC6.Location = new System.Drawing.Point(544, 387);
            this.tabControlTCPforRC6.Name = "tabControlTCPforRC6";
            this.tabControlTCPforRC6.SelectedIndex = 0;
            this.tabControlTCPforRC6.Size = new System.Drawing.Size(676, 577);
            this.tabControlTCPforRC6.TabIndex = 29;
            // 
            // tabClinet
            // 
            this.tabClinet.Controls.Add(this.label2);
            this.tabClinet.Controls.Add(this.txtBoxPortClientRC6);
            this.tabClinet.Controls.Add(this.txtBoxIPAdrRC6);
            this.tabClinet.Controls.Add(this.label3);
            this.tabClinet.Controls.Add(this.label4);
            this.tabClinet.Controls.Add(this.btnSendRC6);
            this.tabClinet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabClinet.Location = new System.Drawing.Point(4, 25);
            this.tabClinet.Name = "tabClinet";
            this.tabClinet.Padding = new System.Windows.Forms.Padding(3);
            this.tabClinet.Size = new System.Drawing.Size(668, 548);
            this.tabClinet.TabIndex = 0;
            this.tabClinet.Text = "Send";
            this.tabClinet.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(52, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(551, 100);
            this.label2.TabIndex = 18;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // txtBoxPortClientRC6
            // 
            this.txtBoxPortClientRC6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtBoxPortClientRC6.Location = new System.Drawing.Point(142, 130);
            this.txtBoxPortClientRC6.Name = "txtBoxPortClientRC6";
            this.txtBoxPortClientRC6.Size = new System.Drawing.Size(186, 30);
            this.txtBoxPortClientRC6.TabIndex = 17;
            // 
            // txtBoxIPAdrRC6
            // 
            this.txtBoxIPAdrRC6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtBoxIPAdrRC6.Location = new System.Drawing.Point(191, 71);
            this.txtBoxIPAdrRC6.Name = "txtBoxIPAdrRC6";
            this.txtBoxIPAdrRC6.Size = new System.Drawing.Size(394, 30);
            this.txtBoxIPAdrRC6.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(52, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 26);
            this.label3.TabIndex = 15;
            this.label3.Text = "Port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(52, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 26);
            this.label4.TabIndex = 14;
            this.label4.Text = "IP adress:";
            // 
            // btnSendRC6
            // 
            this.btnSendRC6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnSendRC6.Location = new System.Drawing.Point(172, 338);
            this.btnSendRC6.Name = "btnSendRC6";
            this.btnSendRC6.Size = new System.Drawing.Size(317, 47);
            this.btnSendRC6.TabIndex = 13;
            this.btnSendRC6.Text = "Send";
            this.btnSendRC6.UseVisualStyleBackColor = true;
            this.btnSendRC6.Click += new System.EventHandler(this.btnSendRC6_Click);
            // 
            // tabServer
            // 
            this.tabServer.Controls.Add(this.txtBoxPortServerRC6);
            this.tabServer.Controls.Add(this.label5);
            this.tabServer.Controls.Add(this.btnStopListeningRC6);
            this.tabServer.Controls.Add(this.btnStartListeningRC6);
            this.tabServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabServer.Location = new System.Drawing.Point(4, 25);
            this.tabServer.Name = "tabServer";
            this.tabServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabServer.Size = new System.Drawing.Size(668, 548);
            this.tabServer.TabIndex = 1;
            this.tabServer.Text = "Recive";
            this.tabServer.UseVisualStyleBackColor = true;
            // 
            // txtBoxPortServerRC6
            // 
            this.txtBoxPortServerRC6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtBoxPortServerRC6.Location = new System.Drawing.Point(258, 69);
            this.txtBoxPortServerRC6.Name = "txtBoxPortServerRC6";
            this.txtBoxPortServerRC6.Size = new System.Drawing.Size(216, 30);
            this.txtBoxPortServerRC6.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(180, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 26);
            this.label5.TabIndex = 18;
            this.label5.Text = "Port:";
            // 
            // btnStopListeningRC6
            // 
            this.btnStopListeningRC6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnStopListeningRC6.Location = new System.Drawing.Point(360, 140);
            this.btnStopListeningRC6.Name = "btnStopListeningRC6";
            this.btnStopListeningRC6.Size = new System.Drawing.Size(264, 47);
            this.btnStopListeningRC6.TabIndex = 15;
            this.btnStopListeningRC6.Text = "Stop Listening";
            this.btnStopListeningRC6.UseVisualStyleBackColor = true;
            this.btnStopListeningRC6.Click += new System.EventHandler(this.btnStopListening_Click);
            // 
            // btnStartListeningRC6
            // 
            this.btnStartListeningRC6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnStartListeningRC6.Location = new System.Drawing.Point(39, 140);
            this.btnStartListeningRC6.Name = "btnStartListeningRC6";
            this.btnStartListeningRC6.Size = new System.Drawing.Size(264, 47);
            this.btnStartListeningRC6.TabIndex = 14;
            this.btnStartListeningRC6.Text = "Start Listening";
            this.btnStartListeningRC6.UseVisualStyleBackColor = true;
            this.btnStartListeningRC6.Click += new System.EventHandler(this.btnStartListening_Click);
            // 
            // checkBoxTCPRC6
            // 
            this.checkBoxTCPRC6.AutoSize = true;
            this.checkBoxTCPRC6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxTCPRC6.Location = new System.Drawing.Point(711, 303);
            this.checkBoxTCPRC6.Name = "checkBoxTCPRC6";
            this.checkBoxTCPRC6.Size = new System.Drawing.Size(181, 24);
            this.checkBoxTCPRC6.TabIndex = 28;
            this.checkBoxTCPRC6.Text = "File Transfer TCP";
            this.checkBoxTCPRC6.UseVisualStyleBackColor = true;
            this.checkBoxTCPRC6.CheckedChanged += new System.EventHandler(this.checkBoxTCPRC6_CheckedChanged);
            // 
            // lblListFSWRC6
            // 
            this.lblListFSWRC6.AutoSize = true;
            this.lblListFSWRC6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListFSWRC6.Location = new System.Drawing.Point(11, 387);
            this.lblListFSWRC6.Name = "lblListFSWRC6";
            this.lblListFSWRC6.Size = new System.Drawing.Size(391, 20);
            this.lblListFSWRC6.TabIndex = 26;
            this.lblListFSWRC6.Text = "Lista primljenih fajlova u direkorijumu Target:";
            // 
            // listViewFSWRC6
            // 
            this.listViewFSWRC6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewFSWRC6.HideSelection = false;
            this.listViewFSWRC6.Location = new System.Drawing.Point(15, 410);
            this.listViewFSWRC6.Name = "listViewFSWRC6";
            this.listViewFSWRC6.Size = new System.Drawing.Size(492, 554);
            this.listViewFSWRC6.TabIndex = 27;
            this.listViewFSWRC6.UseCompatibleStateImageBehavior = false;
            this.listViewFSWRC6.View = System.Windows.Forms.View.List;
            // 
            // checkBoxFSWRC6
            // 
            this.checkBoxFSWRC6.AutoSize = true;
            this.checkBoxFSWRC6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFSWRC6.Location = new System.Drawing.Point(321, 303);
            this.checkBoxFSWRC6.Name = "checkBoxFSWRC6";
            this.checkBoxFSWRC6.Size = new System.Drawing.Size(206, 24);
            this.checkBoxFSWRC6.TabIndex = 25;
            this.checkBoxFSWRC6.Text = "File System Watcher";
            this.checkBoxFSWRC6.UseVisualStyleBackColor = true;
            this.checkBoxFSWRC6.CheckedChanged += new System.EventHandler(this.checkBoxFSWRC6_CheckedChanged);
            // 
            // statusStrip2
            // 
            this.statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelRC6});
            this.statusStrip2.Location = new System.Drawing.Point(3, 988);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1234, 26);
            this.statusStrip2.TabIndex = 0;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // statusLabelRC6
            // 
            this.statusLabelRC6.Name = "statusLabelRC6";
            this.statusLabelRC6.Size = new System.Drawing.Size(52, 20);
            this.statusLabelRC6.Text = "Status:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1272, 1051);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "CryptoFileTransfer Application";
            this.tabControl1.ResumeLayout(false);
            this.tabPagePlayfairCipher.ResumeLayout(false);
            this.tabPagePlayfairCipher.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControlTCPforPC.ResumeLayout(false);
            this.ClientforPC.ResumeLayout(false);
            this.ClientforPC.PerformLayout();
            this.ServerforPC.ResumeLayout(false);
            this.ServerforPC.PerformLayout();
            this.tabPageRC6.ResumeLayout(false);
            this.tabPageRC6.PerformLayout();
            this.tabControlTCPforRC6.ResumeLayout(false);
            this.tabClinet.ResumeLayout(false);
            this.tabClinet.PerformLayout();
            this.tabServer.ResumeLayout(false);
            this.tabServer.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPagePlayfairCipher;
        private System.Windows.Forms.TabPage tabPageRC6;
        private System.Windows.Forms.TextBox txtBoxPFCKey;
        private System.Windows.Forms.Label lblKEY;
        private System.Windows.Forms.TextBox txtBoxPlain;
        private System.Windows.Forms.Label lblPlainTxt;
        private System.Windows.Forms.TextBox txtBoxEncrypted;
        private System.Windows.Forms.Label lblEncrypted;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnLoadFromFile;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Button btnSendPlayfairCipher;
        private System.Windows.Forms.Label lblListFSWPlayFair;
        private System.Windows.Forms.ListView listViewFSWPlayFair;
        private System.Windows.Forms.CheckBox checkBoxFSWPlayFC;
        private System.Windows.Forms.CheckBox checkBoxFileTPlayFC;
        private System.Windows.Forms.Label lblFileNamePFC;
        private System.Windows.Forms.TabControl tabControlTCPforPC;
        private System.Windows.Forms.TabPage ClientforPC;
        private System.Windows.Forms.TabPage ServerforPC;
        private System.Windows.Forms.TextBox txtBoxPortClientPFC;
        private System.Windows.Forms.TextBox txtBoxIPAdrPFC;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lbIPadress;
        private System.Windows.Forms.Label Napomena;
        private System.Windows.Forms.Button btnStopListening;
        private System.Windows.Forms.Button btnStartListening;
        private System.Windows.Forms.TextBox txtBoxPortServerPFC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelPFC;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelRC6;
        private System.Windows.Forms.TabControl tabControlTCPforRC6;
        private System.Windows.Forms.TabPage tabClinet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxPortClientRC6;
        private System.Windows.Forms.TextBox txtBoxIPAdrRC6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSendRC6;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.TextBox txtBoxPortServerRC6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStopListeningRC6;
        private System.Windows.Forms.Button btnStartListeningRC6;
        private System.Windows.Forms.CheckBox checkBoxTCPRC6;
        private System.Windows.Forms.Label lblListFSWRC6;
        private System.Windows.Forms.ListView listViewFSWRC6;
        private System.Windows.Forms.CheckBox checkBoxFSWRC6;
        private System.Windows.Forms.TextBox txtBoxRC6Key;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEncryptRC6;
        private System.Windows.Forms.Button btnDecryptRC6;
        private System.Windows.Forms.CheckBox checkBoxPCBC;
    }
}

