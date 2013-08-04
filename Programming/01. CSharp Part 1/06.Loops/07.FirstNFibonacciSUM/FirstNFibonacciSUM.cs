// Write a program that reads a number N and calculates the sum of the first N members of the sequence of Fibonacci: 
// 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

using System;
class FirstNFibonacciSUM
{
    static void Main()
    {
        int firstFibonacciNumber = 0; // First Fib. number
        int secondFibonacciNumber = 1; // Second Fib. number
        int sum = 0;
        int N;
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
                Console.WriteLine("Incorect value!");
            }
        } while( !flag );

        for( int i = 1; i < N; i++ )
        {
            int temp;
            sum += secondFibonacciNumber;
            temp = firstFibonacciNumber;
            firstFibonacciNumber = secondFibonacciNumber;
            secondFibonacciNumber = temp + firstFibonacciNumber; // next fib number
        }
        Console.WriteLine("The sum is {0}", sum);
    }
}

