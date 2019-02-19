using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsbMonitor
{
    public class UsbEventPortArgs : UsbEventArgs
    {
        public UsbEventPortArgs(UsbDeviceChangeEvent action, string name) : base(action)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
                

        public override string ToString()
        {
            return $"{Action} Port: Name={Name}";
        }
    }
}
