// Write a method that return the maximal element in a portion of array of integers starting at given index. 
// Using it write another method that sorts an array in ascending / descending order.

using System;
using System.Collections.Generic;
class FindMaxIntInSubArray
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
        Console.WriteLine();

        // first part of the task
        Console.WriteLine("Enter starting and ending point for the search");
        Console.Write("Starts at: ");
        int startingPoint = int.Parse(Console.ReadLine());
        Console.Write("Ends at: ");
        int endingPoint = int.Parse(Console.ReadLine());

        // finds the index of the element with max value in given interval
        int maxElementIndex = MaxElement(givenArray, startingPoint, endingPoint);
        Console.WriteLine("Max element of the array between {0} and {1} element (starting from 0) is {2} !", startingPoint, endingPoint, givenArray[maxElementIndex]);
        // end of first part

        // start of the second part
        // sort the array
        givenArray = SortArray(givenArray);
        // print the array on the console
        foreach (var item in givenArray)
        {
            Console.Write("{0} ", item);
        }
        // end of the second part
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

    /// <summary>
    /// Method that find the index of the element with the biggest value from an array in a given interval.
    /// </summary>
    /// <param name="array">Given array to search in.</param>
    /// <param name="startAt">Starting point of the search.</param>
    /// <param name="endAt">Ending point of the search.</param>
    /// <returns></returns>
    public static int MaxElement(int[] array, int startAt, int endAt)
    {
        int maxElement = int.MinValue;
        int maxElementIndex = -1;
        // if the start point has bigger value from the end point show error msg
        if (startAt > endAt)
        {
            Console.WriteLine("Bad input!");
            return -1;
        }
            // if the srat or end point is bigger than the lenght of the array, show error msg
        else if (startAt >= array.Length && endAt >= array.Length)
        {
            Console.WriteLine("Bad input!");
            return -1;
        }

        // loop that srats from srartAt and end at endAt
        for (int index = startAt; index <= endAt; index++)
        {
            // if the element at position index is bigger than the current element with max value
            if (array[index] > maxElement)
            {
                // we have new element with max value
                maxElement = array[index];
                // save the index of that element
                maxElementIndex = index;
            }
        }
        // return the index of the element with max value
        return maxElementIndex;
    }

    /// <summary>
    /// Method that sorts an array by finding the biggest element and switching the places with that element and the last element of the array.
    /// </summary>
    /// <param name="array">Array to sort.</param>
    /// <returns>Returns a sorted array.</returns>
    public static int[] SortArray(int[] array)
    {
        // the srating point of the array
        int startAt = 0;
        // the last element of the array
        int endAt = array.Length-1;

        // loop that goes through all elements (from startAt to endAt), finds the biggest one and switches places between the one with max value and the one at position endAt
        for (int index = 0; endAt >= 0; index++)
        {
            // finds the index of the element with the max value in the array
           int maxElementIndex = MaxElement(array, startAt, endAt);

           // switch the element with max value with the (last element - index) of the array 
            // then find the next max value from the rest and do the same ( index = index + 1);
           int temp = array[array.Length - 1 - index];
           array[array.Length - 1 - index] = array[maxElementIndex];
           array[maxElementIndex] = temp;
           endAt--;
        }

        return array;
    }
}

