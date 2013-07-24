// Write a program that finds all prime numbers in the range [1...10 000 000]. 
// Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

using System;
class EratosthenesAlgorithmPrimeExample
{
    static void Main(string[] args)
    {
        long N = 10000000;
        bool[] isPrime = new bool[N];

        // marking all the elements in the bool array as prime
        for (int i = 2; i < N; i++)
        {
            // every second number will be marked as not prime
            if (i % 2 == 0)
            {
                isPrime[i] = false;
            }
            // if not even
            else
            {
                isPrime[i] = true;
            }
        }
        // this like will make the number 2 a prime number
        isPrime[2] = true;
        for (int j = 3; j < N; j = j + 2)
        {
            // if the elemnt j of the prime array is prime
            if (isPrime[j])
            {
                // every other element * p will be marked as not prime
                for (long p = 2; (p * j) < N; p++)
                {
                    isPrime[p * j] = false;
                }
            }
        }

        // extracting 2 from the loops will make them working time 2 times faster, bcause there will be N/2 loops
        // printing the prime numbers to the console, starting with 2
        Console.WriteLine("2");
        for (int i = 3; i < N; i = i + 2)
        {
            if (isPrime[i])
            {
                Console.WriteLine("{0} ", i);
            }
        }
    }
}
