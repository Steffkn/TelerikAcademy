// Write a program that finds the biggest of three integers using nested if statements.

using System;
class BiggestInteger
{
    static void Main()
    {
        // declaring 3 integers and cheching for invalid input
        int firstValue = 0;
        int secondValue = 0;
        int thirdValue = 0;

        Console.WriteLine("Enter 3 integers");
        if( !int.TryParse(Console.ReadLine(), out firstValue) )
        {
            Console.WriteLine("Invalid value!");
        }
        else if( !int.TryParse(Console.ReadLine(), out secondValue) )
        {
            Console.WriteLine("Invalid value!");
        }
        else if( !int.TryParse(Console.ReadLine(), out thirdValue) )
        {
            Console.WriteLine("Invalid value!");
        }

        // if there are any invalid values the program wont do anything
        // if a >= b
        else if( firstValue >= secondValue )
        {
            // if a >= c, then a is the biggest
            if( firstValue >= thirdValue )
            {
                Console.WriteLine("The biggest integer is {0}", firstValue);
            }
            // else if c >= b, then c is the biggest
            else if( thirdValue >= secondValue )
            {
                Console.WriteLine("The biggest integer is {0}", thirdValue);
            }
        }
            // else if b >= c and b > a, then b is the biggest
        else if( secondValue >= thirdValue )
        {
            Console.WriteLine("The biggest integer is {0}", secondValue);
        }
            // else 'c' is the biggest
        else
        {
            Console.WriteLine("The biggest integer is {0}", thirdValue);
        }


    }
}

