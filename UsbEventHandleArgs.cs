using System;
using System.Linq;

namespace UsbMonitor
{
    /// <summary>
    /// Handle notification arguments
    /// </summary>
    public class UsbEventHandleArgs : UsbEventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="action"></param>
        /// <param name="handle"></param>
        /// <param name="devNotify"></param>
        /// <param name="eventGuid"></param>
        /// <param name="nameOffset"></param>
        /// <param name="data"></param>
        internal UsbEventHandleArgs(UsbDeviceChangeEvent action, IntPtr handle, IntPtr devNotify, Guid eventGuid, ulong nameOffset, byte[] data) : base(action)
        {
            this.Handle = handle;
            this.DevNotify = devNotify;
            this.EventGuid = eventGuid;
            this.NameOffset = nameOffset;
            this.Data = data;
        }

        /// <summary>
        /// A handle to the device to be checked.
        /// </summary>
        public IntPtr Handle { get; private set; }

        /// <summary>
        /// A handle to the device notification.
        /// </summary>
        public IntPtr DevNotify { get; private set; }

        /// <summary>
        /// The GUID for the custom event.
        /// </summary>
        public Guid EventGuid { get; private set; }

        /// <summary>
        /// The offset of an optional string buffer. 
        /// </summary>
        public ulong NameOffset { get; private set; }

        /// <summary>
        /// Optional binary data.
        /// </summary>
        public byte[] Data { get; private set; }

        /// <summary>
        /// Converts arguments to readable string
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            string data = Data.Select(d => $"0x{d:X}").Aggregate((a, b) => $"{a}, {b}");
            return $"{Action} Handle: Handle={Handle} DevNotify={DevNotify} EventGuid={EventGuid} NameOffset={NameOffset} Data={data}";
        }
    }
}
