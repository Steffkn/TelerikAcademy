namespace Abstraction
{
    using System;

    /// <summary>
    /// Basic rectangle
    /// </summary>
    public class Rectangle : Figure
    {
        public Rectangle()
            : base(0, 0)
        {
        }

        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        /// <summary>
        /// Calculates the perimeter of the rectangle
        /// </summary>
        /// <returns>Returns the perimeter of the rectangle as double</returns>
        public double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        /// <summary>
        /// Calculates the surface of the rectangle
        /// </summary>
        /// <returns>Returns the surface of the rectangle as double</returns>
        public double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
