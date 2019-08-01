using UsbMonitor;

namespace DeviceCatcherMember
{
    public partial class MainForm : UsbMonitorForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public override void OnUsbOem(UsbEventOemArgs args)
        {
            this.textBox.Text += args.ToString() + "\r\n";
        }

        public override void OnUsbVolume(UsbEventVolumeArgs args)
        {
            this.textBox.Text += args.ToString() + "\r\n";
        }

        public override void OnUsbPort(UsbEventPortArgs args)
        {
            this.textBox.Text += args.ToString() + "\r\n";
        }

        public override void OnUsbInterface(UsbEventDeviceInterfaceArgs args)
        {
            this.textBox.Text += args.ToString() + "\r\n";
        }

        public override void OnUsbHandle(UsbEventHandleArgs args)
        {
            this.textBox.Text += args.ToString() + "\r\n";
        }

        /// <summary>
        /// Override to handle USB changed notification.
        /// </summary>
        public override void OnUsbChanged(UsbEventArgs args)
        {
            this.textBox.Text += args.ToString() + "\r\n";
        }
    }
}
