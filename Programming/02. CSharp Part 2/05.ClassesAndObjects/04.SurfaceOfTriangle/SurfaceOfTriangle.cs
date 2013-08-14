// Write methods that calculate the surface of a triangle by given:
// Side and an altitude to it; 
// Three sides; 
// Two sides and an angle between them. Use System.Math.

using System;
class Triangle
{
    private double surface;

    /// <summary>
    /// Constructor that will be
    /// </summary>
    /// <param name="side"></param>
    /// <param name="altitude"></param>
    public Triangle(double side, double altitude)
    {
        this.surface = side * altitude / 2;
    }
    /// <summary>
    /// Constructor that will be called if tree sides of the triangle are given. (tree double vars)
    /// </summary>
    /// <param name="sideA">Side A (BC)</param>
    /// <param name="sideB">Side B (AC)</param>
    /// <param name="sideC">Side C (AB)</param>
    public Triangle(double sideA, double sideB, double sideC)
    {
        double p = (sideA + sideB + sideC) / 2;
        // formula: S = sqrt(p*(p-A)*(p-B)*(p-C))
        this.surface = p; //Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
    }

    /// <summary>
    /// Constructor that will be called if 2 sides are given and an angle (integer)
    /// </summary>
    /// <param name="sideA">Side A (BC)</param>
    /// <param name="altitude">Altitude of A (AH)</param>
    /// <param name="angle">angle between them (degrees)</param>
    public Triangle(double sideA, double altitude, int angle)
    {
        this.surface = (sideA * altitude * Math.Sign(angle)) / 2;
    }

    /// <summary>
    /// Nethod that will return the surface.
    /// </summary>
    /// <returns>Returns the surface of the triangle</returns>
    public double GetSurface()
    {
        return surface;
    }
}
class SurfaceOfTriangle
{
    static void Main()
    {

        Triangle triangle1 = new Triangle(3, 4, 5.0);
        Triangle triangle2 = new Triangle(3, 4, 90);
        Triangle triangle3 = new Triangle(3, 4);
        Console.WriteLine(triangle1.GetSurface());
        Console.WriteLine(triangle2.GetSurface());
        Console.WriteLine(triangle3.GetSurface());

    }
}

