// Write a program to convert from any numeral system of given base s 
// to any other numeral system of base d (2 ≤ s, d ≤  16).

using System;

class ConvertSToDSystem
{
    static void Main()
    {
        Console.WriteLine("Enter a number:");
        string numberInS = Console.ReadLine();
        Console.WriteLine("Enter the base of the number {0} : ", numberInS);
        int baseS = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the wanted number system you want to convert {0} to:", numberInS);
        int wantedBaseD = int.Parse(Console.ReadLine());

        string resultInD = SToDSystem(numberInS, baseS, wantedBaseD);
        Console.WriteLine(resultInD);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    static char FindChar(int i)
    {
        if (i >= 10)
        {
            return (char)('A' + i - 10);
        }
        else
        {
            return (char)('0' + i);
        }
    }

    /// <summary>
    /// Method that finds a number in a string as char and returs it as int
    /// </summary>
    /// <param name="givenNumber">Given number</param>
    /// <param name="position">Wanted position</param>
    /// <returns> Returns a number at given position in a string as int</returns>
    static int FindNumber(string givenNumber, int position)
    {
        if (givenNumber[position] >= 'A')
        {
            return givenNumber[position] - 'A' + 10;
        }
        else
        {
            return givenNumber[position] - '0';
        }
    }


    /// <summary>
    /// Method that converts a number with base S to number with base Dec
    /// </summary>
    /// <param name="givenNumber">Given number</param>
    /// <param name="sSystem">The base of the given number</param>
    /// <returns></returns>
    static int SToDec(string givenNumber, int sSystem)
    {
        int result = 0;

        for (int i = givenNumber.Length - 1, p = 1; i >= 0; i--, p *= sSystem)
        {
            result += FindNumber(givenNumber, i) * p;
        }
        return result;
    }


    /// <summary>
    /// Method that converts a number fom dec to system with base D.
    /// </summary>
    /// <param name="numberDec">Given number</param>
    /// <param name="dSystem">Wanted base of the result</param>
    /// <returns></returns>
    static string DecToD(int numberDec, int dSystem)
    {
        string result = String.Empty;

        for (; numberDec != 0; numberDec /= dSystem)
        {
            result = FindChar(numberDec % dSystem) + result;
        }

        return result;
    }

    /// <summary>
    /// Method that combines the other two methods and returns the answer
    /// </summary>
    /// <param name="number"></param>
    /// <param name="sSystem"></param>
    /// <param name="dSystem"></param>
    /// <returns></returns>
    /// 
    static string SToDSystem(string number, int sSystem, int dSystem)
    {
        return DecToD(SToDec(number, sSystem), dSystem);
    }


}