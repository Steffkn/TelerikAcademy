// Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2  value=1.

using System;

class ExtractFromInt
{
    static void Main()
    {
        //  декларираме числото, което проверяваме (i) и съответния бит, който изследваме (b)
        int i = 5;
        int b = 2;

        // логиката е като от предходната задача ( i = v ; b = p)
        // умножаваме "i" с 1 предварително отместено "b" пъти наляво, след което резултатът бива отместен "b" пъти надясно
        // резултатът е едно единствено число, което може да е само 1 или 0, от съответната позиция
        Console.WriteLine("The value {0} has {1} at bit number {2} (counting from 0)", i, (i & ( 1 << b) ) >> b, b);

    }
}
