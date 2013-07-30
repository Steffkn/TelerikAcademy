// Write a method that checks if the element at given position 
// in given array of integers is bigger than its two neighbors (when such exist).

using System;
using System.Collections.Generic;
class NumberBiggerThanItsNeighbors
{
    static void Main()
    {
        // make and fill new array of integers
        int[] givenArray = MakeIntArray();

        // print the elements in a row
        foreach (var item in givenArray)
        {
            Console.Write("{0} ", item);
        }
        // take the wanted position
        Console.Write("\nEnter position that will be checked: ");
        int position = int.Parse(Console.ReadLine());

        Console.WriteLine();

        // check the neighbors and print the result
        CheckNeighbors(givenArray, position);
    }
    /// <summary>
    /// Method that checkes if the neighbors of the element array[position] are bigger that it.
    /// </summary>
    /// <param name="array">Array of integers.</param>
    /// <param name="position">The position of the element that is checked.</param>
    public static void CheckNeighbors(int[] array, int position)
    {
        // if 'position' is less than 0 or bigger that the size of the array 
        if (position < 0 || position > array.Length)
        {
            // msg to the user
            Console.WriteLine("Given position is outside the bounds of the array!");
        }
        else
        {
            // if there is only one neighbor to the right of the element
            if (position == 0)
            {
                Console.WriteLine("There is only one neighbor that is {0} than {1}!", array[position] < array[position + 1] ? "bigger" : "not bigger", array[position]);
            }
            // else if there is only on neightbor to the left of the element
            else if (position == array.Length)
            {
                Console.WriteLine("There is only one neighbor that is {0} than {1}!", array[position] < array[position - 1] ? "bigger" : "not bigger", array[position]);
            }
            // if thre two neighbors
            else
            {
                // check if the element to the left is bigger than the element at [position] and print the result on the screen
                Console.WriteLine("Left neighbor is {0} than {1}!", array[position] < array[position - 1] ? "bigger" : "not bigger", array[position]);
                // check if the element to the right is bigger than the element at [position] and print the result on the screen
                Console.WriteLine("Right neighbor is {0} than {1}!", array[position] < array[position + 1] ? "bigger" : "not bigger", array[position]);
            }
        }
    }

    /// <summary>
    /// Method that makes and fills an integer array with unknown size.
    /// </summary>
    /// <returns>Returns integer array</returns>
    public static int[] MakeIntArray()
    {
        Console.WriteLine("Enter an array (anything else than integer to stop):");
        int number = 0;
        // make a list of integers
        List<int> list = new List<int>();
        // filling the list with integers from the console
        // if anything else thatn integer is given the loop will break
        while (int.TryParse(Console.ReadLine(), out number))
        {
            list.Add(number);
        }

        int[] intArray = new int[list.Count];
        // converting the list to array
        for (int index = 0; index < intArray.Length; index++)
        {
            intArray[index] = list[index];
        }
        return intArray;
    }
}

