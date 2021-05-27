using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UsbMonitor
{
    internal interface IUsbMonitorCommands : IUsbMonitor
    {
        ICommand UsbOemCommand { get; set; }
        ICommand UsbVolumeCommand { get; set; }
        ICommand UsbPortCommand { get; set; }
        ICommand UsbDeviceInterfaceCommand { get; set; }
        ICommand UsbHandleCommand { get; set; }
        ICommand UsbChangedCommand { get; set; }
    }
}
