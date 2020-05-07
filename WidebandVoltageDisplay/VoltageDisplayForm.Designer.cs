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
            this.AlwaysOnTopCheckbox = new System.Windows.Forms.CheckBox();
            this.HeaderPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.HeaderPanel.Controls.Add(this.AlwaysOnTopCheckbox);
            this.HeaderPanel.Controls.Add(this.LastVoltageLabel);
            this.HeaderPanel.Controls.Add(this.ConnectDisconnectButton);
            this.HeaderPanel.Controls.Add(this.DataMonitorTextBox);
            this.HeaderPanel.Controls.Add(this.SerialPortComboBoxLabel);
            this.HeaderPanel.Controls.Add(this.SerialPortComboBox);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(800, 46);
            this.HeaderPanel.TabIndex = 0;
            // 
            // LastVoltageLabel
            // 
            this.LastVoltageLabel.AutoSize = true;
            this.LastVoltageLabel.Location = new System.Drawing.Point(484, 14);
            this.LastVoltageLabel.Name = "LastVoltageLabel";
            this.LastVoltageLabel.Size = new System.Drawing.Size(89, 13);
            this.LastVoltageLabel.TabIndex = 3;
            this.LastVoltageLabel.Text = "LastVoltageLabel";
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
            this.DataMonitorTextBox.Location = new System.Drawing.Point(585, 3);
            this.DataMonitorTextBox.Multiline = true;
            this.DataMonitorTextBox.Name = "DataMonitorTextBox";
            this.DataMonitorTextBox.Size = new System.Drawing.Size(203, 37);
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
            this.ContentPanel.Controls.Add(this.VoltageLabel);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 46);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(800, 404);
            this.ContentPanel.TabIndex = 1;
            // 
            // VoltageLabel
            // 
            this.VoltageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VoltageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoltageLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.VoltageLabel.Location = new System.Drawing.Point(0, 0);
            this.VoltageLabel.Name = "VoltageLabel";
            this.VoltageLabel.Size = new System.Drawing.Size(800, 404);
            this.VoltageLabel.TabIndex = 1;
            this.VoltageLabel.Text = "9.00";
            this.VoltageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlwaysOnTopCheckbox
            // 
            this.AlwaysOnTopCheckbox.AutoSize = true;
            this.AlwaysOnTopCheckbox.Location = new System.Drawing.Point(281, 13);
            this.AlwaysOnTopCheckbox.Name = "AlwaysOnTopCheckbox";
            this.AlwaysOnTopCheckbox.Size = new System.Drawing.Size(96, 17);
            this.AlwaysOnTopCheckbox.TabIndex = 4;
            this.AlwaysOnTopCheckbox.Text = "Always on Top";
            this.AlwaysOnTopCheckbox.UseVisualStyleBackColor = true;
            this.AlwaysOnTopCheckbox.CheckedChanged += new System.EventHandler(this.AlwaysOnTopCheckbox_CheckedChanged);
            // 
            // VoltageDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.HeaderPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VoltageDisplayForm";
            this.Text = "Wideband Voltage Displayer";
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.ContentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.CheckBox AlwaysOnTopCheckbox;
    }
}

