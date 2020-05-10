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
        /// Minimum mapped range for the value that represents the voltage
        /// </summary>
        private readonly float mapRangeStart = 9.00f;

        /// <summary>
        /// Maximum mapped range for the value that represents the voltage
        /// </summary>
        private readonly float mapRangeStop = 19.00f;

        /// <summary>
        /// Gets the value that is mapped for the given voltage
        /// </summary>
        /// <param name="voltage"></param>
        /// <returns></returns>
        private float MappedValue(float voltage) => voltage.Map(minVoltage, maxVoltage, mapRangeStart, mapRangeStop);

        /// <summary>
        /// Whether the serial port is open
        /// </summary>
        private bool isConnected
        {
            get
            {
                return this._isConnected;
            }
            set
            {
                this._isConnected = value;
                this.ConnectDisconnectButton.Text = value ? "Disconnect" : "Connect";
                this.VoltageLabel.Text = "---"; // reset on change
                this.DataMonitorTextBox.Visible = value;
                this.LastVoltageLabel.Visible = value;

                if (!value)
                {
                    this.LastVoltageLabel.Text = "";
                }
            }
        }

        /// <summary>            this.AlwaysOnTopCheckbox.CheckedChanged += new System.EventHandler(this.AlwaysOnTopCheckbox_CheckedChanged);
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
                this.alwaysOnTopMenu.Image = value ? new Bitmap(Properties.Resources._checked) : null;
            }
        }

        public VoltageDisplayForm()
        {
            InitializeComponent();
            this.isConnected = false;
            this.SerialPortComboBox.Items.AddRange(SerialPort.GetPortNames());
            this.dataWriterDelegate = new WriteDataDelegate(DataWriter);
            this.GetVerionInfo();
            this.TopMost = true;
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
                        this.LastVoltageLabel.Text = "Last Voltage: " + data.Voltage.ToString("F2");
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
        private void ConnectDisconnectButton_Click(object sender, EventArgs e)
        {
            if (this.isConnected)
            {
                this.Disconnect();
                return;
            }

            if (String.IsNullOrEmpty(this.SerialPortComboBox.Text))
            {
                MessageBox.Show(this, "You must select a serial port.", "Please Select Serial Port", MessageBoxButtons.OK);
                return;
            }

            try
            {
                this.serialPort = new SerialPort()
                {
                    PortName = this.SerialPortComboBox.Text,
                    BaudRate = 9600
                };

                this.serialPort.DataReceived += this.SerialPort_DataReceived;
                this.serialPort.Open();
                this.isConnected = true;
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
                        this.isConnected = false;
                    }
                }
            }
            catch (Exception e)
            {
                this.serialPort = null;
                this.isConnected = false;
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
    }
}
