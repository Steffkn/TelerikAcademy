// Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.

using System;
class PrintNumbers1ToN_condition
{
    static void Main()
    {
        int digit;
        bool flag;
        do
        { // input with checking for correct values
            Console.WriteLine("Enter a number!");
            string line = Console.ReadLine();
            flag = int.TryParse(line, out digit);
            if( flag )
            {
                digit = int.Parse(line);
            }
            else
            {
                Console.WriteLine("Incorrect value!");
            }
        } while( flag == false );

        // if the number is positive
        if( digit > 1 )
        {
            for( int i = 1; i <= digit; i++ )
            {
                if( i % 21 != 0 )            // dividing by 3 & 7 = dividing by 21; (3*7)
                {
                    Console.WriteLine(i);
                }
            }
        }
        // if the number is negative
        else
        {
            for( int i = 1; i >= digit; i-- )
            {
                if( i % 21 != 0 )
                {
                    Console.WriteLine(i);
                }
            }
        }

    }
}
