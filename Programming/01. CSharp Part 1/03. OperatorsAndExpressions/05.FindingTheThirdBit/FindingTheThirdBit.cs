//Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

using System;
class FindingTheThirdBit
{
    static void Main()
    {

        int someDigit = 8;
        // умножаваме someDigit с 1 предварително отместено 3 пъти наляво (1000 - двоично), след което резултатът бива отместен 3 пъти надясно
        // ако резултатът е равен на 1 => третият бит е единица в противен случай е 0
        if( ( someDigit & ( 1 << 3 ) ) >> 3 == 1 )
        {
            Console.WriteLine("Is 1");
        }
        else
        {
            Console.WriteLine("Is 0");
        }
    }
}

