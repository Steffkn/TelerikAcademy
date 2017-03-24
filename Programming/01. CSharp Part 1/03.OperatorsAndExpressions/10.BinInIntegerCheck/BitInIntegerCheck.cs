// Write a boolean expression that returns if the bit at position p (counting from 0) 
// in a given integer number v has value of 1. Example: v=5; p=1 -> false.

using System;

class BitInIntegerCheck
{
    static void Main()
    {
        // декларираме променливи за числото (v) и позицията (p), за която ще проверяваме
        int v = 8;
        int p = 3;
        // израза е прекалено лесен и не мисля, че си заслужава декларацията на 2 допълнителни променливи...
        // умножаваме "v" с 1 предварително отместено "p" пъти наляво, след което резултатът бива отместен "p" пъти надясно

        // със същият успех може и да се премести единицата от дясната страна на израза "p" пъти наляво, 
        // като по този начин си спестяваме връщането "p" пъти надясно от другата страна на равенството и е по-лесно за разбиране/четене
        // => if( v & ( 1 << p ) == 1 << p )
        if( ( v & ( 1 << p ) ) >> p == 1 )
        {
            Console.WriteLine("The value {0} has a 1 at bit number {1}", v, p);
        }
        else
        {
            Console.WriteLine("The value {0} has a 0 at bit number {1}", v, p);
        }
    }
}