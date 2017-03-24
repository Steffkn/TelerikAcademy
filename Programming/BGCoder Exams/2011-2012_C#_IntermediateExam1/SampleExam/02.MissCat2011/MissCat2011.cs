using System;
class MissCat2011
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] cat = new int[11];
        int vote, winner = 0;

        for (int i = 1; i <= N; i++)
        {
            vote = int.Parse(Console.ReadLine());
            cat[vote]++;
        }
        for (int i = 0; i <= 10; i++)
        {
            if (cat[0] < cat[i])
            {
                cat[0] = cat[i];
                winner = i;
            }
        }
        Console.WriteLine(winner);
    }
}