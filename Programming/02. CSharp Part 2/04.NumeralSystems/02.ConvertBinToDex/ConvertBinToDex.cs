// Write a program to convert binary numbers to their decimal representation.

using System;
class ConvertBinToDex
{
    static void Main()
    {
        Console.WriteLine("Enter a number (bin):");
        string number = Console.ReadLine();
        int result = BinToDec(number);
        Console.WriteLine("{0} (bin) is {1} (dec)", number, result);
    }

    /// <summary>
    /// Method that converts a number in binary form (as string) to a number in dec form (as integer)
    /// </summary>
    /// <returns>Returns a number in dec form (as integer)</returns>
    static int BinToDec(string numberBin)
    {
        int result = 0;
        // trim the spaces before and after the string
        numberBin = numberBin.Trim();
        //loop through the elements of the string
        for (int index = 0; index < numberBin.Length; index++)
        {
            // finds the defree 
            int degree = numberBin.Length - index - 1;

            // multyply every char from the string by 2 degree of 'degree' and add it to the result
            result += int.Parse(string.Empty + numberBin[index]) * (int)Math.Pow(2, degree);
        }

        return result;
    }

}