//* Write a program that shows the internal binary representation of given 32-bit signed 
//floating-point number in IEEE 754 format (the C# type float). 
//Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.


using System;

class Program
{
    /// <summary>
    /// Method that converts a dec number in bin and returns it as string
    /// </summary>
    /// <param name="numberDec">Given number in dec system</param>
    /// <returns>Returns the number as string</returns>
    static string DecToBin(int numberDec)
    {
        string result = String.Empty;

        for (; numberDec != 0; numberDec /= 2)
        {
            result = numberDec % 2 + result;
        }

        return result;
    }

    /// <summary>
    /// Method that converts the mantissa from dec to bin
    /// </summary>
    /// <param name="floatingNumber"></param>
    /// <returns></returns>
    static string DecToBinMantissa(float floatingNumber)
    {
        string resultBin = String.Empty;

        // 0.125 -> 0.25
        for (floatingNumber *= 2; floatingNumber != 0; floatingNumber *= 2) // 0.25 -> 0.5 -> 1 -> 0; 3 times
        {
            resultBin += (int)floatingNumber;
            floatingNumber -= (int)floatingNumber;
        }

        return resultBin;
    }

    /// <summary>
    /// Finds the sign of the number
    /// </summary>
    /// <param name="floatNumber">Given number</param>
    /// <returns>returns 1 for negative or 0 for possitive numbers (depends of the sign)</returns>
    static int FindSign(float floatNumber)
    {
        return floatNumber < 0 ? 1 : 0;
    }

    /// <summary>
    /// Method that finds the exponent and returns it as string
    /// </summary>
    /// <param name="integer"></param>
    /// <param name="fraction"></param>
    /// <returns></returns>
    static string FindExponent(string integer, string fraction)
    {
        // 1 -> 0; 2 -> 1; 3 -> 1; 4 -> 2; 5 -> 2; 6 -> 2; 7 -> 2; 8 -> 3; 9 -> 3; ... 15 -> 3; 16 -> 4 ...
        // 0.8 -> -1; 0.4 -> -2; 0.2 -> -3; 0.1 -> -4
        int exponent;

        // 1.23, 12.3, but not 0.12 or 0.00123
        if (integer.Length != 0) exponent = integer.Length - 1; // 8 = 2 ^ 3 in binary is 1000 - power is +3 - positive
        else exponent = -fraction.IndexOf('1') - 1; // 0.125 = 1 / 8 in binary is 0.001 - power is -3 - negative

        return DecToBin(127 + exponent).PadLeft(8, '0'); // Convert power to binary, 127 is the middle
    }

    /// <summary>
    /// Method that finds the mantisa in bin and returns it as string
    /// </summary>
    /// <param name="integer"></param>
    /// <param name="fraction"></param>
    /// <returns>Returns the mantissa as string</returns>
    static string FindMantissa(string integer, string fraction)
    {
        string mantissa;

        // First number is always 1 (if normalized)
        if (integer.Length != 0)
        {
            mantissa = integer.Substring(1) + fraction;
        }
        else // get first non-zero in fraction
        { 
            mantissa = fraction.Substring(fraction.IndexOf('1') + 1); 
        } 

        return mantissa.PadRight(23, '0'); // Left aligned
    }

   
    static void Main(string[] args)
    {
        // fix the numlock Del key // set dot as floating point not comma
        System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
        customCulture.NumberFormat.NumberDecimalSeparator = ".";

        System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;


        Console.WriteLine("Enter a floating point number:");
        float floatingNumber = float.Parse(Console.ReadLine());

        int sign = FindSign(floatingNumber);

        // If the number is negative make it positive
        floatingNumber = Math.Abs(floatingNumber); 

        // find the integer part of the number
        string integer = DecToBin((int)floatingNumber);
        // find the fraction
        string fraction = DecToBinMantissa(floatingNumber - (int)floatingNumber);

        string exp = FindExponent(integer, fraction);
        string mantissa = FindMantissa(integer, fraction);
        Console.WriteLine("Answer:");
        Console.WriteLine("Sign {0}", sign);
        Console.WriteLine("Exp {0}", exp);
        Console.WriteLine("Mantissa {0}", mantissa);
    }
}