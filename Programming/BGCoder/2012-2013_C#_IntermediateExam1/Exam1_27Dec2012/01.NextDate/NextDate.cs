using System;
class NextDate
{
    static void Main()
    {
        DateTime date;
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());
        date = new DateTime(year, month, day);

        date = date.AddDays(1);
        Console.WriteLine("{0}.{1}.{2}", date.Day, date.Month, date.Year);
    }
}