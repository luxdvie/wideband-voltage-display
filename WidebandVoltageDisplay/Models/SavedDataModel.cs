using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidebandVoltageDisplay.Models
{
    /// <summary>
    /// This class represents all the data that can be saved for this application
    /// </summary>
    public class SavedDataModel
    {
        /// <summary>
        /// The event that is fired when we write data
        /// </summary>
        public event EventHandler DataChanged;

        /// <summary>
        /// The name of the JSON file that holds our settings
        /// </summary>
        public static readonly string SavedDataFileName = "saved-data.json";

        /// <summary>
        /// The full path to the SavedData file
        /// </summary>
        public static string SavedDataFilePath
        {
            get
            {
                var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WidebandVoltageDisplay");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                return Path.Combine(directory, SavedDataFileName);
            }
        }

        /// <summary>
        /// The default profile to use when no other profile has been defined
        /// </summary>
        private static ProfileModel DefaultProfile
        {
            get
            {
                return new ProfileModel()
                {
                    ProfileName = "Default (ASPX 9-19)",
                    GUID = "DEFAULT",
                    MinValue = 9.00f,
                    MaxValue = 19.00f
                };
            }
        }

        /// <summary>
        /// Private field for this.TopMost
        /// </summary>
        private bool _topMost = true;

        /// <summary>
        /// Whether this form was set as TopMost
        /// Defaults to true
        /// </summary>
        public bool TopMost
        {
            get
            {
                return this._topMost;
            }
            set
            {
                this._topMost = value;
                Write(this);
            }
        }

        /// <summary>
        /// Private field for this.IsMaximized
        /// </summary>
        private bool _isMaximized = false;

        /// <summary>
        /// Whether this form is maximized
        /// </summary>
        public bool IsMaximized
        {
            get
            {
                return this._isMaximized;
            }
            set
            {
                this._isMaximized = value;
                Write(this);
            }
        }

        /// <summary>
        /// Private field for this.FormLocation
        /// </summary>
        private Point _formLocation = new Point(10,10);

        /// <summary>
        /// The last position of this form. 
        /// </summary>
        public Point FormLocation
        {
            get
            {
                return this._formLocation;
            }
            set
            {
                this._formLocation = value;
                Write(this);
            }
        }

        /// <summary>
        /// Private field for this.FormSize
        /// </summary>
        private Size _formSize = new Size(800, 450);

        /// <summary>
        /// The last size of this form. 
        /// </summary>
        public Size FormSize
        {
            get
            {
                return this._formSize;
            }
            set
            {
                this._formSize = value;
                Write(this);
            }
        }

        /// <summary>
        /// Private field for this.ScreenName
        /// </summary>
        private string _screenName = String.Empty;

        /// <summary>
        /// The name of the screen (monitor) this form was on
        /// </summary>
        public string ScreenName
        {
            get
            {
                return this._screenName;
            }
            set
            {
                this._screenName = value;
                Write(this);
            }
        }

        /// <summary>
        /// Private field for this.CurrentProfile
        /// </summary>
        private ProfileModel _currentProfile = DefaultProfile;

        /// <summary>
        /// The currently selected profile
        /// </summary>
        public ProfileModel CurrentProfile
        {
            get
            {
                if (!String.IsNullOrEmpty(DefaultProfileGUID))
                {
                    foreach (var profile in this.Profiles)
                    {
                        if (profile.GUID == this.DefaultProfileGUID)
                        {
                            return profile;
                        }
                    }

                    return DefaultProfile;
                }
                else
                {
                    return this._currentProfile;
                }
            }
            set
            {
                this._currentProfile = value ?? DefaultProfile;
                this.DefaultProfileGUID = this._currentProfile.GUID;
                Write(this);
            }
        }


        /// <summary>
        /// Private field for this.DefaultProfileGUID
        /// </summary>
        private string _defaultProfileGUID = "DEFAULT";

        /// <summary>
        /// The identifier for the default profile we have selected
        /// </summary>
        public string DefaultProfileGUID
        {
            get
            {
                return this._defaultProfileGUID;
            }
            set
            {
                this._defaultProfileGUID = value ?? "DEFAULT";
                Write(this);
            }
        }

        /// <summary>
        /// The list of profiles that we have saved
        /// </summary>
        public List<ProfileModel> Profiles { get; set; } = new List<ProfileModel>();

        /// <summary>
        /// Private field for this.lastCOMPort
        /// </summary>
        private string _lastCOMPort = String.Empty;

        /// <summary>
        /// The last COM Port that we connected to
        /// </summary>
        public string LastCOMPort
        {
            get
            {
                return this._lastCOMPort;
            }
            set
            {
                this._lastCOMPort = value ?? String.Empty;
                Write(this);
            }
        }

        /// <summary>
        /// Raises the DataChanged event
        /// </summary>
        public void RaiseDataChanged()
        {
            this.DataChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Reads the current saved-data model from disk or returns a new instance of SavedDataModel
        /// </summary>
        /// <returns></returns>
        public static SavedDataModel Read()
        {
            if (!File.Exists(SavedDataFilePath))
            {
                return new SavedDataModel()
                {
                    Profiles = new List<ProfileModel>()
                    {
                        DefaultProfile
                    }
                };
            }

            var jsonContents = File.ReadAllText(SavedDataFilePath);
            try
            {
                if (String.IsNullOrEmpty(jsonContents))
                {
                    return new SavedDataModel()
                    {
                        Profiles = new List<ProfileModel>()
                    {
                        DefaultProfile
                    }
                    };
                }

                var dm = JsonConvert.DeserializeObject<SavedDataModel>(jsonContents);
                return dm ?? new SavedDataModel()
                {
                    Profiles = new List<ProfileModel>()
                    {
                        DefaultProfile
                    }
                };
            }
            catch
            {
                return new SavedDataModel()
                {
                    Profiles = new List<ProfileModel>()
                    {
                        DefaultProfile
                    }
                };
            }
        }

        /// <summary>
        /// Writes the current settings to disk
        /// </summary>
        /// <param name="model"></param>
        public static void Write(SavedDataModel model)
        {
            try
            {
                var jsonContents = JsonConvert.SerializeObject(model, Formatting.Indented);
                File.WriteAllText(SavedDataFilePath, jsonContents);
                model.RaiseDataChanged();
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred when saving data. \r\nError: " + e.Message);
            }
        }
    }
}
