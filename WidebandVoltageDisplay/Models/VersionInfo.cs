using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidebandVoltageDisplay.Models
{
    /// <summary>
    /// Class that encapsulates any versioning information about this app
    /// </summary>
    public class VersionInfo
    {
        /// <summary>
        /// The current version of this software. Should correspond with tagged release
        /// Should always be in the format Major.Minor.Patch
        /// See https://semver.org/
        /// </summary>
        public string Version { get; set; } = String.Empty;
    }
}
