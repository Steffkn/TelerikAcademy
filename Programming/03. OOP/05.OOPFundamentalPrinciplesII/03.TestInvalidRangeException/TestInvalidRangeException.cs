// Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range. 
// It should hold error message and a range definition [start … end].
// Write a sample application that demonstrates the InvalidRangeException<int> 
//    and InvalidRangeException<DateTime> by entering numbers in the range [1..100] 
//    and dates in the range [1.1.1980 … 31.12.2013].

using System;
class TestInvalidRangeException
{
    static void Main()
    {
        // check the range with ints
        int minValue = 0;
        int maxValue = 100;
        Console.Write("Enter a number [{0}:{1}]: ", minValue, maxValue);
        try
        {
            // wait for the user to enter an integer
            int number = GetInt(minValue, maxValue);
        }
        catch (InvalidRangeException<int> rangeEx)
        {
            // if range exception happens => show user friendly message
            Console.WriteLine("InvalidRangeException catched: {0}", rangeEx.Message);
        }
        catch (Exception)
        {
            // if other exception happens => show message this dump message to the user
            Console.WriteLine("Another exception catched.");
        }

        // check the range exception for datetime values
        DateTime minDate = new DateTime(1980, 1, 1);
        DateTime maxDate = new DateTime(2013, 12, 31);
        Console.Write("Enter a date [{0}, {1}]: ", minDate.ToShortDateString(), maxDate.ToShortDateString());
        try
        {
            // wait for the user to enter a date
            var date = GetDate(minDate, maxDate);
        }
        catch (InvalidRangeException<DateTime> rangeEx)
        {
            // if range exception happens => show user friendly message
            Console.WriteLine("InvalidRangeException catched: {0}", rangeEx.Message);
        }
        catch (Exception)
        {
            // if other exception happens => show message this dump message to the user
            Console.WriteLine("Another exception catched.");
        }
    }

    /// <summary>
    /// Method that gets an int from the user.
    /// </summary>
    /// <param name="minValue">The minimal value that this number can be.</param>
    /// <param name="maxValue">The maximal value that this number can be.</param>
    /// <returns>Returns the number if its in the range [minValue : maxValue] or throws InvalidRangeException<int></returns>
    public static int GetInt(int minValue, int maxValue)
    {
        int number = int.Parse(Console.ReadLine());
        if (number < minValue || number > maxValue)
        {
            // the message can be anything
            throw new InvalidRangeException<int>(
                string.Format("Number {0} is not in range [{1}:{2}]: ", number, minValue, maxValue),
                minValue,
                maxValue);
        }
        // if the number is in the range, return it
        return number;
    }

    /// <summary>
    /// Method that gets an DateTime value from the user.
    /// </summary>
    /// <param name="minDate">Minimal DateTime value</param>
    /// <param name="maxDate">Maximal DateTime value</param>
    /// <returns>Returns the users input or throws InvalidRangeException<DateTime></returns>
    private static DateTime GetDate(DateTime minDate, DateTime maxDate)
    {
        DateTime date = DateTime.Parse(Console.ReadLine());
        if (date < minDate || date > maxDate)
        {
            // the message can be anything
            throw new InvalidRangeException<DateTime>(
                string.Format("Date [{0}] is not in range [{1}, {2}]: ", date, minDate.ToShortDateString(), maxDate.ToShortDateString()),
                minDate,
                maxDate);
        }

        // if the input is in the range, return it
        return date;
    }
}
