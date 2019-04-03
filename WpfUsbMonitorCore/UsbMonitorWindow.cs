using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace UsbMonitor
{
    /// <summary>
    /// USB Monitor window class
    /// </summary>
    public class UsbMonitorWindow : Window, IUsbMonitorCommands, IUsbMonitorEvents, IUsbMonitorOverrides
    {

        private IntPtr windowHandle;

        private DeviceChangeManager deviceChangeManager = new DeviceChangeManager();

        #region IUsbMonitorEvents 

        /// <summary>
        /// Event for USB OEM
        /// </summary>
        public event EventHandler<UsbEventOemArgs> UsbOem;

        /// <summary>
        /// Event for USB Volume
        /// </summary>
        public event EventHandler<UsbEventVolumeArgs> UsbVolume;

        /// <summary>
        /// Event for USB Port
        /// </summary>
        public event EventHandler<UsbEventPortArgs> UsbPort;

        /// <summary>
        /// Event for USB Device Interface
        /// </summary>
        public event EventHandler<UsbEventDeviceInterfaceArgs> UsbDeviceInterface;

        /// <summary>
        /// Event for USB Handle
        /// </summary>
        public event EventHandler<UsbEventHandleArgs> UsbHandle;

        /// <summary>
        /// Event for USB Changed
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

        #region IUsbMonitorCommands

        /// <summary>
        /// USB Changed dependency property
        /// </summary>
        public static readonly DependencyProperty UsbChangedCommandProperty =
            DependencyProperty.Register("UsbChangedCommand", typeof(ICommand), typeof(UsbMonitorWindow), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// ICommand to be called on USB Changed.
        /// </summary>
        public ICommand UsbChangedCommand
        {
            get { return (ICommand)GetValue(UsbChangedCommandProperty); }
            set { SetValue(UsbChangedCommandProperty, value); }
        }

        /// <summary>
        /// USB OEM dependency property
        /// </summary>
        public static readonly DependencyProperty UsbOemCommandProperty =
            DependencyProperty.Register("UsbOemCommand", typeof(ICommand), typeof(UsbMonitorWindow), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// ICommand to be called on USB OEM.
        /// </summary>
        public ICommand UsbOemCommand
        {
            get { return (ICommand)GetValue(UsbOemCommandProperty); }
            set { SetValue(UsbOemCommandProperty, value); }
        }

        /// <summary>
        /// USB Volume dependency property
        /// </summary>
        public static readonly DependencyProperty UsbVolumeCommandProperty =
            DependencyProperty.Register("UsbVolumeCommand", typeof(ICommand), typeof(UsbMonitorWindow), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// ICommand to be called on USB Volume.
        /// </summary>
        public ICommand UsbVolumeCommand
        {
            get { return (ICommand)GetValue(UsbVolumeCommandProperty); }
            set { SetValue(UsbVolumeCommandProperty, value); }
        }

        /// <summary>
        /// USB Port dependency property
        /// </summary>
        public static readonly DependencyProperty UsbPortCommandProperty =
            DependencyProperty.Register("UsbPortCommand", typeof(ICommand), typeof(UsbMonitorWindow), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// ICommand to be called on USB Port.
        /// </summary>
        public ICommand UsbPortCommand
        {
            get { return (ICommand)GetValue(UsbPortCommandProperty); }
            set { SetValue(UsbPortCommandProperty, value); }
        }

        /// <summary>
        /// USB DeviceInterface dependency property
        /// </summary>
        public static readonly DependencyProperty UsbDeviceInterfaceCommandProperty =
            DependencyProperty.Register("UsbDeviceInterfaceCommand", typeof(ICommand), typeof(UsbMonitorWindow), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// ICommand to be called on USB DeviceInterface.
        /// </summary>
        public ICommand UsbDeviceInterfaceCommand
        {
            get { return (ICommand)GetValue(UsbDeviceInterfaceCommandProperty); }
            set { SetValue(UsbDeviceInterfaceCommandProperty, value); }
        }

        /// <summary>
        /// USB Handle dependency property
        /// </summary>
        public static readonly DependencyProperty UsbHandleCommandProperty =
            DependencyProperty.Register("UsbHandleCommand", typeof(ICommand), typeof(UsbMonitorWindow), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// ICommand to be called on USB Handle.
        /// </summary>
        public ICommand UsbHandleCommand
        {
            get { return (ICommand)GetValue(UsbHandleCommandProperty); }
            set { SetValue(UsbHandleCommandProperty, value); }
        }

        #endregion

        /// <summary>
        /// USB Notification dependency property
        /// </summary>
        public static readonly DependencyProperty UsbNotificationProperty =
            DependencyProperty.Register("UsbNotification", typeof(bool), typeof(UsbMonitorWindow), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(OnUsbNotificationChanged)));

        private static void OnUsbNotificationChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            UsbMonitorWindow usbMonitorWindow = (UsbMonitorWindow)o;
            bool value = (bool)e.NewValue;
            if (value)
            {
                usbMonitorWindow.Start();
            }
            else
            {
                usbMonitorWindow.Stop();
            }
        }

        /// <summary>
        /// Enable USB notification.
        /// </summary>
        public bool UsbNotification
        {
            get { return (bool)GetValue(UsbNotificationProperty); }
            set { SetValue(UsbNotificationProperty, value); }
        }

       

        /// <summary>
        /// Raises the System.Windows.FrameworkElement.Initialized event. This method is
        /// invoked whenever System.Windows.FrameworkElement.IsInitialized is set to true internally.
        /// </summary>
        /// <param name="e">The System.Windows.RoutedEventArgs that contains the event data.</param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            this.windowHandle = new WindowInteropHelper(this).EnsureHandle();
            HwndSource.FromHwnd(this.windowHandle)?.AddHook(HwndHandler);

            if (this.UsbNotification)
            {
                Start();
            }
        }
        /// <summary>
        /// Enable USB notification.
        /// </summary>
        public void Start()
        {
            this.deviceChangeManager.Register(this.windowHandle);
        }

        /// <summary>
        /// Disable USB notification.
        /// </summary>
        public void Stop()
        {
            this.deviceChangeManager.Unregister();
        }

        private IntPtr HwndHandler(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
        {
            DeviceChangeManager.HwndHandler(this, hwnd, msg, wparam, lparam);
            return IntPtr.Zero;
        }

        
    }
}
