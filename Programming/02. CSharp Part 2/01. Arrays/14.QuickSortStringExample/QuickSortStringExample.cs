// Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

using System;
class QuickSortStringExample
{
    static void Main(string[] args)
    {
        string[] array = { "Hello", "Lili", "Goodbye", "Madonna", "Didi", "Yewoll", "Magic" };

        Console.WriteLine("Unsorted");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine("\nSorted");

        // sorting with quicksprt
        Quicksort(array, 0, array.Length - 1);

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");

        }
        Console.WriteLine();

    }

    public static void Quicksort(IComparable[] elements, int left, int right)
    {
        int i = left, j = right;
        IComparable pivot = elements[(left + right) / 2];

        while (i <= j)
        {
            while (elements[i].CompareTo(pivot) < 0)
            {
                i++;
            }

            while (elements[j].CompareTo(pivot) > 0)
            {
                j--;
            }

            if (i <= j)
            {
                IComparable tmp = elements[i];
                elements[i] = elements[j];
                elements[j] = tmp;

                i++;
                j--;
            }
        }

        if (left < j)
        {
            Quicksort(elements, left, j);
        }

        if (i < right)
        {
            Quicksort(elements, i, right);
        }
    }
}

