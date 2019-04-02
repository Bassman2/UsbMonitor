using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UsbMonitor;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpDeviceCatchMember
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private UsbMonitorManager usbMonitor;

        public MainPage()
        {
            this.InitializeComponent();

            this.usbMonitor = new UsbMonitorManager();
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
