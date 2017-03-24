using System;
class ForestRoad
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        for (int i = 1; i <= N * 2 - 1; i++)
        {
            for (int j = 1; j <= N; j++)
            {
                if (i == j)
                {
                    Console.Write("*");
                }
                else if (j == 2 * N - i)          // j + i = 2*N after the mid this will work
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }
}