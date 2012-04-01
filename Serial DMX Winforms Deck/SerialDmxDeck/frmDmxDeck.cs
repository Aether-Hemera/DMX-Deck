using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace SerialDmxDeck
{
    public partial class frmDmxDeck : Form
    {
        private SerialPort _comPort;

        public frmDmxDeck()
        {
            InitializeComponent();

            string[] ports = SerialPort.GetPortNames();

            comboBox1.Items.Clear();
            foreach (string  s in ports)
            {
                comboBox1.Items.Add(s);
            }

        }

        private void button1_Click(object sender, EventArgs e)
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

            for (int iCh = (int)nudFrom.Value; iCh <= (int)nudTo.Value; iCh++)
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

            flowLayoutPanel1.ResumeLayout();

            if (comboBox1.Text != "")
            {
                _comPort.DtrEnable = true;
                _comPort.RtsEnable = true;
                _comPort.PortName = comboBox1.Text;
                _comPort.BaudRate = 9600;
                _comPort.DataBits = 8;
                _comPort.Parity = Parity.None;
                _comPort.StopBits = StopBits.One;
                _comPort.Handshake = Handshake.XOnXOff;
                _comPort.DataReceived += new SerialDataReceivedEventHandler(_comPort_DataReceived);
                _comPort.Open();
                _comPort.ReadByte();
            }
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
            textBox1.Text += _databuffer;
            _databuffer = "";
        }
    }
}
