﻿namespace ListenMoeClient
{
	partial class FormSettings
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
			this.btnLogin = new System.Windows.Forms.Button();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tpGeneral = new System.Windows.Forms.TabPage();
			this.gbUpdate = new System.Windows.Forms.GroupBox();
			this.gbLanguage = new System.Windows.Forms.GroupBox();
			this.cbUpdateAutocheck = new System.Windows.Forms.CheckBox();
			this.numericUpdateInterval = new System.Windows.Forms.NumericUpDown();
			this.lblMinutes = new System.Windows.Forms.Label();
			this.gbGeneral = new System.Windows.Forms.GroupBox();
			this.cbFixedSize = new System.Windows.Forms.CheckBox();
			this.cbTopmost = new System.Windows.Forms.CheckBox();
			this.cbCloseToTray = new System.Windows.Forms.CheckBox();
			this.cbThumbnailButton = new System.Windows.Forms.CheckBox();
			this.cbHideFromAltTab = new System.Windows.Forms.CheckBox();
			this.btnRefreshAudioDevices = new System.Windows.Forms.Button();
			this.lblAudioDevice = new System.Windows.Forms.Label();
			this.dropdownAudioDevices = new System.Windows.Forms.ComboBox();
			this.lblLanguage = new System.Windows.Forms.Label();
			this.dropdownLanguage = new System.Windows.Forms.ComboBox();
			this.tpTheme = new System.Windows.Forms.TabPage();
			this.panelVisualiserColor = new ListenMoeClient.Controls.BorderedPanel();
			this.lblVisualiserOpacity = new System.Windows.Forms.Label();
			this.lblVisualiserOpacityDesc = new System.Windows.Forms.Label();
			this.tbVisualiserOpacity = new System.Windows.Forms.TrackBar();
			this.lblVisualiserColor = new System.Windows.Forms.Label();
			this.gbVisualiserSettings = new System.Windows.Forms.GroupBox();
			this.cbVisualiserFadeEdges = new System.Windows.Forms.CheckBox();
			this.cbVisualiserBars = new System.Windows.Forms.CheckBox();
			this.cbEnableVisualiser = new System.Windows.Forms.CheckBox();
			this.cbHeartFavSprite = new System.Windows.Forms.CheckBox();
			this.lblAccentColor = new System.Windows.Forms.Label();
			this.panelAccentColor = new ListenMoeClient.Controls.BorderedPanel();
			this.lblBaseColor = new System.Windows.Forms.Label();
			this.panelBaseColor = new ListenMoeClient.Controls.BorderedPanel();
			this.panelTwoFactorAuth = new System.Windows.Forms.Panel();
			this.lblIncorrectTwoFactorAuth = new System.Windows.Forms.Label();
			this.btnTwoFactorAuthSubmit = new System.Windows.Forms.Button();
			this.gbLayout = new System.Windows.Forms.GroupBox();
			this.lblResolutionScaleDesc = new System.Windows.Forms.Label();
			this.tbResolutionScale = new System.Windows.Forms.TrackBar();
			this.lblResolutionScale = new System.Windows.Forms.Label();
			this.tbOpacity = new System.Windows.Forms.TrackBar();
			this.lblOpacityDesc = new System.Windows.Forms.Label();
			this.lblOpacity = new System.Windows.Forms.Label();
			this.tpAccount = new System.Windows.Forms.TabPage();
			this.panelNotLoggedIn = new System.Windows.Forms.Panel();
			this.txtUsername = new ListenMoeClient.GhostTextbox();
			this.txtPassword = new ListenMoeClient.GhostTextbox();
			this.txtTwoFactorAuthCode = new ListenMoeClient.GhostTextbox();
			this.panelLoggedIn = new System.Windows.Forms.Panel();
			this.lblLoginStatus = new System.Windows.Forms.Label();
			this.btnLogout = new System.Windows.Forms.Button();
			this.tabControl.SuspendLayout();
			this.tpGeneral.SuspendLayout();
			this.gbUpdate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpdateInterval)).BeginInit();
			this.gbGeneral.SuspendLayout();
			this.tpTheme.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbVisualiserOpacity)).BeginInit();
			this.gbVisualiserSettings.SuspendLayout();
			this.gbLayout.SuspendLayout();
			this.gbLanguage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbResolutionScale)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).BeginInit();
			this.tpAccount.SuspendLayout();
			this.panelTwoFactorAuth.SuspendLayout();
			this.panelNotLoggedIn.SuspendLayout();
			this.panelLoggedIn.SuspendLayout();
			this.SuspendLayout();
			//
			// btnLogin
			//
			this.btnLogin.Location = new System.Drawing.Point(147, 67);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(75, 23);
			this.btnLogin.TabIndex = 0;
			this.btnLogin.Text = Localisation.Current.saLogin;
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			//
			// tabControl
			//
			this.tabControl.Controls.Add(this.tpGeneral);
			this.tabControl.Controls.Add(this.tpTheme);
			this.tabControl.Controls.Add(this.tpAccount);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(363, 247);
			this.tabControl.TabIndex = 2;
			//
			// tpGeneral
			//
			this.tpGeneral.Controls.Add(this.gbUpdate);
			this.tpGeneral.Controls.Add(this.gbGeneral);
			this.tpGeneral.Controls.Add(this.gbLanguage);
			this.tpGeneral.Controls.Add(this.btnRefreshAudioDevices);
			this.tpGeneral.Controls.Add(this.lblAudioDevice);
			this.tpGeneral.Controls.Add(this.dropdownAudioDevices);
			this.tpGeneral.Location = new System.Drawing.Point(4, 22);
			this.tpGeneral.Name = "tpGeneral";
			this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tpGeneral.Size = new System.Drawing.Size(355, 221);
			this.tpGeneral.TabIndex = 2;
			this.tpGeneral.Text = Localisation.Current.sGeneral;
			this.tpGeneral.UseVisualStyleBackColor = true;
			//
			// gbUpdate
			//
			this.gbUpdate.Controls.Add(this.cbUpdateAutocheck);
			this.gbUpdate.Controls.Add(this.numericUpdateInterval);
			this.gbUpdate.Controls.Add(this.lblMinutes);
			this.gbUpdate.Location = new System.Drawing.Point(12, 125);
			this.gbUpdate.Name = "gbUpdate";
			this.gbUpdate.Size = new System.Drawing.Size(197, 88);
			this.gbUpdate.TabIndex = 14;
			this.gbUpdate.TabStop = false;
			this.gbUpdate.Text = Localisation.Current.suUpdates;
			//
			// cbUpdateAutocheck
			//
			this.cbUpdateAutocheck.AutoSize = true;
			this.cbUpdateAutocheck.Location = new System.Drawing.Point(6, 24);
			this.cbUpdateAutocheck.Name = "cbUpdateAutocheck";
			this.cbUpdateAutocheck.Size = new System.Drawing.Size(145, 17);
			this.cbUpdateAutocheck.TabIndex = 1;
			this.cbUpdateAutocheck.Text = Localisation.Current.suCheckForUpdatesEvery;
			this.cbUpdateAutocheck.UseVisualStyleBackColor = true;
			//
			// numericUpdateInterval
			//
			this.numericUpdateInterval.Location = new System.Drawing.Point(22, 47);
			this.numericUpdateInterval.Name = "numericUpdateInterval";
			this.numericUpdateInterval.Size = new System.Drawing.Size(49, 20);
			this.numericUpdateInterval.TabIndex = 7;
			this.numericUpdateInterval.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.numericUpdateInterval.ValueChanged += new System.EventHandler(this.NumericUpdateInterval_ValueChanged);
			//
			// lblMinutes
			//
			this.lblMinutes.AutoSize = true;
			this.lblMinutes.Location = new System.Drawing.Point(77, 49);
			this.lblMinutes.Name = "lblMinutes";
			this.lblMinutes.Size = new System.Drawing.Size(28, 13);
			this.lblMinutes.TabIndex = 8;
			this.lblMinutes.Text = Localisation.Current.suMins;
			//
			// gbGeneral
			//
			this.gbGeneral.Controls.Add(this.cbTopmost);
			this.gbGeneral.Controls.Add(this.cbCloseToTray);
			this.gbGeneral.Controls.Add(this.cbThumbnailButton);
			this.gbGeneral.Controls.Add(this.cbHideFromAltTab);
			this.gbGeneral.Controls.Add(this.cbFixedSize);
			this.gbGeneral.Location = new System.Drawing.Point(12, 34);
			this.gbGeneral.Name = "gbGeneral";
			this.gbGeneral.Size = new System.Drawing.Size(333, 85);
			this.gbGeneral.TabIndex = 13;
			this.gbGeneral.TabStop = false;
			this.gbGeneral.Text = Localisation.Current.sGeneral;
			//
			// cbTopmost
			//
			this.cbTopmost.AutoSize = true;
			this.cbTopmost.Location = new System.Drawing.Point(6, 19);
			this.cbTopmost.Name = "cbTopmost";
			this.cbTopmost.Size = new System.Drawing.Size(117, 17);
			this.cbTopmost.TabIndex = 0;
			this.cbTopmost.Text = Localisation.Current.sgKeepTopMost;
			this.cbTopmost.UseVisualStyleBackColor = true;
			//
			// cbFixedSize
			//
			this.cbFixedSize.AutoSize = true;
			this.cbFixedSize.Location = new System.Drawing.Point(6, 61);
			this.cbFixedSize.Name = "cbFixedSize";
			this.cbFixedSize.Size = new System.Drawing.Size(117, 17);
			this.cbFixedSize.TabIndex = 0;
			this.cbFixedSize.Text = Localisation.Current.sgFixedSize;
			this.cbFixedSize.UseVisualStyleBackColor = true;
			//
			// cbCloseToTray
			//
			this.cbCloseToTray.AutoSize = true;
			this.cbCloseToTray.Location = new System.Drawing.Point(6, 40);
			this.cbCloseToTray.Name = "cbCloseToTray";
			this.cbCloseToTray.Size = new System.Drawing.Size(84, 17);
			this.cbCloseToTray.TabIndex = 2;
			this.cbCloseToTray.Text = Localisation.Current.sgCloseToTray;
			this.cbCloseToTray.UseVisualStyleBackColor = true;
			//
			// cbThumbnailButton
			//
			this.cbThumbnailButton.AutoSize = true;
			this.cbThumbnailButton.Checked = true;
			this.cbThumbnailButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbThumbnailButton.Location = new System.Drawing.Point(168, 12);
			this.cbThumbnailButton.Name = "cbThumbnailButton";
			this.cbThumbnailButton.Size = new System.Drawing.Size(143, 30);
			this.cbThumbnailButton.TabIndex = 9;
			this.cbThumbnailButton.Text = Localisation.Current.sgThumbnailToolbarButton + "\n" + Localisation.Current.sRequiesRestart;
			this.cbThumbnailButton.UseVisualStyleBackColor = true;
			//
			// cbHideFromAltTab
			//
			this.cbHideFromAltTab.AutoSize = true;
			this.cbHideFromAltTab.Location = new System.Drawing.Point(168, 40);
			this.cbHideFromAltTab.Name = "cbHideFromAltTab";
			this.cbHideFromAltTab.Size = new System.Drawing.Size(158, 30);
			this.cbHideFromAltTab.TabIndex = 3;
			this.cbHideFromAltTab.Text = Localisation.Current.sgHideFromAltTab;
			this.cbHideFromAltTab.UseVisualStyleBackColor = true;
			//
			// btnRefreshAudioDevices
			//
			this.btnRefreshAudioDevices.Location = new System.Drawing.Point(270, 5);
			this.btnRefreshAudioDevices.Name = "btnRefreshAudioDevices";
			this.btnRefreshAudioDevices.Size = new System.Drawing.Size(75, 23);
			this.btnRefreshAudioDevices.TabIndex = 12;
			this.btnRefreshAudioDevices.Text = Localisation.Current.sgRefresh;
			this.btnRefreshAudioDevices.UseVisualStyleBackColor = true;
			this.btnRefreshAudioDevices.Click += new System.EventHandler(this.btnRefreshAudioDevices_Click);
			//
			// lblAudioDevice
			//
			this.lblAudioDevice.AutoSize = true;
			this.lblAudioDevice.Location = new System.Drawing.Point(9, 10);
			this.lblAudioDevice.Name = "lblAudioDevice";
			this.lblAudioDevice.Size = new System.Drawing.Size(72, 13);
			this.lblAudioDevice.TabIndex = 11;
			this.lblAudioDevice.Text = Localisation.Current.sgAudioDevice;
			//
			// dropdownAudioDevices
			//
			this.dropdownAudioDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dropdownAudioDevices.FormattingEnabled = true;
			this.dropdownAudioDevices.Location = new System.Drawing.Point(89, 6);
			this.dropdownAudioDevices.Name = "dropdownAudioDevices";
			this.dropdownAudioDevices.Size = new System.Drawing.Size(175, 21);
			this.dropdownAudioDevices.TabIndex = 10;
			this.dropdownAudioDevices.SelectionChangeCommitted += new System.EventHandler(this.cbAudioDevices_SelectionChangeCommitted);
			//
			// gbLanguage
			//
			this.gbLanguage.Controls.Add(this.lblLanguage);
			this.gbLanguage.Controls.Add(this.dropdownLanguage);
			this.gbLanguage.Location = new System.Drawing.Point(217, 125);
			this.gbLanguage.Name = "gbLanguage";
			this.gbLanguage.Size = new System.Drawing.Size(128, 88);
			this.gbLanguage.TabIndex = 13;
			this.gbLanguage.TabStop = false;
			this.gbLanguage.Text = Localisation.Current.slLanguage;
			//
			// lblLanguage
			//
			this.lblLanguage.AutoSize = true;
			this.lblLanguage.Location = new System.Drawing.Point(9, 14);
			this.lblLanguage.Name = "lblLanguage";
			this.lblLanguage.Size = new System.Drawing.Size(72, 13);
			this.lblLanguage.TabIndex = 11;
			this.lblLanguage.Text = Localisation.Current.slLanguage + " " + Localisation.Current.sRequiesRestartSplit + ":";
			//
			// dropdownLanguage
			//
			this.dropdownLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dropdownLanguage.FormattingEnabled = true;
			this.dropdownLanguage.Location = new System.Drawing.Point(9, 46);
			this.dropdownLanguage.Name = "dropdownLanguage";
			this.dropdownLanguage.Size = new System.Drawing.Size(100, 21);
			this.dropdownLanguage.TabIndex = 10;
			this.dropdownLanguage.SelectionChangeCommitted += new System.EventHandler(this.cbLanguage_SelectionChangeCommitted);
			//
			// tpTheme
			//
			this.tpTheme.Controls.Add(this.gbVisualiserSettings);
			this.tpTheme.Controls.Add(this.gbLayout);
			this.tpTheme.Location = new System.Drawing.Point(4, 22);
			this.tpTheme.Name = "tpTheme";
			this.tpTheme.Padding = new System.Windows.Forms.Padding(3);
			this.tpTheme.Size = new System.Drawing.Size(355, 221);
			this.tpTheme.TabIndex = 4;
			this.tpTheme.Text = Localisation.Current.sThemeLayout;
			this.tpTheme.UseVisualStyleBackColor = true;
			//
			// gbVisualiserSettings
			//
			this.gbVisualiserSettings.Controls.Add(this.panelVisualiserColor);
			this.gbVisualiserSettings.Controls.Add(this.lblVisualiserOpacity);
			this.gbVisualiserSettings.Controls.Add(this.lblVisualiserOpacityDesc);
			this.gbVisualiserSettings.Controls.Add(this.tbVisualiserOpacity);
			this.gbVisualiserSettings.Controls.Add(this.lblVisualiserColor);
			this.gbVisualiserSettings.Controls.Add(this.cbVisualiserFadeEdges);
			this.gbVisualiserSettings.Controls.Add(this.cbVisualiserBars);
			this.gbVisualiserSettings.Controls.Add(this.cbEnableVisualiser);
			this.gbVisualiserSettings.Location = new System.Drawing.Point(6, 122);
			this.gbVisualiserSettings.Name = "gbVisualiserSettings";
			this.gbVisualiserSettings.Size = new System.Drawing.Size(341, 93);
			this.gbVisualiserSettings.TabIndex = 26;
			this.gbVisualiserSettings.TabStop = false;
			this.gbVisualiserSettings.Text = Localisation.Current.svVisualiser;
			//
			// panelVisualiserColor
			//
			this.panelVisualiserColor.BackColor = System.Drawing.Color.Black;
			this.panelVisualiserColor.BorderColor = System.Drawing.Color.Black;
			this.panelVisualiserColor.BorderWidth = 2;
			this.panelVisualiserColor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.panelVisualiserColor.Location = new System.Drawing.Point(165, 35);
			this.panelVisualiserColor.Name = "panelVisualiserColor";
			this.panelVisualiserColor.Size = new System.Drawing.Size(32, 32);
			this.panelVisualiserColor.TabIndex = 21;
			//
			// lblVisualiserColor
			//
			this.lblVisualiserColor.AutoSize = true;
			this.lblVisualiserColor.Location = new System.Drawing.Point(162, 19);
			this.lblVisualiserColor.Name = "lblVisualiserColor";
			this.lblVisualiserColor.Size = new System.Drawing.Size(77, 13);
			this.lblVisualiserColor.TabIndex = 26;
			this.lblVisualiserColor.Text = Localisation.Current.svVisualiserColor;
			//
			// lblVisualiserOpacity
			//
			this.lblVisualiserOpacity.AutoSize = true;
			this.lblVisualiserOpacity.Location = new System.Drawing.Point(315, 39);
			this.lblVisualiserOpacity.Name = "lblVisualiserOpacity";
			this.lblVisualiserOpacity.Size = new System.Drawing.Size(22, 13);
			this.lblVisualiserOpacity.TabIndex = 18;
			this.lblVisualiserOpacity.Text = "1.0";
			//
			// lblVisualiserOpacityDesc
			//
			this.lblVisualiserOpacityDesc.AutoSize = true;
			this.lblVisualiserOpacityDesc.Location = new System.Drawing.Point(211, 19);
			this.lblVisualiserOpacityDesc.Name = "lblVisualiserOpacityDesc";
			this.lblVisualiserOpacityDesc.Size = new System.Drawing.Size(43, 13);
			this.lblVisualiserOpacityDesc.TabIndex = 24;
			this.lblVisualiserOpacityDesc.Text = Localisation.Current.svVisualiserOpacity;
			//
			// tbVisualiserOpacity
			//
			this.tbVisualiserOpacity.AutoSize = false;
			this.tbVisualiserOpacity.BackColor = System.Drawing.Color.White;
			this.tbVisualiserOpacity.Location = new System.Drawing.Point(208, 35);
			this.tbVisualiserOpacity.Maximum = 255;
			this.tbVisualiserOpacity.Name = "tbVisualiserOpacity";
			this.tbVisualiserOpacity.Size = new System.Drawing.Size(110, 24);
			this.tbVisualiserOpacity.TabIndex = 23;
			this.tbVisualiserOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tbVisualiserOpacity.Value = 1;
			this.tbVisualiserOpacity.Scroll += new System.EventHandler(this.tbVisualiserOpacity_Scroll);
			//
			// cbVisualiserFadeEdges
			//
			this.cbVisualiserFadeEdges.AutoSize = true;
			this.cbVisualiserFadeEdges.Location = new System.Drawing.Point(6, 65);
			this.cbVisualiserFadeEdges.Name = "cbVisualiserFadeEdges";
			this.cbVisualiserFadeEdges.Size = new System.Drawing.Size(82, 17);
			this.cbVisualiserFadeEdges.TabIndex = 25;
			this.cbVisualiserFadeEdges.Text = Localisation.Current.svFadeEdges;
			this.cbVisualiserFadeEdges.UseVisualStyleBackColor = true;
			//
			// cbVisualiserBars
			//
			this.cbVisualiserBars.AutoSize = true;
			this.cbVisualiserBars.Location = new System.Drawing.Point(6, 42);
			this.cbVisualiserBars.Name = "cbVisualiserBars";
			this.cbVisualiserBars.Size = new System.Drawing.Size(68, 17);
			this.cbVisualiserBars.TabIndex = 22;
			this.cbVisualiserBars.Text = Localisation.Current.svUseBars;
			this.cbVisualiserBars.UseVisualStyleBackColor = true;
			//
			// cbEnableVisualiser
			//
			this.cbEnableVisualiser.AutoSize = true;
			this.cbEnableVisualiser.Location = new System.Drawing.Point(6, 19);
			this.cbEnableVisualiser.Name = "cbEnableVisualiser";
			this.cbEnableVisualiser.Size = new System.Drawing.Size(59, 17);
			this.cbEnableVisualiser.TabIndex = 20;
			this.cbEnableVisualiser.Text = Localisation.Current.svEnable;
			this.cbEnableVisualiser.UseVisualStyleBackColor = true;
			//
			// gbLayout
			//
			this.gbLayout.Controls.Add(this.lblAccentColor);
			this.gbLayout.Controls.Add(this.panelAccentColor);
			this.gbLayout.Controls.Add(this.lblBaseColor);
			this.gbLayout.Controls.Add(this.panelBaseColor);
			this.gbLayout.Controls.Add(this.lblResolutionScaleDesc);
			this.gbLayout.Controls.Add(this.tbResolutionScale);
			this.gbLayout.Controls.Add(this.lblResolutionScale);
			this.gbLayout.Controls.Add(this.tbOpacity);
			this.gbLayout.Controls.Add(this.lblOpacityDesc);
			this.gbLayout.Controls.Add(this.lblOpacity);
			this.gbLayout.Controls.Add(this.cbHeartFavSprite);
			this.gbLayout.Location = new System.Drawing.Point(6, 6);
			this.gbLayout.Name = "groupBox1";
			this.gbLayout.Size = new System.Drawing.Size(341, 113);
			this.gbLayout.TabIndex = 19;
			this.gbLayout.TabStop = false;
			this.gbLayout.Text = Localisation.Current.stLayout;
			//
			// cbHeartFavSprite
			//
			this.cbHeartFavSprite.AutoSize = true;
			this.cbHeartFavSprite.Location = new System.Drawing.Point(191, 77);
			this.cbHeartFavSprite.Name = "cbHeartFavSprite";
			this.cbHeartFavSprite.Size = new System.Drawing.Size(59, 17);
			this.cbHeartFavSprite.TabIndex = 20;
			this.cbHeartFavSprite.Text = Localisation.Current.stHeartFav;
			this.cbHeartFavSprite.UseVisualStyleBackColor = true;
			//
			// lblAccentColor
			//
			this.lblAccentColor.AutoSize = true;
			this.lblAccentColor.Location = new System.Drawing.Point(188 + 80, 16);
			this.lblAccentColor.Name = "lblAccentColor";
			this.lblAccentColor.Size = new System.Drawing.Size(67, 13);
			this.lblAccentColor.TabIndex = 5;
			this.lblAccentColor.Text = Localisation.Current.stAccentColor;
			//
			// panelAccentColor
			//
			this.panelAccentColor.BackColor = System.Drawing.Color.Black;
			this.panelAccentColor.BorderColor = System.Drawing.Color.Black;
			this.panelAccentColor.BorderWidth = 2;
			this.panelAccentColor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.panelAccentColor.Location = new System.Drawing.Point(271, 32);
			this.panelAccentColor.Name = "panelAccentColor";
			this.panelAccentColor.Size = new System.Drawing.Size(32, 32);
			this.panelAccentColor.TabIndex = 4;
			//
			// lblBaseColor
			//
			this.lblBaseColor.AutoSize = true;
			this.lblBaseColor.Location = new System.Drawing.Point(188, 16);
			this.lblBaseColor.Name = "lblBaseColor";
			this.lblBaseColor.Size = new System.Drawing.Size(57, 13);
			this.lblBaseColor.TabIndex = 3;
			this.lblBaseColor.Text = Localisation.Current.stBaseColor;
			//
			// panelBaseColor
			//
			this.panelBaseColor.BackColor = System.Drawing.Color.Black;
			this.panelBaseColor.BorderColor = System.Drawing.Color.Black;
			this.panelBaseColor.BorderWidth = 2;
			this.panelBaseColor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.panelBaseColor.Location = new System.Drawing.Point(191, 32);
			this.panelBaseColor.Name = "panelBaseColor";
			this.panelBaseColor.Size = new System.Drawing.Size(32, 32);
			this.panelBaseColor.TabIndex = 2;
			//
			// lblResolutionScaleDesc
			//
			this.lblResolutionScaleDesc.AutoSize = true;
			this.lblResolutionScaleDesc.Location = new System.Drawing.Point(6, 19);
			this.lblResolutionScaleDesc.Name = "lblResolutionScaleDesc";
			this.lblResolutionScaleDesc.Size = new System.Drawing.Size(85, 13);
			this.lblResolutionScaleDesc.TabIndex = 13;
			this.lblResolutionScaleDesc.Text = Localisation.Current.stResolutionScale;
			//
			// tbResolutionScale
			//
			this.tbResolutionScale.AutoSize = false;
			this.tbResolutionScale.BackColor = System.Drawing.Color.White;
			this.tbResolutionScale.Location = new System.Drawing.Point(2, 35);
			this.tbResolutionScale.Maximum = 40;
			this.tbResolutionScale.Minimum = 5;
			this.tbResolutionScale.Name = "tbResolutionScale";
			this.tbResolutionScale.Size = new System.Drawing.Size(134, 27);
			this.tbResolutionScale.TabIndex = 12;
			this.tbResolutionScale.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tbResolutionScale.Value = 10;
			this.tbResolutionScale.Scroll += new System.EventHandler(this.tbResolutionScale_Scroll);
			//
			// lblResolutionScale
			//
			this.lblResolutionScale.AutoSize = true;
			this.lblResolutionScale.Location = new System.Drawing.Point(142, 35);
			this.lblResolutionScale.Name = "lblResolutionScale";
			this.lblResolutionScale.Size = new System.Drawing.Size(22, 13);
			this.lblResolutionScale.TabIndex = 17;
			this.lblResolutionScale.Text = "1.0";
			//
			// tbOpacity
			//
			this.tbOpacity.AutoSize = false;
			this.tbOpacity.BackColor = System.Drawing.Color.White;
			this.tbOpacity.Location = new System.Drawing.Point(2, 77);
			this.tbOpacity.Maximum = 255;
			this.tbOpacity.Name = "tbOpacity";
			this.tbOpacity.Size = new System.Drawing.Size(134, 33);
			this.tbOpacity.TabIndex = 14;
			this.tbOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tbOpacity.Scroll += new System.EventHandler(this.tbOpacity_Scroll);
			//
			// lblOpacityDesc
			//
			this.lblOpacityDesc.AutoSize = true;
			this.lblOpacityDesc.Location = new System.Drawing.Point(6, 61);
			this.lblOpacityDesc.Name = "lblOpacityDesc";
			this.lblOpacityDesc.Size = new System.Drawing.Size(43, 13);
			this.lblOpacityDesc.TabIndex = 16;
			this.lblOpacityDesc.Text = Localisation.Current.stOpacity;
			//
			// lblOpacity
			//
			this.lblOpacity.AutoSize = true;
			this.lblOpacity.Location = new System.Drawing.Point(142, 77);
			this.lblOpacity.Name = "lblOpacity";
			this.lblOpacity.Size = new System.Drawing.Size(22, 13);
			this.lblOpacity.TabIndex = 15;
			this.lblOpacity.Text = "1.0";
			//
			// tpAccount
			//
			this.tpAccount.Controls.Add(this.panelTwoFactorAuth);
			this.tpAccount.Controls.Add(this.panelNotLoggedIn);
			this.tpAccount.Controls.Add(this.panelLoggedIn);
			this.tpAccount.Location = new System.Drawing.Point(4, 22);
			this.tpAccount.Name = "tpAccount";
			this.tpAccount.Padding = new System.Windows.Forms.Padding(3);
			this.tpAccount.Size = new System.Drawing.Size(355, 221);
			this.tpAccount.TabIndex = 0;
			this.tpAccount.Text = Localisation.Current.sAccount;
			this.tpAccount.UseVisualStyleBackColor = true;
			//
			// panelTwoFactorAuth
			//
			this.panelTwoFactorAuth.Controls.Add(this.lblIncorrectTwoFactorAuth);
			this.panelTwoFactorAuth.Controls.Add(this.txtTwoFactorAuthCode);
			this.panelTwoFactorAuth.Controls.Add(this.btnTwoFactorAuthSubmit);
			this.panelTwoFactorAuth.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelTwoFactorAuth.Location = new System.Drawing.Point(3, 3);
			this.panelTwoFactorAuth.Name = "panelTwoFactorAuth";
			this.panelTwoFactorAuth.Size = new System.Drawing.Size(349, 215);
			this.panelTwoFactorAuth.TabIndex = 6;
			this.panelTwoFactorAuth.Visible = false;
			//
	        // lblIncorrectTwoFactorAuth
			//
			this.lblIncorrectTwoFactorAuth.AutoSize = true;
			this.lblIncorrectTwoFactorAuth.Location = new System.Drawing.Point(67, 93);
			this.lblIncorrectTwoFactorAuth.Name = "lblIncorrectTwoFactorAuth";
			this.lblIncorrectTwoFactorAuth.Size = new System.Drawing.Size(243, 13);
			this.lblIncorrectTwoFactorAuth.TabIndex = 3;
			this.lblIncorrectTwoFactorAuth.Text = Localisation.Current.saWrong2faCode;
			this.lblIncorrectTwoFactorAuth.Visible = false;
			//
			// btnTwoFactorAuthSubmit
			//
			this.btnTwoFactorAuthSubmit.Location = new System.Drawing.Point(147, 58);
			this.btnTwoFactorAuthSubmit.Name = "btnTwoFactorAuthSubmit";
			this.btnTwoFactorAuthSubmit.Size = new System.Drawing.Size(75, 23);
			this.btnTwoFactorAuthSubmit.TabIndex = 0;
			this.btnTwoFactorAuthSubmit.Text = Localisation.Current.sa2faSubmit;
			this.btnTwoFactorAuthSubmit.UseVisualStyleBackColor = true;
			this.btnTwoFactorAuthSubmit.Click += new System.EventHandler(this.btnTwoFactorAuthSubmit_Click);
			//
			// panelNotLoggedIn
			//
			this.panelNotLoggedIn.Controls.Add(this.txtUsername);
			this.panelNotLoggedIn.Controls.Add(this.txtPassword);
			this.panelNotLoggedIn.Controls.Add(this.btnLogin);
			this.panelNotLoggedIn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelNotLoggedIn.Location = new System.Drawing.Point(3, 3);
			this.panelNotLoggedIn.Name = "panelNotLoggedIn";
			this.panelNotLoggedIn.Size = new System.Drawing.Size(349, 215);
			this.panelNotLoggedIn.TabIndex = 4;
			//
			// txtUsername
			//
			this.txtUsername.GhostText = Localisation.Current.saUsername;
			this.txtUsername.Location = new System.Drawing.Point(94, 15);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(181, 20);
			this.txtUsername.TabIndex = 2;
			//
			// txtPassword
			//
			this.txtPassword.GhostText = Localisation.Current.saPassword;
			this.txtPassword.Location = new System.Drawing.Point(94, 41);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '⚫';
			this.txtPassword.Size = new System.Drawing.Size(181, 20);
			this.txtPassword.TabIndex = 3;
			this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
			//
			// panelLoggedIn
			//
			this.panelLoggedIn.Controls.Add(this.lblLoginStatus);
			this.panelLoggedIn.Controls.Add(this.btnLogout);
			this.panelLoggedIn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelLoggedIn.Location = new System.Drawing.Point(3, 3);
			this.panelLoggedIn.Name = "panelLoggedIn";
			this.panelLoggedIn.Size = new System.Drawing.Size(349, 215);
			this.panelLoggedIn.TabIndex = 4;
			//
			// lblLoginStatus
			//
			this.lblLoginStatus.AutoSize = true;
			this.lblLoginStatus.Location = new System.Drawing.Point(94, 32);
			this.lblLoginStatus.Name = "lblLoginStatus";
			this.lblLoginStatus.Size = new System.Drawing.Size(68, 13);
			this.lblLoginStatus.TabIndex = 1;
			this.lblLoginStatus.Text = Localisation.Current.saLoggedInAs;
			//
			// btnLogout
			//
			this.btnLogout.Location = new System.Drawing.Point(149, 67);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.Size = new System.Drawing.Size(75, 23);
			this.btnLogout.TabIndex = 0;
			this.btnLogout.Text = Localisation.Current.saLogout;
			this.btnLogout.UseVisualStyleBackColor = true;
			this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
			//
			// FormSettings
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(363, 247);
			this.Controls.Add(this.tabControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormSettings";
			this.Text = Localisation.Current.sSettings;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
			this.tabControl.ResumeLayout(false);
			this.tpGeneral.ResumeLayout(false);
			this.tpGeneral.PerformLayout();
			this.gbUpdate.ResumeLayout(false);
			this.gbUpdate.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpdateInterval)).EndInit();
			this.gbGeneral.ResumeLayout(false);
			this.gbGeneral.PerformLayout();
			this.tpTheme.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tbVisualiserOpacity)).EndInit();
			this.gbVisualiserSettings.ResumeLayout(false);
			this.gbVisualiserSettings.PerformLayout();
			this.gbLayout.ResumeLayout(false);
			this.gbLayout.PerformLayout();
			this.gbLanguage.ResumeLayout(false);
			this.gbLanguage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbResolutionScale)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).EndInit();
			this.tpAccount.ResumeLayout(false);
			this.panelNotLoggedIn.ResumeLayout(false);
			this.panelNotLoggedIn.PerformLayout();
			this.panelLoggedIn.ResumeLayout(false);
			this.panelLoggedIn.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tpAccount;
		private System.Windows.Forms.TabPage tpGeneral;
		private System.Windows.Forms.CheckBox cbTopmost;
		private System.Windows.Forms.CheckBox cbUpdateAutocheck;
		private System.Windows.Forms.CheckBox cbCloseToTray;
		private System.Windows.Forms.CheckBox cbHideFromAltTab;
		private System.Windows.Forms.CheckBox cbFixedSize;
		private GhostTextbox txtUsername;
		private GhostTextbox txtPassword;
		private System.Windows.Forms.Panel panelNotLoggedIn;
		private System.Windows.Forms.Panel panelLoggedIn;
		private System.Windows.Forms.Label lblLoginStatus;
		private System.Windows.Forms.Button btnLogout;
		private System.Windows.Forms.Label lblMinutes;
		private System.Windows.Forms.NumericUpDown numericUpdateInterval;
		private System.Windows.Forms.CheckBox cbThumbnailButton;
		private System.Windows.Forms.TabPage tpTheme;
		private System.Windows.Forms.Label lblResolutionScale;
		private System.Windows.Forms.Label lblOpacityDesc;
		private System.Windows.Forms.Label lblOpacity;
		private System.Windows.Forms.TrackBar tbOpacity;
		private System.Windows.Forms.Label lblResolutionScaleDesc;
		private System.Windows.Forms.TrackBar tbResolutionScale;
		private System.Windows.Forms.Label lblAccentColor;
		private Controls.BorderedPanel panelAccentColor;
		private System.Windows.Forms.Label lblBaseColor;
		private Controls.BorderedPanel panelBaseColor;
		private System.Windows.Forms.GroupBox gbLayout;
		private System.Windows.Forms.Button btnRefreshAudioDevices;
		private System.Windows.Forms.Label lblAudioDevice;
		private System.Windows.Forms.GroupBox gbLanguage;
		private System.Windows.Forms.ComboBox dropdownAudioDevices;
		private System.Windows.Forms.Label lblLanguage;
		private System.Windows.Forms.ComboBox dropdownLanguage;
		private System.Windows.Forms.CheckBox cbVisualiserFadeEdges;
		private System.Windows.Forms.CheckBox cbEnableVisualiser;
		private System.Windows.Forms.CheckBox cbHeartFavSprite;
		private System.Windows.Forms.Label lblVisualiserOpacityDesc;
		private Controls.BorderedPanel panelVisualiserColor;
		private System.Windows.Forms.TrackBar tbVisualiserOpacity;
		private System.Windows.Forms.CheckBox cbVisualiserBars;
		private System.Windows.Forms.GroupBox gbGeneral;
		private System.Windows.Forms.GroupBox gbVisualiserSettings;
		private System.Windows.Forms.Label lblVisualiserColor;
		private System.Windows.Forms.Label lblVisualiserOpacity;
		private System.Windows.Forms.GroupBox gbUpdate;
		private System.Windows.Forms.Panel panelTwoFactorAuth;
		private System.Windows.Forms.Label lblIncorrectTwoFactorAuth;
		private GhostTextbox txtTwoFactorAuthCode;
		private System.Windows.Forms.Button btnTwoFactorAuthSubmit;
	}
}
