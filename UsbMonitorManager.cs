using System;

namespace UsbMonitor
{
    /// <summary>
    /// USB Monitor class to notify if the USB content changes
    /// </summary>
    public partial class UsbMonitorManager : DeviceChangeManager, IUsbMonitorEvents
    {
        private IntPtr windowHandle;

        #region IUsbMonitorEvents

        /// <summary>
        /// Event for USB OEM
        /// </summary>
        public event EventHandler<UsbEventOemArgs> UsbOem;

        /// <summary>
        /// Event for USB Volume
        /// </summary>
        public event EventHandler<UsbEventVolumeArgs> UsbVolume;

        /// <summary>
        /// Event for USB Port
        /// </summary>
        public event EventHandler<UsbEventPortArgs> UsbPort;

        /// <summary>
        /// Event for USB Device Interface
        /// </summary>
        public event EventHandler<UsbEventDeviceInterfaceArgs> UsbDeviceInterface;

        /// <summary>
        /// Event for USB Handle
        /// </summary>
        public event EventHandler<UsbEventHandleArgs> UsbHandle;

        /// <summary>
        /// Event for USB Changed
        /// </summary>
        public event EventHandler<UsbEventArgs> UsbChanged;

        /// <summary>
        /// Internal call of UsbOem
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="args">Arguments</param>
        public void CallUsbOem(object sender, UsbEventOemArgs args)
        {
            this.UsbOem?.Invoke(sender, args);
        }

        /// <summary>
        /// Internal call of UsbVolume
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="args">Arguments</param>
        public void CallUsbVolumem(object sender, UsbEventVolumeArgs args)
        {
            this.UsbVolume?.Invoke(sender, args);
        }

        /// <summary>
        /// Internal call of CallUsbPort
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="args">Arguments</param>
        public void CallUsbPort(object sender, UsbEventPortArgs args)
        {
            this.UsbPort?.Invoke(sender, args);
        }

        /// <summary>
        /// Internal call of UsbDeviceInterface
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="args">Arguments</param>
        public void CallUsbDeviceInterface(object sender, UsbEventDeviceInterfaceArgs args)
        {
            this.UsbDeviceInterface?.Invoke(sender, args);
        }

        /// <summary>
        /// Internal call of UsbHandle
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="args">Arguments</param>
        public void CallUsbHandle(object sender, UsbEventHandleArgs args)
        {
            this.UsbHandle?.Invoke(sender, args);
        }

        /// <summary>
        /// Internal call of UsbChanged
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="args">Arguments</param>
        public void CallUsbChanged(object sender, UsbEventArgs args)
        {
            this.UsbChanged?.Invoke(sender, args);
        }

        #endregion

        /// <summary>
        /// Enable USB notification.
        /// </summary>
        public void Start()
        {
            Register(this.windowHandle);
        }

        /// <summary>
        /// Disable USB notification.
        /// </summary>
        public void Stop()
        {
            Unregister();
        }
    }
}
