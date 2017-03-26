namespace FirTree
{
    using System;

    class Program
    {
        static void Main()
        {
            int N = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i < N; i++)
            {
                Console.WriteLine(string.Format("{0}{1}{2}", new String('.', N - i - 1), new String('*', (i*2)-1), new String('.', N - i - 1)));
            }
            int x = 1;
            Console.WriteLine(string.Format("{0}{1}{2}", new String('.', N - x - 1), new String('*', (x * 2) - 1), new String('.', N - x - 1)));
        }
    }
}
