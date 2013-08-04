// Write a program to print the first 100 members of the sequence of Fibonacci: 
// 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

using System;
using System.Numerics;  // needed for BigInteger type
class First100FibonacciValues
    {
        static void Main( )
        {
            // Fibonacci numbers get quite big after 47th
            BigInteger firstFibonacci = 0;
            BigInteger nextFibonacci = 1;

            Console.WriteLine("1) {0}", firstFibonacci); // printing the first number outside the loop
            
            // loop that will generate and print on the console from 2nd to 100th Fibunacci numbers
            for( int i = 2; i <= 100; i++ )
            {
                // printing next Fibonacci number from the sequence
                Console.WriteLine("{0}) {1}", i, nextFibonacci); // becouse the second Fibonnaci number is equal to the third (1) we can type this here, at the beginning
                nextFibonacci += firstFibonacci;    // next Fibonacci number
                firstFibonacci = nextFibonacci - firstFibonacci;    // previouse Fibonacci number
            }
        }
    }

