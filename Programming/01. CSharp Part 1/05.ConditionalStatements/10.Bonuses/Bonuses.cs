// Write a program that applies bonus scores to given scores in the range [1..9]. 
// The program reads a digit as an input. 
// If the digit is between 1 and 3, the program multiplies it by 10; 
// if it is between 4 and 6, multiplies it by 100; 
// if it is between 7 and 9, multiplies it by 1000. 
//If it is zero or if the value is not a digit, the program must report an error.
// Use a switch statement and at the end print the calculated new value in the console.


using System;

class Bonuses
{
    static void Main()
    {
        int digit;
        Console.Write("Write a number between 1 and 9: ");

        if( !int.TryParse(Console.ReadLine(), out digit) )
        {
            Console.WriteLine("Incorect value!");
        }

        switch( digit )
        {
                // if the digit is 1 2 or 3
            case 1:
            case 2:
            case 3:
                Console.WriteLine("Bonus: {0}", digit * 10);
                break;
                // if the digit is 4 5 or 6
            case 4:
            case 5:
            case 6:
                Console.WriteLine("Bonus: {0}", digit * 100);
                break;
            case 7:
            case 8:
            case 9:
                // if the digit is 7 8 or 9
                Console.WriteLine("Bonus: {0}", digit * 1000);
                break;
            default:
                Console.WriteLine("The digit must be between 1 and 9!");
                break;
        }
    }
}

