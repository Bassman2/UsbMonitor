using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace UsbMonitor
{
    public class DeviceChangeManager
    {

        private const int DEVICE_NOTIFY_WINDOW_HANDLE = 0x00000000;
        private const int DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 0x00000004;

        private IntPtr deviceEventHandle;

        public DeviceChangeManager()
        { }

        public void Register(IntPtr windowHandle)
        {
            int size = Marshal.SizeOf(typeof(DevBroadcastDeviceInterface));

            var deviceInterface = new DevBroadcastDeviceInterface();
            deviceInterface.Size = (uint)size;
            deviceInterface.DeviceType = (uint)UsbDeviceType.DeviceInterface; // DBT_DEVTYP_DEVICEINTERFACE;
            deviceInterface.Reserved = 0;
            //deviceInterface.ClassGuid = new Guid().ToByteArray();

            IntPtr buffer = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(deviceInterface, buffer, true);

            this.deviceEventHandle = NativeMethods.RegisterDeviceNotification(windowHandle, buffer, DEVICE_NOTIFY_WINDOW_HANDLE | DEVICE_NOTIFY_ALL_INTERFACE_CLASSES);
            if (this.deviceEventHandle == IntPtr.Zero)
            {
                int error = Marshal.GetLastWin32Error();
            }
            Marshal.FreeHGlobal(buffer);
        }

        public void Unregister()
        {
            if (this.deviceEventHandle != IntPtr.Zero)
            {
                NativeMethods.UnregisterDeviceNotification(deviceEventHandle);
            }
            this.deviceEventHandle = IntPtr.Zero;
        }

        public UsbEventOemArgs OnDeviceOem(UsbDeviceChangeEvent action, IntPtr lparam)
        {
            var oem = (DevBroadcastOEM)Marshal.PtrToStructure(lparam, typeof(DevBroadcastOEM));
            Debug.WriteLine($"OEM: Size={oem.Size}, DeviceType={oem.DeviceType}, Reserved={oem.Reserved}, Identifier={oem.Identifier}, SuppFunc={oem.SuppFunc}");
            return new UsbEventOemArgs(action, oem.Identifier, oem.SuppFunc);
        }

        public UsbEventVolumeArgs OnDeviceVolume(UsbDeviceChangeEvent action, IntPtr lparam)
        {
            var volume = (DevBroadcastVolume)Marshal.PtrToStructure(lparam, typeof(DevBroadcastVolume));
            char[] drives = DrivesFromMask(volume.UnitMask);
            string drivesStr = drives.Select(d => $"{d}:").Aggregate((a, b) => $"{a}, {b}");
            Debug.WriteLine($"Volume: size={volume.Size}, deviceType={volume.DeviceType}, reserved={volume.Reserved}, unitmask={volume.UnitMask}, flags={volume.Flags}, drives={drivesStr}");
            return new UsbEventVolumeArgs(action, volume.UnitMask, volume.Flags, drives);
        }

        public UsbEventPortArgs OnDevicePort(UsbDeviceChangeEvent action, IntPtr lparam)
        {
            var port = (DevBroadcastPort)Marshal.PtrToStructure(lparam, typeof(DevBroadcastPort));
            Debug.WriteLine($"Port: Size={port.Size}, DeviceType={port.DeviceType}, Reserved={port.Reserved}, Name={port.Name}");
            return new UsbEventPortArgs(action, port.Name);
        }

        public UsbEventDeviceInterfaceArgs OnDeviceInterface(UsbDeviceChangeEvent action, IntPtr lparam)
        {
            var device = (DevBroadcastDeviceInterface)Marshal.PtrToStructure(lparam, typeof(DevBroadcastDeviceInterface));
            Debug.WriteLine($"DeviceInterface: Size={device.Size}, DeviceType={device.DeviceType}, Reserved={device.Reserved}, ClassGuid={device.ClassGuid}, Name={device.Name}");
            return new UsbEventDeviceInterfaceArgs(action, device.ClassGuid, GuidToEnum<UsbDeviceInterface>(device.ClassGuid), device.Name);
        }

        public UsbEventHandleArgs OnDeviceHandle(UsbDeviceChangeEvent action, IntPtr lparam)
        {
            var handle = (DevBroadcastHandle)Marshal.PtrToStructure(lparam, typeof(DevBroadcastHandle));
            Debug.WriteLine($"DeviceInterface: Size={handle.Size}, DeviceType={handle.DeviceType}, Reserved={handle.Reserved}, Handle={handle.Handle}, DevNotify={handle.DevNotify}, EventGuid={handle.EventGuid}, NameOffset={handle.NameOffset}, Data={handle.Data}");
            return new UsbEventHandleArgs(action, handle.Handle, handle.DevNotify, handle.EventGuid, handle.NameOffset, handle.Data);
        }

        private T GuidToEnum<T>(Guid guid)
        {
            T en = Enum.GetValues(typeof(T)).Cast<T>().Where(e =>
            {
                return e.GetType().GetField(e.ToString()).GetCustomAttribute<GuidAttribute>().Guid == guid;
            }).FirstOrDefault();
            return en;
        }

        private char[] DrivesFromMask(uint unitmask)
        {
            List<char> drives = new List<char>();
            for (byte i = 0; i < 26; ++i, unitmask >>= 1)
            {
                if ((unitmask & 0x1) != 0)
                {
                    drives.Add((char)(((byte)'A') + i));
                }
            }
            return drives.ToArray();
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DevBroadcastOEM
        {
            public uint Size;
            public uint DeviceType;
            public uint Reserved;
            public uint Identifier;
            public uint SuppFunc;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct DevBroadcastPort
        {
            public uint Size;
            public uint DeviceType;
            public uint Reserved; 
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
            public String Name;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct DevBroadcastDeviceInterface
        {
            public uint Size;
            public uint DeviceType;
            public uint Reserved;
            public Guid ClassGuid;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
            public String Name;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DevBroadcastVolume
        {
            public uint Size;
            public uint DeviceType;
            public uint Reserved;
            public uint UnitMask;
            public ushort Flags;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct DevBroadcastHandle
        {
            public uint Size;
            public uint DeviceType;
            public uint Reserved;
            public IntPtr Handle;
            public IntPtr DevNotify;
            public Guid EventGuid;
            public ulong NameOffset;
            public byte[] Data;
        }
        
        private static class NativeMethods
        {
            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr RegisterDeviceNotification(IntPtr hRecipient, IntPtr NotificationFilter, Int32 Flags);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool UnregisterDeviceNotification(IntPtr hHandle);
        }
    }
}
