// Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN

using System;

class CalculatesFactorielSum
{
    static void Main()
    {
        int N = 1;
        int X = 0;

        bool flag;
        do
        { // input with checking for correct values
            Console.WriteLine("Calculating S= 1 + 1!/X^1 + 2!/X^2 + ... + N!/X^N");
            Console.WriteLine("Enter N");
            flag = int.TryParse(Console.ReadLine(), out N);
            if( flag )
            {
                if( N <= 0 )
                {
                    Console.WriteLine("N must be a positive number!");
                    flag = false;
                }
                else
                {
                    // enter X
                    Console.WriteLine("Enter X");
                    flag = int.TryParse(Console.ReadLine(), out X);
                    if( flag )
                    {
                        if( X == 0 )
                        {
                            Console.WriteLine("X cant be zero!");
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

        int NFacturiel = 1;
        int Devider = 1;
        double S = 1.0;

        for( int i = 1; i <= N; i++ )
        {
            NFacturiel *= i;
            Devider *= X;
            S = S + 1.0 * NFacturiel / Devider;
        }

        Console.WriteLine("S is {0}", S);
    }
}
