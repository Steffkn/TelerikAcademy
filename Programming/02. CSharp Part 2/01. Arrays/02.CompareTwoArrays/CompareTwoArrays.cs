// Write a program that reads two arrays from the console and compares them element by element.

using System;
class CompareTwoArrays
{
    static void Main(string[] args)
    {
        Console.Write("Enter the lenght of the arrays: ");
        int N = int.Parse(Console.ReadLine());
        bool areEqual = true;
        int[] firstArray = new int[N];
        int[] secondArray = new int[N];

        Console.WriteLine("Enter {0} elements for the first array", N);
        for (int i = 0; i < firstArray.Length; i++)
        {
            firstArray[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Enter {0} elements for the second array", N);
        for (int i = 0; i < secondArray.Length; i++)
        {
            secondArray[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < firstArray.Length; i++)
        {
            if (firstArray[i] != secondArray[i])
            {
                areEqual = false;
            }
        }

        if (areEqual)
        {
            Console.WriteLine("The arrays are equal.");
        }
        else
        {

            Console.WriteLine("The arrays are NOT equal.");
        }
    }
}
