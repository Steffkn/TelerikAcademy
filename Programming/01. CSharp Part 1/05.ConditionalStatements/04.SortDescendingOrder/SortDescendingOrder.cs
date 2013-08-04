// Sort 3 real values in descending order using nested if statements.

using System;
class SortDescendingOrder
{
    static void Main()
    {
        // declaring 3 integers and cheching for invalid input
        double firstValue = 0;
        double secondValue = 0;
        double thirdValue = 0;

        Console.WriteLine("Enter 3 integers");
        if( !double.TryParse(Console.ReadLine(), out firstValue) )
        {
            Console.WriteLine("Invalid value!");
        }
        else if( !double.TryParse(Console.ReadLine(), out secondValue) )
        {
            Console.WriteLine("Invalid value!");
        }
        else if( !double.TryParse(Console.ReadLine(), out thirdValue) )
        {
            Console.WriteLine("Invalid value!");
        }
        else
        {
            // if there are any invalid values the program wont do anything
            // a >= b
            if( firstValue >= secondValue )
            {
                // a>= b && b >= c - descending order
                if( secondValue >= thirdValue )
                {
                }

                // a>= b && a >= c but b < c
                else if( firstValue >= thirdValue )
                {
                    double temp = secondValue;
                    secondValue = thirdValue;
                    thirdValue = temp; 
                    // b > c - descending order
                }
                // a >= b but b < c and a < c => c > a >= b
                else
                {
                    double temp = firstValue;
                    firstValue = thirdValue;
                    thirdValue = secondValue;
                    secondValue = temp;
                    // a > b > c - descending order
                }
            }
            // a < b && a >= c => b > a >= c
            else if( firstValue >= thirdValue )
            {
                double temp = secondValue;
                secondValue = firstValue;
                firstValue = temp;
                // a > b >= c - descending order
            }
            // a < b && b >= c and a < c => b >= c > a 
            else if( secondValue >= thirdValue )
            {
                double temp = secondValue;
                secondValue = thirdValue;
                thirdValue = firstValue;
                firstValue = temp;
                // a >= b > c - descending order
            }
            // a < b, a < c and c > b => c > b > a
            else
            {
                double temp = thirdValue;
                thirdValue = firstValue;
                firstValue = temp;
                // a > b > c - descending order
            }

            Console.WriteLine("Descending order: {0}, {1}, {2}.", firstValue, secondValue, thirdValue);
        }
    }
}

