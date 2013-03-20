namespace NationStates_AutoTelegram
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.aboutTabPage = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.nameVersionLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.statusTabPage = new System.Windows.Forms.TabPage();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.telegramTabPage = new System.Windows.Forms.TabPage();
            this.telegramGroupBox = new System.Windows.Forms.GroupBox();
            this.recipientsTextBox = new System.Windows.Forms.RichTextBox();
            this.nonRecruitmentRadioButton = new System.Windows.Forms.RadioButton();
            this.recruitmentRadioButton = new System.Windows.Forms.RadioButton();
            this.secretKeyTextBox = new System.Windows.Forms.TextBox();
            this.telegramIDTextBox = new System.Windows.Forms.TextBox();
            this.accountGroupBox = new System.Windows.Forms.GroupBox();
            this.clientKeyTextBox = new System.Windows.Forms.TextBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.aboutTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.statusTabPage.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.telegramTabPage.SuspendLayout();
            this.telegramGroupBox.SuspendLayout();
            this.accountGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // aboutTabPage
            // 
            this.aboutTabPage.Controls.Add(this.richTextBox1);
            this.aboutTabPage.Controls.Add(this.copyrightLabel);
            this.aboutTabPage.Controls.Add(this.nameVersionLabel);
            this.aboutTabPage.Controls.Add(this.pictureBox);
            this.aboutTabPage.Location = new System.Drawing.Point(4, 25);
            this.aboutTabPage.Name = "aboutTabPage";
            this.aboutTabPage.Size = new System.Drawing.Size(552, 308);
            this.aboutTabPage.TabIndex = 4;
            this.aboutTabPage.Text = "About";
            this.aboutTabPage.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 44);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(546, 261);
            this.richTextBox1.TabIndex = 37;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Location = new System.Drawing.Point(41, 25);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(39, 13);
            this.copyrightLabel.TabIndex = 36;
            this.copyrightLabel.Text = "Auralia";
            // 
            // nameVersionLabel
            // 
            this.nameVersionLabel.AutoSize = true;
            this.nameVersionLabel.Location = new System.Drawing.Point(41, 6);
            this.nameVersionLabel.Name = "nameVersionLabel";
            this.nameVersionLabel.Size = new System.Drawing.Size(137, 13);
            this.nameVersionLabel.TabIndex = 35;
            this.nameVersionLabel.Text = "NationStates AutoTelegram";
            // 
            // pictureBox
            // 
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(3, 6);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(32, 32);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 34;
            this.pictureBox.TabStop = false;
            // 
            // statusTabPage
            // 
            this.statusTabPage.Controls.Add(this.logTextBox);
            this.statusTabPage.Controls.Add(this.startButton);
            this.statusTabPage.Controls.Add(this.cancelButton);
            this.statusTabPage.Controls.Add(this.progressBar);
            this.statusTabPage.Location = new System.Drawing.Point(4, 25);
            this.statusTabPage.Name = "statusTabPage";
            this.statusTabPage.Size = new System.Drawing.Size(552, 308);
            this.statusTabPage.TabIndex = 3;
            this.statusTabPage.Text = "Status";
            this.statusTabPage.UseVisualStyleBackColor = true;
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.Location = new System.Drawing.Point(3, 32);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(546, 273);
            this.logTextBox.TabIndex = 3;
            this.logTextBox.Text = "";
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Location = new System.Drawing.Point(393, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(474, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(3, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(384, 23);
            this.progressBar.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.telegramTabPage);
            this.tabControl.Controls.Add(this.statusTabPage);
            this.tabControl.Controls.Add(this.aboutTabPage);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(560, 337);
            this.tabControl.TabIndex = 4;
            // 
            // telegramTabPage
            // 
            this.telegramTabPage.Controls.Add(this.telegramGroupBox);
            this.telegramTabPage.Controls.Add(this.accountGroupBox);
            this.telegramTabPage.Location = new System.Drawing.Point(4, 25);
            this.telegramTabPage.Name = "telegramTabPage";
            this.telegramTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.telegramTabPage.Size = new System.Drawing.Size(552, 308);
            this.telegramTabPage.TabIndex = 7;
            this.telegramTabPage.Text = "Telegram";
            this.telegramTabPage.UseVisualStyleBackColor = true;
            // 
            // telegramGroupBox
            // 
            this.telegramGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.telegramGroupBox.Controls.Add(this.label5);
            this.telegramGroupBox.Controls.Add(this.label4);
            this.telegramGroupBox.Controls.Add(this.label3);
            this.telegramGroupBox.Controls.Add(this.label2);
            this.telegramGroupBox.Controls.Add(this.recipientsTextBox);
            this.telegramGroupBox.Controls.Add(this.nonRecruitmentRadioButton);
            this.telegramGroupBox.Controls.Add(this.recruitmentRadioButton);
            this.telegramGroupBox.Controls.Add(this.secretKeyTextBox);
            this.telegramGroupBox.Controls.Add(this.telegramIDTextBox);
            this.telegramGroupBox.Location = new System.Drawing.Point(3, 59);
            this.telegramGroupBox.Name = "telegramGroupBox";
            this.telegramGroupBox.Size = new System.Drawing.Size(546, 246);
            this.telegramGroupBox.TabIndex = 0;
            this.telegramGroupBox.TabStop = false;
            this.telegramGroupBox.Text = "Telegram";
            // 
            // recipientsTextBox
            // 
            this.recipientsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recipientsTextBox.Location = new System.Drawing.Point(89, 120);
            this.recipientsTextBox.Name = "recipientsTextBox";
            this.recipientsTextBox.Size = new System.Drawing.Size(451, 120);
            this.recipientsTextBox.TabIndex = 11;
            this.recipientsTextBox.Text = "";
            // 
            // nonRecruitmentRadioButton
            // 
            this.nonRecruitmentRadioButton.AutoSize = true;
            this.nonRecruitmentRadioButton.Checked = true;
            this.nonRecruitmentRadioButton.Location = new System.Drawing.Point(89, 68);
            this.nonRecruitmentRadioButton.Name = "nonRecruitmentRadioButton";
            this.nonRecruitmentRadioButton.Size = new System.Drawing.Size(334, 17);
            this.nonRecruitmentRadioButton.TabIndex = 7;
            this.nonRecruitmentRadioButton.TabStop = true;
            this.nonRecruitmentRadioButton.Text = "Non-recruitment telegram (maximum 1 telegram every 30 seconds)";
            this.nonRecruitmentRadioButton.UseVisualStyleBackColor = true;
            // 
            // recruitmentRadioButton
            // 
            this.recruitmentRadioButton.AutoSize = true;
            this.recruitmentRadioButton.Location = new System.Drawing.Point(89, 45);
            this.recruitmentRadioButton.Name = "recruitmentRadioButton";
            this.recruitmentRadioButton.Size = new System.Drawing.Size(322, 17);
            this.recruitmentRadioButton.TabIndex = 6;
            this.recruitmentRadioButton.Text = "Recruitment telegram (maximum 1 telegram every 180 seconds)";
            this.recruitmentRadioButton.UseVisualStyleBackColor = true;
            // 
            // secretKeyTextBox
            // 
            this.secretKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.secretKeyTextBox.Location = new System.Drawing.Point(89, 91);
            this.secretKeyTextBox.Name = "secretKeyTextBox";
            this.secretKeyTextBox.Size = new System.Drawing.Size(451, 20);
            this.secretKeyTextBox.TabIndex = 9;
            // 
            // telegramIDTextBox
            // 
            this.telegramIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.telegramIDTextBox.Location = new System.Drawing.Point(89, 19);
            this.telegramIDTextBox.Name = "telegramIDTextBox";
            this.telegramIDTextBox.Size = new System.Drawing.Size(451, 20);
            this.telegramIDTextBox.TabIndex = 4;
            // 
            // accountGroupBox
            // 
            this.accountGroupBox.Controls.Add(this.label1);
            this.accountGroupBox.Controls.Add(this.clientKeyTextBox);
            this.accountGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.accountGroupBox.Location = new System.Drawing.Point(3, 3);
            this.accountGroupBox.Name = "accountGroupBox";
            this.accountGroupBox.Size = new System.Drawing.Size(546, 50);
            this.accountGroupBox.TabIndex = 0;
            this.accountGroupBox.TabStop = false;
            this.accountGroupBox.Text = "Telegrams API";
            // 
            // clientKeyTextBox
            // 
            this.clientKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientKeyTextBox.Location = new System.Drawing.Point(89, 19);
            this.clientKeyTextBox.Name = "clientKeyTextBox";
            this.clientKeyTextBox.Size = new System.Drawing.Size(451, 20);
            this.clientKeyTextBox.TabIndex = 2;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "success");
            this.imageList.Images.SetKeyName(1, "fail");
            this.imageList.Images.SetKeyName(2, "inProgress");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "API client key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Telegram ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Telegram type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Secret key:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Recipients:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "NationStates AutoTelegram";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.aboutTabPage.ResumeLayout(false);
            this.aboutTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.statusTabPage.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.telegramTabPage.ResumeLayout(false);
            this.telegramGroupBox.ResumeLayout(false);
            this.telegramGroupBox.PerformLayout();
            this.accountGroupBox.ResumeLayout(false);
            this.accountGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.TabPage aboutTabPage;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.Label nameVersionLabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TabPage statusTabPage;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage telegramTabPage;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.GroupBox telegramGroupBox;
        private System.Windows.Forms.RadioButton nonRecruitmentRadioButton;
        private System.Windows.Forms.RadioButton recruitmentRadioButton;
        private System.Windows.Forms.TextBox secretKeyTextBox;
        private System.Windows.Forms.TextBox telegramIDTextBox;
        private System.Windows.Forms.GroupBox accountGroupBox;
        private System.Windows.Forms.TextBox clientKeyTextBox;
        private System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.RichTextBox recipientsTextBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;



    }
}

