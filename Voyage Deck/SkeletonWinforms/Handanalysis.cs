using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;
using Microsoft.Kinect;

namespace SkeletonWinforms
{
    class Handanalysis
    {
        public Point3D Center;
        public double Radius;
        
        public Handanalysis(Joint wristJoint, Joint handJoint)
        {
            Center = new Point3D(
                (wristJoint.Position.X + handJoint.Position.X) / 2,
                (wristJoint.Position.Y + handJoint.Position.Y) / 2,
                (wristJoint.Position.Z + handJoint.Position.Z) / 2
                );
            Radius = Math.Sqrt(
                    Math.Pow(wristJoint.Position.X - handJoint.Position.X, 2) +
                    Math.Pow(wristJoint.Position.Y - handJoint.Position.Y, 2) +
                    Math.Pow(wristJoint.Position.Z - handJoint.Position.Z, 2)) / 2;
        }

        public bool InHand(Handanalysis otherHand)
        {
            var dist = Math.Sqrt(
                    Math.Pow(Center.X - otherHand.Center.X, 2) +
                    Math.Pow(Center.Y - otherHand.Center.Y, 2) +
                    Math.Pow(Center.Z - otherHand.Center.Z, 2));
            var threshold = 2 * (Radius + otherHand.Radius);
            Debug.Print("dist: {0}, threshold: {1}", dist, threshold);
            return dist < threshold;
        }
    }
}
