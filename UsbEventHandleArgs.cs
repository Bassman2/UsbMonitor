using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsbMonitor
{
    public class UsbEventHandleArgs : UsbEventArgs
    {
        public UsbEventHandleArgs(UsbDeviceChangeEvent action, IntPtr handle, IntPtr devNotify, Guid eventGuid, ulong nameOffset, byte[] data) : base(action)
        {
            this.Handle = handle;
            this.DevNotify = devNotify;
            this.EventGuid = eventGuid;
            this.NameOffset = nameOffset;
            this.Data = data;
        }

        public IntPtr Handle { get; private set; }

        public IntPtr DevNotify { get; private set; }

        public Guid EventGuid { get; private set; }

        public ulong NameOffset { get; private set; }

        public byte[] Data { get; private set; }


        public override string ToString()
        {
            string data = Data.Select(d => $"0x{d:X}").Aggregate((a, b) => $"{a}, {b}");
            return $"{Action} Handle: Handle={Handle} DevNotify={DevNotify} EventGuid={EventGuid} NameOffset={NameOffset} Data={data}";
        }
    }
}
