// Write a program to convert hexadecimal numbers to their decimal representation.

using System;
class ConvertHexToDec
{
    static void Main()
    {
        Console.WriteLine("Enter a number (hex):");
        string number = Console.ReadLine();
        int result = HexToDec(number);
        if (result != -1)
        {
            Console.WriteLine("{0} (hex) is {1} (dec)", number, result);
        }
    }

    /// <summary>
    /// Method that converts a number in hex form (as string) to a number in bin form (as string)
    /// </summary>
    /// <returns>Returns a number in dec form (as integer)</returns>
    static int HexToDec(string numberBin)
    {
        int result = 0;
        // trim the spaces before and after the string
        numberBin = numberBin.Trim().ToUpper();

        numberBin = numberBin.ToUpper();

        // replace 0x from the string with empty string (delete it)
        // its 0X becaouse of the string is converted to uppercase
        numberBin = numberBin.Replace("0X", string.Empty);

        //loop through the elements of the string
        for (int index = 0; index < numberBin.Length; index++)
        {
            // finds the defree 
            int degree = numberBin.Length - index - 1;
            // finds the index of the letter 'A' for math purpoces
            int indexOfA = (int)'A';

            int digit = 0;
            // if the char is a letter
            if (!int.TryParse("" + numberBin[index], out digit))
            {
                // holds the char as integer value
                digit = 10 + (int)(numberBin[index] - indexOfA);

                // if the char is not from A to F, return -1
                if (digit > 15)
                {
                    // show error msg and return -1
                    Console.WriteLine("Incorect input!");
                    return -1;
                }
                else
                {
                    // add to the result 
                    result += digit * (int)Math.Pow(16, degree);
                }
            }
            else
            {
                digit = int.Parse("" + numberBin[index]);
                // multyply every char from the string by 16 degree of 'degree' and add it to the result
                result += digit * (int)Math.Pow(16, degree);
            }

        }

        return result;
    }

}