using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Diagnostics;
using ZedGraph;

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

            cmbFilterType.Items.Clear();
            cmbFilterType.Items.Add(@"Home & Commands");
            cmbFilterType.Items.Add(@"Home");
            cmbFilterType.Items.Add(@"Commands");
            cmbFilterType.SelectedIndex = 0;
        }

        private void PrepareInterface(List<int> channels)
        {
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
                    AddChannel(channels[i]);
                }
            }

            flowLayoutPanel1.ResumeLayout();
            OpenSerial();
        }

        private void OpenSerial()
        {
            if (_comPort != null)
            {
                if (_comPort.IsOpen)
                {
                    _comPort.Close();
                }
            }

            _comPort = new SerialPort();
            if (cmbSerialSelect.Text != "")
            {
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

        private string _databuffer = "";

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
                string[] split = sub.Split(new char[] {','});
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

                        int Line = Channel/75;
                        int inLine = Channel%75;
                        int Pos = inLine/3;
                        int Col = inLine%3;

                        Line = Line + Univ*4;

                        voyageControl1.SetChannel(Line, Pos, Col, Value);
                    }
                    catch (Exception)
                    {
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (msg != string.Empty)
                Debug.WriteLine(msg);
            msg = string.Empty;
            // ProcessBuffer();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtReport.Text = "";
        }

        private void cmdSetCustomChannels_Click(object sender, EventArgs e)
        {
            List<int> channels = new List<int>();
            string[] sArr = txtCustomChannels.Text.Split(new string[] {";"}, StringSplitOptions.RemoveEmptyEntries);

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
                int iVal = i%channels.Count;
                ISetOneValue ch = flowLayoutPanel1.Controls[i] as ISetOneValue;
                if (ch != null)
                {
                    ch.SetValue(channels[iVal]);
                }
            }
        }

        private void cmdSendCustom_Click(object sender, EventArgs e)
        {
            if (_comPort != null && _comPort.IsOpen)
            {
                string sending = txtCustomCommand.Text;
                _comPort.Write(sending);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenSerial();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = string.Format("@100,{0}:", nudMode.Value.ToString());
            _comPort.Write(s);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<int> r = new List<int>();
            List<int> g = new List<int>();
            List<int> b = new List<int>();

            Bitmap bmp = new Bitmap(@"C:\Users\Bonghi\Desktop\arizonaflag.bmp");
            for (int row = 0; row < bmp.Height; row++)
            {
                for (int col = 0; col < bmp.Width; col++)
                {
                    var c = bmp.GetPixel(col, row);
                    r.Add(c.R);
                    g.Add(c.G);
                    b.Add(c.B);
                }
            }
            txtReport.Text = "";
            txtReport.Text += r.Count + "\r\n\r\n";
            // uncomment and fix
            //txtReport.Text += string.Join(", ", r.ToArray()) + "\r\n\r\n";
            //txtReport.Text += string.Join(", ", g.ToArray()) + "\r\n\r\n";
            //txtReport.Text += string.Join(", ", b.ToArray()) + "\r\n\r\n";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _comPort.Write("@100,14:"); // scheme NO_CHANGE
            _comPort.Write("@103,-1:"); // stay on this scheme
        }

        private void nudRow_ValueChanged(object sender, EventArgs e)
        {
            SendRowCol();
        }

        private void SendRowCol()
        {
            if (chkSendBack.Checked)
            {
                Docolor(btnDefaultColor.BackColor);
            }
            string s = string.Format("@104,{0},{1}:", nudRow.Value.ToString(), nudCol.Value.ToString());
            _comPort.Write(s);
            if (chkAutoColor.Checked)
                Docolor(autoButton.BackColor);
        }

        private void nudCol_ValueChanged(object sender, EventArgs e)
        {
            SendRowCol();
        }

        private Button autoButton;

        private void cmdSendColor_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                if (optionDefault.Checked)
                {
                    btnDefaultColor.BackColor = button.BackColor;
                    optionAll.Checked = true;
                    chkSendBack.Checked = true;
                    return;   
                }

                autoButton = button;
                
                Docolor(button.BackColor);
            }
        }

        private void Docolor(Color color)
        {
            string cmd = "109"; // all
            if (optionRow.Checked)
                cmd = "107";
            else if (optionCol.Checked)
                cmd = "108";
            else if (optionCell.Checked)
                cmd = "110";

            string s = string.Format("@{3},{0},{1},{2}:", color.R, color.G, color.B, cmd);
            _comPort.Write(s);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            _comPort.Write("@103,-1:"); // stay on this scheme
        }

        private class Hit
        {
            public DateTime Date;
            public string url;
        }

        List<Hit> hits = new List<Hit>();

        private void button6_Click(object sender, EventArgs e)
        {
            hits = new List<Hit>();
            txtReport.Text = "";
            string pattern = @"\[(.*) \+0000\] ""GET (/api/command/\d*|/)";
            RegexOptions regexOptions = RegexOptions.None;
            Regex regex = new Regex(pattern, regexOptions);

            DirectoryInfo directoryInfo = new DirectoryInfo(txtDirInfo.Text);
            foreach (var filename in directoryInfo.GetFiles(@"access.log.*"))
            {
                if (filename.FullName.EndsWith(".gz"))
                    continue;
                txtReport.Text += filename.FullName + "\r\n";
                Debug.WriteLine(filename.FullName);
                using (StreamReader reader = new StreamReader(filename.FullName, Encoding.UTF8))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        foreach (Match match in regex.Matches(line))
                        {
                            if (match.Success)
                            {
                                string dts = match.Groups[1].Value;
                                dts = dts.Substring(0, 11) + " " + dts.Substring(12);
                                DateTime dt = Convert.ToDateTime(dts);
                                hits.Add(new Hit() { Date = dt, url = match.Groups[2].Value });
                            }
                        }    
                    }
                }
            }
            txtReport.Text += "Done";
        }

        private IEnumerable<Hit> matchingHits()
        {

            foreach (var hit in hits)
            {
                if (chkDate1.Checked && chkDate2.Checked)
                {
                    if (dateParameter1.Value.Date > hit.Date.Date)
                        continue;
                    if (dateParameter2.Value.Date < hit.Date.Date)
                        continue;
                }
                else if (chkDate1.Checked && dateParameter1.Value.Date != hit.Date.Date)
                    continue;
                if (cmbFilterType.SelectedItem.ToString() == @"Commands" && !hit.url.StartsWith("/api/"))
                    continue;
                if (cmbFilterType.SelectedItem.ToString() == @"Home" && hit.url != "/")
                    continue;
                
                yield return hit;
            }
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Dictionary<int, int> HourHits = new Dictionary<int, int>();

            for (int i = 0; i < 24; i++)
            {
                HourHits.Add(i, 0);
            }

            foreach (var hit in matchingHits())
            {
                HourHits[hit.Date.Hour]++;
            }

            var sb = new StringBuilder();
            foreach (var hour in HourHits)
            {
                sb.AppendFormat("Hour:\t{0}\t{1}\r\n", hour.Key, hour.Value);
            }
            var tmpL = new List<string>();
            var tmpV = new List<double>();

            txtLogReport.Text = sb.ToString();
            for (var i = 0; i < 24; i++)
            {
                tmpL.Add(i.ToString());
                tmpV.Add(HourHits[i]);
            }
            var labels = tmpL.ToArray();
            var values = tmpV.ToArray();
            CreateGraph(zedGraphControl1, labels, values);
        }




        private void CreateGraph(ZedGraphControl zg1, string[] labels, double[] values)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zg1.GraphPane;

            // Set the Titles
            myPane.Title = "My Test Bar Graph";
            myPane.XAxis.Title = "Label";
            myPane.YAxis.Title = "My Y Axis";
            myPane.CurveList.Clear();
            
            
            // Generate a red bar with "Curve 1" in the legend
            BarItem myBar = myPane.AddBar("Hits", null, values, Color.Red);
            myBar.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red);
       
            // Set the XAxis labels
            myPane.XAxis.Scale.TextLabels = labels;
            myPane.XAxis.Type = AxisType.Text;


            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zg1.AxisChange();
            zg1.ZoomOutAll(myPane);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var dateHits = new Dictionary<DateTime, int>();

            DateTime minTime = DateTime.MaxValue;
            DateTime maxTime = DateTime.MinValue;


            foreach (var hit in matchingHits())
            {
                if (minTime > hit.Date.Date)
                    minTime = hit.Date.Date;
                if (maxTime < hit.Date.Date)
                    maxTime = hit.Date.Date;

                if (!dateHits.ContainsKey(hit.Date.Date))
                    dateHits.Add(hit.Date.Date, 0);

                dateHits[hit.Date.Date]++;
            }

            var tmpL = new List<string>();
            var tmpV = new List<double>();

            StringBuilder sb = new StringBuilder();

            for (var runningDate = minTime; runningDate <= maxTime; runningDate = runningDate.AddDays(1))
            {
                var label = runningDate.ToString();
                double val = 0;
                if (dateHits.ContainsKey(runningDate.Date))
                    val = dateHits[runningDate.Date];

                sb.AppendFormat("day:\t{0}\t{1}\r\n", label, val);

                tmpL.Add(label);
                tmpV.Add(val);
            }
            txtLogReport.Text = sb.ToString();
            CreateGraph(zedGraphControl1, tmpL.ToArray(), tmpV.ToArray());
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        void ResetExceptionState(Control control)
        {
            typeof(Control).InvokeMember("SetState", BindingFlags.NonPublic |
              BindingFlags.InvokeMethod | BindingFlags.Instance, null,
              control, new object[] { 0x400000, false });
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ResetExceptionState(voyageControl1);
        }

        private void txtModeInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void nudMode_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
