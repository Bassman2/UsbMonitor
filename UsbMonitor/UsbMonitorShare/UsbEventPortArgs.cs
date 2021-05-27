namespace UsbMonitor
{
    /// <summary>
    /// Port notification arguments
    /// </summary>
    public class UsbEventPortArgs : UsbEventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="action"></param>
        /// <param name="name"></param>
        internal UsbEventPortArgs(UsbDeviceChangeEvent action, string name) : base(action)
        {
            this.Name = name;
        }

        /// <summary>
        /// Specifying the friendly name of the port or the device connected to the port. 
        /// Friendly names are intended to help the user quickly and accurately identify the device
        /// for example, "COM1" and "Standard 28800 bps Modem" are considered friendly names.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Converts arguments to readable string
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return $"{Action} Port: Name={Name}";
        }
    }
}
