// Write a program that gets a number n and after that 
// gets more n numbers and calculates and prints their sum. 

using System;
class SumOfFirstNValues
{
    static void Main()
    {
        Console.Write("Tell me how many numbers you want to add: ");
        int N;
        double sum = 0;
        double nextNumber;
        // chacking the input for positive integer number
        if( int.TryParse(Console.ReadLine(), out N) && N > 0 )
        {
            // loot that will be run N times
            for( int i = 0; i < N; i++ )
            {
                // printing the number's position
                Console.Write(" {0}) ",i+1);
                // checking the input for real number
                if( double.TryParse(Console.ReadLine(), out nextNumber) )
                {
                    // calculating the sum
                    sum += nextNumber;
                }
                else
                {
                    // printing error message if we don't enter real number
                    Console.WriteLine("Please enter only numbers!");
                    // shift back "i", because there was invalid input
                    i--;
                }
            }
            // printing the sum
            Console.WriteLine("The sum is {0}", sum);
        }
        else
        {
            // printing error message if we don't enter positive integer
            Console.WriteLine("Please enter valin number! (positive integer)");
        }
    }
}
