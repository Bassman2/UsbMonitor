using System;

namespace UsbMonitor
{
    /// <summary>
    /// A class for containing USB event data
    /// </summary>
    public class UsbEventArgs : EventArgs
    {
        internal UsbEventArgs(UsbDeviceChangeEvent action)
        {
            this.Action = action;
        }

        /// <summary>
        /// Device action
        /// </summary>
        public UsbDeviceChangeEvent Action { get; private set; }

        /// <summary>
        /// Override ToString
        /// </summary>
        /// <returns>Debug string</returns>
        public override string ToString()
        {
            return $"{Action}";
        }
    }
}
