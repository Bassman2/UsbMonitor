using System.Windows.Forms;
using UsbMonitor;

namespace DeviceCatcherMember
{
    public partial class MainForm : Form
    {
        private UsbMonitorManager usbMonitor;

        public MainForm()
        {
            InitializeComponent();

            this.usbMonitor = new UsbMonitorManager(this);
            this.usbMonitor.UsbOem += OnUsb;
            this.usbMonitor.UsbVolume += OnUsb;
            this.usbMonitor.UsbPort += OnUsb;
            this.usbMonitor.UsbDeviceInterface += OnUsb;
            this.usbMonitor.UsbHandle += OnUsb;
            this.usbMonitor.UsbChanged += OnUsb;
        }

        private void OnUsb(object sender, UsbEventArgs e)
        {
            this.textBox.Text += e.ToString() + "\r\n";
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            this.usbMonitor?.HwndHandler(ref m);
            base.WndProc(ref m);
        }
    }
}
