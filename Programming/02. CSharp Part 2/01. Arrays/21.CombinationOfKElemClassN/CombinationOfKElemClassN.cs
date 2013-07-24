// Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. 
// Example:
//    N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

using System;
class CombinationOfKElemClassN
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int N = int.Parse(Console.ReadLine());

        Console.Write("Enter K: ");
        int K = int.Parse(Console.ReadLine());

        int[] combinations = new int[K];

        Console.WriteLine("Combinations of K elements class N");
        Combinations(combinations, 0, 1, N);
    }
    // function that will generate the combinations
    static void Combinations(int[] array, int index, int currentNumber, int N)
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
            for (int i = currentNumber; i <= N; i++)
            {
                array[index] = i;
                Combinations(array, index + 1, i + 1, N);
            }
        }
    }
    
}

