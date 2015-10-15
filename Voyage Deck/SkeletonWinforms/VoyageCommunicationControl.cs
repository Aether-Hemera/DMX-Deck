using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SerialDmxDeck
{
    public partial class VoyageCommunicationControl : UserControl
    {
        public int CurrentMode = -1;

        public VoyageCommunicationControl()
        {
            InitializeComponent();


            var ports = SerialPort.GetPortNames();

            cmbSerialSelect.Items.Clear();
            foreach (var s in ports)
            {
                cmbSerialSelect.Items.Add(s);
            }
            if (cmbSerialSelect.Items.Count > 0)
                cmbSerialSelect.SelectedIndex = 0;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenSerial();
        }

        private SerialPort _comPort;

        private void _comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (_comPort.BytesToRead > 0)
            {
                int size = _comPort.BytesToRead;
                char[] vals = new char[size];
                _comPort.Read(vals, 0, size);
                _databuffer += new string(vals);
            }
            ProcessBuffer();
        }

        private string _databuffer = "";

        private void ProcessBuffer()
        {
            if (chkSerialShowText.Checked)
            {
                if (txtReport.InvokeRequired)
                {
                    txtReport.Invoke((MethodInvoker)delegate
                    {
                        txtReport.Text += _databuffer;
                    });
                }
                else
                    txtReport.Text += _databuffer;


                _databuffer = "";
            }
            int idx;
            while ((idx = _databuffer.IndexOf(';')) > -1)
            {
                string sub = _databuffer.Substring(0, idx);
                _databuffer = _databuffer.Substring(idx + 1);
                string[] split = sub.Split(new char[] { ',' });
                if (split.Length == 5)
                {
                    try
                    {
                        int row = Convert.ToInt16(split[0]);
                        int col = Convert.ToInt16(split[1]);
                        int red = Convert.ToInt16(split[2]);
                        int gre = Convert.ToInt16(split[3]);
                        int blu = Convert.ToInt16(split[4]);
                        voyageControl1.SetColor(row, col, Color.FromArgb(red, gre, blu));
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (split.Length == 3)
                {
                    try
                    {
                        int Univ = Convert.ToInt16(split[0]);
                        int Channel = Convert.ToInt16(split[1]);
                        int Value = Convert.ToInt16(split[2]);

                        int Line = Channel / 75;
                        int inLine = Channel % 75;
                        int Pos = inLine / 3;
                        int Col = inLine % 3;

                        Line = Line + Univ * 4;

                        voyageControl1.SetChannel(Line, Pos, Col, Value);
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (split.Length == 1) // probably the mode
                {
                    int iRead;
                    if (Int32.TryParse(split[0], out iRead))
                    {
                        CurrentMode = iRead;

                        if (label1.InvokeRequired)
                        {
                            label1.Invoke((MethodInvoker)delegate
                            {
                                label1.Text = "Received mode: " + CurrentMode;
                            });
                        }
                        else
                            label1.Text = "Received mode: " + CurrentMode;

                        
                    }
                    
                    
                }
                else
                {
                    msg += sub;
                    // 
                }
            }
        }

        private string msg = "";


        public void OpenSerial()
        {
            lblSerialStatus.Text = "Error";
            if (_comPort != null)
            {
                if (_comPort.IsOpen)
                {
                    _comPort.Close();
                }
            }

            _comPort = new SerialPort();
            if (cmbSerialSelect.Text == "") 
                return;
            var portName = cmbSerialSelect.Text.Substring(0, 4);
            _comPort.DtrEnable = true;
            _comPort.RtsEnable = true;
            _comPort.PortName = portName;
            _comPort.BaudRate = 115200;
            // _comPort.BaudRate = 57600;
            _comPort.DataBits = 8;
            _comPort.Parity = Parity.None;
            _comPort.StopBits = StopBits.One;
            _comPort.Handshake = Handshake.XOnXOff;
            _comPort.DataReceived += new SerialDataReceivedEventHandler(_comPort_DataReceived);
            _comPort.Open();
            // _comPort.ReadByte();
            lblSerialStatus.Text = "Open";
        }

        private void cmdSendCustom_Click(object sender, EventArgs e)
        {
            if (_comPort == null || !_comPort.IsOpen) 
                return;
            string sending = txtCustomCommand.Text;
            _comPort.Write(sending);
        }

        private int iLastSentMode = -1;

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var iMode = Convert.ToInt32(nudMode.Value);
                SendMode(iMode);
            }
            catch (Exception)
            {
                
            }
        }

        private void SendMode(int iMode)
        {
            
            iLastSentMode = iMode;
            var s = string.Format("@100,{0}:", iLastSentMode.ToString(CultureInfo.InvariantCulture));
            Send(s);
        }

        public void Send(string commnad)
        {
            if (_comPort == null || !_comPort.IsOpen)
                return;
            _comPort.Write(commnad);
        }

        public void EnsureMode(int i)
        {
            if (CurrentMode!= i)   
                SendMode(i);
        }

    }
}
