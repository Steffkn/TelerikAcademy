// Write a program that reads 3 integer numbers from the console and prints their sum.

using System;
class ReadIntsAndPrintTheSum
{
    static void Main()
    {
        int sum = 0;

        // this loop will continue untill we add 3 numbers
        for( int i = 0; i < 3; i++ )
        {
            int temp;
            // checking the input for integers
            if( int.TryParse(Console.ReadLine(), out temp) )
            {
                // adding temp to the sum
                sum += temp;
            }
            else
            {
                // error message for invalid input
                Console.WriteLine("Invalid input! (Integers only)");
                // because we made a mistake in the input - extracting 1 from i, so we can continue the inputS
                i--;    
            }
        }
        // showing the result
        Console.WriteLine(sum);
    }
}
