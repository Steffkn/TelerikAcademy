// * Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

// същата като 13

using System;

class BitExchangeInRange
{
    static void Main()
    {
        // деклрация на променливи
        int UInteger = 56;   // изследваното число; резултат -> 117440512
        int newUInteger = UInteger; // новополученото число (117440512 в случая)
        int mask;                   // маска за поредния бит

        int p = 3;      // младшият бит от който започва размятана
        int q = 24;     // старшият бит от който започва размяната
        int k = 3;      // колко бита ще бъдат разменени

        int tempValue;  // за разместването
        int UIntAndMask;    // резултатът от умножението на маската и числото

        for( int t = 0; t <= k - 1; t++ )
        {

            // взимаме старшият бит за размяна
            mask = 1 << ( q + t );
            UIntAndMask = UInteger & mask;
            tempValue = UIntAndMask >> q + t;      // взимаме 24, 25, 26 бит

            // взимаме съответният младши бит за размяна
            mask = 1 << ( p + t );
            UIntAndMask = UInteger & mask;
            UIntAndMask = UIntAndMask >> p + t;     // взимаме 3, 4, 5 бит


            // размяната на младшия бит в зависимост от това дали е 1 (събиране) или 0 (умножение)
            if( UIntAndMask == 1 )
            {
                mask = 1 << q + t;
                newUInteger = newUInteger | mask;
            }
            else
            {
                mask = ~( 1 << q + t ); // маска в която желания бит е 0, всичко друго 1
                newUInteger = newUInteger & mask;
            }

            // размяната на старшия бит в зависимост от това дали е 1 (събиране) или 0 (умножение)
            if( tempValue == 1 )
            {
                mask = 1 << p + t;
                newUInteger = newUInteger | mask;
            }
            else
            {
                mask = ~( 1 << p + t ); // маска в която желания бит е 0, всичко друго 1
                newUInteger = newUInteger & mask;
            }
        }
        Console.WriteLine("The value {0} changed to {1}", UInteger, newUInteger);
    }
}
