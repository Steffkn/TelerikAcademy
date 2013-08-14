//Write a program that generates and prints to the console 10 random values in the range [100, 200].

using System;
    class Program
    {
        static void Main()
        {
            // init parameters
            // min and max value
            // [100, 200] means range [100,201] because 200 should be included too
            int rangeMin = 100;
            int rangeMax = 200;
            // how many numbers we want to generate
            int times = 10;

            Random generateRandom = new Random();

            for (int time = 0; time < times; time++)
            {
                // print a random number in range [rangeMin,rangeMax]
                Console.WriteLine(generateRandom.Next(rangeMin, rangeMax + 1)); // rangeMax is included
            }
        }
    }

