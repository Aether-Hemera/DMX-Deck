using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Kinect;

namespace SkeletonWinforms
{
    public partial class frmMain
    {
        /// <summary>
        /// Active Kinect sensor
        /// </summary>
        private KinectSensor sensor;

        private void checkBoxSeatedMode_CheckedChanged(object sender, EventArgs e)
        {
            if (null == sensor)
                return;
            sensor.SkeletonStream.TrackingMode = checkBoxSeatedMode.Checked
                ? SkeletonTrackingMode.Seated
                : SkeletonTrackingMode.Default;
        }

        private int minTime = 100;

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
            if (stopwatch.ElapsedMilliseconds < minTime)
            {
                // Debug.Write("Skipped");
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
            var sortedList = okAnalysed.OrderBy(x => x.DistanceFrom(_userCenterPosX, _userCenterPosZ)).ToList();
            var closestSkeleton = sortedList.FirstOrDefault();
            if (closestSkeleton == null)
            {
                largeText.Text = "<>";
                return;
            }
            // test the behaviour of the first skeleton
            if (SingleActionCapturedFor(closestSkeleton))
                return;
                
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

            // test specific behaviours in others.
            if (false)
            {
                if (sortedList.Any(SingleActionCapturedFor))
                {
                    return;
                }
            }

            // visual on screen
            var visualOnScreen = new StringBuilder();
            visualOnScreen.Append("<");
            foreach (var analysed in sortedList)
            {
                visualOnScreen.Append(analysed.VisualText());
            }
            visualOnScreen.Append(">");
            largeText.Text = visualOnScreen.ToString();

            // we have got one skeleton, and no specific actions... 
            // then send color command
            var txtCommand = new StringBuilder();
            txtCommand.AppendFormat(",{0}", ElevationToColor(closestSkeleton.LeftForeArmElevationRatio));
            txtCommand.AppendFormat(",{0}", ElevationToColor(closestSkeleton.RightForeArmElevationRatio));
            
            // this will only happen if not 22 yet
            EnsureMode(22);
            voyageCommunicationControl1.Send(string.Format("@111,2{0}:", txtCommand)); 

        }

        private bool SingleActionCapturedFor(SkeletonAnalysis skel)
        {
            if (skel == null)
                return false;

            if (skel.OnHips())
            {
                largeText.Text = "OnHips";
                EnsureMode(25); // stars
                minTime = 500;
                return true;
            }

            if (skel.OverHead())
            {
                largeText.Text = "OverHead";
                EnsureMode(10); // stars
                minTime = 500;
                return true;
            }

            // check for OnHead
            if (skel.OnHead())
            {
                largeText.Text = "OnHead";
                EnsureMode(9); // fireworks
                minTime = 500;
                return true;
            }

            // check for SelfHand
            if (skel.SelfHand())
            {
                largeText.Text = "SelfHand : " + skel.SelfHandCurrent; // + " " + skel.posComp;
                if (skel.SelfHandCurrent == SkeletonAnalysis.SelfHandMode.Lefty)
                {
                    // voyageCommunicationControl1.Send("@105,255,255,255:"); // set white
                    EnsureMode(23);
                    minTime = 500;
                    return true;
                }
                if (skel.SelfHandCurrent == SkeletonAnalysis.SelfHandMode.Righty)
                {
                    // voyageCommunicationControl1.Send("@105,255,255,255:"); // set white
                    EnsureMode(24);
                    minTime = 500;
                    return true;
                }
            }
            return false;
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
    }
}
