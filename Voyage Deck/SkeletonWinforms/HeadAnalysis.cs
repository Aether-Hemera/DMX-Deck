using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;
using Microsoft.Kinect;

namespace SkeletonWinforms
{
    class HeadAnalysis
    {
        public Point3D Center;
        public double Radius;
        
        public HeadAnalysis(Joint head, Joint shoulderCenter)
        {
            Center = new Point3D(
                (shoulderCenter.Position.X + head.Position.X) / 2,
                (shoulderCenter.Position.Y + head.Position.Y) / 2,
                (shoulderCenter.Position.Z + head.Position.Z) / 2
                );
            Radius = Math.Sqrt(
                    Math.Pow(shoulderCenter.Position.X - head.Position.X, 2) +
                    Math.Pow(shoulderCenter.Position.Y - head.Position.Y, 2) +
                    Math.Pow(shoulderCenter.Position.Z - head.Position.Z, 2)) / 2;
        }

        public bool InHand(HandAnalysis otherHand)
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
