// Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

using System;

class CalculatesFacturiel
{
    static void Main()
    {
        int K = 1, N = 1;
        bool flag;
        do
        { // input with checking for correct values
            Console.WriteLine("Enter N (bigger than 1)");
            string line = Console.ReadLine();
            flag = int.TryParse(line, out N);
            if( flag )
            {
                N = int.Parse(line);
                if( N <= 1 )
                {
                    Console.WriteLine("N must be bigger than 1!");
                    flag = false;
                }
                else
                {
                    // enter N
                    Console.WriteLine("Enter K (bigger than N)");
                    line = Console.ReadLine();
                    flag = int.TryParse(line, out K);
                    if( flag )
                    {
                        K = int.Parse(line);
                        if( K <= N )
                        {
                            Console.WriteLine("K must be bigger than N!");
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

        ulong knFacturiel = 1;
        for( int i = 1; i <= K; i++ )
        {
            checked
            {
                knFacturiel = knFacturiel * (ulong)i;
                if( i > K - N & i <= N )
                {
                    knFacturiel = knFacturiel * (ulong)i;
                }
            }
        }
        Console.WriteLine("Result: N!*K! / (K-N)! = {0}", knFacturiel);
    }
}

