// * Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. 
//  Example:
//  n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}

using System;

class PermutationFrom1toN
{

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] arrayOfNumbers = new int[N];

        for (int i = 1; i <= N; i++)
        {
            arrayOfNumbers[i - 1] = i;
        }

        Permutate(arrayOfNumbers, 0, arrayOfNumbers.Length - 1);



    }

    static void Permutate(int[] givenArrayOfNumbers, int current, int length)
    {
        if (current == length)
        {
            for (int i = 0; i <= length; i++)
            {
                Console.Write(givenArrayOfNumbers[i] + " ");
            }
            Console.WriteLine();
        }
        else
        {
            for (int i = current; i <= length; i++)
            {
                int temp = givenArrayOfNumbers[i];
                givenArrayOfNumbers[i] = givenArrayOfNumbers[current];
                givenArrayOfNumbers[current] = temp;

                Permutate(givenArrayOfNumbers, current + 1, length);

                temp = givenArrayOfNumbers[i];
                givenArrayOfNumbers[i] = givenArrayOfNumbers[current];
                givenArrayOfNumbers[current] = temp;
            }
        }

    }


}


