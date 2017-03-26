namespace _4.DancingBits
{
    using System;

    class Program
    {
        static void Main()
        {
            int K = Convert.ToInt32(Console.ReadLine());
            int N = Convert.ToInt32(Console.ReadLine());
            string bin = string.Empty;

            int count = 0;

            for (int i = 0; i < N; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                string numberBin = Convert.ToString(number, 2);
                bin += numberBin;
            }

            char current = bin[0];
            char nextBit = bin[0];
            int currentSum = 0;

            for (int i = 0; i <= bin.Length; i++)
            {

                if (i < bin.Length)
                {
                    nextBit = bin[i];
                }
                if (current != nextBit || i == bin.Length)
                {
                    if (currentSum == K)
                    {
                        count++;
                    }

                    currentSum = 1;
                }
                else
                {
                    currentSum++;
                }

                current = nextBit;
            }

            Console.WriteLine(count);
        }
    }
}
