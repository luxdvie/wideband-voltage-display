using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidebandVoltageDisplay.Models
{
    /// <summary>
    /// This class represents properties of a profile
    /// </summary>
    public class ProfileModel
    {
        /// <summary>
        /// The unique identifier for this profile
        /// </summary>
        public string GUID { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Friendly identifier for this profile
        /// </summary>
        public string ProfileName { get; set; } = String.Empty;

        /// <summary>
        /// The min value for the given range
        /// </summary>
        public float MinValue { get; set; } = 0.00f;

        /// <summary>
        /// The max value for the given range
        /// </summary>
        public float MaxValue { get; set; } = 0.00f;
    }
}
