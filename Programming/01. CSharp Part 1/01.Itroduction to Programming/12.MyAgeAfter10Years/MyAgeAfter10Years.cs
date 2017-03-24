using System;
class MyAgeAfter10Years
{
    static void Main()
    {
        int currentAge;
        int yearsToAdd = 10;
        Console.WriteLine("How old are you now?");
        string readFromCon = Console.ReadLine();
        if( int.TryParse(readFromCon, out currentAge) )
        {
            currentAge = int.Parse(readFromCon);
        }
        else
        {
            Console.WriteLine(new FormatException("Invalid input!"));
        }
        if( currentAge <= 0 )
        {
            Console.WriteLine(new IndexOutOfRangeException("Age must be positive integer!"));
        }
        else
        {
            Console.WriteLine("In {0} you will be {1} years old!", DateTime.Now.AddYears(yearsToAdd).Year, currentAge + yearsToAdd);
        }
    }
}

