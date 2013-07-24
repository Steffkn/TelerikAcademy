// Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. 
// Example:
// N = 3, K = 2 -> {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3},{3, 1}, {3, 2}, {3, 3}

using System;

class VariationOfKFromNElements
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int N = int.Parse(Console.ReadLine());

        Console.Write("Enter K: ");
        int K = int.Parse(Console.ReadLine());

        int[] variations = new int[K];

        Console.WriteLine("Variation of K elements from N elements");
        Variations(variations, 0, N);
    }


    // function that will generate the variations
    static void Variations(int[] array, int index, int N)
    {
        if (index == array.Length)
        {
            Console.Write("{");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("}");
        }
        else
        {
            for (int i = 1; i <= N; i++)
            {
                array[index] = i;
                Variations(array, index + 1, N);
            }
        }
    }


}


