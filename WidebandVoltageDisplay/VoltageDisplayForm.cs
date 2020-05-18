using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WidebandVoltageDisplay.Models;

namespace WidebandVoltageDisplay
{
    /// <summary>
    /// This form should show a number to the user that represents a voltage reading from a COM port
    /// A value OUTPUTS 1 - Analog 0-5V Linear
    /// Range is 9-19 AFR 0V = 9 AFR 5V = 19 AFR
    /// https://www.wide-band.com/product-p/wb_d1diy.htm?fbclid=IwAR1HxyFk0bE6KYueTIFYDgQe6jiabUKki9khknbDLKLF-AkUgwS7NVnc5vw
    /// </summary>
    public partial class VoltageDisplayForm : Form
    {
        /// <summary>
        /// Link to the GitHub repository
        /// </summary>
        public static readonly string GithubRepoLink = "https://github.com/luxdvie/wideband-voltage-display";

        /// <summary>
        /// Link to the changelog
        /// </summary>
        public static readonly string ChangelogLink = $"{GithubRepoLink}/blob/master/CHANGELOG.md";

        /// <summary>
        /// Signature for background thread updater
        /// </summary>
        /// <param name="newData"></param>
        public delegate void WriteDataDelegate(string newData);

        /// <summary>
        /// background thread updater; Delegate that updates UI outside of main thread (performance)
        /// </summary>
        public WriteDataDelegate dataWriterDelegate;

        /// <summary>
        /// The current connection to a serial port
        /// </summary>
        private SerialPort serialPort;

        /// <summary>
        /// Private field for this.isConnected
        /// </summary>
        private bool _isConnected = false;

        /// <summary>
        /// Minimum voltage that can be reported from the serial port
        /// </summary>
        private readonly float minVoltage = 0.00f;

        /// <summary>
        /// Maximum voltage that can be reported from the serial port
        /// </summary>
        private readonly float maxVoltage = 5.00f;

        /// <summary>
        /// The profile we have currently selected for display
        /// </summary>
        public static SavedDataModel SavedData { get; set; }

        /// <summary>
        /// Gets the value that is mapped for the given voltage
        /// </summary>
        /// <param name="voltage"></param>
        /// <returns></returns>
        private float MappedValue(float voltage) => voltage.Map(minVoltage, maxVoltage, SavedData?.CurrentProfile?.MinValue ?? 0.00f, SavedData?.CurrentProfile?.MaxValue ?? 0.00f);

        /// <summary>
        /// Whether the serial port is open
        /// </summary>
        private bool IsConnected
        {
            get
            {
                return this._isConnected;
            }
            set
            {
                this._isConnected = value;
                this.connectMenu.Text = value ? "Disconnect" : "Connect";
                this.VoltageLabel.Text = "---"; // reset on change
                this.LastVoltageLabel.Visible = value;

                if (!value)
                {
                    this.LastVoltageLabel.Text = "";
                }
            }
        }

        /// <summary>
        /// Private field for this.SelectedComPort
        /// </summary>

        private string _selectedComPort = String.Empty;

        /// <summary>
        /// The name of the COM Port we have selected
        /// </summary>
        private string SelectedComPort
        {
            get
            {
                return this._selectedComPort;
            }
            set
            {
                this._selectedComPort = value ?? String.Empty;
                SavedData.LastCOMPort = this._selectedComPort;
            }
        }

        /// <summary>            
        /// this.AlwaysOnTopCheckbox.CheckedChanged += new System.EventHandler(this.AlwaysOnTopCheckbox_CheckedChanged);
        /// Information about the current version of this app
        /// </summary>
        public VersionInfo CurrentVersion { get; set; } = new VersionInfo();

        /// <summary>
        /// Override TopMost to control icon on the 'Always on Top' menu icon
        /// </summary>
        public new bool TopMost
        {
            get
            {
                return base.TopMost;
            }
            set
            {
                base.TopMost = value;
                this.alwaysOnTopMenu.Image = base.TopMost ? new Bitmap(Properties.Resources._checked) : null;
                SavedData.TopMost = base.TopMost;
            }
        }

        public VoltageDisplayForm()
        {
            InitializeComponent();

            SavedData = SavedDataModel.Read();
            SavedData.DataChanged += this.SavedData_DataChanged;
            this.FormClosed += this.OnFormClosed;
            this.SetScreenSizeAndPosition();

            this.IsConnected = false;
            this.SetupComPortMenu();
            this.dataWriterDelegate = new WriteDataDelegate(DataWriter);
            this.GetVerionInfo();
            this.SetupProfiles();
        }

        /// <summary>
        /// Sets the size, start position, etc. of this form
        /// </summary>
        private void SetScreenSizeAndPosition()
        {
            var screens = Screen.AllScreens;
            Screen previousScreen = null;
            foreach (var screen in screens)
            {
                if (screen.DeviceName == SavedData.ScreenName)
                {
                    previousScreen = screen;
                    break;
                }
            }

            bool onSecondaryMonitor = screens.Length > 1 && previousScreen != null;
            previousScreen = previousScreen ?? screens[0]; // default to first monitor

            if (onSecondaryMonitor)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = SavedData.FormLocation;
            }

