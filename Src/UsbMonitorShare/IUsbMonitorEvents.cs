using System;

namespace UsbMonitor
{
    interface IUsbMonitorEvents : IUsbMonitor
    {
        event EventHandler<UsbEventOemArgs> UsbOem;

        event EventHandler<UsbEventVolumeArgs> UsbVolume;

        event EventHandler<UsbEventPortArgs> UsbPort;

        event EventHandler<UsbEventDeviceInterfaceArgs> UsbDeviceInterface;

        event EventHandler<UsbEventHandleArgs> UsbHandle;

        event EventHandler<UsbEventArgs> UsbChanged;

        void CallUsbOem(object sender, UsbEventOemArgs args);
        void CallUsbVolumem(object sender, UsbEventVolumeArgs args);
        void CallUsbPort(object sender, UsbEventPortArgs args);
        void CallUsbDeviceInterface(object sender, UsbEventDeviceInterfaceArgs args);
        void CallUsbHandle(object sender, UsbEventHandleArgs args);
        void CallUsbChanged(object sender, UsbEventArgs args);
    }
}
