public class Square : Shape
{
    // constructor
    public Square(double width)
        : base(width, width) // height = width
    {
    }
    /// <summary>
    /// Calculates the surface of a square.
    /// </summary>
    /// <returns>Returns the surface of the square as double</returns>
    public override double CalculateSurface()
    {
        return this.Width * this.Width;
    }
}
