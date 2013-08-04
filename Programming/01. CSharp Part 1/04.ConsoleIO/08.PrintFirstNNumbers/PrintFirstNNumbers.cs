// Write a program that reads an integer number n from the console and 
// prints all the numbers in the interval [1..n], each on a single line.


using System;
class PrintFirstNNumbers
{
    static void Main()
    {
        int N;
        Console.Write("Tell me how many numbers you want to be printed: ");
         // chacking the input for positive integer number
        if( int.TryParse(Console.ReadLine(), out N) && N > 0 )
        {
            // loot that will be run N times
            for( int i = 0; i < N;  )
            {
                // printing i on the console, but before that we add 1 to i
                Console.WriteLine(++i);
            }
        }
        else
        {
            // printing error message if we don't enter positive integer
            Console.WriteLine("Please enter valin number! (positive integer)");
        }

    }
}

