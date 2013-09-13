//Write a program that reads an integer number and calculates and prints its square root. 
//If the number is invalid or negative, print "Invalid number". 
//In all cases finally print "Good bye". 
//Use try-catch-finally

using System;
class SquareRootExceptions
{
    static void Main()
    {
        try
        {
            // read a number
	    Console.WriteLine("Enter a number: ")
            uint number = uint.Parse(Console.ReadLine());
            // try to find the sqrt of that number
            Console.WriteLine("Square root of {0} is {1}", number, Math.Sqrt(number));
        }
        // if overflow exception is cought // negative number
        catch (OverflowException)
        {
            // print on the screen
            Console.WriteLine("Invalid number!");
        }
        // if format exception is cought // not an integer
        catch (FormatException)
        {
            // print on the screen
            Console.WriteLine("Invalid number!");
        }
        finally
        {
            // say good bye to the user
            Console.WriteLine("Good bye!");
        }
    }
}

