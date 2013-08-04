// Write a program to calculate the sum (with accuracy of 0.001): 
// 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

using System;
class SumOfSequence
{
    static void Main()
    {
        int N;
        double sum = 1.0;
        Console.Write("Enter end value (n) of the sequence 1 + 1/2 - 1/3 + ... + 1/(n-1) - 1/n: ");
        // chacking the input for positive integer number
        if( int.TryParse(Console.ReadLine(), out N) && N > 0 )
        {
            // loot that will be run N - 1 times
            for( int i = 2; i <= N; i++ )
            {
                // if i is even the formula is as follows 
                if( i % 2 == 0 )
                {
                    sum = sum + (1.0 / i);
                }
                // if i is odd the formula is as follows
                else
                {
                    sum = sum - (1.0 / i);
                }
            }

            // printing the result in the format 0,000
            Console.WriteLine("The sum is {0:0.000}", sum);
        }
        else
        {
            // printing error message if we don't enter positive integer
            Console.WriteLine("Please enter valin number! (positive integer)");
        }
    }
}
