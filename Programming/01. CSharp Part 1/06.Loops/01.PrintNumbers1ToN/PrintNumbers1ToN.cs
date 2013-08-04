//Write a program that prints all the numbers from 1 to N.
using System;
class PrintNumbers1ToN
{

    static void Main()
    {
        int digit;
        bool flag;
        do
        { 
            // input with checking for correct values
            Console.WriteLine("Enter a number!");
            string line = Console.ReadLine();
            flag = int.TryParse(line, out digit);
            if( flag )
            {
                digit = int.Parse(line);
            }
            else
            {
                Console.WriteLine("Incorect value!");
            }
        } while( flag == false );

        // if the number is positive
        if( digit >= 1 )
        {
            for( int i = 1; i <= digit; i++ )
            {
                Console.WriteLine(i);
            }
        }
        // if the number is negative or zero
        else
        {
            for( int i = 1; i >= digit; i-- )
            {
                Console.WriteLine(i);
            }
        }

    }
}
