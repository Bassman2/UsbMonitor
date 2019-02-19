using System;

namespace UsbMonitor
{
    interface IUsbMonitor
    {
        

        event EventHandler<UsbEventOemArgs> UsbOem;

        event EventHandler<UsbEventVolumeArgs> UsbVolume;

        event EventHandler<UsbEventPortArgs> UsbPort;

        event EventHandler<UsbEventDeviceInterfaceArgs> UsbDeviceInterface;

        event EventHandler<UsbEventHandleArgs> UsbHandle;

        event EventHandler<UsbEventArgs> UsbChanged;

        /// <summary>
        /// Override to handle USB interface notification.
        /// </summary>
        /// <param name="args">Update arguments</param>
        void OnUsbOem(UsbEventOemArgs args);
        
        void OnUsbVolume(UsbEventVolumeArgs args);

        void OnUsbPort(UsbEventPortArgs args);

        void OnUsbInterface(UsbEventDeviceInterfaceArgs args);

        void OnUsbHandle(UsbEventHandleArgs args);

        /// <summary>
        /// Override to handle USB changed notification.
        /// </summary>
        void OnUsbChanged(UsbEventArgs args);

    }
}
