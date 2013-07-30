// Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, 
// if there’s no such element.
// Use the method from the previous exercise.


using System;
using System.Collections.Generic;
class FirstIntBiggerThanNeightbors
{
    static void Main(string[] args)
    {
        // make and fill new array of integers
        int[] givenArray = MakeIntArray();

        // print the elements in a row
        foreach (var item in givenArray)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();

        // loop trough all the elements if the array
        for (int index = 0; index < givenArray.Length; index++)
        {
            // give to result the position of the wanted element or -1 if there is none found
            int result = CheckNeighbors(givenArray, index);
            // if wanted element is found
            if (result != -1)
            {
                Console.WriteLine("First element that has neightbors with bigger values is found at position {0}", result + 1);
                // stop the loop
                break;
            }
        }
    }

    // although the method is not made for this task, the result is good
    /// <summary>
    /// Method that checkes if the neighbors of the element array[position] are bigger that it.
    /// </summary>
    /// <param name="array">Array of integers.</param>
    /// <param name="position">The position of the element that is checked.</param>
    /// <returns>Returns the position of an element with bigger beightbors or -1 if none is found.</returns>
    public static int CheckNeighbors(int[] array, int position)
    {
        // if 'position' is less than 0 or bigger that the size of the array 
        if (position < 0 || position >= array.Length)
        {
            // msg to the user
            Console.WriteLine("Given position is outside the bounds of the array!");
            return -1;
        }
        else
        {
            // if there is only one neighbor to the right of the element
            if (position == 0 && (array[position] < array[position + 1]))
            {
                Console.WriteLine("There is only one neighbor that is {0} than {1}!", array[position] < array[position + 1] ? "bigger" : "not bigger", array[position]);
                return position;
            }
            // else if there is only on neightbor to the left of the element
            else if (position == array.Length - 1 && (array[position] < array[position - 1]))
            {
                Console.WriteLine("There is only one neighbor that is {0} than {1}!", array[position] < array[position - 1] ? "bigger" : "not bigger", array[position]);
                return position;
            }
            // if thre two neighbors
            else
            {
                // because its said to use the same method there is only an if statement inserted to minimize the spam on the console
                if ((position != 0 && position != array.Length - 1) && (array[position] < array[position - 1]) && (array[position] < array[position + 1]))
                {
                    // check if the element to the left is bigger than the element at [position] and print the result on the screen
                    Console.WriteLine("Left neighbor is {0} than {1}!", array[position] < array[position - 1] ? "bigger" : "not bigger", array[position]);
                    // check if the element to the right is bigger than the element at [position] and print the result on the screen
                    Console.WriteLine("Right neighbor is {0} than {1}!", array[position] < array[position + 1] ? "bigger" : "not bigger", array[position]);
                    return position;
                }
            }
            return -1;
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

