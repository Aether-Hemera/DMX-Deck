using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;

namespace SerialDmxDeck
{
    public partial class frmDmxDeck : Form
    {
        private SerialPort _comPort;

        public frmDmxDeck()
        {
            InitializeComponent();

            string[] ports = SerialPort.GetPortNames();

            cmbSerialSelect.Items.Clear();
            foreach (string  s in ports)
            {
                cmbSerialSelect.Items.Add(s);
            }
            try
            {
                cmbSerialSelect.SelectedIndex = 0;
            }
            catch
            {

            }
        }

        private void PrepareInterface(List<int> channels)
        {
            if (_comPort != null)
            {
                if (_comPort.IsOpen)
                {
                    _comPort.Close();
                }
            }

            _comPort = new SerialPort();

            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();

            

            for (int i = 0; i < channels.Count; i++)
            {
                if (chkAsColor.Checked && i + 2 < channels.Count)
                {
                    AddColorChannel(channels[i], channels[i + 1], channels[i + 2]);
                    i += 2;
                }
                else
                {
                    AddChannel(i);
                }
            }

            flowLayoutPanel1.ResumeLayout();

            if (cmbSerialSelect.Text != "")
            {
                _comPort.DtrEnable = true;
                _comPort.RtsEnable = true;
                _comPort.PortName = cmbSerialSelect.Text;
                _comPort.BaudRate = 115200;
                _comPort.DataBits = 8;
                _comPort.Parity = Parity.None;
                _comPort.StopBits = StopBits.One;
                _comPort.Handshake = Handshake.XOnXOff;
                _comPort.DataReceived += new SerialDataReceivedEventHandler(_comPort_DataReceived);
                _comPort.Open();
                _comPort.ReadByte();
            }
        }


        private void AddColorChannel(int iChR, int iChG, int iChB)
        {
            SerialDmxDeck.DmxColor chControl = new SerialDmxDeck.DmxColor();
            chControl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            chControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            chControl.ChannelR = iChR;
            chControl.ChannelG = iChG;
            chControl.ChannelB = iChB;

            chControl.CommSerial = _comPort;
            chControl.Location = new System.Drawing.Point(3, 3);
            chControl.Name = "dmxChannel";
            // chControl.Size = new System.Drawing.Size(49, 314);
            chControl.TabIndex = 0;
            flowLayoutPanel1.Controls.Add(chControl);
        }

        private void AddChannel(int iCh)
        {
            SerialDmxDeck.DmxChannel chControl = new SerialDmxDeck.DmxChannel();
            chControl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            chControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            chControl.Channel = iCh;
            chControl.CommSerial = _comPort;
            chControl.Location = new System.Drawing.Point(3, 3);
            chControl.Name = "dmxChannel";
            chControl.Size = new System.Drawing.Size(49, 314);
            chControl.TabIndex = 0;
            flowLayoutPanel1.Controls.Add(chControl);
        }

        string _databuffer = "";

        void _comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (_comPort.BytesToRead > 0)
            {
                int size = _comPort.BytesToRead;
                char[] vals = new char[size];
                _comPort.Read(vals, 0, size);

                string s = "";
                foreach (char c in vals)
                {
                    s += Convert.ToString(c);
                }
                _databuffer += s;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtReport.Text += _databuffer;
            _databuffer = "";
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtReport.Text = "";
        }

        private void cmdSetCustomChannels_Click(object sender, EventArgs e)
        {
            List<int> channels = new List<int>();
            string[] sArr = txtCustomChannels.Text.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in sArr)
            {
                Regex reRange = new Regex(" *(\\d+) *- *(\\d+) *"); // x-y
                var mts = reRange.Matches(item);
                if (mts.Count > 0)
                {
                    int vFrom = Convert.ToInt32(mts[0].Groups[1].Value);
                    int vTo = Convert.ToInt32(mts[0].Groups[2].Value);

                    int vMin = Math.Min(vFrom, vTo);
                    int vMax = Math.Max(vFrom, vTo);

                    for (int i = vMin; i <= vMax; i++)
                    {
                        channels.Add(i);
                    }
                }
                else
                {
                    Regex reSingle = new Regex(" *(\\d+) *"); // x-y
                    if (reSingle.IsMatch(item))
                    {
                        var mtsingle = reSingle.Match(item);
                        int vSingle = Convert.ToInt32(mtsingle.Value);
                        channels.Add(vSingle);
                    }
                }
            }
            if (channels.Count > 0)
            {
                PrepareInterface(channels);
            }
        }

        private void cmdSetAll_Click(object sender, EventArgs e)
        {
            foreach (var item in flowLayoutPanel1.Controls)
            {
                ISetOneValue ch = item as ISetOneValue;
                if (ch != null)
                {
                    ch.SetValue(0);
                }
            }
        }

        private void cmdEchoOn_Click(object sender, EventArgs e)
        {
            try
            {
                _comPort.Write("e");
            }
            catch (Exception)
            {
                
            }
            
        }

        private void cmdEchoOff_Click(object sender, EventArgs e)
        {
            try
            {
                _comPort.Write("o");
            }
            catch (Exception)
            {
                
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> channels = new List<int>();
            Regex re = new Regex("(\\d+)"); // one or more digits
            var mts = re.Matches(txtValues.Text);
            foreach (Match m in mts)
            {
                int v = Convert.ToInt32(m.Value);
                channels.Add(v);
            }
            if (channels.Count == 0)
            {
                return;
            }

            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {    
                int iVal = i % channels.Count;
                ISetOneValue ch = flowLayoutPanel1.Controls[i] as ISetOneValue;
                if (ch != null)
                {
                    ch.SetValue(channels[iVal]);
                }   
            }
        }
    }
}
