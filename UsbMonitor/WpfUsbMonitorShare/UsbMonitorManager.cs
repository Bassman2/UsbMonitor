using System;
using System.Windows;
using System.Windows.Interop;

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
        public UsbMonitorManager(Window window, bool start = true)
        {
            this.windowHandle = new WindowInteropHelper(window).EnsureHandle();
            HwndSource.FromHwnd(this.windowHandle)?.AddHook(HwndHandler);
            if (start)
            {
                Start();
            }
        }

        private IntPtr HwndHandler(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
        {
            DeviceChangeManager.HwndHandler(this, hwnd, msg, wparam, lparam);
            return IntPtr.Zero;
        }
    }
}
