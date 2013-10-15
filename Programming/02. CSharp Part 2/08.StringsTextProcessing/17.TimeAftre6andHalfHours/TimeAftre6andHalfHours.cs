//Write a program that reads a date and time given in the format: 
//day.month.year hour:minute:second 
//and prints the date and time after 6 hours and 30 minutes (in the same format) 
//along with the day of week in Bulgarian.


using System;
using System.Globalization;
class TimeAftre6andHalfHours
{
    static void Main()
    {
        Console.Write("Enter second date (format: DD.MM.YYYY hour:minute:seconds): ");
        Console.WriteLine();
        //string date = "30.12.2013 12:30:30";

        string date = Console.ReadLine();
        string pattern = "dd.MM.yyyy HH:mm:ss";
        DateTime parsedDate;

        //try to parse the date
        if (DateTime.TryParseExact(date, pattern, null, DateTimeStyles.None, out parsedDate))
        {
            // add hours and minutes
            parsedDate = parsedDate.AddHours(6.5);
            // print the new date
            Console.WriteLine("{0} {1}", parsedDate.ToString("dddd", new CultureInfo("bg-BG")), parsedDate);
        }
            // if the parsing wasnt successful show this msg to the user
        else
        {
            Console.WriteLine("Unable to convert '{0}' to a date and time.", date);
        }
    }

}
