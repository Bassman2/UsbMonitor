using UsbMonitor;


namespace DeviceCatcherEvent
{
    public partial class MainForm : UsbMonitorForm
    {
        public MainForm()
        {
            InitializeComponent();

            this.UsbOem += (s, e) => { this.textBox.Text += e.ToString() + "\r\n"; };
            this.UsbVolume += (s, e) => { this.textBox.Text += e.ToString() + "\r\n"; };
            this.UsbPort += (s, e) => { this.textBox.Text += e.ToString() + "\r\n"; };
            this.UsbDeviceInterface += (s, e) => { this.textBox.Text += e.ToString() + "\r\n"; };
            this.UsbHandle += (s, e) => { this.textBox.Text += e.ToString() + "\r\n"; };
            this.UsbChanged += (s, e) => { this.textBox.Text += e.ToString() + "\r\n"; };
        }
    }
}
