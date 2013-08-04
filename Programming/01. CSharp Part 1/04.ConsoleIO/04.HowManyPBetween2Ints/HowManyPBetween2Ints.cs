// Write a program that reads two positive integer numbers and 
// prints how many numbers p exist between them such that the 
// reminder of the division by 5 is 0 (inclusive). 
// Example: p(17,25) = 2.

using System;

// this task is done little tricky, because I wanted to make it little bit more interesting
// задачата е сложно решена, но това е с цел да бъде по-интересно :)
class HowManyPBetween2Ints
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
                // counter for the numbers we want
                int count = 0;
                // temp variable that will hold the numbers we are seeking
                int temp = firstNumber;

                // exchanging the values of the first and the second variable if the second one is smaller than the first one
                if( firstNumber > secondNumber )
                {
                    temp = secondNumber;
                    secondNumber = firstNumber;
                    firstNumber = temp;
                }

                // with this line we add to temp as much as in needs to become a number that divides by 5 without reminder
                // if temp equals 17, this line will add 5 - 2 = 3 => temp will be 20
                temp += 5 - temp % 5;
                // now we can start counting the numbers we want by adding 5 to temp, untill temp get bigger than the second variable
                for( ; temp <= secondNumber; temp += 5 ) { count++; }
                Console.WriteLine("Between {0} and {1} there are {2} numbers that divide by 5 without reminder", firstNumber, secondNumber, count);
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

