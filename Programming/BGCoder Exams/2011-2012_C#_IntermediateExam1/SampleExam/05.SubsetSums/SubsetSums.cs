using System;
class SubsetSums
{
    static void Main()
    {
        long S = long.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        long[] sequence = new long[N];

        for (int i = 0; i < N; i++)
        {
            sequence[i] = long.Parse(Console.ReadLine());
        }
        int answer = 0;
        int counter = (int)Math.Pow(2, N) - 1;
        for (int i = 1; i <= counter; i++)
        {
            long currentSum = 0;
            for (int j = 0; j < N; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    currentSum += sequence[j];
                }
            }
            if (currentSum == S)
            {
                answer++;
            }
        }
        Console.WriteLine(answer);

    }
}