using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class ExtensionIEnumerable
{
    static void Main(string[] args)
    {

        decimal[] numberTest = new decimal[] { 12, 15, 17.5M };
        Console.WriteLine("Test strings with numbers:");
        numberTest.Print();

        Console.WriteLine("Sum:");
        Console.WriteLine(numberTest.Sum());
        Console.WriteLine("Product:");
        Console.WriteLine(numberTest.Product());
        Console.WriteLine("Average:");
        Console.WriteLine(numberTest.Average());

        string[] stringTest = new string[] { "some", "borring", "string" };
        stringTest.Print();

        Console.WriteLine("Maximal element (alphabeticly):");
        Console.WriteLine(stringTest.Max());
        Console.WriteLine("Minimal element (alphabeticly):");
        Console.WriteLine(stringTest.Min());
        Console.WriteLine();

        Console.WriteLine("Sums the length of the strings:");
        Console.WriteLine(stringTest.Sum(x => x.Length));
        Console.WriteLine("Average using the length of the strings:");
        Console.WriteLine(stringTest.Average(x => x.Length));
        Console.WriteLine("Product using the length of the strings:");
        Console.WriteLine(stringTest.Product(x => x.Length));
        Console.WriteLine();

    }

    /// <summary>
    /// Find the min elemnt from a collection of elements.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="elements"></param>
    /// <returns></returns>
    public static T Min<T>(this IEnumerable<T> elements) where T : IComparable
    {
        // take the first element
        T min = elements.First();
        foreach (var element in elements)
        {
            // if smaller element is found
            if (element.CompareTo(min) < 0)
            {
                min = element;
            }
        }
        return min;
    }

    /// <summary>
    /// Find the max elemnt from a collection of elements.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="elements"></param>
    /// <returns></returns>
    public static T Max<T>(this IEnumerable<T> elements) where T : IComparable
    {
        // take the first element
        T max = elements.First();
        foreach (var element in elements)
        {
            // if bigger element is found
            if (element.CompareTo(max) > 0)
            {
                max = element;
            }
        }
        return max;
    }

    /// <summary>
    /// Product of elements in a collection
    /// </summary>
    /// <typeparam name="T">Type of the collection</typeparam>
    /// <param name="collection"></param>
    /// <param name="condition">Condition of the values of the collection. (null if left blank)</param>
    /// <returns></returns>
    public static decimal Product<T>(this IEnumerable<T> collection, Func<T, decimal> condition = null)
    {
        // if condition is not set convert the numbers to decimal
        if (condition == null)
        {
            condition = (x => Convert.ToDecimal(x));
        }

        decimal result = 1;
        try
        {
            foreach (var element in collection)
            {
                result *= condition(element);
            }
        }
        catch (FormatException formEx)
        {
            throw new ArgumentException("Give a condition to make sum of the collection!", formEx);
        }
        catch (InvalidCastException invEx)
        {
            throw new ArgumentException("Elements cannot be summed! (infinity, Not-a-Number or too large value is given)", invEx);
        }
        return result;
    }

    /// <summary>
    /// Method that finds the sum of a collection of elements
    /// </summary>
    /// <typeparam name="T">Type of the collection</typeparam>
    /// <param name="collection"></param>
    /// <param name="condition">Lambda expression</param>
    /// <returns></returns>
    public static decimal Sum<T>(this IEnumerable<T> collection, Func<T, decimal> condition = null)
    {
        // if condition is not set convert the numbers to decimal
        if (condition == null)
        {
            condition = (x => Convert.ToDecimal(x));
        }
        decimal result = 0;

        try
        {
            foreach (var element in collection)
            {
                result += condition(element);
            }
        }
        catch (FormatException formEx)
        {
            throw new ArgumentException("Give a condition to make sum of the collection!", formEx);
        }
        catch (InvalidCastException invEx)
        {
            throw new ArgumentException("Elements cannot be summed! (infinity, Not-a-Number or too large value is given)", invEx);
        }


        return result;
    }

    /// <summary>
    /// Method that finds the avarage of a collection of elements
    /// </summary>
    /// <typeparam name="T">Type of the collection</typeparam>
    /// <param name="elements"></param>
    /// <param name="condition"></param>
    /// <returns></returns>
    public static decimal Average<T>(this IEnumerable<T> elements, Func<T, decimal> condition = null)
    {
        decimal sum = elements.Sum(condition);
        return sum / elements.Count();
    }

    /// <summary>
    /// Print the elements in the collection.
    /// </summary>
    /// <typeparam name="T">Type of the collection</typeparam>
    /// <param name="elements"></param>
    public static void Print<T>(this IEnumerable<T> elements)
    {
        if (elements.First() != null)
        {
            Console.Write("[ ");
            foreach (var element in elements)
            {
                Console.Write("{0} ", element);
            }
            Console.WriteLine("]");
        }
        else
        {
            Console.WriteLine("There are no elements..");
        }

    }


}