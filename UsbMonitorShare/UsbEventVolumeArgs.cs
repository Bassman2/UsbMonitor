using System.Linq;

namespace UsbMonitor
{
    /// <summary>
    /// Volume notification arguments
    /// </summary>
    public class UsbEventVolumeArgs : UsbEventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="action"></param>
        /// <param name="unitmask"></param>
        /// <param name="flags"></param>
        /// <param name="drives"></param>
        internal UsbEventVolumeArgs(UsbDeviceChangeEvent action, uint unitmask, ushort flags, char[] drives) : base(action)
        {
            this.UnitMask = unitmask;
            this.Flags = (UsbVolumeFlags)flags;
            this.Drives = drives;
        }

        /// <summary>
        /// The logical unit mask identifying one or more logical units. 
        /// Each bit in the mask corresponds to one logical drive. 
        /// Bit 0 represents drive A, bit 1 represents drive B, and so on.
        /// </summary>
        public uint UnitMask { get; private set; }

        /// <summary>
        /// This parameter can be one of the following values.
        /// Media: Change affects media in drive. If not set, change affects physical device or drive. 
        /// Net: Indicated logical volume is a network volume. 
        /// </summary>
        public UsbVolumeFlags Flags { get; private set; }

        /// <summary>
        /// Array of drive letters, build from UnitMask.
        /// </summary>
        public char[] Drives { get; private set; }

        /// <summary>
        /// Converts arguments to readable string
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            string drives = Drives.Select(d => $"{d}:").Aggregate((a, b) => $"{a}, {b}");
            return $"{Action} Volume: UnitMask=0x{UnitMask:X} Flags={Flags} Drives={drives}";
        }
    }
}
