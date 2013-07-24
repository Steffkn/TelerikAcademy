// Write a program that finds the index of given element in a sorted array of integers 
// by using the binary search algorithm (find it in Wikipedia).

using System;

class BinarySearchIntExample
{
    static void Main()
    {


        int[] sortedArray = { 1, 3, 8, 9, 13, 15, 16, 18, 24, 27, 
                              29, 31, 34, 36, 39, 42, 44, 47, 48, 50 };

        Console.WriteLine("Type one of the following integers to find it's index in the array:");
        Console.WriteLine("Index : Number");
        for (int i = 0; i < sortedArray.Length; i++)
        {
            Console.WriteLine("{0} : {1}", i, sortedArray[i]);
        }
        Console.Write("-> ");
        int choice = int.Parse(Console.ReadLine());
        int bottom = 0;
        int top = sortedArray.Length;
        int mid = (top + bottom) / 2;

        while (true)
        {

            if (sortedArray[mid] == choice)
            {
                Console.WriteLine("The index of {0} is {1}", choice, mid);
                break;
            }
            if (bottom == mid || top == mid)
            {
                Console.WriteLine("The number not found!");
                break;
            }
            else if (sortedArray[mid] > choice)
            {
                top = mid;
                mid = (top + bottom) / 2;
            }
            else if (sortedArray[mid] < choice)
            {
                bottom = mid;
                mid = (top + bottom) / 2;
            }
        }
    }
}

