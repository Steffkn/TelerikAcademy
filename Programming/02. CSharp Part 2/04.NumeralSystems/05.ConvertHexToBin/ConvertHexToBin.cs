// Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;
class ConvertHexToBin
{
    static void Main()
    {
        Console.WriteLine("Enter a number (hex):");
        string number = Console.ReadLine();
        string result = HexToDec(number);
        if (result != null)
        {
            Console.WriteLine("{0} (bin) is {1} (bin)", number, result);
        }
    }

    /// <summary>
    /// Method that converts a number in hex form (as string) to a number in dec form (as integer)
    /// </summary>
    /// <returns>Returns a number in dec form (as integer)</returns>
    static string HexToDec(string numberBin)
    {
        string[] binValues = {
                               "0000",  "0001",  "0010","0011",
                               "0100",  "0101",  "0110",
                               "0111",  "1000",  "1001",
                               "1010",  "1011",  "1100",
                               "1101",  "1110",  "1111",
                           };
        string result = string.Empty;
        // trim the spaces before and after the string
        numberBin = numberBin.Trim();
        numberBin = numberBin.ToUpper();

        //loop through the elements of the string
        for (int index = 0; index < numberBin.Length; index++)
        {
            // finds the index of the letter 'A' for math purpoces
            int indexOfA = (int)'A';

            int digit = 0;
            // if the char is a letter
            if (!int.TryParse("" + numberBin[index], out digit))
            {
                // holds the char as integer value
                digit = 10 + (int)(numberBin[index] - indexOfA);

                // if the char is not from A to F, return null
                if (digit > 15)
                {
                    // show error msg and return -1
                    Console.WriteLine("Incorect input!");
                    return null;
                }
                else
                {
                    // add to the result 
                    result += binValues[digit];
                }
            }
            else
            {
                digit = int.Parse("" + numberBin[index]);
                // add to the result 
                result += binValues[digit];
            }
        }
        return result;
    }
}

