// Write a program to calculate the Nth Catalan number by given N.

using System;

class NthCatalanNumber
{
    static void Main()
    {
        double Cn = 1.0;
        int N;
        bool flag;

        do
        {
            // input with checking for correct values
            Console.WriteLine("Calculating the first N Catalan numbers");
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
                Console.WriteLine("Incorrect value!");
            }
        } while( !flag );

        for( int i = 0; i <= N - 2; i++ )
        {
            Cn *= 1.0 * ( N + i + 2 ) / ( i + 2 );
        }
        Console.WriteLine("The {0} Catalan number is {1}", N, Cn);
    }
}

