namespace UsbMonitor
{
    /// <summary>
    /// Device type
    /// </summary>
    public enum UsbDeviceType : uint
    {
        /// <summary>
        /// OEM- or IHV-defined device type. This structure is a DEV_BROADCAST_OEM structure.
        /// </summary>
        OEM = 0x00000000,

        /// <summary>
        /// Logical volume. This structure is a DEV_BROADCAST_VOLUME structure.
        /// </summary>
        Volume = 0x00000002,

        /// <summary>
        /// Port device (serial or parallel). This structure is a DEV_BROADCAST_PORT structure.
        /// </summary>
        Port = 0x00000003,

        /// <summary>
        /// Class of devices. This structure is a DEV_BROADCAST_DEVICEINTERFACE structure.
        /// </summary>
        DeviceInterface = 0x00000005,

        /// <summary>
        /// File system handle. This structure is a DEV_BROADCAST_HANDLE structure.
        /// </summary>
        Handle = 0x00000006,
    }
}
