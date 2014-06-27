namespace CohesionAndCoupling
{
    using System;

    public static class Prismatoid
    {
        private static double width;

        private static double height;

        private static double depth;

        public static double Width
        {
            get
            {
                return width;
            }

            set
            {
                if (value >= 0)
                {
                    width = value;
                }
                else
                {
                    throw new ArgumentException("Invalid value for width!");
                }
            }
        }

        public static double Height
        {
            get
            {
                return height;
            }

            set
            {
                if (value >= 0)
                {
                    height = value;
                }
                else
                {
                    throw new ArgumentException("Invalid value for height!");
                }
            }
        }

        public static double Depth
        {
            get
            {
                return depth;
            }

            set
            {
                if (value >= 0)
                {
                    depth = value;
                }
                else
                {
                    throw new ArgumentException("Invalid value for depth!");
                }
            }
        }

        public static double CalcVolume()
        {
            double volume = Width * Height * Depth;
            return volume;
        }

        public static double CalcDiagonalXYZ()
        {
            double distance = GeometryMath.CalcDistance3D(0, 0, 0, Width, Height, Depth);
            return distance;
        }

        public static double CalcDiagonalXY()
        {
            double distance = GeometryMath.CalcDistance2D(0, 0, Width, Height);
            return distance;
        }

        public static double CalcDiagonalXZ()
        {
            double distance = GeometryMath.CalcDistance2D(0, 0, Width, Depth);
            return distance;
        }

        public static double CalcDiagonalYZ()
        {
            double distance = GeometryMath.CalcDistance2D(0, 0, Height, Depth);
            return distance;
        }
    }
}
