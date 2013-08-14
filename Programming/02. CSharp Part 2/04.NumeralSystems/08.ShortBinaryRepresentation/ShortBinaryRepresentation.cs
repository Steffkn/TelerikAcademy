//Write a program that shows the binary representation of 
//given 16-bit signed integer number (the C# type short).

using System;

class ShortBinaryRepresentation
{
    static void Main()
    {
        Console.WriteLine("Enter a short number:");
        short shortNumber = short.Parse(Console.ReadLine());

        string resultBin = String.Empty;

        for (int i = 0; i < 16; i++)
        {
            // finds the bit at position i and adds in infront of the string resultBin
            resultBin = (shortNumber >> i & 1) + resultBin;
        }

        Console.WriteLine(resultBin);
    }
}