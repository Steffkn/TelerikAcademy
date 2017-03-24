// Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

using System;

class IsPrimeNumber
{
    static void Main()
    {
        // числото трябва да е <= 100 следователно няма смисъл да се проверява дали n се дели на по-големи прости числа от 7
        byte number = 47;

        if( number % 2 == 0 || number % 3 == 0 || number % 5 == 0 || number % 7 == 0 )
        {
            Console.WriteLine("The number {0} is NOT a prime number!", number);
        }
        else
        {
            Console.WriteLine("The number {0} is a prime number!", number);
        }
    }
}