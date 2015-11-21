using System;
using System.Net;
using System.Windows.Forms;
using Microsoft.Kinect;
using SkeletonWinforms.Properties;

namespace SkeletonWinforms
{
    // ReSharper disable once InconsistentNaming
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            chkSerialStart.Checked = Settings.Default.SerialStart;
            timer1.Enabled = chkSerialStart.Checked;

            // load center position setting and apply
            nudX.Value = Convert.ToDecimal(Settings.Default.CenterPosX);
            nudZ.Value = Convert.ToDecimal(Settings.Default.CenterPosZ);
            ApplyCenterPos();
        }

        private void ApplyCenterPos()
        {
            _userCenterPosX = Convert.ToDouble(nudX.Value);
            _userCenterPosZ = Convert.ToDouble(nudZ.Value);
            Settings.Default.CenterPosX = _userCenterPosX;
            Settings.Default.CenterPosZ = _userCenterPosZ;
            Settings.Default.Save();
        }

        private double _userCenterPosX = 0;
        private double _userCenterPosZ = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            // KinectLaunch();
        }
        
        private int LastSentMode = -1;
        
        private void EnsureMode(int i)
        {
            if (LastSentMode != i)
            {
                voyageCommunicationControl1.EnsureMode(i); 
            }
        }

        private static int ElevationToColor(double v)
        {
            try
            {
                var value = Convert.ToInt32((v * 120));
                if (value < 0)
                    value += 360;
                return value;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private bool InClosing = false;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (InClosing == false)
            {
                InClosing = true;
                if (null != sensor)
                {
                    sensor.Stop();
                }
                Settings.Default.SerialStart = chkSerialStart.Checked;
                Settings.Default.Save();
                InClosing = true;
                if (chkShutBirds.Checked)
                {
                    e.Cancel = true;
                    timer2.Enabled = true;
                    var client = new WebClient();
                    var ret = client.DownloadString("http://10.0.50.20/dmin/sdown.php");
                    lblShutDown.Text = ret;
                }
            }
        }

        private int _iCountDown = 20;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_iCountDown == 5)
            {
                KinectLaunch();
            }

            lblSerial.Text = _iCountDown.ToString();
            if (_iCountDown == 0)
            {
                voyageCommunicationControl1.OpenSerial();
                timer1.Enabled = false;
            }
            _iCountDown--;
        }

        private void voyageCommunicationControl1_Load(object sender, EventArgs e)
        {

        }

        private void SetCenter_Click(object sender, EventArgs e)
        {
            ApplyCenterPos();
        }

        private int ShutDownWait = 10;

        private void timer2_Tick(object sender, EventArgs e)
        {
            ShutDownWait--;
            lblSerial.Text = ShutDownWait.ToString();
            if (ShutDownWait < 1)
            {
                this.Close();
            }
        }

        private void kLaunch_Click(object sender, EventArgs e)
        {
            KinectLaunch();
        }

        private void kCount_Click(object sender, EventArgs e)
        {
            largeText.Text = "Kinect count: " + KinectSensor.KinectSensors.Count;
        }

        private void kState_Click(object sender, EventArgs e)
        {
            largeText.Text = "";
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                largeText.Text += potentialSensor.Status + "; ";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            chkShutBirds.Checked = false;
            Close();
        }
    }
}
