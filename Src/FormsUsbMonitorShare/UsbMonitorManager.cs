using System.Windows.Forms;

namespace UsbMonitor
{
    /// <summary>
    /// USB Monitor class to notify if the USB content changes
    /// </summary>
    public partial class UsbMonitorManager : IUsbMonitorEvents //, IMessageFilter
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="form">Main form of the application.</param>
        /// <param name="start">Enable USB notification on startup or not.</param>
        public UsbMonitorManager(Form form, bool start = true)
        {
            this.windowHandle = form.Handle;
            // AddMessageFilter does not work for WM_DEVICECHANGE
            //Application.AddMessageFilter(this);
            if (start)
            {
                Start();
            }
        }

        //public bool PreFilterMessage(ref Message m)
        //{
        //    if (m.HWnd == this.windowHandle)
        //    {
        //        DeviceChangeManager.HwndHandler(this, m.HWnd, m.Msg, m.WParam, m.LParam);
        //    }
        //    return false;
        //}

        /// <summary>
        /// Message handler
        /// </summary>
        /// <param name="m">Message parameter</param>
        public void HwndHandler(ref Message m)
        {
            DeviceChangeManager.HwndHandler(this, m.HWnd, m.Msg, m.WParam, m.LParam);
        }
    }
}
