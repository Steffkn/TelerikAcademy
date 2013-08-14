//Write a method that calculates the number of workdays between today and given date, 
//passed as parameter. Consider that workdays are all days from Monday to Friday 
//except a fixed list of public holidays specified preliminary as array.


using System;
class NumberOfWorkDays
{
    static void Main()
    {
        // find the end date day:month:year
        Console.WriteLine("Enter a end date:");
        Console.Write("day: ");
        int day = int.Parse(Console.ReadLine());
        Console.Write("month: ");
        int month = int.Parse(Console.ReadLine());
        Console.Write("year: ");
        int year = int.Parse(Console.ReadLine());

        int countWorkDays = CountWorkDays(day, month, year);



        Console.WriteLine("From today (including) untill {0}:{1}:{2} there are {3} working days!", day, month, year, countWorkDays);
    }
    /// <summary>
    /// Method that coulculates the working days from today to a given date in time.
    /// </summary>
    /// <param name="day">The end date's day</param>
    /// <param name="month">The end date's month</param>
    /// <param name="year">The end date's year</param>
    /// <returns></returns>
    private static int CountWorkDays(int day, int month, int year)
    {
        // list of public holidays specified preliminary as array
        int[,] holidays = 
        {
            {1,1},
            {3,3},
            {1,5},
            {6,5},
            {24,5},
            {6,9},
            {22,9},
            {24,12},
            {25,12},
            {26,12},
            {31,12},
        };

        // current day (today)
        DateTime today = DateTime.Now;

        // counter for the work days
        int countWorkDays = 0;
        // number of days that will be added from today
        int daysToAdd = 0;


        while (true)
        {
            // generate new day that will be "dayToAdd" away from today
            DateTime newDay = today.AddDays(daysToAdd);
            // if the end day is reached
            if (newDay.Year == year && newDay.Month == month && newDay.Day == day)
            {
                break;
            }
            else
            {
                // if the new day is saturday or sunday, move to the next day
                if (newDay.DayOfWeek.ToString().Equals("Saturday") || newDay.DayOfWeek.ToString().Equals("Sunday"))
                {
                    daysToAdd++;
                }
                // if not, find if that day is not in the holiday array
                else
                {

                    // loop trough the holidays array
                    for (int i = 0; i < holidays.GetLength(0); i++)
                    {
                        // if that day is a holiday
                        if (newDay.Day == holidays[i, 0] && newDay.Month == holidays[i, 1])
                        {
                            // add one day; go to the next day
                            daysToAdd++;
                            break;
                        }
                        // if the end of the array is reached
                        else if (i + 1 == holidays.GetLength(0))
                        {
                            // then that day is a work day; count it and move on to the next day
                            countWorkDays++;
                            daysToAdd++;

                        }
                    }//end of for
                }
            }
        }// end of while

        return countWorkDays;
    }
}

