// Write a program that gets two numbers from the console and 
// prints the greater of them. Don’t use if statements.

using System;
class CompareWithoutIf
{
    static void Main()
    {
        Console.WriteLine("Enter 2 integers");
        
        int firstNumber;
        int secondNumber;

        // checking if the input is an integer
        if( int.TryParse(Console.ReadLine(), out firstNumber) )
        {
            // checking if the input is an integer
            // this if statement is nested because both numers should be valid
            if( int.TryParse(Console.ReadLine(), out secondNumber) )
            {

                // using while loop instead of if statement
                while( firstNumber > secondNumber )
                {
                    Console.WriteLine("{0} is bigger than {1}", firstNumber, secondNumber);
                    break;
                }
                while( firstNumber < secondNumber )
                {
                    Console.WriteLine("{0} is bigger than {1}", secondNumber, firstNumber);
                    break;
                }
                while( firstNumber == secondNumber )
                {
                    Console.WriteLine("{0} is equal to {1}, aren't they? :)", firstNumber, secondNumber);
                    break;
                }

            }
            else
            {
                // if the second number is no a valid number we will see this line at the console
                Console.WriteLine("Invalid input! (Numbers only)");
            }
        }
        else
        {
            // if the first number is no a valid number we will see this line at the console
            Console.WriteLine("Invalid input! (Numbers only)");
        }
    }
}

