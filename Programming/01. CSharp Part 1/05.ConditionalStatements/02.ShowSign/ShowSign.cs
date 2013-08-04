// Write a program that shows the sign (+ or -) of the product of three 
// real numbers without calculating it. Use a sequence of if statements.

using System;

class ShowSign
{
    static void Main()
    {
        int firstValue;
        if( !int.TryParse(Console.ReadLine(), out firstValue) )
        {
            Console.WriteLine("Invalid value!");
        }
        int secondValue;
        if( !int.TryParse(Console.ReadLine(), out secondValue) )
        {
            Console.WriteLine("Invalid value!");
        }
        int thirdValue;
        if( !int.TryParse(Console.ReadLine(), out thirdValue) )
        {
            Console.WriteLine("Invalid value!");
        }

        bool isPlus = true; // this will hold the sign (true = plus, false = minus)
        
        // every time we find a negative value we will change the value of isPlus
        if( firstValue < 0 )
        {
            isPlus = !isPlus;
        }
        if( secondValue < 0 )
        {
            isPlus = !isPlus;
        }
        if( thirdValue < 0 )
        {
            isPlus = !isPlus;
        }

        //  if we have even number of minus signs the result will be true ( + )
        if( isPlus )
        {
            Console.WriteLine("the sign is +");
        }
        else if( firstValue == 0 && secondValue == 0 && thirdValue == 0 )
        {
            Console.WriteLine("All numbers are zeros!");
        }
        //  if we have odd number of minus signs the result will be true ( - )
        else
        {
            Console.WriteLine("the sign is -");
        }
    }
}

