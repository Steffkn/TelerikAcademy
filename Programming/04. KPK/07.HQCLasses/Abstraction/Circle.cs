namespace Abstraction
{
    using System;

    /// <summary>
    /// Basic circle
    /// </summary>
    public class Circle : Figure
    {
        public Circle()
        {
            this.Radius = 0;
        }

        public Circle(double radius)
        {
            this.Radius = radius;
        }
        
        public double Radius { get; set; }
        
        public double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
