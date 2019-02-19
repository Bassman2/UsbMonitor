using System;
using System.Runtime.InteropServices;

namespace UsbMonitor
{
    /// <summary>
    /// USB Monitor class to notify if the USB content changes
    /// </summary>
    public partial class UsbMonitorManager : DeviceChangeManager
    {
        private const int WM_DEVICECHANGE = 0x0219;
       
        private IntPtr windowHandle;
        
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

        private IntPtr HwndHandler(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
        {
            if (msg == WM_DEVICECHANGE)
            {
                UsbDeviceChangeEvent deviceChangeEvent = (UsbDeviceChangeEvent)wparam.ToInt32();
                switch (deviceChangeEvent)
                {
                case UsbDeviceChangeEvent.Arrival:
                case UsbDeviceChangeEvent.QueryRemove:
                case UsbDeviceChangeEvent.QueryRemoveFailed:
                case UsbDeviceChangeEvent.RemovePending:
                case UsbDeviceChangeEvent.RemoveComplete:
                    UsbDeviceType deviceType = (UsbDeviceType)Marshal.ReadInt32(lparam, 4);
                    switch (deviceType)
                    {
                    case UsbDeviceType.OEM:
                        var oemArgs = OnDeviceOem(deviceChangeEvent, lparam);
                        // fire event
                        this.UsbOem?.Invoke(this, oemArgs);
                        break;
                    case UsbDeviceType.Volume:
                        var volumeArgs = OnDeviceVolume(deviceChangeEvent, lparam);
                        // fire event
                        this.UsbVolume?.Invoke(this, volumeArgs);
                        break;
                    case UsbDeviceType.Port:
                        var portArgs = OnDevicePort(deviceChangeEvent, lparam);
                        // fire event
                        this.UsbPort?.Invoke(this, portArgs);
                        break;
                    case UsbDeviceType.DeviceInterface:
                        var interfaceArgs = OnDeviceInterface(deviceChangeEvent, lparam);
                        // fire event
                        this.UsbDeviceInterface?.Invoke(this, interfaceArgs);
                        break;
                    case UsbDeviceType.Handle:
                        var handleArgs = OnDeviceHandle(deviceChangeEvent, lparam);
                        // fire event
                        this.UsbHandle?.Invoke(this, handleArgs);
                        break;
                    default:
                        break;
                    }
                    break;
                case UsbDeviceChangeEvent.Changed:
                    // fire event
                    this.UsbChanged?.Invoke(this, new UsbEventArgs(deviceChangeEvent));
                    break;
                }
            }
            handled = false;
            return IntPtr.Zero;
        }
    }
}
