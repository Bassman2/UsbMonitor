using System;

namespace UsbMonitor
{
    internal class EnumGuidAttribute : Attribute
    {
        public EnumGuidAttribute()
        {
            this.Guid = Guid.Empty;
        }

        public EnumGuidAttribute(uint a, ushort b, ushort c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k)
        {
            this.Guid = new Guid(a, b, c, d, e, f, g, h, i, j, k);
        }

        public EnumGuidAttribute(string guid)
        {
            this.Guid = new Guid(guid);
        }

        public Guid Guid { get; private set; }
    }
}
