using System;
using System.Windows;
using UsbMonitor;

namespace DeviceCatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UsbMonitorManager usbMonitor;

        public MainWindow()
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
    }
}
