// Write a program to convert decimal numbers to their hexadecimal representation.

using System;
class ConvertDecToHex
{
    static void Main()
    {
        Console.WriteLine("Enter a number (dec):");
        int number = int.Parse(Console.ReadLine());
        string result = DecToHex(number);
        Console.WriteLine("{0} (dec) is 0x{1} (hex)", number, result);
    }

    /// <summary>
    /// Method that converses a number in dec to its hex representation.
    /// </summary>
    /// <param name="dec">Given integer</param>
    /// <returns>Returns a string that holds the integer in hexadecimal</returns>
    static string DecToHex(int dec)
    {
        string bin = "";
        string newString = string.Empty;

        // finds the index of the letter 'A' for math purpoces
        int indexOfA = (int)'A';
        // while the number is bigger than 0
        while (dec > 0)
        {
            string helpString = (dec % 16).ToString();

            // if the result is bigger than 9
            if (int.Parse(helpString) > 9)
            {
                // find and return the number as a letter: 10 = A; 11 = B; 12 = C ... 15 = F
                helpString = ((char)(int.Parse(helpString) - 10 + indexOfA)).ToString();
            }
            // add the reminder to the string
            newString += helpString;
            // cut the number by 16
            dec /= 16;
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

