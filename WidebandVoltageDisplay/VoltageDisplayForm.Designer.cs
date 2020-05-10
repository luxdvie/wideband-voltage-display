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
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.LastVoltageLabel = new System.Windows.Forms.Label();
            this.ConnectDisconnectButton = new System.Windows.Forms.Button();
            this.DataMonitorTextBox = new System.Windows.Forms.TextBox();
            this.SerialPortComboBoxLabel = new System.Windows.Forms.Label();
            this.SerialPortComboBox = new System.Windows.Forms.ComboBox();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.VoltageLabel = new System.Windows.Forms.Label();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.versionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubRepoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HeaderPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.HeaderPanel.Controls.Add(this.ConnectDisconnectButton);
            this.HeaderPanel.Controls.Add(this.SerialPortComboBoxLabel);
            this.HeaderPanel.Controls.Add(this.SerialPortComboBox);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 24);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(800, 46);
            this.HeaderPanel.TabIndex = 0;
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
            // ConnectDisconnectButton
            // 
            this.ConnectDisconnectButton.Location = new System.Drawing.Point(199, 9);
            this.ConnectDisconnectButton.Name = "ConnectDisconnectButton";
            this.ConnectDisconnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectDisconnectButton.TabIndex = 2;
            this.ConnectDisconnectButton.Text = "Connect";
            this.ConnectDisconnectButton.UseVisualStyleBackColor = true;
            this.ConnectDisconnectButton.Click += new System.EventHandler(this.ConnectDisconnectButton_Click);
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
            // SerialPortComboBoxLabel
            // 
            this.SerialPortComboBoxLabel.AutoSize = true;
            this.SerialPortComboBoxLabel.Location = new System.Drawing.Point(12, 15);
            this.SerialPortComboBoxLabel.Name = "SerialPortComboBoxLabel";
            this.SerialPortComboBoxLabel.Size = new System.Drawing.Size(53, 13);
            this.SerialPortComboBoxLabel.TabIndex = 1;
            this.SerialPortComboBoxLabel.Text = "COM Port";
            // 
            // SerialPortComboBox
            // 
            this.SerialPortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SerialPortComboBox.FormattingEnabled = true;
            this.SerialPortComboBox.Location = new System.Drawing.Point(71, 12);
            this.SerialPortComboBox.Name = "SerialPortComboBox";
            this.SerialPortComboBox.Size = new System.Drawing.Size(121, 21);
            this.SerialPortComboBox.TabIndex = 0;
            // 
            // ContentPanel
            // 
            this.ContentPanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ContentPanel.Controls.Add(this.LastVoltageLabel);
            this.ContentPanel.Controls.Add(this.DataMonitorTextBox);
            this.ContentPanel.Controls.Add(this.VoltageLabel);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 70);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(800, 380);
            this.ContentPanel.TabIndex = 1;
            // 
            // VoltageLabel
            // 
            this.VoltageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VoltageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoltageLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.VoltageLabel.Location = new System.Drawing.Point(0, 0);
            this.VoltageLabel.Name = "VoltageLabel";
            this.VoltageLabel.Size = new System.Drawing.Size(800, 380);
            this.VoltageLabel.TabIndex = 1;
            this.VoltageLabel.Text = "9.00";
            this.VoltageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
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
            this.alwaysOnTopMenu.Size = new System.Drawing.Size(152, 22);
            this.alwaysOnTopMenu.Text = "Always On Top";
            this.alwaysOnTopMenu.Click += new System.EventHandler(this.OnClickAlwaysOnTop);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnClickExitMenu);
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
            // VoltageDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "VoltageDisplayForm";
            this.Text = "Wideband Voltage Displayer";
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.ContentPanel.ResumeLayout(false);
            this.ContentPanel.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.ComboBox SerialPortComboBox;
        private System.Windows.Forms.Label SerialPortComboBoxLabel;
        private System.Windows.Forms.TextBox DataMonitorTextBox;
        private System.Windows.Forms.Button ConnectDisconnectButton;
        private System.Windows.Forms.Label VoltageLabel;
        private System.Windows.Forms.Label LastVoltageLabel;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AboutMenu;
        private System.Windows.Forms.ToolStripMenuItem versionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubRepoMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopMenu;
    }
}

