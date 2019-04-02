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
            //Window window = Window.Current;

            //this.windowHandle = new WindowInteropHelper(window).EnsureHandle();
            //HwndSource.FromHwnd(this.windowHandle)?.AddHook(HwndHandler);




            dynamic corewin = CoreWindow.GetForCurrentThread();
            var interop = (ICoreWindowInterop)corewin;
            this.windowHandle = interop.WindowHandle;
            //HwndSource.FromHwnd(this.windowHandle)?.AddHook(HwndHandler);
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
