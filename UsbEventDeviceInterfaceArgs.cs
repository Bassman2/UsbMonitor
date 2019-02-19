using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsbMonitor
{
    public class UsbEventDeviceInterfaceArgs : UsbEventArgs
    {
        public UsbEventDeviceInterfaceArgs(UsbDeviceChangeEvent action, Guid classGuid, UsbDeviceInterface deviceInterface, string name) : base(action)
        {
            this.ClassGuid = classGuid;
            this.DeviceInterface = deviceInterface;
            this.Name = name;
        }

        public Guid ClassGuid { get; private set; }

        public UsbDeviceInterface DeviceInterface { get; private set; }

        public string Name { get; private set; }


        public override string ToString()
        {
            return $"{Action} DeviceInterface: ClassGuid={ClassGuid} DeviceInterface={DeviceInterface} Name ={Name}";
        }
    }
}
