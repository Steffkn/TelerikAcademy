using System;

class Carpets
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int halfSide = N / 2;

        for (int i = 1; i <= N / 2; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (j < halfSide)
                {
                    if (j < halfSide - i)
                    {
                        Console.Write(".");
                    }
                    else if (j == halfSide - 1)
                    {
                        Console.Write("/");
                    }
                    else if (j >= halfSide - i)
                    {
                        Console.Write("/ ");
                        j++;
                    }
                }
                else if (j >= halfSide)
                {
                    if (i % 2 != 0 && j == halfSide)
                    {
                        Console.Write("\\");
                    }
                    else if (j >= halfSide + i)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write(" \\");
                        j++;
                    }
                }
            }
            Console.WriteLine();
        }


        for (int i = N / 2; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (j < halfSide)
                {
                    if (j < i - halfSide)
                    {
                        Console.Write(".");
                    }
                    else if (j == halfSide - 1)
                    {
                        Console.Write("\\");
                    }
                    else if (j >= halfSide - i)
                    {
                        Console.Write("\\ ");
                        j++;
                    }
                }
                else if (j >= halfSide)
                {
                    if (i % 2 != 0 && j == halfSide)
                    {
                        Console.Write("/");
                    }
                    else if (j < N - i + halfSide)
                    {
                        Console.Write(" /");
                        j++;
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}