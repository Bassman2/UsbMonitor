using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsbMonitor;

namespace DeviceCatcherMember
{
    public partial class MainForm : UsbMonitorForm
    {
        public MainForm()
        {
            InitializeComponent();

            this.UsbOem += (s,e) => { this.textBox.Text += e.ToString() + "\r\n"; }; 
            this.UsbVolume += (s, e) => { this.textBox.Text += e.ToString() + "\r\n"; };
            this.UsbPort += (s, e) => { this.textBox.Text += e.ToString() + "\r\n"; };
            this.UsbDeviceInterface += (s, e) => { this.textBox.Text += e.ToString() + "\r\n"; };
            this.UsbHandle += (s, e) => { this.textBox.Text += e.ToString() + "\r\n"; };
            this.UsbChanged += (s, e) => { this.textBox.Text += e.ToString() + "\r\n"; };
        }
    }
}
