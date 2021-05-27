using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsbMonitor
{
    internal interface IUsbMonitorOverrides : IUsbMonitor
    {
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
