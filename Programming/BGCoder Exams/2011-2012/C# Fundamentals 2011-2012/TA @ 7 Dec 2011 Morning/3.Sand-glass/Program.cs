namespace _3.Sand_glass
{
    using System;

    class Program
    {
        static void Main()
        {
            int N = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i <= N / 2; i++)
            {
                Console.WriteLine("{0}{1}{2}", new String('.', i), new String('*', N - (i * 2)), new String('.', i));
            }

            for (int i = (N / 2) - 1; i >= 0; i--)
            {
                Console.WriteLine("{0}{1}{2}", new String('.', i), new String('*', N - (i * 2)), new String('.', i));
            }
        }
    }
}
