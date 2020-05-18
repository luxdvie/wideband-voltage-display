using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WidebandVoltageDisplay.Models;

namespace WidebandVoltageDisplay
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
            this.SetupProfileList();
            this.SelectByGUID(VoltageDisplayForm.SavedData.CurrentProfile?.GUID ?? "DEFAULT");
        }

        /// <summary>
        /// Sets up the options in the profile list
        /// </summary>
        private void SetupProfileList()
        {
            this.profileCombobox.SelectedValueChanged -= ProfileCombobox_SelectedValueChanged;
            this.profileCombobox.Items.Clear();
            foreach (var profile in VoltageDisplayForm.SavedData.Profiles)
            {
                this.profileCombobox.Items.Add(profile);
            }

            this.profileCombobox.ValueMember = "GUID";
            this.profileCombobox.DisplayMember = "ProfileName";
            this.profileCombobox.SelectedValueChanged += ProfileCombobox_SelectedValueChanged;
        }

        /// <summary>
        /// Adds a new profile to the list
        /// </summary>
        private void OnClickAddButton(object sender, EventArgs e)
        {
            this.profileCombobox.Items.Add(new ProfileModel()
            {
                GUID = "New",
                ProfileName = "New Profile"
            });

            this.profileCombobox.SelectedIndex = this.profileCombobox.Items.Count - 1;
        }

        private void ProfileCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.profileCombobox.SelectedItem is ProfileModel pm)
            {
                this.profileNameTextbox.Text = pm.ProfileName;
                this.minValueTextbox.Text = pm.MinValue.ToString("F2");
                this.maxValueTextbox.Text = pm.MaxValue.ToString("F2");

                // You cannot delete the default profile
                this.DeleteProfileButton.Visible = pm.GUID != "DEFAULT";
                this.SaveProfileButton.Visible = pm.GUID != "DEFAULT";
                this.profileNameTextbox.Enabled = pm.GUID != "DEFAULT";
                this.minValueTextbox.Enabled = pm.GUID != "DEFAULT";
                this.maxValueTextbox.Enabled = pm.GUID != "DEFAULT";
            }
        }

        /// <summary>
        /// Handles the click of the save button to save the current settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveProfileButton_Click(object sender, EventArgs e)
        {
            if (this.profileCombobox.SelectedItem is ProfileModel pm)
            {
                if (pm.GUID != "Default")
                {
                    pm.ProfileName = this.profileNameTextbox.Text.Trim();

                    // Ensure a unique name
                    foreach (var existingProfile in VoltageDisplayForm.SavedData.Profiles)
                    {
                        if (pm.ProfileName == existingProfile.ProfileName && pm.GUID != existingProfile.GUID)
                        {
                            pm.ProfileName += " (Copy)";
                            this.profileNameTextbox.Text = pm.ProfileName;
                            break;
                        }
                    }


                    if (!this.minValueTextbox.Text.Contains("."))
                    {
                        this.minValueTextbox.Text += ".00";
                    }

                    if (!this.maxValueTextbox.Text.Contains("."))
                    {
                        this.maxValueTextbox.Text += ".00";
                    }

                    float.TryParse(this.minValueTextbox.Text, out float minValue);
                    float.TryParse(this.maxValueTextbox.Text, out float maxValue);

                    this.minValueTextbox.Text = minValue.ToString("F2");
                    this.maxValueTextbox.Text = maxValue.ToString("F2");

                    pm.MinValue = minValue;
                    pm.MaxValue = maxValue;

                    if (pm.GUID == "New")
                    {
                        // we're adding a new item
                        pm.GUID = Guid.NewGuid().ToString();
                        VoltageDisplayForm.SavedData.Profiles.Add(pm);
                    }
                    else
                    {
                        // we're updating an existing item
                        foreach (var profile in VoltageDisplayForm.SavedData.Profiles)
                        {
                            if (profile.GUID == pm.GUID)
                            {
                                pm = profile; // overwrite all properties
                                break;
                            }
                        }
                    }
                }

                SavedDataModel.Write(VoltageDisplayForm.SavedData);
                SetupProfileList();
                this.SelectByGUID(pm.GUID);
            }
        }

        /// <summary>
        /// Chooses a profile in the list by GUID
        /// </summary>
        /// <param name="guid"></param>
        private void SelectByGUID(string guid)
        {
            int index = 0;
            foreach (ProfileModel item in this.profileCombobox.Items)
            {
                if (item.GUID == guid)
                {
                    break;
                }

                index++;
            }

            this.profileCombobox.SelectedIndex = index;
        }

        /// <summary>
        /// Handles the click of the delete button to delete the current profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteProfileButton_Click(object sender, EventArgs e)
        {
            if (this.profileCombobox.SelectedItem is ProfileModel pm)
            {
                if (pm.GUID == "DEFAULT")
                {
                    MessageBox.Show("You cannot delete the default profile.");
                    return;
                }
                else
                {
                    ProfileModel deleteModel = null;
                    foreach (var profile in VoltageDisplayForm.SavedData.Profiles)
                    {
                        if (profile.GUID == pm.GUID)
                        {
                            deleteModel = profile;
                            break;
                        }
                    }

                    if (deleteModel != null)
                    {
                        VoltageDisplayForm.SavedData.Profiles.Remove(deleteModel);
                        SavedDataModel.Write(VoltageDisplayForm.SavedData);
                        SetupProfileList();
                        this.profileCombobox.SelectedIndex = 0;
                    }
                }
            }
        }
    }
}
