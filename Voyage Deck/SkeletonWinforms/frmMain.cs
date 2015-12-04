using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Kinect;
// ReSharper disable LocalizableElement

namespace SkeletonWinforms
{
    // ReSharper disable once InconsistentNaming
    public partial class frmMain : Form
    {
        // ReSharper disable once ConvertToConstant.Local
        private readonly bool _doStart = true;
        // ReSharper disable once ConvertToConstant.Local
        private readonly double _centerPosX = 0.25;
        // ReSharper disable once ConvertToConstant.Local
        private readonly double _centerPosZ = 2.7;


        public frmMain()
        {
            InitializeComponent();
            chkSerialStart.Checked = _doStart;
            timerEnableKit.Enabled = chkSerialStart.Checked;

            // load center position setting and apply
            nudX.Value = Convert.ToDecimal(_centerPosX);
            nudZ.Value = Convert.ToDecimal(_centerPosZ);
            ApplyCenterPos();
        }

        private void ApplyCenterPos()
        {
            _userCenterPosX = Convert.ToDouble(nudX.Value);
            _userCenterPosZ = Convert.ToDouble(nudZ.Value);
        }

        private double _userCenterPosX;
        private double _userCenterPosZ;

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        private void EnsureMode(int i)
        {
            voyageCommunicationControl1.EnsureMode(i);
   
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

        private class ShortTimeOutClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri uri)
            {
                var w = base.GetWebRequest(uri);
                if (w != null)
                {
                    w.Timeout = 5 * 1000;
                }
                return w;
            }
        }

        private bool _inClosing;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_inClosing)
                return;
            _inClosing = true;
            if (null != sensor)
            {
                sensor.Stop();
            }
            _inClosing = true;
            if (!chkShutBirds.Checked)
                return;
            e.Cancel = true;
            
            timerShutDownBirds.Enabled = true;
            timerEnableKit.Enabled = false;

            new Thread(() =>
            {
                var client = new ShortTimeOutClient();
                try
                {
                    var ret = client.DownloadString("http://10.0.50.20/dmin/sdown.php");
                    // lblShutDown.Text = ret;
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);
                }
            }).Start();    
        }

        private int _iCountDown = 20;

        private void timerEnableKit_Tick(object sender, EventArgs e)
        {
            if (_iCountDown == 5)
            {
                KinectLaunch();
            }

            lblSerial.Text = _iCountDown.ToString();
            if (_iCountDown == 0)
            {
                voyageCommunicationControl1.OpenSerial();
                timerEnableKit.Enabled = false;
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

        private int _shutDownWait = 10;

        private void timerShutDownBirds_Tick(object sender, EventArgs e)
        {
            _shutDownWait--;
            lblSerial.Text = _shutDownWait.ToString();
            if (_shutDownWait < 1)
            {
                Close();
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

        private void chkSerialStart_CheckedChanged(object sender, EventArgs e)
        {
            timerEnableKit.Enabled = chkSerialStart.Checked;
        }
    }
}
