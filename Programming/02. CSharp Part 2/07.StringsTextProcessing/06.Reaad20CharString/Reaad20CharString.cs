using System;
using System.Text;
using System.Threading;
class Reaad20CharString
{
    static void Main()
    {
        // Set the user interface to display in the 
        // same culture as that set in Control Panel.
        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        
        Console.WriteLine("Enter a string that is 20 chars lenght");
        string twentyCharsString = string.Empty;
        StringBuilder twentyCharsSB = new StringBuilder();

        // while the input string has more than 20 chars in it or the string is empty,
        while (twentyCharsString.Length > 20 || twentyCharsString.Length == 0)
        {
            // read the input from the console
            twentyCharsString = Console.ReadLine();
        }
        // apped the string to the StringBuilder
        twentyCharsSB.Append(twentyCharsString);

        // while the stringBuilder has less than 20 chars in it, append a '*'
        while (twentyCharsSB.Length < 20)
        {
            twentyCharsSB.Append("*");
        }
        // show the indexes untill the 20th char; for easy check
        //Console.WriteLine("12345678901234567890");
        // show the result
        Console.WriteLine(twentyCharsSB);
    }
}

