namespace UsbMonitor
{
    /// <summary>
    /// Volume flags
    /// </summary>
    public enum UsbVolumeFlags : ushort
    {
        /// <summary>
        /// Change affects media in drive. If not set, change affects physical device or drive. 
        /// </summary>
        Media = 0x0001,

        /// <summary>
        /// Indicated logical volume is a network volume. 
        /// </summary>
        Net = 0x0002
    }
}
