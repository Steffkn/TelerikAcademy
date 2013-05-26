// Declare five variables choosing for each 
// of them the most appropriate of the types 
// byte, sbyte, short, ushort, int, uint, long, ulong 
// to represent the following values: 
// 52130, -115, 4825932, 97, -10000.

using System;

class MostAppropriateType
{
    static void Main()
    {
        // въвеждане на подходящи типове за дадените числа
        ushort ushorty = 52130;
        sbyte sbyty = -115;
        int integer = 4825932;
        byte byty = 97;
        short shorty = -10000;

        // изчеждане на екрана на променливите
        Console.WriteLine(ushorty);
        Console.WriteLine(sbyty);
        Console.WriteLine(integer);
        Console.WriteLine(byty);
        Console.WriteLine(shorty);
    }
}
