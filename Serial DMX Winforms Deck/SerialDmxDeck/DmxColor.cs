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
    public partial class DmxColor : UserControl
    {
        public DmxColor()
        {
            InitializeComponent();
            lblValue.Text = "0";
        }

        public DmxColor(SerialPort Serial, int ChannelNumber)
            : this()
        {
            
            CommSerial = Serial;
            ChannelR = ChannelNumber;
            
        }

        private int _ChannelR;
        public int ChannelR
        {
            get
            {
                return _ChannelR;
            }
            set
            {
                _ChannelR = value;
                UpdateLabel();
            }
        }

        private int _ChannelG;
        public int ChannelG
        {
            get
            {
                return _ChannelG;
            }
            set
            {
                _ChannelG = value;
                UpdateLabel();
            }
        }


        private int _ChannelB;
        public int ChannelB
        {
            get
            {
                return _ChannelB;
            }
            set
            {
                _ChannelB = value;
                UpdateLabel();
            }
        }

        private void UpdateLabel()
        {
            lblChannel.Text = _ChannelR + " "  + _ChannelG + " " + _ChannelB;
        }
        public SerialPort CommSerial { get; set; }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            SendCommand();
        }

        private void SendCommand()
        {
            // todo: calculate the r/g/b values here as well and allow the user to change
            // 
            lblValue.Text = trackBar1.Value.ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append(ChannelR.ToString() + "r");
            sb.Append(ChannelG.ToString() + "g");
            sb.Append(ChannelB.ToString() + "b");
            sb.Append(trackBar1.Value.ToString() + "h");
            if (CommSerial != null && CommSerial.IsOpen)
            {
                string sending = sb.ToString();
                CommSerial.Write(sending);
            }
        }

        internal void SetValue(int p)
        {
            trackBar1.Value = p;
            SendCommand();
        }
    }
}
