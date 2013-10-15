// Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
// Use the built-in extension methods and lambda expressions. 
// Rewrite the same with LINQ.

using System;
using System.Linq;

class FindNumbersDivisibleBy21
{
    static void Main()
    {
        int[] intArr = new int[] { 3, 7, 16, 21, 23, 42, 147, 153, 210 };

        Console.WriteLine();
        Console.WriteLine("Numbers that are divisible by 7 and 3 (build-in and lambda):");

        int[] canDivideBy21 = intArr
            .Where((x) => x % 21 == 0) // 3*7 = 21 it is the same as: (number % 3 == 0 && number % 7 == 0)
            .ToArray<int>(); 

        foreach (var item in canDivideBy21)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("Numbers that are divisible by 7 and 3 (LINQ):");

        int[] canDivideBy21LINQ =
                (from number in intArr
                 where number % 21 == 0 // 3*7 = 21 it is the same as: (number % 3 == 0 && number % 7 == 0)
                 select number).ToArray<int>();

        foreach (var item in canDivideBy21LINQ)
        {
            Console.WriteLine(item);
        }
    }
}
