// Write an if statement that examines two integer variables and 
// exchanges their values if the first one is greater than the second one.

using System;

class TwoValuesExchange
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

        // excahnging 2 values without temp var (not a good practice but its interesting :) )
        if( firstValue > secondValue )
        {
            firstValue ^= secondValue;
            secondValue = firstValue ^ secondValue;
            firstValue ^= secondValue;
        }

        Console.WriteLine("{0} {1}",firstValue,secondValue);
    }
}

