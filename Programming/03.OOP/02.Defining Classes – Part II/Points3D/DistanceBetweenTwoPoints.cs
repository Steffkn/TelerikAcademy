using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space3D
{
    public static class DistanceBetweenTwoPoints
    {
        static double DistanceBetween2Points(Point3D pointA, Point3D pointB ) 
        {
            // points A and B2 have same Z value so that we can calculate the distance between them
            Point3D pointB2 = new Point3D(pointB.PointX , pointB.PointY , pointA.PointZ);

            // pitagor SquareDistanceAB2 = x*x + y*y
            int SquareDistanceAB2 = (pointB.PointX - pointA.PointX) * (pointB.PointX - pointA.PointX) + (pointB.PointY - pointA.PointY) * (pointB.PointY - pointA.PointY);
            // we need the distance B to B2
            int SquareDistanceBB2 = (pointB.PointZ - pointB2.PointZ) * (pointB.PointZ - pointB2.PointZ);
            
            // return pitagor for A B2 B
            return Math.Sqrt(SquareDistanceAB2 + SquareDistanceBB2);
        }
    }
}
