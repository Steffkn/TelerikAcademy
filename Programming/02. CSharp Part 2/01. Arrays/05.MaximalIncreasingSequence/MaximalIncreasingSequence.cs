//Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.
using System;

class MaximalIncreasingSequence
{
    static void Main()
    {
        int[] arrayOfInts = { 3, 2, 3, 4, 2, 2, 4 };

        int maxSeqIndex = 0;
        int maxLenght = 0;
        int count = 1;
        for (int i = 0; i < arrayOfInts.Length - 1; i++)
        {
            if (arrayOfInts[i] <= arrayOfInts[i + 1])
            {
                count++;
            }
            else
            {
                count = 1;
            }

            if (count > maxLenght)
            {
                maxSeqIndex = i - count + 2;
                maxLenght = count;
            }
        }

        Console.WriteLine("The first maximal increasing sequence starts from {0} number", maxSeqIndex + 1);
        Console.WriteLine("With maximal lenght of {0} digits!", maxLenght);
        Console.Write("Sequance {");
        for (int i = maxSeqIndex; i < maxSeqIndex + maxLenght; i++)
        {
            if (i < maxSeqIndex + maxLenght - 1)
            {
                Console.Write(arrayOfInts[i] + ", ");
            }
            else
            {
                Console.Write(arrayOfInts[i]);
            }
        }
        Console.WriteLine("}");
    }
}

