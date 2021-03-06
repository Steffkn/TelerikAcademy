﻿// Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. 
// Use variable number of arguments.

using System;
using System.Collections.Generic;
class CalcMinMaxAvaragaSumProduct
{
    static void Main()
    {
        int element;
        List<int> listOfIntegers = new List<int>();
        Console.WriteLine("Enter integers and anything else to stop: ");

        // fill the list with valid integers
        // if the input isnt a valid integer the loop will break
        while (int.TryParse(Console.ReadLine(), out element))
        {
            listOfIntegers.Add(element);
        }

        // find the wanted values
        int min = MinValue(listOfIntegers);
        int max = MaxValue(listOfIntegers);
        int avarage = Avarage(listOfIntegers);
        int sum = SumAll(listOfIntegers);
        long product = ProductOfAll(listOfIntegers);

        // print the results
        Console.WriteLine("The minimal value is {0}", min);
        Console.WriteLine("The maximal value is {0}", max);
        Console.WriteLine("The avarage value is {0}", avarage);
        Console.WriteLine("The sum of all elements is {0}", sum);
        Console.WriteLine("The product of all elements is {0}", product);
    }

    /// <summary>
    /// This method finds the minimal value from a list and returs it.
    /// </summary>
    /// <param name="listOfElements">List of elements</param>
    /// <returns>Returns the element with minimal value</returns>
    public static int MinValue(List<int> listOfElements)
    {
        int min = int.MaxValue;

        foreach (var element in listOfElements)
        {
            if (min > element)
            {
                min = element;
            }
        }

        return min;
    }

    /// <summary>
    /// This method finds the maximal value from a list and returs it.
    /// </summary>
    /// <param name="listOfElements">List of elements</param>
    /// <returns>Returns the element with maximal value</returns>
    public static int MaxValue(List<int> listOfElements)
    {
        int max = int.MinValue;

        foreach (var element in listOfElements)
        {
            if (max < element)
            {
                max = element;
            }
        }
        return max;
    }

    /// <summary>
    /// Method that finds the sum of the elements of a list of elements
    /// </summary>
    /// <param name="listOfElements">List of elements</param>
    /// <returns>Returns the sum (int)</returns>
    public static int SumAll(List<int> listOfElements)
    {
        int sum = 0;
        foreach (var element in listOfElements)
        {
            sum += element;
        }
        return sum;
    }

    /// <summary>
    /// Find the avarage in a list of integers.
    /// </summary>
    /// <param name="listOfElements">The list of integers</param>
    /// <returns></returns>
    public static int Avarage(List<int> listOfElements)
    {
        int sum = 0;
        int counter = 0;

        // find the sum and the number of the elements
        sum = SumAll(listOfElements);
        counter = listOfElements.Count;

        // find and return the avarage
        return sum / counter;
    }

    /// <summary>
    /// Method that finds the product of the elements of a list of elements
    /// </summary>
    /// <param name="listOfElements">List of elements</param>
    /// <returns>Returns the product (long)</returns>
    public static long ProductOfAll(List<int> listOfElements)
    {
        long product = 1;

        foreach (var element in listOfElements)
        {
            product *= element;
        }
        return product;
    }
}
