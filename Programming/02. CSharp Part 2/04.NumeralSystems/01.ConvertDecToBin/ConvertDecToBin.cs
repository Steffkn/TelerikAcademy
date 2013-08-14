// Write a program to convert decimal numbers to their binary representation.

using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a number (dec):");
        int number = int.Parse(Console.ReadLine());
        string result = DecToBid(number);
        Console.WriteLine("{0} (dec) is {1} (bin)", number, result);
    }

    /// <summary>
    /// Method that converses a number in dec to its binary representation.
    /// </summary>
    /// <param name="dec">Given integer</param>
    /// <returns>Returns a string that holds the integer in bin</returns>
    static string DecToBid(int dec)
    {
        string bin = string.Empty;
        string newString = string.Empty;

        // while the number is bigger than 0
        while (dec > 0)
        {
            // add the reminder to the string
            newString += dec % 2;
            // cut the number by half
            dec /= 2;
        }

        // reverse the order of the string so that the returned string will have the right answer
        for (int index = newString.Length - 1; index >= 0; index--)
        {
            bin += newString[index];
        }
        // return the number as string in bin form
        return bin;
    }

}

