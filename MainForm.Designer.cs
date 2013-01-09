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
            this.aboutTabPage = new System.Windows.Forms.TabPage();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.nameVersionLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.creditsTextBox = new System.Windows.Forms.TextBox();
            this.sendTabPage = new System.Windows.Forms.TabPage();
            this.startButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.logColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.recipientsTabPage = new System.Windows.Forms.TabPage();
            this.recipientsTabControl = new System.Windows.Forms.TabControl();
            this.nationsTabPage = new System.Windows.Forms.TabPage();
            this.nationsExcludeLimitDelegatesCheckBox = new System.Windows.Forms.CheckBox();
            this.nationsExcludeLabel = new System.Windows.Forms.Label();
            this.nationsExcludeAllDelegatesCheckBox = new System.Windows.Forms.CheckBox();
            this.nationsExcludeLimitWACheckBox = new System.Windows.Forms.CheckBox();
            this.nationsExcludeAllWACheckBox = new System.Windows.Forms.CheckBox();
            this.nationsExcludeTextBox = new System.Windows.Forms.TextBox();
            this.nationsIncludeAllNationsCheckBox = new System.Windows.Forms.CheckBox();
            this.nationsIncludeLimitDelegatesCheckBox = new System.Windows.Forms.CheckBox();
            this.nationsIncludeLabel = new System.Windows.Forms.Label();
            this.nationsIncludeTextBox = new System.Windows.Forms.TextBox();
            this.nationsIncludeLimitWACheckBox = new System.Windows.Forms.CheckBox();
            this.nationsIncludeAllDelegatesCheckBox = new System.Windows.Forms.CheckBox();
            this.nationsIncludeAllWACheckBox = new System.Windows.Forms.CheckBox();
            this.regionsTabPage = new System.Windows.Forms.TabPage();
            this.regionsExcludeLimitDelegatesCheckBox = new System.Windows.Forms.CheckBox();
            this.regionsExcludeLabel = new System.Windows.Forms.Label();
            this.regionsExcludeTextBox = new System.Windows.Forms.TextBox();
            this.regionsIncludeTextBox = new System.Windows.Forms.TextBox();
            this.regionsExcludeLimitWACheckBox = new System.Windows.Forms.CheckBox();
            this.regionsIncludeLimitDelegatesCheckBox = new System.Windows.Forms.CheckBox();
            this.regionsIncludeLabel = new System.Windows.Forms.Label();
            this.regionsIncludeLimitWACheckBox = new System.Windows.Forms.CheckBox();
            this.tagsTabPage = new System.Windows.Forms.TabPage();
            this.tagsExcludeLimitDelegatesCheckBox = new System.Windows.Forms.CheckBox();
            this.tagsExcludeLabel = new System.Windows.Forms.Label();
            this.tagsExcludeTextBox = new System.Windows.Forms.TextBox();
            this.tagsExcludeLimitWACheckBox = new System.Windows.Forms.CheckBox();
            this.tagsIncludeLimitDelegatesCheckBox = new System.Windows.Forms.CheckBox();
            this.tagsIncludeLabel = new System.Windows.Forms.Label();
            this.tagsIncludeTextBox = new System.Windows.Forms.TextBox();
            this.tagsIncludeLimitWACheckBox = new System.Windows.Forms.CheckBox();
            this.textTabPage = new System.Windows.Forms.TabPage();
            this.telegramTextBox = new System.Windows.Forms.TextBox();
            this.textToolStrip = new System.Windows.Forms.ToolStrip();
            this.clearToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.nationToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.regionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.senderTabPage = new System.Windows.Forms.TabPage();
            this.emailExpLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.aboutTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.sendTabPage.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.recipientsTabPage.SuspendLayout();
            this.recipientsTabControl.SuspendLayout();
            this.nationsTabPage.SuspendLayout();
            this.regionsTabPage.SuspendLayout();
            this.tagsTabPage.SuspendLayout();
            this.textTabPage.SuspendLayout();
            this.textToolStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.senderTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // aboutTabPage
            // 
            this.aboutTabPage.Controls.Add(this.copyrightLabel);
            this.aboutTabPage.Controls.Add(this.nameVersionLabel);
            this.aboutTabPage.Controls.Add(this.pictureBox);
            this.aboutTabPage.Controls.Add(this.creditsTextBox);
            this.aboutTabPage.Location = new System.Drawing.Point(4, 25);
            this.aboutTabPage.Name = "aboutTabPage";
            this.aboutTabPage.Size = new System.Drawing.Size(602, 358);
            this.aboutTabPage.TabIndex = 4;
            this.aboutTabPage.Text = "About";
            this.aboutTabPage.UseVisualStyleBackColor = true;
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Location = new System.Drawing.Point(38, 25);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(39, 13);
            this.copyrightLabel.TabIndex = 36;
            this.copyrightLabel.Text = "Auralia";
            // 
            // nameVersionLabel
            // 
            this.nameVersionLabel.AutoSize = true;
            this.nameVersionLabel.Location = new System.Drawing.Point(38, 6);
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
            // creditsTextBox
            // 
            this.creditsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.creditsTextBox.Location = new System.Drawing.Point(0, 44);
            this.creditsTextBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.creditsTextBox.Multiline = true;
            this.creditsTextBox.Name = "creditsTextBox";
            this.creditsTextBox.ReadOnly = true;
            this.creditsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.creditsTextBox.Size = new System.Drawing.Size(602, 314);
            this.creditsTextBox.TabIndex = 1;
            this.creditsTextBox.Text = resources.GetString("creditsTextBox.Text");
            // 
            // sendTabPage
            // 
            this.sendTabPage.Controls.Add(this.startButton);
            this.sendTabPage.Controls.Add(this.cancelButton);
            this.sendTabPage.Controls.Add(this.listView);
            this.sendTabPage.Controls.Add(this.progressBar);
            this.sendTabPage.Location = new System.Drawing.Point(4, 25);
            this.sendTabPage.Name = "sendTabPage";
            this.sendTabPage.Size = new System.Drawing.Size(602, 358);
            this.sendTabPage.TabIndex = 3;
            this.sendTabPage.Text = "Send Telegram";
            this.sendTabPage.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Location = new System.Drawing.Point(446, 3);
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
            this.cancelButton.Location = new System.Drawing.Point(527, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.logColumnHeader});
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView.Location = new System.Drawing.Point(0, 32);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(602, 326);
            this.listView.SmallImageList = this.imageList;
            this.listView.TabIndex = 3;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.Resize += new System.EventHandler(this.listView_Resize);
            // 
            // logColumnHeader
            // 
            this.logColumnHeader.Text = "Log";
            this.logColumnHeader.Width = 598;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.logToolStripSeparator,
            this.clearToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(124, 54);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // logToolStripSeparator
            // 
            this.logToolStripSeparator.Name = "logToolStripSeparator";
            this.logToolStripSeparator.Size = new System.Drawing.Size(120, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "information.png");
            this.imageList.Images.SetKeyName(1, "error.png");
            this.imageList.Images.SetKeyName(2, "cancel.png");
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(0, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(440, 23);
            this.progressBar.TabIndex = 5;
            // 
            // recipientsTabPage
            // 
            this.recipientsTabPage.Controls.Add(this.recipientsTabControl);
            this.recipientsTabPage.Location = new System.Drawing.Point(4, 25);
            this.recipientsTabPage.Name = "recipientsTabPage";
            this.recipientsTabPage.Size = new System.Drawing.Size(602, 358);
            this.recipientsTabPage.TabIndex = 2;
            this.recipientsTabPage.Text = "Recipients";
            this.recipientsTabPage.UseVisualStyleBackColor = true;
            // 
            // recipientsTabControl
            // 
            this.recipientsTabControl.Controls.Add(this.nationsTabPage);
            this.recipientsTabControl.Controls.Add(this.regionsTabPage);
            this.recipientsTabControl.Controls.Add(this.tagsTabPage);
            this.recipientsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipientsTabControl.Location = new System.Drawing.Point(0, 0);
            this.recipientsTabControl.Name = "recipientsTabControl";
            this.recipientsTabControl.SelectedIndex = 0;
            this.recipientsTabControl.Size = new System.Drawing.Size(602, 358);
            this.recipientsTabControl.TabIndex = 1;
            // 
            // nationsTabPage
            // 
            this.nationsTabPage.Controls.Add(this.nationsExcludeLimitDelegatesCheckBox);
            this.nationsTabPage.Controls.Add(this.nationsExcludeLabel);
            this.nationsTabPage.Controls.Add(this.nationsExcludeAllDelegatesCheckBox);
            this.nationsTabPage.Controls.Add(this.nationsExcludeLimitWACheckBox);
            this.nationsTabPage.Controls.Add(this.nationsExcludeAllWACheckBox);
            this.nationsTabPage.Controls.Add(this.nationsExcludeTextBox);
            this.nationsTabPage.Controls.Add(this.nationsIncludeAllNationsCheckBox);
            this.nationsTabPage.Controls.Add(this.nationsIncludeLimitDelegatesCheckBox);
            this.nationsTabPage.Controls.Add(this.nationsIncludeLabel);
            this.nationsTabPage.Controls.Add(this.nationsIncludeTextBox);
            this.nationsTabPage.Controls.Add(this.nationsIncludeLimitWACheckBox);
            this.nationsTabPage.Controls.Add(this.nationsIncludeAllDelegatesCheckBox);
            this.nationsTabPage.Controls.Add(this.nationsIncludeAllWACheckBox);
            this.nationsTabPage.Location = new System.Drawing.Point(4, 22);
            this.nationsTabPage.Name = "nationsTabPage";
            this.nationsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.nationsTabPage.Size = new System.Drawing.Size(594, 332);
            this.nationsTabPage.TabIndex = 0;
            this.nationsTabPage.Text = "Nations";
            this.nationsTabPage.UseVisualStyleBackColor = true;
            // 
            // nationsExcludeLimitDelegatesCheckBox
            // 
            this.nationsExcludeLimitDelegatesCheckBox.AutoSize = true;
            this.nationsExcludeLimitDelegatesCheckBox.Location = new System.Drawing.Point(315, 183);
            this.nationsExcludeLimitDelegatesCheckBox.Name = "nationsExcludeLimitDelegatesCheckBox";
            this.nationsExcludeLimitDelegatesCheckBox.Size = new System.Drawing.Size(148, 17);
            this.nationsExcludeLimitDelegatesCheckBox.TabIndex = 12;
            this.nationsExcludeLimitDelegatesCheckBox.Text = "Limit to regional delegates";
            this.nationsExcludeLimitDelegatesCheckBox.UseVisualStyleBackColor = true;
            // 
            // nationsExcludeLabel
            // 
            this.nationsExcludeLabel.AutoSize = true;
            this.nationsExcludeLabel.Location = new System.Drawing.Point(7, 132);
            this.nationsExcludeLabel.Name = "nationsExcludeLabel";
            this.nationsExcludeLabel.Size = new System.Drawing.Size(85, 13);
            this.nationsExcludeLabel.TabIndex = 81;
            this.nationsExcludeLabel.Text = "Exclude nations:";
            // 
            // nationsExcludeAllDelegatesCheckBox
            // 
            this.nationsExcludeAllDelegatesCheckBox.AutoSize = true;
            this.nationsExcludeAllDelegatesCheckBox.Location = new System.Drawing.Point(245, 106);
            this.nationsExcludeAllDelegatesCheckBox.Name = "nationsExcludeAllDelegatesCheckBox";
            this.nationsExcludeAllDelegatesCheckBox.Size = new System.Drawing.Size(166, 17);
            this.nationsExcludeAllDelegatesCheckBox.TabIndex = 9;
            this.nationsExcludeAllDelegatesCheckBox.Text = "Exclude all regional delegates";
            this.nationsExcludeAllDelegatesCheckBox.UseVisualStyleBackColor = true;
            // 
            // nationsExcludeLimitWACheckBox
            // 
            this.nationsExcludeLimitWACheckBox.AutoSize = true;
            this.nationsExcludeLimitWACheckBox.Location = new System.Drawing.Point(95, 183);
            this.nationsExcludeLimitWACheckBox.Name = "nationsExcludeLimitWACheckBox";
            this.nationsExcludeLimitWACheckBox.Size = new System.Drawing.Size(214, 17);
            this.nationsExcludeLimitWACheckBox.TabIndex = 11;
            this.nationsExcludeLimitWACheckBox.Text = "Limit to World Assembly member nations";
            this.nationsExcludeLimitWACheckBox.UseVisualStyleBackColor = true;
            // 
            // nationsExcludeAllWACheckBox
            // 
            this.nationsExcludeAllWACheckBox.AutoSize = true;
            this.nationsExcludeAllWACheckBox.Location = new System.Drawing.Point(7, 106);
            this.nationsExcludeAllWACheckBox.Name = "nationsExcludeAllWACheckBox";
            this.nationsExcludeAllWACheckBox.Size = new System.Drawing.Size(232, 17);
            this.nationsExcludeAllWACheckBox.TabIndex = 8;
            this.nationsExcludeAllWACheckBox.Text = "Exclude all World Assembly member nations";
            this.nationsExcludeAllWACheckBox.UseVisualStyleBackColor = true;
            // 
            // nationsExcludeTextBox
            // 
            this.nationsExcludeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nationsExcludeTextBox.Location = new System.Drawing.Point(95, 129);
            this.nationsExcludeTextBox.Multiline = true;
            this.nationsExcludeTextBox.Name = "nationsExcludeTextBox";
            this.nationsExcludeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.nationsExcludeTextBox.Size = new System.Drawing.Size(495, 48);
            this.nationsExcludeTextBox.TabIndex = 10;
            // 
            // nationsIncludeAllNationsCheckBox
            // 
            this.nationsIncludeAllNationsCheckBox.AutoSize = true;
            this.nationsIncludeAllNationsCheckBox.Location = new System.Drawing.Point(7, 6);
            this.nationsIncludeAllNationsCheckBox.Name = "nationsIncludeAllNationsCheckBox";
            this.nationsIncludeAllNationsCheckBox.Size = new System.Drawing.Size(111, 17);
            this.nationsIncludeAllNationsCheckBox.TabIndex = 2;
            this.nationsIncludeAllNationsCheckBox.Text = "Include all nations";
            this.nationsIncludeAllNationsCheckBox.UseVisualStyleBackColor = true;
            // 
            // nationsIncludeLimitDelegatesCheckBox
            // 
            this.nationsIncludeLimitDelegatesCheckBox.AutoSize = true;
            this.nationsIncludeLimitDelegatesCheckBox.Location = new System.Drawing.Point(315, 83);
            this.nationsIncludeLimitDelegatesCheckBox.Name = "nationsIncludeLimitDelegatesCheckBox";
            this.nationsIncludeLimitDelegatesCheckBox.Size = new System.Drawing.Size(148, 17);
            this.nationsIncludeLimitDelegatesCheckBox.TabIndex = 7;
            this.nationsIncludeLimitDelegatesCheckBox.Text = "Limit to regional delegates";
            this.nationsIncludeLimitDelegatesCheckBox.UseVisualStyleBackColor = true;
            this.nationsIncludeLimitDelegatesCheckBox.CheckedChanged += new System.EventHandler(this.nationsIncludeLimitDelegatesCheckBox_CheckedChanged);
            // 
            // nationsIncludeLabel
            // 
            this.nationsIncludeLabel.AutoSize = true;
            this.nationsIncludeLabel.Location = new System.Drawing.Point(7, 32);
            this.nationsIncludeLabel.Name = "nationsIncludeLabel";
            this.nationsIncludeLabel.Size = new System.Drawing.Size(82, 13);
            this.nationsIncludeLabel.TabIndex = 75;
            this.nationsIncludeLabel.Text = "Include nations:";
            // 
            // nationsIncludeTextBox
            // 
            this.nationsIncludeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nationsIncludeTextBox.Location = new System.Drawing.Point(95, 29);
            this.nationsIncludeTextBox.Multiline = true;
            this.nationsIncludeTextBox.Name = "nationsIncludeTextBox";
            this.nationsIncludeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.nationsIncludeTextBox.Size = new System.Drawing.Size(493, 48);
            this.nationsIncludeTextBox.TabIndex = 5;
            // 
            // nationsIncludeLimitWACheckBox
            // 
            this.nationsIncludeLimitWACheckBox.AutoSize = true;
            this.nationsIncludeLimitWACheckBox.Location = new System.Drawing.Point(95, 83);
            this.nationsIncludeLimitWACheckBox.Name = "nationsIncludeLimitWACheckBox";
            this.nationsIncludeLimitWACheckBox.Size = new System.Drawing.Size(214, 17);
            this.nationsIncludeLimitWACheckBox.TabIndex = 6;
            this.nationsIncludeLimitWACheckBox.Text = "Limit to World Assembly member nations";
            this.nationsIncludeLimitWACheckBox.UseVisualStyleBackColor = true;
            // 
            // nationsIncludeAllDelegatesCheckBox
            // 
            this.nationsIncludeAllDelegatesCheckBox.AutoSize = true;
            this.nationsIncludeAllDelegatesCheckBox.Location = new System.Drawing.Point(359, 6);
            this.nationsIncludeAllDelegatesCheckBox.Name = "nationsIncludeAllDelegatesCheckBox";
            this.nationsIncludeAllDelegatesCheckBox.Size = new System.Drawing.Size(163, 17);
            this.nationsIncludeAllDelegatesCheckBox.TabIndex = 4;
            this.nationsIncludeAllDelegatesCheckBox.Text = "Include all regional delegates";
            this.nationsIncludeAllDelegatesCheckBox.UseVisualStyleBackColor = true;
            this.nationsIncludeAllDelegatesCheckBox.CheckedChanged += new System.EventHandler(this.nationsIncludeAllDelegatesCheckBox_CheckedChanged);
            // 
            // nationsIncludeAllWACheckBox
            // 
            this.nationsIncludeAllWACheckBox.AutoSize = true;
            this.nationsIncludeAllWACheckBox.Location = new System.Drawing.Point(124, 6);
            this.nationsIncludeAllWACheckBox.Name = "nationsIncludeAllWACheckBox";
            this.nationsIncludeAllWACheckBox.Size = new System.Drawing.Size(229, 17);
            this.nationsIncludeAllWACheckBox.TabIndex = 3;
            this.nationsIncludeAllWACheckBox.Text = "Include all World Assembly member nations";
            this.nationsIncludeAllWACheckBox.UseVisualStyleBackColor = true;
            // 
            // regionsTabPage
            // 
            this.regionsTabPage.Controls.Add(this.regionsExcludeLimitDelegatesCheckBox);
            this.regionsTabPage.Controls.Add(this.regionsExcludeLabel);
            this.regionsTabPage.Controls.Add(this.regionsExcludeTextBox);
            this.regionsTabPage.Controls.Add(this.regionsIncludeTextBox);
            this.regionsTabPage.Controls.Add(this.regionsExcludeLimitWACheckBox);
            this.regionsTabPage.Controls.Add(this.regionsIncludeLimitDelegatesCheckBox);
            this.regionsTabPage.Controls.Add(this.regionsIncludeLabel);
            this.regionsTabPage.Controls.Add(this.regionsIncludeLimitWACheckBox);
            this.regionsTabPage.Location = new System.Drawing.Point(4, 22);
            this.regionsTabPage.Name = "regionsTabPage";
            this.regionsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.regionsTabPage.Size = new System.Drawing.Size(594, 332);
            this.regionsTabPage.TabIndex = 1;
            this.regionsTabPage.Text = "Regions";
            this.regionsTabPage.UseVisualStyleBackColor = true;
            // 
            // regionsExcludeLimitDelegatesCheckBox
            // 
            this.regionsExcludeLimitDelegatesCheckBox.AutoSize = true;
            this.regionsExcludeLimitDelegatesCheckBox.Location = new System.Drawing.Point(315, 137);
            this.regionsExcludeLimitDelegatesCheckBox.Name = "regionsExcludeLimitDelegatesCheckBox";
            this.regionsExcludeLimitDelegatesCheckBox.Size = new System.Drawing.Size(148, 17);
            this.regionsExcludeLimitDelegatesCheckBox.TabIndex = 7;
            this.regionsExcludeLimitDelegatesCheckBox.Text = "Limit to regional delegates";
            this.regionsExcludeLimitDelegatesCheckBox.UseVisualStyleBackColor = true;
            // 
            // regionsExcludeLabel
            // 
            this.regionsExcludeLabel.AutoSize = true;
            this.regionsExcludeLabel.Location = new System.Drawing.Point(7, 86);
            this.regionsExcludeLabel.Name = "regionsExcludeLabel";
            this.regionsExcludeLabel.Size = new System.Drawing.Size(85, 13);
            this.regionsExcludeLabel.TabIndex = 73;
            this.regionsExcludeLabel.Text = "Exclude regions:";
            // 
            // regionsExcludeTextBox
            // 
            this.regionsExcludeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.regionsExcludeTextBox.Location = new System.Drawing.Point(95, 83);
            this.regionsExcludeTextBox.Multiline = true;
            this.regionsExcludeTextBox.Name = "regionsExcludeTextBox";
            this.regionsExcludeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.regionsExcludeTextBox.Size = new System.Drawing.Size(492, 48);
            this.regionsExcludeTextBox.TabIndex = 5;
            // 
            // regionsIncludeTextBox
            // 
            this.regionsIncludeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.regionsIncludeTextBox.Location = new System.Drawing.Point(95, 6);
            this.regionsIncludeTextBox.Multiline = true;
            this.regionsIncludeTextBox.Name = "regionsIncludeTextBox";
            this.regionsIncludeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.regionsIncludeTextBox.Size = new System.Drawing.Size(492, 48);
            this.regionsIncludeTextBox.TabIndex = 2;
            // 
            // regionsExcludeLimitWACheckBox
            // 
            this.regionsExcludeLimitWACheckBox.AutoSize = true;
            this.regionsExcludeLimitWACheckBox.Location = new System.Drawing.Point(95, 137);
            this.regionsExcludeLimitWACheckBox.Name = "regionsExcludeLimitWACheckBox";
            this.regionsExcludeLimitWACheckBox.Size = new System.Drawing.Size(214, 17);
            this.regionsExcludeLimitWACheckBox.TabIndex = 6;
            this.regionsExcludeLimitWACheckBox.Text = "Limit to World Assembly member nations";
            this.regionsExcludeLimitWACheckBox.UseVisualStyleBackColor = true;
            // 
            // regionsIncludeLimitDelegatesCheckBox
            // 
            this.regionsIncludeLimitDelegatesCheckBox.AutoSize = true;
            this.regionsIncludeLimitDelegatesCheckBox.Location = new System.Drawing.Point(315, 60);
            this.regionsIncludeLimitDelegatesCheckBox.Name = "regionsIncludeLimitDelegatesCheckBox";
            this.regionsIncludeLimitDelegatesCheckBox.Size = new System.Drawing.Size(148, 17);
            this.regionsIncludeLimitDelegatesCheckBox.TabIndex = 4;
            this.regionsIncludeLimitDelegatesCheckBox.Text = "Limit to regional delegates";
            this.regionsIncludeLimitDelegatesCheckBox.UseVisualStyleBackColor = true;
            this.regionsIncludeLimitDelegatesCheckBox.CheckedChanged += new System.EventHandler(this.regionsIncludeLimitDelegatesCheckBox_CheckedChanged);
            // 
            // regionsIncludeLabel
            // 
            this.regionsIncludeLabel.AutoSize = true;
            this.regionsIncludeLabel.Location = new System.Drawing.Point(7, 9);
            this.regionsIncludeLabel.Name = "regionsIncludeLabel";
            this.regionsIncludeLabel.Size = new System.Drawing.Size(82, 13);
            this.regionsIncludeLabel.TabIndex = 69;
            this.regionsIncludeLabel.Text = "Include regions:";
            // 
            // regionsIncludeLimitWACheckBox
            // 
            this.regionsIncludeLimitWACheckBox.AutoSize = true;
            this.regionsIncludeLimitWACheckBox.Location = new System.Drawing.Point(95, 60);
            this.regionsIncludeLimitWACheckBox.Name = "regionsIncludeLimitWACheckBox";
            this.regionsIncludeLimitWACheckBox.Size = new System.Drawing.Size(214, 17);
            this.regionsIncludeLimitWACheckBox.TabIndex = 3;
            this.regionsIncludeLimitWACheckBox.Text = "Limit to World Assembly member nations";
            this.regionsIncludeLimitWACheckBox.UseVisualStyleBackColor = true;
            // 
            // tagsTabPage
            // 
            this.tagsTabPage.Controls.Add(this.tagsExcludeLimitDelegatesCheckBox);
            this.tagsTabPage.Controls.Add(this.tagsExcludeLabel);
            this.tagsTabPage.Controls.Add(this.tagsExcludeTextBox);
            this.tagsTabPage.Controls.Add(this.tagsExcludeLimitWACheckBox);
            this.tagsTabPage.Controls.Add(this.tagsIncludeLimitDelegatesCheckBox);
            this.tagsTabPage.Controls.Add(this.tagsIncludeLabel);
            this.tagsTabPage.Controls.Add(this.tagsIncludeTextBox);
            this.tagsTabPage.Controls.Add(this.tagsIncludeLimitWACheckBox);
            this.tagsTabPage.Location = new System.Drawing.Point(4, 22);
            this.tagsTabPage.Name = "tagsTabPage";
            this.tagsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tagsTabPage.Size = new System.Drawing.Size(594, 332);
            this.tagsTabPage.TabIndex = 2;
            this.tagsTabPage.Text = "Tags";
            this.tagsTabPage.UseVisualStyleBackColor = true;
            // 
            // tagsExcludeLimitDelegatesCheckBox
            // 
            this.tagsExcludeLimitDelegatesCheckBox.AutoSize = true;
            this.tagsExcludeLimitDelegatesCheckBox.Location = new System.Drawing.Point(315, 137);
            this.tagsExcludeLimitDelegatesCheckBox.Name = "tagsExcludeLimitDelegatesCheckBox";
            this.tagsExcludeLimitDelegatesCheckBox.Size = new System.Drawing.Size(148, 17);
            this.tagsExcludeLimitDelegatesCheckBox.TabIndex = 7;
            this.tagsExcludeLimitDelegatesCheckBox.Text = "Limit to regional delegates";
            this.tagsExcludeLimitDelegatesCheckBox.UseVisualStyleBackColor = true;
            // 
            // tagsExcludeLabel
            // 
            this.tagsExcludeLabel.AutoSize = true;
            this.tagsExcludeLabel.Location = new System.Drawing.Point(7, 86);
            this.tagsExcludeLabel.Name = "tagsExcludeLabel";
            this.tagsExcludeLabel.Size = new System.Drawing.Size(71, 13);
            this.tagsExcludeLabel.TabIndex = 68;
            this.tagsExcludeLabel.Text = "Exclude tags:";
            // 
            // tagsExcludeTextBox
            // 
            this.tagsExcludeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagsExcludeTextBox.Location = new System.Drawing.Point(95, 83);
            this.tagsExcludeTextBox.Multiline = true;
            this.tagsExcludeTextBox.Name = "tagsExcludeTextBox";
            this.tagsExcludeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tagsExcludeTextBox.Size = new System.Drawing.Size(491, 48);
            this.tagsExcludeTextBox.TabIndex = 5;
            // 
            // tagsExcludeLimitWACheckBox
            // 
            this.tagsExcludeLimitWACheckBox.AutoSize = true;
            this.tagsExcludeLimitWACheckBox.Location = new System.Drawing.Point(95, 137);
            this.tagsExcludeLimitWACheckBox.Name = "tagsExcludeLimitWACheckBox";
            this.tagsExcludeLimitWACheckBox.Size = new System.Drawing.Size(214, 17);
            this.tagsExcludeLimitWACheckBox.TabIndex = 6;
            this.tagsExcludeLimitWACheckBox.Text = "Limit to World Assembly member nations";
            this.tagsExcludeLimitWACheckBox.UseVisualStyleBackColor = true;
            // 
            // tagsIncludeLimitDelegatesCheckBox
            // 
            this.tagsIncludeLimitDelegatesCheckBox.AutoSize = true;
            this.tagsIncludeLimitDelegatesCheckBox.Location = new System.Drawing.Point(315, 60);
            this.tagsIncludeLimitDelegatesCheckBox.Name = "tagsIncludeLimitDelegatesCheckBox";
            this.tagsIncludeLimitDelegatesCheckBox.Size = new System.Drawing.Size(148, 17);
            this.tagsIncludeLimitDelegatesCheckBox.TabIndex = 4;
            this.tagsIncludeLimitDelegatesCheckBox.Text = "Limit to regional delegates";
            this.tagsIncludeLimitDelegatesCheckBox.UseVisualStyleBackColor = true;
            this.tagsIncludeLimitDelegatesCheckBox.CheckedChanged += new System.EventHandler(this.tagsIncludeLimitDelegatesCheckBox_CheckedChanged);
            // 
            // tagsIncludeLabel
            // 
            this.tagsIncludeLabel.AutoSize = true;
            this.tagsIncludeLabel.Location = new System.Drawing.Point(7, 9);
            this.tagsIncludeLabel.Name = "tagsIncludeLabel";
            this.tagsIncludeLabel.Size = new System.Drawing.Size(68, 13);
            this.tagsIncludeLabel.TabIndex = 64;
            this.tagsIncludeLabel.Text = "Include tags:";
            // 
            // tagsIncludeTextBox
            // 
            this.tagsIncludeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagsIncludeTextBox.Location = new System.Drawing.Point(95, 6);
            this.tagsIncludeTextBox.Multiline = true;
            this.tagsIncludeTextBox.Name = "tagsIncludeTextBox";
            this.tagsIncludeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tagsIncludeTextBox.Size = new System.Drawing.Size(491, 48);
            this.tagsIncludeTextBox.TabIndex = 2;
            // 
            // tagsIncludeLimitWACheckBox
            // 
            this.tagsIncludeLimitWACheckBox.AutoSize = true;
            this.tagsIncludeLimitWACheckBox.Location = new System.Drawing.Point(95, 60);
            this.tagsIncludeLimitWACheckBox.Name = "tagsIncludeLimitWACheckBox";
            this.tagsIncludeLimitWACheckBox.Size = new System.Drawing.Size(214, 17);
            this.tagsIncludeLimitWACheckBox.TabIndex = 3;
            this.tagsIncludeLimitWACheckBox.Text = "Limit to World Assembly member nations";
            this.tagsIncludeLimitWACheckBox.UseVisualStyleBackColor = true;
            // 
            // textTabPage
            // 
            this.textTabPage.Controls.Add(this.telegramTextBox);
            this.textTabPage.Controls.Add(this.textToolStrip);
            this.textTabPage.Location = new System.Drawing.Point(4, 25);
            this.textTabPage.Name = "textTabPage";
            this.textTabPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textTabPage.Size = new System.Drawing.Size(602, 358);
            this.textTabPage.TabIndex = 0;
            this.textTabPage.Text = "Telegram Text";
            this.textTabPage.UseVisualStyleBackColor = true;
            // 
            // telegramTextBox
            // 
            this.telegramTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telegramTextBox.Location = new System.Drawing.Point(0, 25);
            this.telegramTextBox.Multiline = true;
            this.telegramTextBox.Name = "telegramTextBox";
            this.telegramTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.telegramTextBox.Size = new System.Drawing.Size(602, 333);
            this.telegramTextBox.TabIndex = 1;
            // 
            // textToolStrip
            // 
            this.textToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripButton,
            this.toolStripSeparator1,
            this.nationToolStripButton,
            this.regionToolStripButton});
            this.textToolStrip.Location = new System.Drawing.Point(0, 0);
            this.textToolStrip.Name = "textToolStrip";
            this.textToolStrip.Size = new System.Drawing.Size(602, 25);
            this.textToolStrip.TabIndex = 2;
            this.textToolStrip.Text = "toolStrip";
            // 
            // clearToolStripButton
            // 
            this.clearToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("clearToolStripButton.Image")));
            this.clearToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearToolStripButton.Name = "clearToolStripButton";
            this.clearToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.clearToolStripButton.Text = "Clear";
            this.clearToolStripButton.Click += new System.EventHandler(this.clearToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // nationToolStripButton
            // 
            this.nationToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nationToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nationToolStripButton.Image")));
            this.nationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nationToolStripButton.Name = "nationToolStripButton";
            this.nationToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.nationToolStripButton.Text = "Insert %NATION%";
            this.nationToolStripButton.Click += new System.EventHandler(this.nationToolStripButton_Click);
            // 
            // regionToolStripButton
            // 
            this.regionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.regionToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("regionToolStripButton.Image")));
            this.regionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.regionToolStripButton.Name = "regionToolStripButton";
            this.regionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.regionToolStripButton.Text = "Insert %REGION%";
            this.regionToolStripButton.Click += new System.EventHandler(this.regionToolStripButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.textTabPage);
            this.tabControl.Controls.Add(this.senderTabPage);
            this.tabControl.Controls.Add(this.recipientsTabPage);
            this.tabControl.Controls.Add(this.sendTabPage);
            this.tabControl.Controls.Add(this.aboutTabPage);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(610, 387);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // senderTabPage
            // 
            this.senderTabPage.Controls.Add(this.emailExpLabel);
            this.senderTabPage.Controls.Add(this.passwordTextBox);
            this.senderTabPage.Controls.Add(this.emailTextBox);
            this.senderTabPage.Controls.Add(this.usernameTextBox);
            this.senderTabPage.Controls.Add(this.emailLabel);
            this.senderTabPage.Controls.Add(this.passwordLabel);
            this.senderTabPage.Controls.Add(this.usernameLabel);
            this.senderTabPage.Location = new System.Drawing.Point(4, 25);
            this.senderTabPage.Name = "senderTabPage";
            this.senderTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.senderTabPage.Size = new System.Drawing.Size(602, 358);
            this.senderTabPage.TabIndex = 6;
            this.senderTabPage.Text = "Sender";
            this.senderTabPage.UseVisualStyleBackColor = true;
            // 
            // emailExpLabel
            // 
            this.emailExpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailExpLabel.Location = new System.Drawing.Point(68, 81);
            this.emailExpLabel.Name = "emailExpLabel";
            this.emailExpLabel.Size = new System.Drawing.Size(528, 31);
            this.emailExpLabel.TabIndex = 24;
            this.emailExpLabel.Text = "Your email address is required in addition to your username and password so that " +
    "the NationStates administrators can contact you in the event of a problem with t" +
    "he program.";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.Location = new System.Drawing.Point(68, 32);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '●';
            this.passwordTextBox.Size = new System.Drawing.Size(528, 20);
            this.passwordTextBox.TabIndex = 22;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailTextBox.Location = new System.Drawing.Point(68, 58);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(528, 20);
            this.emailTextBox.TabIndex = 23;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameTextBox.Location = new System.Drawing.Point(68, 6);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(528, 20);
            this.usernameTextBox.TabIndex = 21;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(6, 61);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(35, 13);
            this.emailLabel.TabIndex = 18;
            this.emailLabel.Text = "Email:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(6, 35);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 19;
            this.passwordLabel.Text = "Password:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(6, 9);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(44, 13);
            this.usernameLabel.TabIndex = 20;
            this.usernameLabel.Text = "Nation: ";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 411);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(650, 450);
            this.Name = "MainForm";
            this.Text = "NationStates AutoTelegram";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.aboutTabPage.ResumeLayout(false);
            this.aboutTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.sendTabPage.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.recipientsTabPage.ResumeLayout(false);
            this.recipientsTabControl.ResumeLayout(false);
            this.nationsTabPage.ResumeLayout(false);
            this.nationsTabPage.PerformLayout();
            this.regionsTabPage.ResumeLayout(false);
            this.regionsTabPage.PerformLayout();
            this.tagsTabPage.ResumeLayout(false);
            this.tagsTabPage.PerformLayout();
            this.textTabPage.ResumeLayout(false);
            this.textTabPage.PerformLayout();
            this.textToolStrip.ResumeLayout(false);
            this.textToolStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.senderTabPage.ResumeLayout(false);
            this.senderTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage aboutTabPage;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.Label nameVersionLabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox creditsTextBox;
        private System.Windows.Forms.TabPage sendTabPage;
        private System.Windows.Forms.TabPage recipientsTabPage;
        private System.Windows.Forms.TabPage textTabPage;
        private System.Windows.Forms.TextBox telegramTextBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage senderTabPage;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.ListView listView;
        internal System.Windows.Forms.ColumnHeader logColumnHeader;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TabControl recipientsTabControl;
        private System.Windows.Forms.TabPage nationsTabPage;
        private System.Windows.Forms.CheckBox nationsExcludeLimitDelegatesCheckBox;
        private System.Windows.Forms.Label nationsExcludeLabel;
        private System.Windows.Forms.CheckBox nationsExcludeAllDelegatesCheckBox;
        private System.Windows.Forms.CheckBox nationsExcludeLimitWACheckBox;
        private System.Windows.Forms.CheckBox nationsExcludeAllWACheckBox;
        private System.Windows.Forms.TextBox nationsExcludeTextBox;
        private System.Windows.Forms.CheckBox nationsIncludeAllNationsCheckBox;
        private System.Windows.Forms.CheckBox nationsIncludeLimitDelegatesCheckBox;
        private System.Windows.Forms.Label nationsIncludeLabel;
        private System.Windows.Forms.TextBox nationsIncludeTextBox;
        private System.Windows.Forms.CheckBox nationsIncludeLimitWACheckBox;
        private System.Windows.Forms.CheckBox nationsIncludeAllDelegatesCheckBox;
        private System.Windows.Forms.CheckBox nationsIncludeAllWACheckBox;
        private System.Windows.Forms.TabPage regionsTabPage;
        private System.Windows.Forms.CheckBox regionsExcludeLimitDelegatesCheckBox;
        private System.Windows.Forms.Label regionsExcludeLabel;
        private System.Windows.Forms.TextBox regionsExcludeTextBox;
        private System.Windows.Forms.TextBox regionsIncludeTextBox;
        private System.Windows.Forms.CheckBox regionsExcludeLimitWACheckBox;
        private System.Windows.Forms.CheckBox regionsIncludeLimitDelegatesCheckBox;
        private System.Windows.Forms.Label regionsIncludeLabel;
        private System.Windows.Forms.CheckBox regionsIncludeLimitWACheckBox;
        private System.Windows.Forms.TabPage tagsTabPage;
        private System.Windows.Forms.CheckBox tagsExcludeLimitDelegatesCheckBox;
        private System.Windows.Forms.Label tagsExcludeLabel;
        private System.Windows.Forms.TextBox tagsExcludeTextBox;
        private System.Windows.Forms.CheckBox tagsExcludeLimitWACheckBox;
        private System.Windows.Forms.CheckBox tagsIncludeLimitDelegatesCheckBox;
        private System.Windows.Forms.Label tagsIncludeLabel;
        private System.Windows.Forms.TextBox tagsIncludeTextBox;
        private System.Windows.Forms.CheckBox tagsIncludeLimitWACheckBox;
        private System.Windows.Forms.Label emailExpLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripSeparator logToolStripSeparator;
        private System.Windows.Forms.ToolStrip textToolStrip;
        private System.Windows.Forms.ToolStripButton nationToolStripButton;
        private System.Windows.Forms.ToolStripButton regionToolStripButton;
        private System.Windows.Forms.ToolStripButton clearToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;



    }
}

