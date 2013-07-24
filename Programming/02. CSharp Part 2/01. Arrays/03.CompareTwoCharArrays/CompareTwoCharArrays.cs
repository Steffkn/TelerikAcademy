// Write a program that compares two char arrays lexicographically (letter by letter).

using System;
class CompareTwoCharArrays
{
    static void Main(string[] args)
    {
        char[] firstArray = { 'a', 'b', 'c', 'D' };
        char[] secondArray = { 'a', 'b', 'c', 'D', 's' };

        bool equal = true;
        int minLenght;

        if (firstArray.Length > secondArray.Length)
        {
            minLenght = secondArray.Length;
            Console.WriteLine("First arrays is longer!");
        }
        else if (firstArray.Length < secondArray.Length)
        {
            minLenght = firstArray.Length;
            Console.WriteLine("The second array is longer!");
        }
        else
        {
            Console.WriteLine("The array are with equal lenght!");
            minLenght = firstArray.Length;
        }

        // checking if both arrays are equal symbol by symbol
        for (int i = 0; i < minLenght; i++)
        {
            if (firstArray[i] != secondArray[i])
            {
                equal = false;
                break;
            }
        }

        if (equal)
        {
            Console.WriteLine("The arrays are equal intil the {0} symbol", minLenght);
        }
        else
        {
            Console.WriteLine("The arrays are not equal");
        }
    }
}


