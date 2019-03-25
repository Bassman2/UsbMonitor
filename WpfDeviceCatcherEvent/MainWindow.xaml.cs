using System;
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

        private void UsbMonitorWindow_Usb(object sender, UsbEventArgs e)
        {
            this.textBox.Text += e.ToString() + "\r\n";
        }
    }
}
