// Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;
class ConvertBinToHex
{
    static void Main()
    {
        Console.WriteLine("Enter a number (bin):");
        string number = Console.ReadLine();
        string result = BinToHex(number);
        Console.WriteLine("{0} (bin) is {1} (hex)", number, result);
    }

    static string BinToHex(string numberBin)
    {
        string[] binValues = {
                               "0000",  "0001",  "0010","0011",
                               "0100",  "0101",  "0110",
                               "0111",  "1000",  "1001",
                               "1010",  "1011",  "1100",
                               "1101",  "1110",  "1111",
                           };
        string[] hexValues = {
                               "0",  "1",  "2","3",
                               "4",  "5",  "6",
                               "7",  "8",  "9",
                               "A",  "B",  "C",
                               "D",  "E",  "F",
                           };
        string result = string.Empty;

        // while the lenght of the number isnt devided by 4 without reminder 
        // this will triger if the number doesnt have enough digits in it, add zeros infron of the number(bin) untill the lenght of the number is multiple of four;
        while (numberBin.Length % 4 != 0)
        {
            numberBin = "0" + numberBin;
        }

        // loop untill the end of the string array of binary values and if we reach the end of the binary number
        for (int i = 0, startIndex = 0; i < binValues.Length && startIndex < numberBin.Length; i++ )
        {
            // digit will hold 1 number from numberBin represented as bin
            string digit = numberBin.Substring(startIndex, 4);            

            // if the digit is found in the array of binValues
            if (digit.Equals(binValues[i]))
            {
                // add to the result the corresponding digit in hexValue
                result += hexValues[i];
                // jump to the next starting point of the next digit
                startIndex = startIndex + 4;
                // reset 'i' so that it will go infront of the list of bin values for the next digit
                i = 0;
            }
        }
        // return the result
        return result;
    }
}

