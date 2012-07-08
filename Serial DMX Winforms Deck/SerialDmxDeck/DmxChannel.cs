using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace SerialDmxDeck
{
    public partial class DmxChannel : UserControl
    {
        public DmxChannel()
        {
            
            InitializeComponent();
            lblValue.Text = "0";
        }

        public DmxChannel(SerialPort Serial, int ChannelNumber): this()
        {
            
            CommSerial = Serial;
            Channel = ChannelNumber;
            
        }

        private int _Channel;
        public int Channel
        {
            get
            {
                return _Channel;
            }
            set
            {
                _Channel = value;
                lblChannel.Text = "Ch: " + value.ToString();
            }
        }
        public SerialPort CommSerial { get; set; }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            SendCommand();
        }

        private void SendCommand()
        {
            lblValue.Text = trackBar1.Value.ToString();

            string sc = Channel.ToString() + "c";
            string sv = trackBar1.Value.ToString() + "v";

            if (CommSerial != null && CommSerial.IsOpen)
                CommSerial.Write(sc + sv);
        }

        internal void SetValue(int p)
        {
            trackBar1.Value = p;
            SendCommand();
        }
    }
}
