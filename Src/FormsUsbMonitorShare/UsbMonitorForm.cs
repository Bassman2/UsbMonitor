using System;
using System.Windows.Forms;

namespace UsbMonitor
{
    /// <summary>
    /// Base class for main form
    /// </summary>
    public class UsbMonitorForm : Form, IUsbMonitorEvents, IUsbMonitorOverrides
    {
#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable IDE0090 // Use 'new(...)'
        private readonly DeviceChangeManager deviceChangeManager = new DeviceChangeManager();
#pragma warning restore IDE0090 // Use 'new(...)'
#pragma warning restore IDE0079 // Remove unnecessary suppression

        #region IUsbMonitorEvents
        /// <summary>
        /// Event for OEM messages
        /// </summary>
        public event EventHandler<UsbEventOemArgs> UsbOem;

        /// <summary>
        /// Event for volume messages
        /// </summary>
        public event EventHandler<UsbEventVolumeArgs> UsbVolume;

        /// <summary>
        /// Event for port messages
        /// </summary>
        public event EventHandler<UsbEventPortArgs> UsbPort;

        /// <summary>
        /// Event for device interface messages
        /// </summary>
        public event EventHandler<UsbEventDeviceInterfaceArgs> UsbDeviceInterface;

        /// <summary>
        /// Event for handle messages
        /// </summary>
        public event EventHandler<UsbEventHandleArgs> UsbHandle;

        /// <summary>
        /// Event for changed messages
        /// </summary>
        public event EventHandler<UsbEventArgs> UsbChanged;

        /// <summary>
        /// Internal call of UsbOem
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="args">Arguments</param>
        public void CallUsbOem(object sender, UsbEventOemArgs args)
        {
            this.UsbOem?.Invoke(sender, args);
        }

        /// <summary>
        /// Internal call of UsbVolume
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="args">Arguments</param>
        public void CallUsbVolumem(object sender, UsbEventVolumeArgs args)
        {
            this.UsbVolume?.Invoke(sender, args);
        }

        /// <summary>
        /// Internal call of CallUsbPort
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="args">Arguments</param>
        public void CallUsbPort(object sender, UsbEventPortArgs args)
        {
            this.UsbPort?.Invoke(sender, args);
        }

        /// <summary>
        /// Internal call of UsbDeviceInterface
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="args">Arguments</param>
        public void CallUsbDeviceInterface(object sender, UsbEventDeviceInterfaceArgs args)
        {
            this.UsbDeviceInterface?.Invoke(sender, args);
        }

        /// <summary>
        /// Internal call of UsbHandle
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="args">Arguments</param>
        public void CallUsbHandle(object sender, UsbEventHandleArgs args)
        {
            this.UsbHandle?.Invoke(sender, args);
        }

        /// <summary>
        /// Internal call of UsbChanged
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="args">Arguments</param>
        public void CallUsbChanged(object sender, UsbEventArgs args)
        {
            this.UsbChanged?.Invoke(sender, args);
        }

        #endregion

        #region IUsbMonitorOverrides

        /// <summary>
        /// Override to handle USB OEM notification.
        /// </summary>
        /// <param name="args">OEM arguments</param>
        public virtual void OnUsbOem(UsbEventOemArgs args)
        { }

        /// <summary>
        /// Override to handle USB Volume notification.
        /// </summary>
        /// <param name="args">Volume arguments</param>
        public virtual void OnUsbVolume(UsbEventVolumeArgs args)
        { }

        /// <summary>
        /// Override to handle USB Port notification.
        /// </summary>
        /// <param name="args">Port arguments</param>
        public virtual void OnUsbPort(UsbEventPortArgs args)
        { }

        /// <summary>
        /// Override to handle USB Interface notification.
        /// </summary>
        /// <param name="args">Interface arguments</param>
        public virtual void OnUsbInterface(UsbEventDeviceInterfaceArgs args)
        { }

        /// <summary>
        /// Override to handle USB Handle notification.
        /// </summary>
        /// <param name="args">Handle arguments</param>
        public virtual void OnUsbHandle(UsbEventHandleArgs args)
        { }

        /// <summary>
        /// Override to handle USB changed notification.
        /// </summary>
        /// <param name="args">Changed arguments</param>
        public virtual void OnUsbChanged(UsbEventArgs args)
        { }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public UsbMonitorForm()
        { }
 
        /// <summary>
        /// Raises the System.Windows.Forms.Form.Load event.
        /// </summary>
        /// <param name="e">An System.EventArgs that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            Start();
            base.OnLoad(e);
        }

        /// <summary>
        /// Enable USB notification.
        /// </summary>
        public void Start()
        {
            this.deviceChangeManager.Register(this.Handle);
        }

        /// <summary>
        /// Disable USB notification.
        /// </summary>
        public void Stop()
        {
            this.deviceChangeManager.Unregister();
        }

        /// <summary>
        /// Overrides main window WndProc
        /// </summary>
        /// <param name="m">Message parameter</param>
#if NETFRAMEWORK
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
#endif
        protected override void WndProc(ref Message m)
        {
            DeviceChangeManager.HwndHandler(this, m.HWnd, m.Msg, m.WParam, m.LParam);
            base.WndProc(ref m);
        }
    }
}
