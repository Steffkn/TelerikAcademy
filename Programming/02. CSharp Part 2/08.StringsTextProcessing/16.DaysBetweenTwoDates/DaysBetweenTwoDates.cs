//Write a program that reads two dates in the format: 
//day.month.year and calculates the number of days between them. 

using System;
class DaysBetweenTwoDates
{
    static void Main()
    {

        Console.Write("Enter first date (format: DD.MM.YYYY): ");
        string[] firstDate = Console.ReadLine().Split('.');

        Console.Write("Enter second date (format: DD.MM.YYYY): ");
        string[] secondDate = Console.ReadLine().Split('.');
        try
        {
            // try to parse the dates to DateTime
            DateTime firstDateTime = new DateTime(int.Parse(firstDate[2]), int.Parse(firstDate[1]), int.Parse(firstDate[0]));
            DateTime secondDateTime = new DateTime(int.Parse(secondDate[2]), int.Parse(secondDate[1]), int.Parse(secondDate[0]));
            
            TimeSpan timeGap = secondDateTime.Subtract(firstDateTime);
            // if everything is ok return the days
            Console.WriteLine(Math.Abs(timeGap.Days));
        }
        catch (FormatException)
        {
            Console.WriteLine("One of the dates was not in right format! The format is (DD.MM.YYYY) day.month.year!");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("One of the dates was not it right format or null!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid date! Check your values! [DD].[MM].[YYYY] - [1-31].[1-12].[1-9999]");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Dates cant have null values!");
        }

    }
}

