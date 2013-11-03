
public abstract class Shape
{
    // fields
    private double width;
    private double height;

    // properties
    public double Width
    {
        get { return width; }
        set { width = value; }
    }
    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    // constructor
    /// <summary>
    /// Take the dimensions of the shape
    /// </summary>
    /// <param name="width">Width of the shape.</param>
    /// <param name="height">Height of the shape.</param>
    public Shape(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    /// <summary>
    /// Abstract method for calculating the surface of the shape by given height and widht.
    /// </summary>
    /// <returns>Returns the surface of a shape as double.</returns>
    public abstract double CalculateSurface();
}

