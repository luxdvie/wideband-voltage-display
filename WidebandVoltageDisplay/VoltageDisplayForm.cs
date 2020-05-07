using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public VoltageDisplayForm()
        {
            InitializeComponent();
        }
    }
}
