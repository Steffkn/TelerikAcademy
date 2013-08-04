using System;
class SquareMatrixEasy
{
    static void Main()
    {
        int N;
        int counter;
        bool flag;

        do
        {
            // input with checking for correct values
            Console.WriteLine("Calculating the sum of the first N Fibonacci numbers");
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

        for( int j = 0; j < N; j++ )
        {
            counter = j + 1;
            for( int i = 0; i < N; i++, counter++ )
            {
                Console.Write("{0}\t",counter);
            }
            Console.WriteLine();
        }
    }
}

