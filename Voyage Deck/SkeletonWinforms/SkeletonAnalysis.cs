using System;
using System.Windows.Media.Media3D;
using Microsoft.Kinect;

namespace SkeletonWinforms
{
    internal class SkeletonAnalysis
    {
        private readonly Skeleton _skeleton;
        private readonly HandAnalysis _leftHand;
        private readonly HandAnalysis _rightHand;
        private readonly HeadAnalysis _head;
        private Joint _distanceCalcPoint;

        public SkeletonAnalysis(Skeleton skeleton)
        {
            _skeleton = skeleton;
            LeftForeArmElevationRatio = double.NaN;
            RightForeArmElevationRatio = double.NaN;
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

                    LeftForeArmElevationRatio = leftComp/leftForeArm.Length;
                    RightForeArmElevationRatio = rightComp/rightForeArm.Length;
                    ElevationOk = true;
                }

                if (IsTracking(JointType.HandLeft, JointType.HandRight))
                {
                    _leftHand = new HandAnalysis(skeleton.Joints[JointType.WristLeft], _skeleton.Joints[JointType.HandLeft]);
                    _rightHand = new HandAnalysis(skeleton.Joints[JointType.WristRight], _skeleton.Joints[JointType.HandRight]);
                    HandsOk = true;
                }

                if (IsTracking(JointType.Head))
                {
                    _head = new HeadAnalysis(skeleton.Joints[JointType.Head], skeleton.Joints[JointType.ShoulderCenter]);
                    HeadOk = true;
                }
            }

            if (IsTracking(JointType.Head))
            {
                _distanceCalcPoint = skeleton.Joints[JointType.Head];
            }
        }

        private static Vector3D FromPoints(SkeletonPoint pos1, SkeletonPoint pos2)
        {
            return new Vector3D(
                pos2.X - pos1.X,
                pos2.Y - pos1.Y,
                pos2.Z - pos1.Z
                );
        }

        private Vector3D FromJoints(JointType jointType1, JointType jointType2)
        {
            var joint1 = _skeleton.Joints[jointType1];
            var joint2 = _skeleton.Joints[jointType2];
            return FromPoints(joint1.Position, joint2.Position);
        }

        public bool ElevationOk { get; private set; }
        public bool HandsOk { get; private set; }
        public bool HeadOk { get; private set; }
        

        public double LeftForeArmElevationRatio { get; private set; }

        public double RightForeArmElevationRatio { get; private set; }

        public string VisualText()
        {
            // return String.Concat(LeftArmElevationRatio.ToString("#.#"), " ", RightArmElevationRatio.ToString("#.#"));
            return string.Concat(
                _distanceCalcPoint.Position.X.ToString("##.000"), " ",
                _distanceCalcPoint.Position.Y.ToString("##.000"), " ",
                _distanceCalcPoint.Position.Z.ToString("##.000"), " "
                );

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
            return _leftHand.InHand(other._rightHand) || _rightHand.InHand(other._leftHand);
        }

        public bool OnHead()
        {
            return _leftHand.OnHead(_head) && _rightHand.OnHead(_head);
        }

        public enum SelfHandMode
        {
            Undefined,
            Not,
            Centry,
            Lefty,
            Righty
        }

        SelfHandMode _selfHandMode = SelfHandMode.Undefined;

        public bool SelfHand()
        {
            var selfHand = _leftHand.InHand(_rightHand);
            if (!selfHand)
            {
                _selfHandMode = SelfHandMode.Not;
                return false;
            }
            if (!ElevationOk) 
                return true;
            // here's where we compute the leftiness/rightiness of the self hand
            var midWrist = MidPoint(_skeleton.Joints[JointType.WristLeft], _skeleton.Joints[JointType.WristRight]);
            var midShoulder = MidPoint(_skeleton.Joints[JointType.ShoulderLeft], _skeleton.Joints[JointType.ShoulderRight]);

            var midHandVector = FromPoints(midShoulder, midWrist);
            var midShoulderRightVector = FromPoints(midShoulder, _skeleton.Joints[JointType.ShoulderRight].Position);

            // todo: check here for thresholds of centerness
            var posComp = Vector3D.DotProduct(midHandVector, midShoulderRightVector);
            
            _selfHandMode = posComp < 0 
                ? SelfHandMode.Lefty 
                : SelfHandMode.Righty;

            return true;
        }

        private SkeletonPoint MidPoint(Joint joint1, Joint joint2)
        {
            var p = new SkeletonPoint
            {
                X = (joint1.Position.X + joint2.Position.X)/2,
                Y = (joint1.Position.Y + joint2.Position.Y)/2,
                Z = (joint1.Position.Z + joint2.Position.Z)/2
            };
            return p;
        }

        /// <summary>
        /// Computes and returns 2D distance from required points (ignores elevation Y)
        /// </summary>
        internal double DistanceFrom(double cenPosX, double cenPosZ)
        {
            return Math.Sqrt(
                Math.Pow(_distanceCalcPoint.Position.X - cenPosX, 2) +
                Math.Pow(_distanceCalcPoint.Position.Z - cenPosZ, 2)
                );
        }
    }
}
