// Write a method that reverses the digits of given decimal number. 
// Example: 256 -> 652

using System;
class ReverseDigit
{
    static void Main()
    {
        Console.Write("Enter a digit to be mirrored: ");
        decimal digit = decimal.Parse(Console.ReadLine());

        // reverse the digit
        Console.WriteLine("Reversed digit: {0} ", ReverseDigits(digit));
    }

    /// <summary>
    /// Method that reverse a givien decimal digit.
    /// </summary>
    /// <param name="digit">Given digit to be reversed.</param>
    /// <returns>Return the reversed digit.</returns>
    public static decimal ReverseDigits(decimal digit)
    {
        decimal reversedDigit = 0;
        // loop that goesr around while the digit is bigger or egual that 1
        while (digit >= 1)
        {
            // takes the last digit
            int lastDigit = (int)digit % 10;
            // multyply the reversed digit to make room for the last digit
            reversedDigit = reversedDigit * 10 + lastDigit;
            digit = digit / 10;
        }

        return reversedDigit;
    }
}
