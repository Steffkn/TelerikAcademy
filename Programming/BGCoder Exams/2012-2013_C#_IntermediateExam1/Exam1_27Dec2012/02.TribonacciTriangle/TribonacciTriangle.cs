using System;

class TribonacciTriangle
{
    static void Main()
    {
        long firstTribonacci = int.Parse(Console.ReadLine());
        long secondTribonacci = int.Parse(Console.ReadLine());
        long thirdTribonacci = int.Parse(Console.ReadLine());
        long rows = int.Parse(Console.ReadLine());

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                Console.Write(firstTribonacci);
                if (j <= i)
                {
                    Console.Write(" ");
                    long temp = firstTribonacci + secondTribonacci + thirdTribonacci;
                    firstTribonacci = secondTribonacci;
                    secondTribonacci = thirdTribonacci;
                    thirdTribonacci = temp;
                }
            }
            Console.WriteLine();
        }
    }
}