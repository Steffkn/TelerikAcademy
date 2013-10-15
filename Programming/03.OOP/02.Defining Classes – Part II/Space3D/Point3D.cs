using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space3D
{
    // 1 structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 
    public struct Point3D : IPoint3D
    {
        private int pointX;
        private int pointY;
        private int pointZ;


        // property to return the point's x,y,z.
        public int PointX
        {
            get { return pointX; }
        }
        public int PointY
        {
            get { return pointY; }
        }
        public int PointZ
        {
            get { return pointZ; }
        }

        // structure's Point3D constructor
        public Point3D(int pointX, int pointY, int pointZ)
        {
            this.pointX = pointX;
            this.pointY = pointY;
            this.pointZ = pointZ;
        }

        // 2 private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. 
        private static readonly Point3D point0 = new Point3D(0, 0, 0);

        // 2 static property to return the point O.
        public static Point3D Point0
        {
            get { return Point3D.point0; }
        }

        // 1 Implementing the ToString() to enable printing a 3D point.
        public override string ToString()
        {
            return string.Format("Point[{0},{1},{2}]", pointX.ToString(), pointY.ToString(), pointZ.ToString());
        }
    }
}
