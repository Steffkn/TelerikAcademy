// Write a program that can solve these tasks:
// 1 Reverses the digits of a number
// 2 Calculates the average of a sequence of integers
// 3 Solves a linear equation a * x + b = 0
//         Create appropriate methods.
//         Provide a simple text-based menu for the user to choose which task to solve.
// Validate the input data:
// -The decimal number should be non-negative
// -The sequence should not be empty
// -a should not be equal to 0

using System;
using System.Collections.Generic;
class ReverseDigitFindAvarageSolvesEquation
{
    static void Main(string[] args)
    {
        int option = Menu();

        switch (option)
        {
            // first case, task 1
            case 1:
                Console.WriteLine("Enter a number:");
                decimal number;
                // if a valid number is given
                if (decimal.TryParse(Console.ReadLine(), out number))
                {
                    // and that number is bigger than 0
                    if (number >= 0)
                    {
                        // find the result and print it on the console
                        decimal result = ReverseDigits(number);
                        Console.WriteLine("Result: {0}", result);
                    }
                    // if the number is negative print error message
                    else
                    {
                        Console.WriteLine("The number should be positive number!");
                    }
                }
                // if the NAN is given error msg is printed
                else
                {
                    Console.WriteLine("That was not a number!");
                }
                break;

            // second case, task 2
            case 2:
                int element;
                int avarage;
                List<int> listOfIntegers = new List<int>();
                Console.WriteLine("Enter integers and anything else to stop: ");

                // fill the list with valid integers
                // if the input isnt a valid integer the loop will break
                while (int.TryParse(Console.ReadLine(), out element))
                {
                    listOfIntegers.Add(element);
                }

                // check if the list has items in it
                if (listOfIntegers.Count != 0)
                {
                    // find the avarage
                    avarage = FindAvarage(listOfIntegers);
                    Console.WriteLine("The avarage is {0}!", avarage);
                }
                // tell the user that he hasnt entered any integers
                else
                {
                    Console.WriteLine("The list of integers was empty!");
                }
                break;

            // third case, task 3
            case 3:
                double a, b;
                double x;
                Console.Write("Enter 'a' (a!=0):");

                // if a valid 'a' is given
                if (double.TryParse(Console.ReadLine(), out a))
                {
                    // if 'a' is not 0
                    if (a != 0)
                    {
                        Console.Write("Enter 'b': ");
                        // if a valid 'b' is given
                        if (double.TryParse(Console.ReadLine(), out b))
                        {
                            x = SolveEquation(a, b);
                            Console.WriteLine("x = {0}", x);
                        }
                        // show error for 'b'
                        else
                        {
                            Console.WriteLine("Invalid 'b'!");
                        }
                    }
                    // if 'a' is 0
                    else
                    {
                        Console.WriteLine("'a' should be different than 0!");
                    }
                    // error msg for 'a'
                }
                else
                {
                    Console.WriteLine("Invalid 'a'!");
                }
                break;
            case 4:
                // exit the program
                // clear the screan and print Bye Bye to the user
                Console.Clear();
                Console.WriteLine("Bye Bye!");
                return;
            default:
                // this will never happen
                break;
        }
    }
    /// <summary>
    /// Simple solving of linear equation a * x + b = 0.
    /// </summary>
    /// <param name="a">First parameter infront of x</param>
    /// <param name="b">Free parameter.</param>
    /// <returns>Returns the answer for x.</returns>
    public static double SolveEquation(double a, double b)
    {
        return -b / a;
    }

    /// <summary>
    /// Find the avarage in a list of integers.
    /// </summary>
    /// <param name="listOfElements">The list of integers</param>
    /// <returns></returns>
    public static int FindAvarage(List<int> listOfElements)
    {
        int sum = 0;
        int counter = 0;

        // find the sum and the number of the elements
        foreach (var item in listOfElements)
        {
            counter++;
            sum += item;
        }
        // find and return the avarage
        return sum / counter;
    }

    /// <summary>
    /// The menu for the program.
    /// </summary>
    /// <returns>Returns the selected option.</returns>
    public static int Menu()
    {
        int option;
        // do this while a valid input is given
        while (true)
        {
            // print the menu on the console.
            Console.Clear();
            Console.WriteLine("This program can:");
            Console.WriteLine("1. Reverses the digits of a number");
            Console.WriteLine("2. Calculates the average of a sequence of integers");
            Console.WriteLine("3. Solves a linear equation a * x + b = 0");
            Console.WriteLine("4. Exit");
            Console.WriteLine("What do you want to do? (1, 2, 3, 4)");
            // read the input for option 
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid selection!\n Try again!");
            }
            else
            {
                // if everything is ok
                break;
            }
        }
        // and return the option selected
        return option;
    }

    /// <summary>
    /// Method that reverse a givien decimal digit.
    /// </summary>
    /// <param name="digit">Given digit to be reversed.</param>
    /// <returns>Return the reversed digit.</returns>
    public static decimal ReverseDigits(decimal digit)
    {
        decimal reversedDigit = 0;
        // loop that goesr around while the digit is bigger or egual that 1
        while (digit >= 1)
        {
            // takes the last digit
            int lastDigit = (int)digit % 10;
            // multyply the reversed digit to make room for the last digit
            reversedDigit = reversedDigit * 10 + lastDigit;
            digit = digit / 10;
        }

        return reversedDigit;
    }
}

