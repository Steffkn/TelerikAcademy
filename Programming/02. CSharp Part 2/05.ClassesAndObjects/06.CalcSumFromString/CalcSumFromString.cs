// You are given a sequence of positive integer values written into a string, separated by spaces. Write a function that reads these values from given string and calculates their sum. Example:
//        string = "43 68 9 23 318" -> result = 461

using System;
class CalcSumFromString
{
    static void Main()
    {
        string strSequence= "43 68 9 23 318" ;

        int sum = CalcSumFromString(strSequence);

        Console.WriteLine("The sum is: {0}", sum);
    }
    /// <summary>
    /// Method that finds a sum from a string of integers separated by spaces.
    /// </summary>
    /// <param name="givenString">String of integers that holds the digits separated by spaces</param>
    /// <returns>Returns the sum of the digits in the string</returns>
    static int CalcSumFromString(string givenString)
    {
        // make an array of strings with the digits; every digit in a separate row
        string[] subString = givenString.Split(' ');

        int sum = 0;
        // loop trought the elements in the array
        foreach (var number in subString)
        {
            // parse the digit and add it to the end sum
            sum += int.Parse(number);
        }
        // return the sum
        return sum;
    }
}

