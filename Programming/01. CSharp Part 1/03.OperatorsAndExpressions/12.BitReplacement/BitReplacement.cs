// We are given integer number n, value v (v=0 or 1) and a position p. 
// Write a sequence of operators that modifies n to hold the value v at the position p from the binary representation of n.
//    Example: n = 5 (00000101), p=3, v=1 -> 13 (00001101)
//    n = 5 (00000101), p=2, v=0 -> 1 (00000001)

using System;

class BitReplacement
{
    static void Main()
    {
        // декларираме променливи за числото, което изследваме (i)
        int i = 5;
        int newInt;
        int bit = 3;
        byte value = 1;
        int mask;
        // ако трябва да заместим с бит = 1
        if( value == 1 )
        {
            mask = 1 << bit; // създаваме си маска с бита, който искаме да заместим равен на 1;
            newInt = i | mask; // събираме към старото число маската и получаваме числото "i" с единица на желаното място;
        }
        // в противен случай, ако трябва да заместим с бит = 0;
        else
        {
            mask = ~( 1 << bit ); // създаваме си инвертирана маска с бита, който искаме да заместим равен на 0;
            newInt = i & mask; // тъй като искаме да "добавим" 0 , трябва да умножим числото с маската
        }
        Console.WriteLine("The value {0} changed to {1}", i, newInt);
    }
}
