// Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

using System;
class PrintFrom1ToN
{
    static void Main()
    {
        int K = 1, N = 1;
        bool flag;
        do
        { // input with checking for correct values
            Console.WriteLine("Enter K (bigger than 1)");
            string line = Console.ReadLine();
            flag = int.TryParse(line, out K);
            if( flag )
            {
                K = int.Parse(line);
                if( K <= 1 )
                {
                    Console.WriteLine("K must be bigger than 1!");
                    flag = false;
                }

                else
                {
                    // enter N
                    Console.WriteLine("Enter N (bigger than K)");
                    line = Console.ReadLine();
                    flag = int.TryParse(line, out N);
                    if( flag )
                    {
                        N = int.Parse(line);
                        if( N <= K )
                        {
                            Console.WriteLine("N must be bigger than K!");
                            flag = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorect value!");
                    }
                }
            }
        } while( flag == false );

        long knFacturiel = 1;

        for( int i = K + 1; i <= N; i++ )
        {
            checked
            {
                knFacturiel = knFacturiel * i;
            }

        }
            Console.WriteLine("Result: N!/K! = {0}", knFacturiel);
    }
}
