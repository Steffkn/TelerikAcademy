// Write a program that reads the radius r of a circle and prints its perimeter and area.

using System;
class CalcAreaAndPerimeterCircle
{
    static void Main()
    {
        Console.Write("Enter the radius of the circle: ");
        // declaring the radius var
        double radius; 
        // checking for correct input
        if( double.TryParse(Console.ReadLine(), out radius) )
        {
            Console.WriteLine("Properties of the circle with radius = {0}:", radius);
            Console.WriteLine("Perimeter = {0}", 2 * 3.1415 * radius);      // calculating and showing the perimeter of the circle
            Console.WriteLine("Area = {0}", 3.1415 * radius * radius);      // calculating and showing the area of the circle
        }
        else
        {
            // error message for NaN input
            Console.WriteLine("Invalid input!!");
        }

    }

}
