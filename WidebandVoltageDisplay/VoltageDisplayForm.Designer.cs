namespace WidebandVoltageDisplay
{
    partial class VoltageDisplayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoltageDisplayForm));
            this.LastVoltageLabel = new System.Windows.Forms.Label();
            this.DataMonitorTextBox = new System.Windows.Forms.TextBox();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.VoltageLabel = new System.Windows.Forms.Label();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comPortMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.connectMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.versionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubRepoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.profileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editProfilesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ContentPanel.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // LastVoltageLabel
            // 
            this.LastVoltageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LastVoltageLabel.Location = new System.Drawing.Point(708, 3);
            this.LastVoltageLabel.Margin = new System.Windows.Forms.Padding(0);
            this.LastVoltageLabel.Name = "LastVoltageLabel";
            this.LastVoltageLabel.Size = new System.Drawing.Size(89, 13);
            this.LastVoltageLabel.TabIndex = 3;
            this.LastVoltageLabel.Text = "LastVoltageLabel";
            this.LastVoltageLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LastVoltageLabel.Visible = false;
            // 
            // DataMonitorTextBox
            // 
            this.DataMonitorTextBox.Location = new System.Drawing.Point(585, 19);
            this.DataMonitorTextBox.Multiline = true;
            this.DataMonitorTextBox.Name = "DataMonitorTextBox";
            this.DataMonitorTextBox.Size = new System.Drawing.Size(203, 149);
            this.DataMonitorTextBox.TabIndex = 0;
            this.DataMonitorTextBox.Visible = false;
            // 
            // ContentPanel
            // 
            this.ContentPanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ContentPanel.Controls.Add(this.LastVoltageLabel);
            this.ContentPanel.Controls.Add(this.DataMonitorTextBox);
            this.ContentPanel.Controls.Add(this.VoltageLabel);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 24);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(800, 426);
            this.ContentPanel.TabIndex = 1;
            // 
            // VoltageLabel
            // 
            this.VoltageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VoltageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoltageLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.VoltageLabel.Location = new System.Drawing.Point(0, 0);
            this.VoltageLabel.Name = "VoltageLabel";
            this.VoltageLabel.Size = new System.Drawing.Size(800, 426);
            this.VoltageLabel.TabIndex = 1;
            this.VoltageLabel.Text = "9.00";
            this.VoltageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.connectionToolStripMenuItem,
            this.AboutMenu});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(800, 24);
            this.MenuStrip.TabIndex = 5;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alwaysOnTopMenu,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // alwaysOnTopMenu
            // 
            this.alwaysOnTopMenu.Name = "alwaysOnTopMenu";
            this.alwaysOnTopMenu.Size = new System.Drawing.Size(180, 22);
            this.alwaysOnTopMenu.Text = "Always On Top";
            this.alwaysOnTopMenu.Click += new System.EventHandler(this.OnClickAlwaysOnTop);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnClickExitMenu);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileMenu,
            this.comPortMenu,
            this.connectMenu,
            this.editProfilesMenu});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // comPortMenu
            // 
            this.comPortMenu.Name = "comPortMenu";
            this.comPortMenu.Size = new System.Drawing.Size(180, 22);
            this.comPortMenu.Text = "COM Port";
            // 
            // connectMenu
            // 
            this.connectMenu.Name = "connectMenu";
            this.connectMenu.Size = new System.Drawing.Size(180, 22);
            this.connectMenu.Text = "Connect";
            this.connectMenu.Click += new System.EventHandler(this.OnClickConnectDisconnectMenu);
            // 
            // AboutMenu
            // 
            this.AboutMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionMenuItem,
            this.githubRepoMenu});
            this.AboutMenu.Name = "AboutMenu";
            this.AboutMenu.Size = new System.Drawing.Size(52, 20);
            this.AboutMenu.Text = "About";
            // 
            // versionMenuItem
            // 
            this.versionMenuItem.Name = "versionMenuItem";
            this.versionMenuItem.Size = new System.Drawing.Size(142, 22);
            this.versionMenuItem.Text = "Version ";
            this.versionMenuItem.Click += new System.EventHandler(this.OnClickVersionMenu);
            // 
            // githubRepoMenu
            // 
            this.githubRepoMenu.Name = "githubRepoMenu";
            this.githubRepoMenu.Size = new System.Drawing.Size(142, 22);
            this.githubRepoMenu.Text = "GitHub Repo";
            this.githubRepoMenu.Click += new System.EventHandler(this.OnClickGithubRepoMenu);
            // 
            // profileMenu
            // 
            this.profileMenu.Name = "profileMenu";
            this.profileMenu.Size = new System.Drawing.Size(180, 22);
            this.profileMenu.Text = "Profile";
            // 
            // editProfilesMenu
            // 
            this.editProfilesMenu.Name = "editProfilesMenu";
            this.editProfilesMenu.Size = new System.Drawing.Size(180, 22);
            this.editProfilesMenu.Text = "Edit Profiles";
            this.editProfilesMenu.Click += new System.EventHandler(this.OnClickEditProfilesMenu);
            // 
            // VoltageDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "VoltageDisplayForm";
            this.Text = "Wideband Voltage Displayer";
            this.ContentPanel.ResumeLayout(false);
            this.ContentPanel.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.TextBox DataMonitorTextBox;
        private System.Windows.Forms.Label VoltageLabel;
        private System.Windows.Forms.Label LastVoltageLabel;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AboutMenu;
        private System.Windows.Forms.ToolStripMenuItem versionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubRepoMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopMenu;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comPortMenu;
        private System.Windows.Forms.ToolStripMenuItem connectMenu;
        private System.Windows.Forms.ToolStripMenuItem profileMenu;
        private System.Windows.Forms.ToolStripMenuItem editProfilesMenu;
    }
}