            if (SavedData.IsMaximized)
            {
                this.Size = new Size(800, 450); // force the default size if they 'un-maximize' the window
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.Size = SavedData.FormSize;
                this.Location = SavedData.FormLocation;
            }

            // Make sure the form isn't too big, if the screen size changed
            if (this.Size.Height > previousScreen.Bounds.Height)
            {
                this.Size = new Size(this.Size.Width, previousScreen.Bounds.Height);
            }

            if (this.Size.Width > previousScreen.Bounds.Width)
            {
                this.Size = new Size(previousScreen.Bounds.Width, this.Size.Height);
            }

            this.TopMost = SavedData.TopMost;
        }

        /// <summary>
        /// Handles the close event to save the form's size/position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            SavedData.FormSize = this.Size;
            SavedData.FormLocation = this.Location;
            SavedData.IsMaximized = this.WindowState == FormWindowState.Maximized;

            var screens = Screen.AllScreens;
            if (screens.Length == 1)
            {
                SavedData.ScreenName = String.Empty;
            }
            else
            {
                var currentScreen = Screen.FromControl(this);
                SavedData.ScreenName = currentScreen.DeviceName;
            }
        }

        /// <summary>
        /// Fires when the data is changed in our SavedData model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SavedData_DataChanged(object sender, EventArgs e)
        {
            this.SetupProfiles();
        }

        /// <summary>
        /// Sets up the list of profiles in the profile menu
        /// </summary>
        private void SetupProfiles()
        {
            this.profileMenu.DropDownItemClicked -= ProfileMenu_DropDownItemClicked;
            this.profileMenu.DropDownItems.Clear();
            foreach (var profile in SavedData.Profiles)
            {
                this.profileMenu.DropDownItems.Add(profile.ProfileName);
            }

            this.UpdateAfterProfileChange();
            this.profileMenu.DropDownItemClicked += ProfileMenu_DropDownItemClicked;
        }

        /// <summary>
        /// Handles the change of the selected profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProfileMenu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string selectedProfileName = e.ClickedItem.Text.Trim();

            ProfileModel selectedProfile = null;
            foreach (var profile in SavedData.Profiles)
            {
                if (profile.ProfileName == selectedProfileName)
                {
                    selectedProfile = profile;
                    break;
                }
            }

            SavedData.CurrentProfile = selectedProfile;
            this.UpdateAfterProfileChange();
        }

        /// <summary>
        /// Sets the 'selected icon' in the current profile and updates form text
        /// after changing the current profile
        /// </summary>
        private void UpdateAfterProfileChange()
        {
            this.Text = $"Wideband Voltage Displayer ({SavedData.CurrentProfile.ProfileName})";

            // 'Check' the current profile
            foreach (ToolStripMenuItem m in this.profileMenu.DropDownItems)
            {
                if (m.Text?.Trim() == SavedData.CurrentProfile?.ProfileName)
                {
                    m.Image = new Bitmap(Properties.Resources._checked);
                }
                else
                {
                    m.Image = null;
                }
            }
        }

        /// <summary>
        /// Creates the COM Port options in the context menu
        /// </summary>
        private void SetupComPortMenu()
        {
            var serialPorts = SerialPort.GetPortNames();
            foreach (var port in serialPorts)
            {
                this.comPortMenu.DropDownItems.Add(port);
            }

            this.comPortMenu.DropDownItemClicked += OnClickComPortMenuItem;

            // Choose the last COM Port if it's still available on this PC
            if (!String.IsNullOrEmpty(SavedData?.LastCOMPort) && serialPorts.Contains(SavedData.LastCOMPort))
            {
                SelectedComPort = SavedData.LastCOMPort;
                this.comPortMenu.Image = new Bitmap(Properties.Resources._checked);
                this.comPortMenu.Text = $"COM Port ({SelectedComPort})";

                foreach (ToolStripMenuItem m in this.comPortMenu.DropDownItems)
                {
                    if (m.Text?.Trim() == SelectedComPort)
                    {
                        m.Image = new Bitmap(Properties.Resources._checked);
                    }
                    else
                    {
                        m.Image = null;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the selection of a COM Port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickComPortMenuItem(object sender, ToolStripItemClickedEventArgs e)
        {
            SelectedComPort = e.ClickedItem.Text.Trim();
            this.comPortMenu.Image = new Bitmap(Properties.Resources._checked);
            this.comPortMenu.Text = $"COM Port ({SelectedComPort})";

            foreach (ToolStripMenuItem m in this.comPortMenu.DropDownItems)
            {
                if (m.Text?.Trim() == SelectedComPort)
                {
                    m.Image = new Bitmap(Properties.Resources._checked);
                }
                else
                {
                    m.Image = null;
                }
            }
        }

        /// <summary>
        /// On a background thread, update the value shown in the display for the voltage
        /// </summary>
        /// <param name="newData"></param>
        public void DataWriter(string newData)
        {
            this.DataMonitorTextBox.AppendText(newData); // log to the log file

            var strings = this.DataMonitorTextBox.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (strings.Length == 0)
            {
                return;
            }

            var lastString = strings[strings.Length - 1].Trim();
            bool isValid = !String.IsNullOrEmpty(lastString) && lastString.StartsWith("{") && lastString.EndsWith("{");

            if (strings.Length > 2 && !isValid)
            {
                lastString = strings[strings.Length - 2].Trim();
                isValid = !String.IsNullOrEmpty(lastString) && lastString.StartsWith("{") && lastString.EndsWith("}");
            }

            if (isValid)
            {
                try
                {
                    var data = JsonConvert.DeserializeObject<DataModel>(lastString);
                    if (data != null)
                    {
                        this.LastVoltageLabel.Text = "Voltage: " + data.Voltage.ToString("F2");
                        this.VoltageLabel.Text = this.MappedValue(data.Voltage).ToString("F2");
                    }
                }
                catch
                {
                    // never fail
                }
            }
        }

        /// <summary>
        /// Handles the click of the button that either connects to or disconnects from a serial port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TogglePortConnection()
        {
            if (this.IsConnected)
            {
                this.Disconnect();
                return;
            }

            if (String.IsNullOrEmpty(SelectedComPort))
            {
                MessageBox.Show(this, "You must select a serial port.", "Please Select Serial Port", MessageBoxButtons.OK);
                return;
            }

            try
            {
                this.serialPort = new SerialPort()
                {
                    PortName = SelectedComPort,
                    BaudRate = 9600
                };

                this.serialPort.DataReceived += this.SerialPort_DataReceived;
                this.serialPort.Open();
                this.IsConnected = true;
            }
            catch (Exception ex)
            {
                this.Disconnect();
                MessageBox.Show(this, "Error connecting to the serial port: " + ex.Message, "Error Disconnecting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Disconnect from the current serial port and dispose of our serial port connection
        /// </summary>
        private void Disconnect()
        {
            try
            {
                if (this.serialPort != null)
                {
                    if (this.serialPort.IsOpen)
                    {
                        this.serialPort.DataReceived -= this.SerialPort_DataReceived;
                        this.serialPort.DiscardInBuffer();
                        Thread.Sleep(200);
                        this.serialPort.Close();
                        this.serialPort.Dispose();
                        this.serialPort = null;
                        this.IsConnected = false;
                    }
                }
            }
            catch (Exception e)
            {
                this.serialPort = null;
                this.IsConnected = false;
                MessageBox.Show(this, "Error disconnecting from the serial port: " + e.Message, "Error", MessageBoxButtons.OK);
            }
            finally
            {
                this.DataMonitorTextBox.Clear();
            }
        }

        /// <summary>
        /// Handles when data is received on the serial port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (sender is SerialPort sp)
            {
                string indata = sp.ReadExisting();
                this.DataMonitorTextBox.BeginInvoke(this.dataWriterDelegate, new Object[] { indata });
            }
        }

        /// <summary>
        /// Attempts to read version information from the version.json file and put it into the app
        /// </summary>
        public void GetVerionInfo()
        {
            try
            {
                var vString = File.ReadAllText("version.json");
                if (String.IsNullOrEmpty(vString))
                {
                    return;
                }

                var versionInfo = JsonConvert.DeserializeObject<VersionInfo>(vString);
                this.CurrentVersion = versionInfo ?? new VersionInfo();
                this.versionMenuItem.Text = $"Version: {this.CurrentVersion?.Version ?? "Unknown"}";
            }
            catch (Exception e)
            {
                MessageBox.Show(this, $"There was an error reading the version information. Please make sure version.json exists in the application directory.\r\n Error: {e.Message}", "Version Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Handles the click of the 'GitHub Repo' menu, to open the github repository
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickGithubRepoMenu(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(GithubRepoLink);
        }

        /// <summary>
        /// Handles the click of the 'Version' menu, to open the changelog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickVersionMenu(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(ChangelogLink);
        }

        /// <summary>
        /// Handles the click of the 'Exit' menu, to exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickExitMenu(object sender, EventArgs e)
        {
            this.Disconnect();
            this.Close();
        }

        /// <summary>
        /// Handles the click of 'Always on Top' to enable or disable that feature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickAlwaysOnTop(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        private void OnClickConnectDisconnectMenu(object sender, EventArgs e)
        {
            this.TogglePortConnection();
        }

        /// <summary>
        /// Handles when the user clicks the menu to manage profiles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickEditProfilesMenu(object sender, EventArgs e)
        {
            var sw = new SettingsWindow
            {
                StartPosition = FormStartPosition.CenterParent,
                TopMost = this.TopMost
                
            };

            void OnFormClosed(object fSender, FormClosedEventArgs fe)
            {
                sw.FormClosed -= OnFormClosed;
                this.SetupProfiles();
            };

            sw.ShowDialog();
            sw.FormClosed += OnFormClosed;
        }
    }
}
