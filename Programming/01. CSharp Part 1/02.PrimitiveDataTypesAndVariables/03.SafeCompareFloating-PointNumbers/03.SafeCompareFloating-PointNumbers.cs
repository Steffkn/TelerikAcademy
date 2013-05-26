// Сравняване на 2 числа с точност 0.000001;

using System;

class Program
{
    static void Main()
    {
        
        //float smallValue = 5.09f;
        //float bigValue = 6.1f;
        //                 0.000001   точност - float ще ни свърши работа за тази точност
        float smallValue = 5.00000001f;
        float bigValue = 5.00000003f;

        Console.Write("({0} ; {1}) -> ", smallValue, bigValue);
        if( smallValue != bigValue )
        {
            Console.Write(false + Environment.NewLine); // Environment.NewLine преминаваме на нов ред след като изпише False на конзолата
        }
        else
        {
            Console.Write(true + Environment.NewLine); // Environment.NewLine преминаваме на нов ред след като изпише True на конзолата
        }

        //           0.000001   точност - float ще ни свърши работа за тази точност
        smallValue = 5.000001f;
        bigValue =   5.000003f;

        Console.Write("({0} ; {1}) -> ", smallValue, bigValue);
        if( smallValue != bigValue )
        {
            Console.Write(false + Environment.NewLine);
        }
        else
        {
            Console.Write(true + Environment.NewLine);
        }

    }
}

