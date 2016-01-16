
public class Rectangle : Shape
{
    // constructor
    public Rectangle(double width, double height)
        : base(width, height)
    {
    }
    /// <summary>
    /// Calculates the surface of a rectangle.
    /// </summary>
    /// <returns>Returns the surface of a rectangle as double.</returns>
    public override double CalculateSurface()
    {
        return this.Height * this.Width;
    }
}

