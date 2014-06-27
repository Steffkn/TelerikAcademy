namespace Abstraction
{
    using System;

    /// <summary>
    /// Basic figure
    /// </summary>
    public abstract class Figure
    {
        public Figure()
        {
            this.Width = 0;
            this.Height = 0;
        }

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width { get; set; }

        public virtual double Height { get; set; }
    }
}
