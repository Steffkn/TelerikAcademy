using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
class Program
{
    static void Main()
    {
        BigInteger number = BigInteger.Parse(Console.ReadLine());

        List<string> digits = new List<string>();
        string result = string.Empty;

        if (number == 0)
        {
            result = "A";
        }

        for (char index = 'A'; index <= 'Z'; index++)
        {
            digits.Add(index.ToString());
        }

        for (char index = 'a'; index <= 'i'; index++)
        {
            for (char i = 'A'; i <= 'Z'; i++)
            {
                digits.Add(index.ToString() + i.ToString());
            }
        }

        while (number != 0)
        {
            result = digits[(int)(number % 256)] + result;
            number /= 256;
        }

        Console.WriteLine(result);
    }
}

