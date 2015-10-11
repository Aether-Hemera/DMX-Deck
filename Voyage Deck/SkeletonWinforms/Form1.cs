using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Kinect;

namespace SkeletonWinforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Active Kinect sensor
        /// </summary>
        private KinectSensor sensor;


        private void Form1_Load(object sender, EventArgs e)
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
                statusBarText.Text = "Kinect not ready.";
            }
        }

        

        // private Skeleton[] skeletons;

        private Stopwatch stopwatch;

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
            if (stopwatch.ElapsedMilliseconds < 100)
                return;           
            stopwatch.Restart();
            
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
                label1.Text = "<>";
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
                label1.Text = "<>";
                return;
            }

            for (var i = 0; i < okAnalysed.Count; i++)
            {
                for (var iNext = i + 1; iNext < okAnalysed.Count; iNext++)
                {
                    if (!okAnalysed[i].InHand(okAnalysed[iNext])) 
                        continue;
                    label1.Text = "InHand";
                    return;
                }
            }


            var sortedList = okAnalysed.ToList();
            
            var txt = new StringBuilder();
            var txtCommand = new StringBuilder();
            txt.Append("<");
            
            foreach (var arm in sortedList)
            {
                txtCommand.Append("," + ElevationToColor(arm.LeftArmElevationRatio));
                txtCommand.Append("," + ElevationToColor(arm.RightArmElevationRatio)); 
                txt.Append(arm.Visual());
            }
            txt.Append(">");

            label1.Text = txt.ToString();
            voyageCommunicationControl1.Send(string.Format("@111,{0}{1}:", sortedList.Count, txtCommand.ToString()));
        }

        private static int ElevationToColor(double v)
        {
            var value = Convert.ToInt32((v*120));
            if (value < 0)
                value += 360;
            return value;
        }


        private void checkBoxSeatedMode_CheckedChanged(object sender, EventArgs e)
        {
            if (null == sensor)
                return;
            sensor.SkeletonStream.TrackingMode = checkBoxSeatedMode.Checked
                ? SkeletonTrackingMode.Seated
                : SkeletonTrackingMode.Default;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (null != sensor)
            {
                sensor.Stop();
            }
        }
    }
}
