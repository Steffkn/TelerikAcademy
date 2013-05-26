// Create a program that assigns null values to an integer and to double 
// variables. Try to print them on the console, try to add some values 
// or the null literal to them and see the result.

using System;

class NullableVariables
{
    static void Main()
    {
        int? IntVar = null;
        double? DoubleVar = null;
        Console.WriteLine("First line:" + IntVar + " " + DoubleVar);
        IntVar += 5;
        DoubleVar += 10.01;
        Console.WriteLine("Second line (Adding numbers): " + IntVar + " " + DoubleVar);
        IntVar = 5;
        DoubleVar = 10.01;
        Console.WriteLine("Third line (Asigning numbers): " + IntVar + " " + DoubleVar);
        IntVar += null;
        DoubleVar += null;
        Console.WriteLine("Fourth line (Adding null): " + IntVar + " " + DoubleVar);
    }
}
