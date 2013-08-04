// Write a program that finds the greatest of given 5 variables.

using System;
class BiggestFromFive
{
    static void Main()
    {
        double number;
        double max = double.MinValue;
        Console.WriteLine("Enter 5 numbers: ");
        // loop 5 times
        for( int i = 0; i < 5; i++ )
        {
            // if invalit number is given 
            if( !double.TryParse(Console.ReadLine(), out number) )
            {
                Console.WriteLine("Invalid value!");
                break;
            }
            else
            {
                // if the max value is smaller than the last given number
                if( max <= number )
                {
                    // max becomes equal to number
                    max = number;
                }
            }
        }
        // printing the max value
        Console.WriteLine("Greatest of the given 5 variables is {0}.", max);
    }
}

