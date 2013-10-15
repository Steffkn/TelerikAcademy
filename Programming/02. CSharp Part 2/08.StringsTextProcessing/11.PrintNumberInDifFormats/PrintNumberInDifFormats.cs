//Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation. 
//Format the output aligned right in 15 symbols.

using System;

class PrintNumberInDifFormats
{
    static void Main()
    {
        Console.WriteLine("Enter a number:");
        int number = int.Parse(Console.ReadLine());

        // the format is simple {index, number of symbols : format}
        Console.WriteLine(string.Format("{0,15:D} Number", number));
        Console.WriteLine(string.Format("{0,15:X} HEX", number));
        Console.WriteLine(string.Format("{0,15:P} Percentage", number / 100));
        Console.WriteLine(string.Format("{0,15:E} Scientific ", number));
    }
}
