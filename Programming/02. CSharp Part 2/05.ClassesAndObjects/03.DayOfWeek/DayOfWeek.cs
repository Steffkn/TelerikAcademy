// Write a program that prints to the console which day of the week is today. Use System.DateTime.

using System;
class DayOfWeek
    {
        static void Main()
        {
            // finds the day of the week as string and converts its letters to lower case
            Console.WriteLine("Today is {0}!", DateTime.Today.DayOfWeek.ToString().ToLower());
        }
    }
