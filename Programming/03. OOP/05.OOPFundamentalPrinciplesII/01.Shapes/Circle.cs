public class Circle : Shape
{
    // constructor
    public Circle(double radius)
        : base(radius, radius) // height = width = radius
    {
    }
    /// <summary>
    /// Calculates the surface of a circle.
    /// </summary>
    /// <returns>Returns the surface of the circle as double</returns>
    public override double CalculateSurface()
    {
        return 3.141592 * Height * Height;
    }
}
