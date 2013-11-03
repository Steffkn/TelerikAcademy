
public class Triangle : Shape
{
    // constructor
    public Triangle(double width, double height)
        : base(width, height)
    { }

    /// <summary>
    /// Calculates the surface of a triangle.
    /// </summary>
    /// <returns>Returns the surface of a triangle as double</returns>
    public override double CalculateSurface()
    {
        return ( Height * Width )/ 2;
    }
}

