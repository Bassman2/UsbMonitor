using UsbMonitor;

namespace DeviceCatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UsbMonitorWindow
    {
        public MainWindow()
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

        public override void OnUsbChanged(UsbEventArgs args)
        {
            this.textBox.Text += args.ToString() + "\r\n";
        }
    }
}
