namespace Pillars
{
    using System;

    class Program
    {
        static void Main()
        {
            int N = 8;
            byte[] numbers = new byte[N];

            for (int i = 0; i < N; i++)
            {
                numbers[i] = Convert.ToByte(Console.ReadLine());
            }

            int[] bitSumByCol = new int[8];
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (((numbers[i] & (1 << y)) >> y) == 1)
                    {
                        bitSumByCol[y]++;
                    }
                }
            }

            int leftSum = 0;
            int rightSum = 0;
            int possition = 0;
            for (int i = 0, y = bitSumByCol.Length - 1; ;)
            {
                if (y == i)
                {
                    possition = i;
                    break;
                }
                else if (leftSum > rightSum)
                {
                    rightSum += bitSumByCol[i];
                    i++;
                }
                else if (leftSum < rightSum)
                {
                    leftSum += bitSumByCol[y];
                    y--;
                }
                else
                {
                    rightSum += bitSumByCol[i];
                    i++;
                }
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine(possition);
                Console.WriteLine(leftSum);
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
