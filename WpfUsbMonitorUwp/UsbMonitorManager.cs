using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Interop;
using System.Runtime.InteropServices;
using Windows.UI.Core;

namespace UsbMonitor
{
    /// <summary>
    /// USB Monitor class to notify if the USB content changes
    /// </summary>
    public partial class UsbMonitorManager : IUsbMonitorEvents
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="window">Main window of the application.</param>
        /// <param name="start">Enable USB notification on startup or not.</param>
        public UsbMonitorManager(bool start = true)
        {
            Window window = Window.Current;

            //this.windowHandle = new WindowInteropHelper(window).EnsureHandle();
            //HwndSource.FromHwnd(this.windowHandle)?.AddHook(HwndHandler);

            //CoreWindow::GetForCurrentThread()


            dynamic corewin = CoreWindow.GetForCurrentThread();
            var interop = (ICoreWindowInterop)corewin;
            this.windowHandle = interop.WindowHandle;

            Hook();
            //HwndSource.FromHwnd(this.windowHandle)?.AddHook(HwndHandler);

            if (start)
            {
                Start();
            }
        }

        //private IntPtr HwndHandler(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
        //{
        //    DeviceChangeManager.HwndHandler(this, hwnd, msg, wparam, lparam);
        //    return IntPtr.Zero;
        //}

        private IntPtr hook;
        //IntPtr _hwnd;
        private NativeMethods.CBTProc callback;


        private void Hook()
        {
            this.callback = this.CallBack;
            this.hook = NativeMethods.SetWindowsHookEx(NativeMethods.HookType.WH_GETMESSAGE, this.callback, IntPtr.Zero, NativeMethods.GetCurrentThreadId());
        }

        private void Unhook()
        {
            if (this.hook != IntPtr.Zero)
            {
                NativeMethods.UnhookWindowsHookEx(this.hook);
                this.hook = IntPtr.Zero;
            }
        }

        private const int WM_DEVICECHANGE = 0x0219;
        private IntPtr CallBack(int msg, IntPtr wParam, IntPtr lParam)
        {
            

            if (msg == WM_DEVICECHANGE)
            {

            }
            DeviceChangeManager.HwndHandler(this, this.windowHandle, msg, wParam, lParam);
            return NativeMethods.CallNextHookEx(IntPtr.Zero, msg, wParam, lParam);
        }


        private static class NativeMethods
        {
            public enum HookType
            {
                WH_MIN = (-1),
                WH_MSGFILTER = (-1),
                WH_JOURNALRECORD = 0,
                WH_JOURNALPLAYBACK = 1,
                WH_KEYBOARD = 2,
                WH_GETMESSAGE = 3,
                WH_CALLWNDPROC = 4,
                WH_CBT = 5,
                WH_SYSMSGFILTER = 6,
                WH_MOUSE = 7,
                WH_HARDWARE = 8,
                WH_DEBUG = 9,
                WH_SHELL = 10,
                WH_FOREGROUNDIDLE = 11,
                WH_CALLWNDPROCRET = 12,
                WH_KEYBOARD_LL = 13,
                WH_MOUSE_LL = 14
            }

            public delegate IntPtr CBTProc(int code, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool UnhookWindowsHookEx(IntPtr hookPtr);

            [DllImport("user32.dll")]
            public static extern IntPtr CallNextHookEx(IntPtr hookPtr, int nCode, IntPtr wordParam, IntPtr longParam);

            [DllImport("user32.dll")]
            public static extern IntPtr SetWindowsHookEx(HookType hookType, CBTProc hookProc, IntPtr instancePtr, uint threadID);

            [DllImport("kernel32.dll")]
            public static extern uint GetCurrentThreadId();

        }
    }
}
