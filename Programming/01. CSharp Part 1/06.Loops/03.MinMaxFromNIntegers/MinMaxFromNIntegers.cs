// Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

using System;
class PrintFrom1ToN
{
    static void Main()
    {
        int digit = 0;
        int min = int.MaxValue;
        int max = int.MinValue;
        bool flag;
        do
        { // input with checking for correct values
            Console.WriteLine("Enter the length of the sequence! (above 1)");
            flag = int.TryParse(Console.ReadLine(), out digit);
            if( flag )
            {
                if( digit <= 1 )
                {
                    Console.WriteLine("The number must be above 1!");
                    flag = false;
                }
            }
            else
            {
                Console.WriteLine("Incorrect value!");
            }
        } while( flag == false );


        // entering 'digit' number of values
        for( int i = 0; i < digit; i++ )
        {
            do
            {
                int temp;
                Console.Write("Write number[{0}]: ", i+1);
                flag = int.TryParse(Console.ReadLine(), out temp);
                if( flag )
                {
                    if( min > temp )
                    {
                        min = temp;
                    }
                    if( max < temp )
                    {
                        max = temp;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect value!");
                }
            } while( flag == false );
        }// end of input

        Console.WriteLine("Min = {0} \nMax = {1}", min, max);

    }
}
