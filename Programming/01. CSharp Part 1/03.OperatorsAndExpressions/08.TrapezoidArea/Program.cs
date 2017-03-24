// Write an expression that calculates trapezoid's area by given sides a and b and height h.

using System;

class TrapezoidArea
{
    static void Main()
    {
        // Формулата за лице на трапец е ( ( a + b ) * h ) / 2. Директно смятаме резултата и го извеждаме на екрана
        int a = 2;
        int b = 3;
        int h = 2;
        Console.WriteLine("Trapezoid's area with parametersis a = {0} b = {1} h = {2} is: {3}", a, b, h, ( ( a + b ) * h ) / 2);
    }
}