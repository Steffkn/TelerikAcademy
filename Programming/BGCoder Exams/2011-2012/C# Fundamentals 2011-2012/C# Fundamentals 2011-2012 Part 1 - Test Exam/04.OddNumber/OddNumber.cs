﻿using System;
class OddNumber
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        long result = 0;
        for (int i = 1; i <= N; i++)
        {
            long number = long.Parse(Console.ReadLine());
            result ^= number;
        }
        Console.WriteLine(result);
    }
}
