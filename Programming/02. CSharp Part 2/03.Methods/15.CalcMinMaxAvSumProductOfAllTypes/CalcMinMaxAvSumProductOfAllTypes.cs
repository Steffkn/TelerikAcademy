// Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. 
// Use variable number of arguments.

// * Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.). 
// Use generic method (read in Internet about generic methods in C#).


using System;
using System.Collections.Generic;
class CalcMinMaxAvSumProductOfAllTypes
{
    static void Main()
    {
        // find the wanted values
        dynamic min = MinValue(1, 2, 3, 4, 5, 6);
        dynamic max = MaxValue(1, 2, 3, 4, 5, 6);
        dynamic avarage = Avarage(1, 2, 3, 4, 5, 6);
        dynamic sum = SumAll(1, 2, 3, 4, 5, 6);
        dynamic product = ProductOfAll(1, 2, 3, 4, 5, 6);

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
    public static T MinValue<T>(params T[] elements)
    {
        dynamic min = elements[0];

        foreach (T element in elements)
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
    public static T MaxValue<T>(params T[] elements)
    {
        dynamic max = int.MinValue;

        foreach (var element in elements)
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
    public static T SumAll<T>(params T[] elements)
    {
        dynamic sum = 0;
        foreach (var element in elements)
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
    public static T Avarage<T>(params T[] elements)
    {
        dynamic sum = 0;
        int counter = 0;

        // find the sum and the number of the elements
        sum = SumAll(elements);
        counter = elements.Length;

        // find and return the avarage
        return sum / counter;
    }

    /// <summary>
    /// Method that finds the product of the elements of a list of elements
    /// </summary>
    /// <param name="listOfElements">List of elements</param>
    /// <returns>Returns the product (long)</returns>
    public static T ProductOfAll<T>(params T[] elements)
    {
        dynamic product = 1;

        foreach (var element in elements)
        {
            product *= element;
        }
        return product;
    }
}
