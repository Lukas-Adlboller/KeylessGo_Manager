namespace KeylessGo_GUI
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
      this.panelInformation = new System.Windows.Forms.Panel();
      this.bttnMinimize = new System.Windows.Forms.Button();
      this.bttnExit = new System.Windows.Forms.Button();
      this.passwordEntryPanel = new System.Windows.Forms.Panel();
      this.buttonSoftwareInfo = new System.Windows.Forms.Button();
      this.buttonDeviceInfo = new System.Windows.Forms.Button();
      this.entryFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
      this.lblPlaceholder = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.sideMenuePanel = new KeylessGo_GUI.GradientPanel();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.buttonSyncDevice = new System.Windows.Forms.Button();
      this.buttonSettings = new System.Windows.Forms.Button();
      this.buttonImportFile = new System.Windows.Forms.Button();
      this.buttonAddEntry = new System.Windows.Forms.Button();
      this.buttonAbout = new System.Windows.Forms.Button();
      this.panelInformation.SuspendLayout();
      this.entryFlowLayoutPanel.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.sideMenuePanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      this.SuspendLayout();
      // 
      // panelInformation
      // 
      this.panelInformation.BackColor = System.Drawing.Color.White;
      this.panelInformation.Controls.Add(this.bttnMinimize);
      this.panelInformation.Controls.Add(this.bttnExit);
      this.panelInformation.Controls.Add(this.passwordEntryPanel);
      this.panelInformation.Controls.Add(this.buttonSoftwareInfo);
      this.panelInformation.Controls.Add(this.buttonDeviceInfo);
      this.panelInformation.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelInformation.Location = new System.Drawing.Point(0, 0);
      this.panelInformation.Name = "panelInformation";
      this.panelInformation.Size = new System.Drawing.Size(917, 37);
      this.panelInformation.TabIndex = 0;
      this.panelInformation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelInformation_MouseDown);
      // 
      // bttnMinimize
      // 
      this.bttnMinimize.FlatAppearance.BorderSize = 0;
      this.bttnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.bttnMinimize.Image = global::KeylessGo_GUI.Properties.Resources.minimize_icon;
      this.bttnMinimize.Location = new System.Drawing.Point(844, 4);
      this.bttnMinimize.Name = "bttnMinimize";
      this.bttnMinimize.Size = new System.Drawing.Size(30, 30);
      this.bttnMinimize.TabIndex = 6;
      this.bttnMinimize.UseVisualStyleBackColor = true;
      this.bttnMinimize.Click += new System.EventHandler(this.bttnMinimize_Click);
      // 
      // bttnExit
      // 
      this.bttnExit.FlatAppearance.BorderSize = 0;
      this.bttnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.bttnExit.Image = global::KeylessGo_GUI.Properties.Resources.exit_icon;
      this.bttnExit.Location = new System.Drawing.Point(880, 3);
      this.bttnExit.Name = "bttnExit";
      this.bttnExit.Size = new System.Drawing.Size(30, 30);
      this.bttnExit.TabIndex = 5;
      this.bttnExit.UseVisualStyleBackColor = true;
      this.bttnExit.Click += new System.EventHandler(this.bttnExit_Click);
      // 
      // passwordEntryPanel
      // 
      this.passwordEntryPanel.AutoScroll = true;
      this.passwordEntryPanel.Location = new System.Drawing.Point(0, 64);
      this.passwordEntryPanel.Name = "passwordEntryPanel";
      this.passwordEntryPanel.Size = new System.Drawing.Size(914, 536);
      this.passwordEntryPanel.TabIndex = 2;
      // 
      // buttonSoftwareInfo
      // 
      this.buttonSoftwareInfo.BackColor = System.Drawing.Color.Transparent;
      this.buttonSoftwareInfo.FlatAppearance.BorderSize = 0;
      this.buttonSoftwareInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
      this.buttonSoftwareInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
      this.buttonSoftwareInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonSoftwareInfo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonSoftwareInfo.ForeColor = System.Drawing.Color.Black;
      this.buttonSoftwareInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.buttonSoftwareInfo.ImageKey = "(none)";
      this.buttonSoftwareInfo.Location = new System.Drawing.Point(9, 7);
      this.buttonSoftwareInfo.Name = "buttonSoftwareInfo";
      this.buttonSoftwareInfo.Size = new System.Drawing.Size(131, 23);
      this.buttonSoftwareInfo.TabIndex = 4;
      this.buttonSoftwareInfo.Text = "App Version: 1.0";
      this.buttonSoftwareInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.buttonSoftwareInfo.UseVisualStyleBackColor = false;
      // 
      // buttonDeviceInfo
      // 
      this.buttonDeviceInfo.BackColor = System.Drawing.Color.Transparent;
      this.buttonDeviceInfo.FlatAppearance.BorderSize = 0;
      this.buttonDeviceInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
      this.buttonDeviceInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
      this.buttonDeviceInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonDeviceInfo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonDeviceInfo.ForeColor = System.Drawing.Color.Black;
      this.buttonDeviceInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.buttonDeviceInfo.ImageKey = "(none)";
      this.buttonDeviceInfo.Location = new System.Drawing.Point(146, 7);
      this.buttonDeviceInfo.Name = "buttonDeviceInfo";
      this.buttonDeviceInfo.Size = new System.Drawing.Size(141, 23);
      this.buttonDeviceInfo.TabIndex = 3;
      this.buttonDeviceInfo.Text = "Device Version: 1.1";
      this.buttonDeviceInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.buttonDeviceInfo.UseVisualStyleBackColor = false;
      // 
      // entryFlowLayoutPanel
      // 
      this.entryFlowLayoutPanel.AutoScroll = true;
      this.entryFlowLayoutPanel.Controls.Add(this.lblPlaceholder);
      this.entryFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.entryFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.entryFlowLayoutPanel.Location = new System.Drawing.Point(0, 37);
      this.entryFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
      this.entryFlowLayoutPanel.Name = "entryFlowLayoutPanel";
      this.entryFlowLayoutPanel.Size = new System.Drawing.Size(917, 563);
      this.entryFlowLayoutPanel.TabIndex = 2;
      this.entryFlowLayoutPanel.WrapContents = false;
      // 
      // lblPlaceholder
      // 
      this.lblPlaceholder.AutoSize = true;
      this.lblPlaceholder.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblPlaceholder.Location = new System.Drawing.Point(350, 250);
      this.lblPlaceholder.Margin = new System.Windows.Forms.Padding(350, 250, 3, 0);
      this.lblPlaceholder.Name = "lblPlaceholder";
      this.lblPlaceholder.Size = new System.Drawing.Size(226, 29);
      this.lblPlaceholder.TabIndex = 0;
      this.lblPlaceholder.Text = "  Nothing to see here...";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.entryFlowLayoutPanel);
      this.panel1.Controls.Add(this.panelInformation);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel1.Location = new System.Drawing.Point(197, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(917, 600);
      this.panel1.TabIndex = 2;
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox1.Image = global::KeylessGo_GUI.Properties.Resources.fast_ein_logo;
      this.pictureBox1.Location = new System.Drawing.Point(9, 7);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(182, 45);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 1;
      this.pictureBox1.TabStop = false;
      // 
      // sideMenuePanel
      // 
      this.sideMenuePanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
      this.sideMenuePanel.ColorBottom = System.Drawing.Color.Empty;
      this.sideMenuePanel.ColorTop = System.Drawing.Color.Empty;
      this.sideMenuePanel.Controls.Add(this.pictureBox2);
      this.sideMenuePanel.Controls.Add(this.buttonSyncDevice);
      this.sideMenuePanel.Controls.Add(this.buttonSettings);
      this.sideMenuePanel.Controls.Add(this.buttonImportFile);
      this.sideMenuePanel.Controls.Add(this.buttonAddEntry);
      this.sideMenuePanel.Controls.Add(this.buttonAbout);
      this.sideMenuePanel.Dock = System.Windows.Forms.DockStyle.Left;
      this.sideMenuePanel.Location = new System.Drawing.Point(0, 0);
      this.sideMenuePanel.Name = "sideMenuePanel";
      this.sideMenuePanel.Size = new System.Drawing.Size(200, 600);
      this.sideMenuePanel.TabIndex = 1;
      // 
      // pictureBox2
      // 
      this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox2.Image = global::KeylessGo_GUI.Properties.Resources.logo;
      this.pictureBox2.Location = new System.Drawing.Point(3, 7);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(191, 88);
      this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox2.TabIndex = 6;
      this.pictureBox2.TabStop = false;
      // 
      // buttonSyncDevice
      // 
      this.buttonSyncDevice.BackColor = System.Drawing.Color.Transparent;
      this.buttonSyncDevice.FlatAppearance.BorderSize = 0;
      this.buttonSyncDevice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
      this.buttonSyncDevice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
      this.buttonSyncDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonSyncDevice.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonSyncDevice.ForeColor = System.Drawing.Color.White;
      this.buttonSyncDevice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.buttonSyncDevice.ImageKey = "(none)";
      this.buttonSyncDevice.Location = new System.Drawing.Point(12, 203);
      this.buttonSyncDevice.Name = "buttonSyncDevice";
      this.buttonSyncDevice.Size = new System.Drawing.Size(179, 41);
      this.buttonSyncDevice.TabIndex = 5;
      this.buttonSyncDevice.Text = "  Sync With Device";
      this.buttonSyncDevice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.buttonSyncDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.buttonSyncDevice.UseVisualStyleBackColor = false;
      this.buttonSyncDevice.Click += new System.EventHandler(this.buttonSyncDevice_Click);
      // 
      // buttonSettings
      // 
      this.buttonSettings.BackColor = System.Drawing.Color.Transparent;
      this.buttonSettings.FlatAppearance.BorderSize = 0;
      this.buttonSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
      this.buttonSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
      this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonSettings.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonSettings.ForeColor = System.Drawing.Color.White;
      this.buttonSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.buttonSettings.ImageKey = "(none)";
      this.buttonSettings.Location = new System.Drawing.Point(12, 250);
      this.buttonSettings.Name = "buttonSettings";
      this.buttonSettings.Size = new System.Drawing.Size(179, 41);
      this.buttonSettings.TabIndex = 4;
      this.buttonSettings.Text = "  Device Settings";
      this.buttonSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.buttonSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.buttonSettings.UseVisualStyleBackColor = false;
      this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
      // 
      // buttonImportFile
      // 
      this.buttonImportFile.BackColor = System.Drawing.Color.Transparent;
      this.buttonImportFile.FlatAppearance.BorderSize = 0;
      this.buttonImportFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
      this.buttonImportFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
      this.buttonImportFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonImportFile.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonImportFile.ForeColor = System.Drawing.Color.White;
      this.buttonImportFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.buttonImportFile.ImageKey = "(none)";
      this.buttonImportFile.Location = new System.Drawing.Point(12, 156);
      this.buttonImportFile.Name = "buttonImportFile";
      this.buttonImportFile.Size = new System.Drawing.Size(179, 41);
      this.buttonImportFile.TabIndex = 3;
      this.buttonImportFile.Text = "  Import From File";
      this.buttonImportFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.buttonImportFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.buttonImportFile.UseVisualStyleBackColor = false;
      this.buttonImportFile.Click += new System.EventHandler(this.buttonImportFile_Click);
      // 
      // buttonAddEntry
      // 
      this.buttonAddEntry.BackColor = System.Drawing.Color.Transparent;
      this.buttonAddEntry.FlatAppearance.BorderSize = 0;
      this.buttonAddEntry.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
      this.buttonAddEntry.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
      this.buttonAddEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonAddEntry.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonAddEntry.ForeColor = System.Drawing.Color.White;
      this.buttonAddEntry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.buttonAddEntry.ImageKey = "(none)";
      this.buttonAddEntry.Location = new System.Drawing.Point(12, 109);
      this.buttonAddEntry.Name = "buttonAddEntry";
      this.buttonAddEntry.Size = new System.Drawing.Size(179, 41);
      this.buttonAddEntry.TabIndex = 2;
      this.buttonAddEntry.Text = "  Add New Entry";
      this.buttonAddEntry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.buttonAddEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.buttonAddEntry.UseVisualStyleBackColor = false;
      this.buttonAddEntry.Click += new System.EventHandler(this.buttonAddEntry_Click);
      // 
      // buttonAbout
      // 
      this.buttonAbout.BackColor = System.Drawing.Color.Transparent;
      this.buttonAbout.FlatAppearance.BorderSize = 0;
      this.buttonAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
      this.buttonAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
      this.buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonAbout.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonAbout.ForeColor = System.Drawing.Color.White;
      this.buttonAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.buttonAbout.ImageKey = "(none)";
      this.buttonAbout.Location = new System.Drawing.Point(12, 547);
      this.buttonAbout.Name = "buttonAbout";
      this.buttonAbout.Size = new System.Drawing.Size(179, 41);
      this.buttonAbout.TabIndex = 0;
      this.buttonAbout.Text = "  About Us";
      this.buttonAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.buttonAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.buttonAbout.UseVisualStyleBackColor = false;
      this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1114, 600);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.sideMenuePanel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "KeylessGo Manager Tool";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.panelInformation.ResumeLayout(false);
      this.entryFlowLayoutPanel.ResumeLayout(false);
      this.entryFlowLayoutPanel.PerformLayout();
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.sideMenuePanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panelInformation;
    private GradientPanel sideMenuePanel;
    private System.Windows.Forms.Button buttonAbout;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button buttonAddEntry;
    private System.Windows.Forms.Button buttonImportFile;
    private System.Windows.Forms.Button buttonSettings;
    private System.Windows.Forms.Button buttonSyncDevice;
    private System.Windows.Forms.Button buttonDeviceInfo;
    private System.Windows.Forms.Button buttonSoftwareInfo;
    private System.Windows.Forms.Panel passwordEntryPanel;
    private System.Windows.Forms.FlowLayoutPanel entryFlowLayoutPanel;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button bttnExit;
    private System.Windows.Forms.Button bttnMinimize;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.Label lblPlaceholder;
  }
}

