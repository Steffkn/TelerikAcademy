// Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height. 
// Define two new classes Triangle and Rectangle that implement the virtual method and 
// return the surface of the figure (height*width for rectangle and height*width/2 for triangle). 
// Define class Square and suitable constructor so that at initialization 
// height must be kept equal to width and implement the CalculateSurface() method. 
// Write a program that tests the behavior of the CalculateSurface() method 
// for different shapes (Square, Rectangle, Triangle) stored in an array.

using System;
class TestShapes
{
    static void Main()
    {
        // define few shapes
        Triangle triangle = new Triangle(3, 4);
        Rectangle rectangle = new Rectangle(4,5);
        Square square = new Square(4);

        // call for the CalculateSurface method for all the shapes
        Console.WriteLine(triangle.CalculateSurface());
        Console.WriteLine(rectangle.CalculateSurface());
        Console.WriteLine(square.CalculateSurface());
    }
}

