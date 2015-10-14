using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;
using Microsoft.Kinect;

namespace SkeletonWinforms
{
    internal class SkeletonAnalysis
    {
        private Skeleton _skeleton;
        private HandAnalysis leftHand;
        private HandAnalysis rightHand;
        private HeadAnalysis head;

        public SkeletonAnalysis(Skeleton skeleton)
        {
            _skeleton = skeleton;
            LeftArmElevationRatio = double.NaN;
            RightArmElevationRatio = double.NaN;
            ElevationOk = false;
            HandsOk = false;
            HeadOk = false;

            if (IsTracking(JointType.WristLeft, JointType.WristRight))
            {

                if (
                    IsTracking(JointType.Spine, JointType.ShoulderCenter) &&
                    IsTracking(JointType.ShoulderLeft, JointType.ElbowLeft ) &&
                    IsTracking(JointType.ShoulderRight, JointType.ElbowRight)
                    )
                {
                    var spine = FromJoints(JointType.Spine, JointType.ShoulderCenter);
                    spine.Normalize();
                    var leftForeArm = FromJoints(JointType.ElbowLeft, JointType.WristLeft);
                    var rightForeArm = FromJoints(JointType.ElbowRight, JointType.WristRight);
                    var leftComp = Vector3D.DotProduct(leftForeArm, spine);
                    var rightComp = Vector3D.DotProduct(rightForeArm, spine);

                    LeftArmElevationRatio = leftComp/leftForeArm.Length;
                    RightArmElevationRatio = rightComp/rightForeArm.Length;
                    ElevationOk = true;
                }

                if (IsTracking(JointType.HandLeft, JointType.HandRight))
                {
                    leftHand = new HandAnalysis(skeleton.Joints[JointType.WristLeft], _skeleton.Joints[JointType.HandLeft]);
                    rightHand = new HandAnalysis(skeleton.Joints[JointType.WristRight], _skeleton.Joints[JointType.HandRight]);
                    HandsOk = true;
                }

                if (IsTracking(JointType.Head))
                {
                    head = new HeadAnalysis(skeleton.Joints[JointType.Head], skeleton.Joints[JointType.ShoulderCenter]);
                    HeadOk = true;
                }
            }
        }

        private Vector3D FromJoints(JointType jointType1, JointType jointType2)
        {
            var joint1 = _skeleton.Joints[jointType1];
            var joint2 = _skeleton.Joints[jointType2];
            return new Vector3D(
                joint2.Position.X - joint1.Position.X, 
                joint2.Position.Y - joint1.Position.Y, 
                joint2.Position.Z - joint1.Position.Z 
                );
        }

        public bool ElevationOk { get; private set; }
        public bool HandsOk { get; private set; }
        public bool HeadOk { get; private set; }
        

        public double LeftArmElevationRatio { get; private set; }

        public double RightArmElevationRatio { get; private set; }

        public string Visual()
        {
            return String.Concat(LeftArmElevationRatio.ToString("#.#"), " ", RightArmElevationRatio.ToString("#.#"));
        }

        private bool IsTracking(params JointType[] joints)
        {
            foreach (var jointType in joints)
            {
                var joint = _skeleton.Joints[jointType];
                if (joint.TrackingState == JointTrackingState.NotTracked)
                    return false;
            }
            return true;
        }

        public bool AllOk()
        {
            return ElevationOk && HandsOk;
        }

        public bool InHand(SkeletonAnalysis other)
        {
            return leftHand.InHand(other.rightHand) || rightHand.InHand(other.leftHand);
        }

        public bool OnHead()
        {
            return leftHand.OnHead(head) && rightHand.OnHead(head);
        }

        public bool SelfHand()
        {
            return leftHand.InHand(rightHand);
        }
    }
}
