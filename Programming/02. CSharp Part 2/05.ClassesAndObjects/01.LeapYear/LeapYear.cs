//Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Emter a year to check:");
        uint year = uint.Parse(Console.ReadLine());

        DateTime dayTime = new DateTime((int)year, 2, 28);

        // add 1 day and check if the month is changed
        if (dayTime.AddDays(1).Month == 2)
        {
            Console.WriteLine("The year {0} is a leap year!",year);
        }
        else
        {
            Console.WriteLine("The year {0} is NOT a leap year!", year);
        }

    }
}

