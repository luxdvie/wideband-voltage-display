namespace WidebandVoltageDisplay
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.minValueTextbox = new System.Windows.Forms.MaskedTextBox();
            this.maxValueTextbox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.profileNameTextbox = new System.Windows.Forms.MaskedTextBox();
            this.SaveProfileButton = new System.Windows.Forms.Button();
            this.DeleteProfileButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.profileCombobox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.addProfileButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // minValueTextbox
            // 
            this.minValueTextbox.Location = new System.Drawing.Point(101, 55);
            this.minValueTextbox.Name = "minValueTextbox";
            this.minValueTextbox.Size = new System.Drawing.Size(100, 20);
            this.minValueTextbox.TabIndex = 1;
            // 
            // maxValueTextbox
            // 
            this.maxValueTextbox.Location = new System.Drawing.Point(101, 86);
            this.maxValueTextbox.Name = "maxValueTextbox";
            this.maxValueTextbox.Size = new System.Drawing.Size(100, 20);
            this.maxValueTextbox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Minimum Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Maximum Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Profile Name";
            // 
            // profileNameTextbox
            // 
            this.profileNameTextbox.Location = new System.Drawing.Point(101, 24);
            this.profileNameTextbox.Name = "profileNameTextbox";
            this.profileNameTextbox.Size = new System.Drawing.Size(168, 20);
            this.profileNameTextbox.TabIndex = 5;
            // 
            // SaveProfileButton
            // 
            this.SaveProfileButton.Location = new System.Drawing.Point(299, 205);
            this.SaveProfileButton.Name = "SaveProfileButton";
            this.SaveProfileButton.Size = new System.Drawing.Size(75, 23);
            this.SaveProfileButton.TabIndex = 7;
            this.SaveProfileButton.Text = "Save Profile";
            this.SaveProfileButton.UseVisualStyleBackColor = true;
            this.SaveProfileButton.Click += new System.EventHandler(this.SaveProfileButton_Click);
            // 
            // DeleteProfileButton
            // 
            this.DeleteProfileButton.Location = new System.Drawing.Point(299, 177);
            this.DeleteProfileButton.Name = "DeleteProfileButton";
            this.DeleteProfileButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteProfileButton.TabIndex = 8;
            this.DeleteProfileButton.Text = "Delete Profile";
            this.DeleteProfileButton.UseVisualStyleBackColor = true;
            this.DeleteProfileButton.Click += new System.EventHandler(this.DeleteProfileButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.minValueTextbox);
            this.groupBox1.Controls.Add(this.maxValueTextbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.profileNameTextbox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 132);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // profileCombobox
            // 
            this.profileCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileCombobox.FormattingEnabled = true;
            this.profileCombobox.Location = new System.Drawing.Point(109, 15);
            this.profileCombobox.Name = "profileCombobox";
            this.profileCombobox.Size = new System.Drawing.Size(184, 21);
            this.profileCombobox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Selected Profile";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(285, 51);
            this.label5.TabIndex = 11;
            this.label5.Text = "Use this screen to add, edit, and delete profiles. Profiles define the minimum an" +
    "d maximum values that are mapped from the input voltage.";
            // 
            // addProfileButton
            // 
            this.addProfileButton.Location = new System.Drawing.Point(299, 12);
            this.addProfileButton.Name = "addProfileButton";
            this.addProfileButton.Size = new System.Drawing.Size(75, 23);
            this.addProfileButton.TabIndex = 12;
            this.addProfileButton.Text = "Add Profile";
            this.addProfileButton.UseVisualStyleBackColor = true;
            this.addProfileButton.Click += new System.EventHandler(this.OnClickAddButton);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 237);
            this.Controls.Add(this.addProfileButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.profileCombobox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DeleteProfileButton);
            this.Controls.Add(this.SaveProfileButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsWindow";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox minValueTextbox;
        private System.Windows.Forms.MaskedTextBox maxValueTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox profileNameTextbox;
        private System.Windows.Forms.Button SaveProfileButton;
        private System.Windows.Forms.Button DeleteProfileButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox profileCombobox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button addProfileButton;
    }
}