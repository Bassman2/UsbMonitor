using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace UsbMonitor
{
    /// <summary>
    /// Device change manager
    /// </summary>
    public class DeviceChangeManager
    {
        private const int DEVICE_NOTIFY_WINDOW_HANDLE = 0x00000000;
        private const int DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 0x00000004;

        private const int WM_DEVICECHANGE = 0x0219;

        private readonly Guid InterfaceClassGuid = new Guid(0x4d1e55b2, 0xf16f, 0x11cf, 0x88, 0xcb, 0x00, 0x11, 0x11, 0x00, 0x00, 0x30);



        private IntPtr deviceEventHandle;

        /// <summary>
        /// Constructor
        /// </summary>
        public DeviceChangeManager()
        { }

        /// <summary>
        /// Register windows for notification
        /// </summary>
        /// <param name="windowHandle">Windows handle of the main window</param>
        public void Register(IntPtr windowHandle)
        {
#if WINDOWS_UWP
            int size = Marshal.SizeOf<DevBroadcastDeviceInterface>();
#else
            int size = Marshal.SizeOf(typeof(DevBroadcastDeviceInterface));
#endif
            var deviceInterface = new DevBroadcastDeviceInterface();
            deviceInterface.Size = (uint)size;
            deviceInterface.DeviceType = (uint)UsbDeviceType.DeviceInterface; // DBT_DEVTYP_DEVICEINTERFACE;
            deviceInterface.Reserved = 0;
            deviceInterface.ClassGuid = InterfaceClassGuid;

            IntPtr buffer = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(deviceInterface, buffer, true);

            try
            {
                this.deviceEventHandle = NativeMethods.RegisterDeviceNotification(windowHandle, buffer, DEVICE_NOTIFY_WINDOW_HANDLE | DEVICE_NOTIFY_ALL_INTERFACE_CLASSES);
            }
            catch (Exception)
            {

            }


            if (this.deviceEventHandle == IntPtr.Zero)
            {
                int error = Marshal.GetLastWin32Error();
            }
            Marshal.FreeHGlobal(buffer);
        }

        /// <summary>
        /// Unregister notifications
        /// </summary>
        public void Unregister()
        {
            if (this.deviceEventHandle != IntPtr.Zero)
            {
                try
                {
                    NativeMethods.UnregisterDeviceNotification(deviceEventHandle);
                }
                catch (Exception)
                {

                }
            }
            this.deviceEventHandle = IntPtr.Zero;
        }
        
        /// <summary>
        /// Main windows message handler and dispatcher
        /// </summary>
        /// <param name="monitor">Monitor class to signal notifications</param>
        /// <param name="hwnd">Window handle</param>
        /// <param name="msg">Window message</param>
        /// <param name="wparam">W parameter</param>
        /// <param name="lparam">L parameter</param>
        internal static void HwndHandler(IUsbMonitor monitor, IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam)
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
#if WINDOWS_UWP
                        var oem = Marshal.PtrToStructure<DevBroadcastOEM>(lparam);
#else
                        var oem = (DevBroadcastOEM)Marshal.PtrToStructure(lparam, typeof(DevBroadcastOEM));
#endif
                        Debug.WriteLine($"OEM: Size={oem.Size}, DeviceType={oem.DeviceType}, Reserved={oem.Reserved}, Identifier={oem.Identifier}, SuppFunc={oem.SuppFunc}");
                        var oemArgs = new UsbEventOemArgs(deviceChangeEvent, oem.Identifier, oem.SuppFunc);
                        // fire event
                        (monitor as IUsbMonitorEvents)?.CallUsbOem(monitor, oemArgs);
                        // execute command
                        if ((monitor as IUsbMonitorCommands)?.UsbOemCommand?.CanExecute(oemArgs) ?? false)
                        {
                            (monitor as IUsbMonitorCommands)?.UsbOemCommand?.Execute(oemArgs);
                        }
                        // call virtual method
                        (monitor as IUsbMonitorOverrides)?.OnUsbOem(oemArgs);
                        break;
                    case UsbDeviceType.Volume:
#if WINDOWS_UWP
                        var volume = Marshal.PtrToStructure<DevBroadcastVolume>(lparam);
#else
                        var volume = (DevBroadcastVolume)Marshal.PtrToStructure(lparam, typeof(DevBroadcastVolume));
#endif
                        char[] drives = DrivesFromMask(volume.UnitMask);
                        string drivesStr = drives.Select(d => $"{d}:").Aggregate((a, b) => $"{a}, {b}");
                        Debug.WriteLine($"Volume: size={volume.Size}, deviceType={volume.DeviceType}, reserved={volume.Reserved}, unitmask={volume.UnitMask}, flags={volume.Flags}, drives={drivesStr}");
                        var volumeArgs = new UsbEventVolumeArgs(deviceChangeEvent, volume.UnitMask, volume.Flags, drives);
                        // fire event
                        (monitor as IUsbMonitorEvents)?.CallUsbVolumem(monitor, volumeArgs);
                        // execute command
                        if ((monitor as IUsbMonitorCommands)?.UsbVolumeCommand?.CanExecute(volumeArgs) ?? false)
                        {
                            (monitor as IUsbMonitorCommands)?.UsbVolumeCommand?.Execute(volumeArgs);
                        }
                        // call virtual method
                        (monitor as IUsbMonitorOverrides)?.OnUsbVolume(volumeArgs);
                        break;
                    case UsbDeviceType.Port:
#if WINDOWS_UWP
                        var port = Marshal.PtrToStructure<DevBroadcastPort>(lparam);
#else
                        var port = (DevBroadcastPort)Marshal.PtrToStructure(lparam, typeof(DevBroadcastPort));
#endif
                        Debug.WriteLine($"Port: Size={port.Size}, DeviceType={port.DeviceType}, Reserved={port.Reserved}, Name={port.Name}");
                        var portArgs = new UsbEventPortArgs(deviceChangeEvent, port.Name);
                        // fire event
                        (monitor as IUsbMonitorEvents)?.CallUsbPort(monitor, portArgs);
                        // execute command
                        if ((monitor as IUsbMonitorCommands)?.UsbPortCommand?.CanExecute(portArgs) ?? false)
                        {
                            (monitor as IUsbMonitorCommands)?.UsbPortCommand?.Execute(portArgs);
                        }
                        // call virtual method
                        (monitor as IUsbMonitorOverrides)?.OnUsbPort(portArgs);
                        break;
                    case UsbDeviceType.DeviceInterface:
#if WINDOWS_UWP
                        var device = Marshal.PtrToStructure<DevBroadcastDeviceInterface>(lparam);
#else
                        var device = (DevBroadcastDeviceInterface)Marshal.PtrToStructure(lparam, typeof(DevBroadcastDeviceInterface));
#endif
                        Debug.WriteLine($"DeviceInterface: Size={device.Size}, DeviceType={device.DeviceType}, Reserved={device.Reserved}, ClassGuid={device.ClassGuid}, Name={device.Name}");
                        var interfaceArgs = new UsbEventDeviceInterfaceArgs(deviceChangeEvent, device.ClassGuid, GuidToEnum<UsbDeviceInterface>(device.ClassGuid), device.Name);
                        // fire event
                        (monitor as IUsbMonitorEvents)?.CallUsbDeviceInterface(monitor, interfaceArgs);
                        // execute command
                        if ((monitor as IUsbMonitorCommands)?.UsbDeviceInterfaceCommand?.CanExecute(interfaceArgs) ?? false)
                        {
                            (monitor as IUsbMonitorCommands)?.UsbDeviceInterfaceCommand?.Execute(interfaceArgs);
                        }
                        // call virtual method
                        (monitor as IUsbMonitorOverrides)?.OnUsbInterface(interfaceArgs);
                        break;
                    case UsbDeviceType.Handle:
#if WINDOWS_UWP
                        var handle = Marshal.PtrToStructure<DevBroadcastHandle>(lparam);
#else
                        var handle = (DevBroadcastHandle)Marshal.PtrToStructure(lparam, typeof(DevBroadcastHandle));
#endif
                        Debug.WriteLine($"DeviceInterface: Size={handle.Size}, DeviceType={handle.DeviceType}, Reserved={handle.Reserved}, Handle={handle.Handle}, DevNotify={handle.DevNotify}, EventGuid={handle.EventGuid}, NameOffset={handle.NameOffset}, Data={handle.Data}");
                        var handleArgs = new UsbEventHandleArgs(deviceChangeEvent, handle.Handle, handle.DevNotify, handle.EventGuid, handle.NameOffset, handle.Data);
                        // fire event
                        (monitor as IUsbMonitorEvents)?.CallUsbHandle(monitor, handleArgs);
                        // execute command
                        if ((monitor as IUsbMonitorCommands)?.UsbHandleCommand?.CanExecute(handleArgs) ?? false)
                        {
                            (monitor as IUsbMonitorCommands)?.UsbHandleCommand?.Execute(handleArgs);
                        }
                        // call virtual method
                        (monitor as IUsbMonitorOverrides)?.OnUsbHandle(handleArgs);
                        break;
                    default:
                        break;
                    }
                    break;
                case UsbDeviceChangeEvent.Changed:
                    var changedArgs = new UsbEventArgs(deviceChangeEvent);
                    // fire event
                    (monitor as IUsbMonitorEvents)?.CallUsbChanged(monitor, changedArgs);
                    // execute command
                    if ((monitor as IUsbMonitorCommands)?.UsbChangedCommand?.CanExecute(changedArgs) ?? false)
                    {
                        (monitor as IUsbMonitorCommands)?.UsbChangedCommand?.Execute(changedArgs);
                    }
                    // call virtual method
                    (monitor as IUsbMonitorOverrides)?.OnUsbChanged(changedArgs);
                    break;
                }
            }
        }

        private static T GuidToEnum<T>(Guid guid)
        {
            T en = Enum.GetValues(typeof(T)).Cast<T>().Where(e =>
            {
                return e.GetType().GetField(e.ToString()).GetCustomAttribute<EnumGuidAttribute>().Guid == guid;
            }).FirstOrDefault();
            return en;
        }

        private static char[] DrivesFromMask(uint unitmask)
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
        private struct DevBroadcastOEM
        {
            public uint Size;
            public uint DeviceType;
            public uint Reserved;
            public uint Identifier;
            public uint SuppFunc;
        }

#if WINDOWS_UWP
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
#else
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
#endif
        private struct DevBroadcastPort
        {
            public uint Size;
            public uint DeviceType;
            public uint Reserved; 
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
            public String Name;
        }

#if WINDOWS_UWP
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
#else
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
#endif
        private struct DevBroadcastDeviceInterface
        {
            public uint Size;
            public uint DeviceType;
            public uint Reserved;
            public Guid ClassGuid;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
            public String Name;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct DevBroadcastVolume
        {
            public uint Size;
            public uint DeviceType;
            public uint Reserved;
            public uint UnitMask;
            public ushort Flags;
        }

#if WINDOWS_UWP
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
#else
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
#endif
        private struct DevBroadcastHandle
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
