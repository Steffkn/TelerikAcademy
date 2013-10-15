//Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
//Display them in the standard date format for Canada.

using System;
using System.Globalization;
using System.Text.RegularExpressions;
class ExtractDateByFormat
{
    static void Main()
    {

        string date = "Some text here! 01.01.2014 01/01/2014 and here some more 1#1#2014 31.12.2013 31.21.2013 text";

        string[] dateArray = date.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string pattern = "dd.MM.yyyy";
        DateTime parsedDate;

        Console.WriteLine("Valid dates found:");
        for (int index = 0; index < dateArray.Length; index++)
        {
            //try to parse the date
            if (DateTime.TryParseExact(dateArray[index], pattern, null, DateTimeStyles.None, out parsedDate))
            {
                // print the date
                Console.WriteLine(parsedDate.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
            }
        }
    }
}
