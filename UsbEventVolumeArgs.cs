using System.Linq;

namespace UsbMonitor
{
    public class UsbEventVolumeArgs : UsbEventArgs
    {
        public UsbEventVolumeArgs(UsbDeviceChangeEvent action, uint unitmask, ushort flags, char[] drives) : base(action)
        {
            this.UnitMask = unitmask;
            this.Flags = flags;
            this.Drives = drives;
        }

        public uint UnitMask { get; private set; }

        public ushort Flags { get; private set; }

        public char[] Drives { get; private set; }

        public override string ToString()
        {
            string drives = Drives.Select(d => $"{d}:").Aggregate((a, b) => $"{a}, {b}");
            return $"{Action} Volume: UnitMask=0x{UnitMask:X} Flags={Flags} Drives={drives}";
        }
    }
}
