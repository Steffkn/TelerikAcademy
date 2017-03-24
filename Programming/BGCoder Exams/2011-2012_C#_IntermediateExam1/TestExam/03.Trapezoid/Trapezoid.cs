using System;
class Trapezoid
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        for (int j = 1; j <= N + 1; j++)
        {
            for (int i = 1; i <= 2 * N; i++)
            {
                if (i > N && j == 1 || i == (2 * N) || (i == (N - j + 2) && j != 1) || j == N + 1) // every || is another if..
                //  top border      || right border || left border /                || bottom border
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