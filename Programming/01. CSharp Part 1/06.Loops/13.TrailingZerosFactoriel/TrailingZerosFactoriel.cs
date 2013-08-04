// Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
//	N = 10 -> N! = 3628800 -> 2
//	N = 20 -> N! = 2432902008176640000 -> 4

using System;
class TrailingZerosFactoriel
{
    static void Main()
    {
        int N;
        int counter = 0;
        bool flag;
        do
        {
            // input with checking for correct values
            Console.WriteLine("Counting the trailing zeros of N!");
            Console.WriteLine("Enter N");
            flag = int.TryParse(Console.ReadLine(), out N);
            if( flag )
            {
                if( N < 2 )
                {
                    Console.WriteLine("N must be bigger than 1!");
                    flag = false;
                }
            }
            else
            {
                Console.WriteLine("Incorect value!");
            }
        } while( !flag );

        for( int i = 5; i <= N; i = i + 5 )
        {
            counter++;
        }
        Console.WriteLine("{0}! has {1} trailing zeros!", N, counter);
    }
}

