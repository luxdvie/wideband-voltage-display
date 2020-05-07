using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidebandVoltageDisplay.Models
{
    /// <summary>
    /// The model that represents data the arduino sends us
    /// </summary>
    public class DataModel
    {
        /// <summary>
        /// The voltage reading, expected to be between 0.00 and 5.00
        /// </summary>
        public float Voltage { get; set; } = 0.00F;
    }
}
