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
        /// Width of output drawing
        /// </summary>
        private const int RenderWidth = 640;

        /// <summary>
        /// Height of our output drawing
        /// </summary>
        private const int RenderHeight = 480;

        /// <summary>
        /// Thickness of drawn joint lines
        /// </summary>
        private const int JointThickness = 3;

        /// <summary>
        /// Thickness of body center ellipse
        /// </summary>
        private const int BodyCenterThickness = 10;

        /// <summary>
        /// Thickness of clip edge rectangles
        /// </summary>
        private const int ClipBoundsThickness = 10;

        /// <summary>
        /// Brush used to draw skeleton center point
        /// </summary>
        private readonly Brush centerPointBrush = Brushes.Blue;

        /// <summary>
        /// Brush used for drawing joints that are currently tracked
        /// </summary>
        private readonly Brush trackedJointBrush = new SolidBrush(Color.FromArgb(255, 68, 192, 68));

        /// <summary>
        /// Brush used for drawing joints that are currently inferred
        /// </summary>        
        private readonly Brush inferredJointBrush = Brushes.Yellow;

        /// <summary>
        /// Pen used for drawing bones that are currently tracked
        /// </summary>
        private readonly Pen trackedBonePen = new Pen(Brushes.Green, 6);

        /// <summary>
        /// Pen used for drawing bones that are currently inferred
        /// </summary>        
        private readonly Pen inferredBonePen = new Pen(Brushes.Gray, 1);

        /// <summary>
        /// Active Kinect sensor
        /// </summary>
        private KinectSensor sensor;

        /// <summary>
        /// Draws indicators to show which edges are clipping skeleton data
        /// </summary>
        /// <param name="skeleton">skeleton to draw clipping information for</param>
        /// <param name="drawingContext">drawing context to draw to</param>
        private static void RenderClippedEdges(Skeleton skeleton, Graphics drawingContext)
        {
            if (skeleton.ClippedEdges.HasFlag(FrameEdges.Bottom))
            {
                drawingContext.DrawRectangle(
                    Pens.Red,
                    new Rectangle(0, RenderHeight - ClipBoundsThickness, RenderWidth, ClipBoundsThickness));
            }

            if (skeleton.ClippedEdges.HasFlag(FrameEdges.Top))
            {
                drawingContext.DrawRectangle(
                    Pens.Red,
                    new Rectangle(0, 0, RenderWidth, ClipBoundsThickness));
            }

            if (skeleton.ClippedEdges.HasFlag(FrameEdges.Left))
            {
                drawingContext.DrawRectangle(
                    Pens.Red,
                    new Rectangle(0, 0, ClipBoundsThickness, RenderHeight));
            }

            if (skeleton.ClippedEdges.HasFlag(FrameEdges.Right))
            {
                drawingContext.DrawRectangle(
                    Pens.Red,
                    new Rectangle(RenderWidth - ClipBoundsThickness, 0, ClipBoundsThickness, RenderHeight));
            }
        }

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

        class ArmInWave
        {
            public double elevationRatio;
            public double xOnScreen;
            public double Len;
            public double DElevation;

            public string Visual
            {
                get
                {
                    // return DElevation.ToString("#.##");
                    return elevationRatio.ToString("#.##");

                    if (elevationRatio > 0)
                        return "U";
                    return "D";
                }
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
            List<ArmInWave> arms = new List<ArmInWave>();

            foreach (var skeleton in skeletons)
            {
                var leftArm = getArm(skeleton, JointType.ShoulderLeft, JointType.ElbowLeft, JointType.HandLeft);
                if (leftArm != null)
                {
                    arms.Add(leftArm);
                }
                var rightArm = getArm(skeleton, JointType.ShoulderRight, JointType.ElbowRight, JointType.HandRight);
                if (rightArm != null)
                {
                    arms.Add(rightArm);
                }


                if (false)
                {
                    //bool leftArm = IsTrackingArm(skeleton, JointType.ShoulderLeft, JointType.ElbowLeft,
                    //    JointType.HandLeft);
                    //bool rightArm = IsTrackingArm(skeleton, JointType.ShoulderRight, JointType.ElbowRight,
                    //    JointType.HandRight);

                    //if (leftArm)
                    //    arms++;

                    //if (rightArm)
                    //    arms++;
                }
                // Joint joint0 = skeleton.Joints[jointType0];
                // Joint joint1 = skeleton.Joints[jointType1];

                // Left Arm

            }
            if (!arms.Any())
            {
                label1.Text = "<>";
                return;
            }

            var sortedList = arms.OrderBy(o => o.xOnScreen).ToList();
            
            var txt = new StringBuilder();
            var txtCommand = new StringBuilder();
            txt.Append("<");
            
            foreach (var arm in sortedList)
            {
                txtCommand.Append("," + Convert.ToInt32((arm.elevationRatio + 1)*180));
                txt.Append(arm.Visual);
            }
            txt.Append(">");

            label1.Text = txt.ToString();
            voyageCommunicationControl1.Send(string.Format("@111,{0}{1}:", sortedList.Count, txtCommand.ToString()));
            return;

            MethodInvoker methodInvokerDelegate = delegate()
            {
                using (Graphics dc = pictureBox1.CreateGraphics())
                {
                    // Draw a transparent background to set the render size
                    dc.DrawRectangle(Pens.Red, new Rectangle(0, 0, RenderWidth, RenderHeight));

                    if (skeletons.Length != 0)
                    {
                        foreach (Skeleton skel in skeletons)
                        {
                            RenderClippedEdges(skel, dc);

                            if (skel.TrackingState == SkeletonTrackingState.Tracked)
                            {
                                DrawBonesAndJoints(skel, dc);
                            }
                            else if (skel.TrackingState == SkeletonTrackingState.PositionOnly)
                            {
                                // todo: ellipse?
                                // dc.DrawEllipse(centerPointBrush, null, SkeletonPointToScreen(skel.Position), BodyCenterThickness, BodyCenterThickness);
                            }
                        }
                    }
                    
                    // prevent drawing outside of our render area
                    // drawingGroup.ClipGeometry = new RectangleGeometry(new Rect(0.0, 0.0, RenderWidth, RenderHeight));
                }
            };

            //This will be true if Current thread is not UI thread.
            if (this.InvokeRequired)
                this.Invoke(methodInvokerDelegate);
            else
                methodInvokerDelegate();
            
        }

        private ArmInWave getArm(Skeleton skeleton, JointType shoulder, JointType elbow, JointType hand)
        {
            Joint jointShoulder = skeleton.Joints[shoulder];
            Joint jointElbow = skeleton.Joints[elbow];
            Joint jointHand = skeleton.Joints[hand];

            // If we can't find either of these joints, exit
            if (jointHand.TrackingState == JointTrackingState.NotTracked ||
                jointElbow.TrackingState == JointTrackingState.NotTracked)
            {
                return null;
            }
            
            var foreArmLen = GetDistance(jointHand, jointElbow);
            var dElevation = jointHand.Position.Y - jointElbow.Position.Y;

            var p = SkeletonPointToScreen(jointHand.Position);
            var ret = new ArmInWave
            {
                Len = foreArmLen,
                DElevation = dElevation,
                elevationRatio = dElevation/foreArmLen,
                xOnScreen = p.X
            };

            return ret;
        }

        private double GetDistance(Joint joint1, Joint joint2)
        {
            return Math.Sqrt(
                Math.Pow(joint1.Position.X - joint2.Position.X, 2) +
                Math.Pow(joint1.Position.Y - joint2.Position.Y, 2) +
                Math.Pow(joint1.Position.Z - joint2.Position.Z, 2)
                );

        }

        private bool IsTrackingArm(Skeleton skeleton, JointType shoulder, JointType elbow, JointType hand)
        {
            Joint jointShoulder = skeleton.Joints[shoulder];
            Joint jointElbow = skeleton.Joints[elbow];
            Joint jointHand = skeleton.Joints[hand];

            // If we can't find either of these joints, exit
            if (jointHand.TrackingState == JointTrackingState.NotTracked ||
                jointElbow.TrackingState == JointTrackingState.NotTracked)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Draws a skeleton's bones and joints
        /// </summary>
        /// <param name="skeleton">skeleton to draw</param>
        /// <param name="drawingContext">drawing context to draw to</param>
        private void DrawBonesAndJoints(Skeleton skeleton, Graphics drawingContext)
        {
            // Render Torso
            DrawBone(skeleton, drawingContext, JointType.Head, JointType.ShoulderCenter);
            DrawBone(skeleton, drawingContext, JointType.ShoulderCenter, JointType.ShoulderLeft);
            DrawBone(skeleton, drawingContext, JointType.ShoulderCenter, JointType.ShoulderRight);
            DrawBone(skeleton, drawingContext, JointType.ShoulderCenter, JointType.Spine);
            DrawBone(skeleton, drawingContext, JointType.Spine, JointType.HipCenter);
            DrawBone(skeleton, drawingContext, JointType.HipCenter, JointType.HipLeft);
            DrawBone(skeleton, drawingContext, JointType.HipCenter, JointType.HipRight);

            // Left Arm
            DrawBone(skeleton, drawingContext, JointType.ShoulderLeft, JointType.ElbowLeft);
            DrawBone(skeleton, drawingContext, JointType.ElbowLeft, JointType.WristLeft);
            DrawBone(skeleton, drawingContext, JointType.WristLeft, JointType.HandLeft);

            // Right Arm
            DrawBone(skeleton, drawingContext, JointType.ShoulderRight, JointType.ElbowRight);
            DrawBone(skeleton, drawingContext, JointType.ElbowRight, JointType.WristRight);
            DrawBone(skeleton, drawingContext, JointType.WristRight, JointType.HandRight);

            // Left Leg
            DrawBone(skeleton, drawingContext, JointType.HipLeft, JointType.KneeLeft);
            DrawBone(skeleton, drawingContext, JointType.KneeLeft, JointType.AnkleLeft);
            DrawBone(skeleton, drawingContext, JointType.AnkleLeft, JointType.FootLeft);

            // Right Leg
            DrawBone(skeleton, drawingContext, JointType.HipRight, JointType.KneeRight);
            DrawBone(skeleton, drawingContext, JointType.KneeRight, JointType.AnkleRight);
            DrawBone(skeleton, drawingContext, JointType.AnkleRight, JointType.FootRight);
 
            // Render Joints
            foreach (Joint joint in skeleton.Joints)
            {
                Brush drawBrush = null;

                if (joint.TrackingState == JointTrackingState.Tracked)
                {
                    drawBrush = trackedJointBrush;                    
                }
                else if (joint.TrackingState == JointTrackingState.Inferred)
                {
                    drawBrush = inferredJointBrush;                    
                }

                if (drawBrush != null)
                {
                    // todo: draw ellipse?
                    // drawingContext.DrawEllipse(drawBrush, null, SkeletonPointToScreen(joint.Position), JointThickness, JointThickness);
                }
            }
        }

        /// <summary>
        /// Maps a SkeletonPoint to lie within our render space and converts to Point
        /// </summary>
        /// <param name="skelpoint">point to map</param>
        /// <returns>mapped point</returns>
        private Point SkeletonPointToScreen(SkeletonPoint skelpoint)
        {
            // Convert point to depth space.  
            // We are not using depth directly, but we do want the points in our 640x480 output resolution.
            DepthImagePoint depthPoint = sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(skelpoint, DepthImageFormat.Resolution640x480Fps30);
            return new Point(depthPoint.X, depthPoint.Y);
        }

        /// <summary>
        /// Draws a bone line between two joints
        /// </summary>
        /// <param name="skeleton">skeleton to draw bones from</param>
        /// <param name="drawingContext">drawing context to draw to</param>
        /// <param name="jointType0">joint to start drawing from</param>
        /// <param name="jointType1">joint to end drawing at</param>
        private void DrawBone(Skeleton skeleton, Graphics drawingContext, JointType jointType0, JointType jointType1)
        {
            Joint joint0 = skeleton.Joints[jointType0];
            Joint joint1 = skeleton.Joints[jointType1];

            // If we can't find either of these joints, exit
            if (joint0.TrackingState == JointTrackingState.NotTracked ||
                joint1.TrackingState == JointTrackingState.NotTracked)
            {
                return;
            }

            // Don't draw if both points are inferred
            if (joint0.TrackingState == JointTrackingState.Inferred &&
                joint1.TrackingState == JointTrackingState.Inferred)
            {
                return;
            }

            // We assume all drawn bones are inferred unless BOTH joints are tracked
            Pen drawPen = inferredBonePen;
            if (joint0.TrackingState == JointTrackingState.Tracked && joint1.TrackingState == JointTrackingState.Tracked)
            {
                drawPen = trackedBonePen;
            }

            drawingContext.DrawLine(drawPen, SkeletonPointToScreen(joint0.Position), SkeletonPointToScreen(joint1.Position));
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

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
