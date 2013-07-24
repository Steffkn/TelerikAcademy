// Write a program that reads two integer numbers N and K and an array of N elements from the console. 
// Find in the array those K elements that have maximal sum.

using System;
class KElementsWithMaxSum
{
    static void Main()
    {
        Console.Write("Enter the lenght of the sequence (N): ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("Enter how much of the maximal numbers you want to know (K): ");
        int K = int.Parse(Console.ReadLine());

        int[] arrayOfInts = new int[N];
        int[] newArrayOfMaxInts = new int[K];

        for (int i = 0; i < N; i++)
        {
            arrayOfInts[i] = int.Parse(Console.ReadLine());
        }
        
        int tempMaxInt = int.MinValue;
        int maxIndex = 0;

        for (int i = 0; i < K; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (arrayOfInts[j] > tempMaxInt)
                {
                    tempMaxInt = arrayOfInts[j];
                    maxIndex = j;
                }
            }
            arrayOfInts[maxIndex] = int.MinValue;
            newArrayOfMaxInts[i] = tempMaxInt;
            tempMaxInt = int.MinValue;
        }
        Console.WriteLine("Answer: ");
        for (int i = 0; i < K; i++)
        {
            Console.Write(newArrayOfMaxInts[i]+ " ");
        }
    }

}
