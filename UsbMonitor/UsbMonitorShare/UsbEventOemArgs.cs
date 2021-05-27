namespace UsbMonitor
{

    /// <summary>
    /// OEM notification arguments
    /// </summary>
    public class UsbEventOemArgs : UsbEventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="action"></param>
        /// <param name="identifier"></param>
        /// <param name="suppFunc"></param>
        internal UsbEventOemArgs(UsbDeviceChangeEvent action, uint identifier, uint suppFunc) : base(action)
        {
            this.Identifier = identifier;
            this.SuppFunc = suppFunc;
        }

        /// <summary>
        /// The OEM-specific identifier for the device.
        /// </summary>
        public uint Identifier { get; private set; }

        /// <summary>
        /// The OEM-specific function value. Possible values depend on the device.
        /// </summary>
        public uint SuppFunc { get; private set; }

        /// <summary>
        /// Converts arguments to readable string
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return $"{Action} OEM: Identifier={Identifier} SuppFunc={SuppFunc}";
        }
    }
}
