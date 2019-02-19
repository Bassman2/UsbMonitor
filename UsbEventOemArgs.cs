using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsbMonitor
{
    
    public class UsbEventOemArgs : UsbEventArgs
    {
        public UsbEventOemArgs(UsbDeviceChangeEvent action, uint identifier, uint suppFunc) : base(action)
        {
            this.Identifier = identifier;
            this.SuppFunc = suppFunc;
        }

        public uint Identifier { get; private set; }

        public uint SuppFunc { get; private set; }

        public override string ToString()
        {
            return $"{Action} OEM: Identifier={Identifier} SuppFunc={SuppFunc}";
        }
    }
}
