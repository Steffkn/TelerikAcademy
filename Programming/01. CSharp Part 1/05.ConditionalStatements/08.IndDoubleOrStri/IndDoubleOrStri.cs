// Write a program that, depending on the user's choice inputs int, double or string variable. 
// If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end. 
// The program must show the value of that variable as a console output. Use switch statement.

using System;

class IndDoubleOrStri
{
    static void Main()
    {
        Console.Write("Enter number or text: ");

        string value = Console.ReadLine();
        string flag;
        int numbVal = 0;
        double doubleVal = 0;

        bool intDoubleString = int.TryParse(value, out numbVal);
        // if the value is integer
        if( intDoubleString )
        {
            flag = "int";
            numbVal = int.Parse(value);
        }

        else
        {
            intDoubleString = double.TryParse(value, out doubleVal);
            // if the value is double
            if( intDoubleString )
            {
                flag = "double";
                doubleVal = double.Parse(value);
            }
            // only case left is string
            else
            {
                flag = "string";
            }
        }
    
        switch( flag )
        {
            case "int":
                Console.WriteLine(numbVal + 1);
                break;
            case "double":
                Console.WriteLine(doubleVal + 1);
                break;
            case "string":
                Console.WriteLine(value + '*');
                break;
            default:
                Console.WriteLine("Something went wrong!");
                break;
        }
    }
}

