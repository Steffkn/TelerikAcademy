// Sorting an array means to arrange its elements in increasing order. 
// Write a program to sort an array. Use the "selection sort" algorithm: 
// Find the smallest element, move it at the first position, find the smallest from the rest, 
// move it at the second position, etc.

using System;

class SelectionSortAlgorithm
{
    static void Main()
    {
        int[] arrayToBeSorted = { 65, 32, 84, 59, 61, 73, 59, 28, 54, 16, 37, 82, 94, 16, 2, 0, 89, 100 };

        for (int i = 0; i < arrayToBeSorted.Length; i++)
        {
            for (int j = i; j < arrayToBeSorted.Length-1; j++)
            {
                // every time when we find a smaller number that the one at position 'i', that number is swaped with the number at position 'i'
                if (arrayToBeSorted[j] < arrayToBeSorted[i])
                {
                    int temp = arrayToBeSorted[i];
                    arrayToBeSorted[i] = arrayToBeSorted[j];
                    arrayToBeSorted[j] = temp;
                }
            }
        }

        // printing the array after sorting it
        for (int i = 0; i < arrayToBeSorted.Length; i++)
        {
            Console.Write(arrayToBeSorted[i] + " ");
        }
    }
}