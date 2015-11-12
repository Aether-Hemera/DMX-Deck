using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Microsoft.Kinect;
using SkeletonWinforms.Properties;

namespace SkeletonWinforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chkSerialStart.Checked = Settings.Default.SerialStart;
            timer1.Enabled = chkSerialStart.Checked;

            nudX.Value = Convert.ToDecimal(Settings.Default.CenterPosX);
            nudZ.Value = Convert.ToDecimal(Settings.Default.CenterPosZ);
            UseCenterPos();
        }

        private void UseCenterPos()
        {
            cenPosX = Convert.ToDouble(nudX.Value);
            cenPosZ = Convert.ToDouble(nudZ.Value);
            Settings.Default.CenterPosX = cenPosX;
            Settings.Default.CenterPosZ = cenPosZ;
            Settings.Default.Save();
        }

        private double cenPosX = 0;
        private double cenPosZ = 0;

        /// <summary>
        /// Active Kinect sensor
        /// </summary>
        private KinectSensor sensor;

        private void Form1_Load(object sender, EventArgs e)
        {
            // KinectLaunch();
        }
        
        private int LastSentMode = -1;

        // private Skeleton[] skeletons;

        private Stopwatch stopwatch;

        private int minTime = 100;

        /// <summary>
        /// Event handler for Kinect sensor's SkeletonFrameReady event
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            if (stopwatch == null)
            {
                stopwatch = new Stopwatch();
                stopwatch.Start();
                return;
            }
            if (stopwatch.ElapsedMilliseconds < minTime)
            {
                Debug.Write("Skipped");
                return;
            }
            stopwatch.Restart();
            minTime = 100;
            
            Skeleton[] skeletons = new Skeleton[0];
            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                }
            }
            if (skeletons.Length == 0)
            {
                largeText.Text = "<>";
                return;
            }

            
            var okAnalysed = new List<SkeletonAnalysis>();
            foreach (var skeleton in skeletons)
            {
                var sk = new SkeletonAnalysis(skeleton);
                if (sk.AllOk())
                    okAnalysed.Add(sk);
            }


            if (!okAnalysed.Any())
            {
                largeText.Text = "<>";
                return;
            }
            var sortedList = okAnalysed.OrderBy(x=>x.DistanceFrom(cenPosX,cenPosZ)).ToList();

            SingleAnalysis(sortedList.FirstOrDefault());

            foreach (var skel in sortedList)
            {
                if (SingleAnalysis(skel)) 
                    return;
            }

            // check for InHands
            for (var i = 0; i < okAnalysed.Count; i++)
            {
                for (var iNext = i + 1; iNext < okAnalysed.Count; iNext++)
                {
                    if (!okAnalysed[i].InHand(okAnalysed[iNext])) 
                        continue;
                    largeText.Text = "InHand";
                    EnsureMode(8);
                    minTime = 3000;
                    return;
                }
            }

            // visual on screen
            var visualOnScreen = new StringBuilder();
            visualOnScreen.Append("<");
            foreach (var analysed in sortedList)
            {
                visualOnScreen.Append(analysed.Visual());
            }
            visualOnScreen.Append(">");
            largeText.Text = visualOnScreen.ToString();


            // send color command
            // todo: get the closer to the kinect only
            var txtCommand = new StringBuilder();
            foreach (var analysed in sortedList)
            {
                txtCommand.Append("," + ElevationToColor(analysed.LeftArmElevationRatio));
                txtCommand.Append("," + ElevationToColor(analysed.RightArmElevationRatio));
            }
            EnsureMode(22);
            voyageCommunicationControl1.Send(string.Format("@111,2{0}:", txtCommand)); // 2 parameters only

        }

        private bool SingleAnalysis(SkeletonAnalysis skel)
        {
            if (skel == null)
                return false;
            // check for OnHead
            if (skel.OnHead())
            {
                largeText.Text = "OnHead";
                EnsureMode(9);
                minTime = 5000;
                return true;
            }

            // check for SelfHand
            if (skel.SelfHand())
            {
                largeText.Text = "SelfHand";
                voyageCommunicationControl1.Send("@105,255,255,255:"); // set white
                EnsureMode(12);
                minTime = 2000;
                return true;
            }
            return false;
        }

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


        private void checkBoxSeatedMode_CheckedChanged(object sender, EventArgs e)
        {
            if (null == sensor)
                return;
            sensor.SkeletonStream.TrackingMode = checkBoxSeatedMode.Checked
                ? SkeletonTrackingMode.Seated
                : SkeletonTrackingMode.Default;
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

        private int iCount = 20;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (iCount == 5)
            {
                KinectLaunch();
            }

            lblSerial.Text = iCount.ToString();
            if (iCount == 0)
            {
                voyageCommunicationControl1.OpenSerial();
                timer1.Enabled = false;
            }
            iCount--;
        }

        private void voyageCommunicationControl1_Load(object sender, EventArgs e)
        {

        }

        private void SetCenter_Click(object sender, EventArgs e)
        {
            UseCenterPos();
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

        private void KinectLaunch()
        {
            // Create the drawing group we'll use for drawing
            //drawingGroup = new DrawingGroup();

            //// Create an image source that we can use in our image control
            //imageSource = new DrawingImage(drawingGroup);

            //// Display the drawing using our image control
            //Image.Source = imageSource;

            // Look through all sensors and start the first connected one.
            // This requires that a Kinect is connected at the time of app startup.
            // To make your app robust against plug/unplug, 
            // it is recommended to use KinectSensorChooser provided in Microsoft.Kinect.Toolkit (See components in Toolkit Browser).
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    sensor = potentialSensor;
                    break;
                }
            }

            if (null != sensor)
            {
                // Turn on the skeleton stream to receive skeleton frames
                sensor.SkeletonStream.Enable();

                // Add an event handler to be called whenever there is new color frame data
                sensor.SkeletonFrameReady += SensorSkeletonFrameReady;

                // Start the sensor!
                try
                {
                    sensor.Start();
                }
                catch (IOException)
                {
                    sensor = null;
                }
            }

            if (null == sensor)
            {
                largeText.Text = "Kinect not ready.";
            }
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
