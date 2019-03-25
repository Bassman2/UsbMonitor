using System;

namespace UsbMonitor
{
    /// <summary>
    /// Interface notification arguments
    /// </summary>
    public class UsbEventDeviceInterfaceArgs : UsbEventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="action"></param>
        /// <param name="classGuid"></param>
        /// <param name="deviceInterface"></param>
        /// <param name="name"></param>
        internal UsbEventDeviceInterfaceArgs(UsbDeviceChangeEvent action, Guid classGuid, UsbDeviceInterface deviceInterface, string name) : base(action)
        {
            this.ClassGuid = classGuid;
            this.DeviceInterface = deviceInterface;
            this.Name = name;
        }

        /// <summary>
        /// GUID of the interface class
        /// </summary>
        public Guid ClassGuid { get; private set; }

        /// <summary>
        /// Interface type
        /// </summary>
        public UsbDeviceInterface DeviceInterface { get; private set; }

        /// <summary>
        /// Name od the interface
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Converts arguments to readable string
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return $"{Action} DeviceInterface: ClassGuid={ClassGuid} DeviceInterface={DeviceInterface} Name ={Name}";
        }
    }
}
