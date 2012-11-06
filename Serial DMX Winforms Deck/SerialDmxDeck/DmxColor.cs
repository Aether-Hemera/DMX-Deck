using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Devcorp.Controls.Design;

namespace SerialDmxDeck
{
    public partial class DmxColor : UserControl, ISetOneValue
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

            // UpdateRGB(

            var v = ColorSpaceHelper.HSBtoRGB(
                (double)this.tbHue.Value, 1, 1);
            //);
            tbRed.Value = v.Red;
            tbGreen.Value = v.Green;
            tbBlue.Value = v.Blue;

            SendCommand();
        }

        private void SendCommand()
        {
            // todo: calculate the r/g/b values here as well and allow the user to change
            // 
            lblValue.Text = tbHue.Value.ToString();
            StringBuilder sb = new StringBuilder(); 
#if calcremotely
            // the following applies if the rgb value is calculated remotely
            // sb.Append(ChannelR.ToString() + "r");
            // sb.Append(ChannelG.ToString() + "g");
            // sb.Append(ChannelB.ToString() + "b");
            // sb.Append(tbHue.Value.ToString() + "h");
#else
            sb.Append(ChannelR.ToString() + "c");
            sb.Append(tbRed.Value.ToString() + "v");

            sb.Append(ChannelG.ToString() + "c");
            sb.Append(tbGreen.Value.ToString() + "v");

            sb.Append(ChannelB.ToString() + "c");
            sb.Append(tbBlue.Value.ToString() + "v");
#endif
            if (CommSerial != null && CommSerial.IsOpen)
            {
                string sending = sb.ToString();
                CommSerial.Write(sending);
            }
        }

        void ISetOneValue.SetValue(int value)
        {
            tbHue.Value = value;
            SendCommand();
        }
    }
}
