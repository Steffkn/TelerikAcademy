using System;

class Program
{
    static void Main()
    {
        string[] valleyNumbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        int[] valley = new int[valleyNumbers.Length];

        for (int i = 0; i < valley.Length; i++)
        {
            valley[i] = int.Parse(valleyNumbers[i]);
        }

        int patternNumber = int.Parse(Console.ReadLine());

        long bestPrice = long.MinValue;

        for (int index = 0; index < patternNumber; index++)
        {
            long sum = FindPrice(valley);
            if (sum > bestPrice)
            {
                bestPrice = sum;
            }
        }

        Console.WriteLine(bestPrice);
    }

    static long FindPrice(int[] valley)
    {
        string[] pattern = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        int[] patternNumbers = new int[pattern.Length];

        for (int index = 0; index < patternNumbers.Length; index++)
        {
            patternNumbers[index] = int.Parse(pattern[index]);
        }

        bool[] isVisited = new bool[valley.Length];
        long sum = valley[0];
        isVisited[0] = true;
        int currentPosition = 0;

        while (true)
        {
            for (int index = 0; index < patternNumbers.Length; index++)
            {
                int move = currentPosition + patternNumbers[index];

                if (move >= 0 && move < valley.Length && !isVisited[move])
                {
                    sum += valley[move];
                    isVisited[move] = true;
                    currentPosition = move;
                }
                else
                {
                    return sum;
                }
            }
        }
    }
}

