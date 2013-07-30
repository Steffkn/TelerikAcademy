using System;
using System.Collections.Generic;
using System.Numerics;
class AddTwoIntsAsArrays
{
    static void Main()
    {
        // it is possible without the bigInteger if we add the input directly to the array with Console.Read()
        Console.Write("Enter first digit: ");
        BigInteger firstDigit = BigInteger.Parse(Console.ReadLine());
        Console.Write("Enter second digit: ");
        BigInteger secondDigit = BigInteger.Parse(Console.ReadLine());

        int[] firstArray = ConvertIntToArray(firstDigit);
        int[] secondArray = ConvertIntToArray(secondDigit);
        // what does this line do is that gives to resultArrayLenght, the bigger from the lenghts of both arrays
        int resultArrayLenght = (firstArray.Length >= secondArray.Length) ? firstArray.Length : secondArray.Length;
        Console.WriteLine(resultArrayLenght);
        // will hold the result of the sum
        int[] resultArray = new int[resultArrayLenght];

        Console.Write("The sum of the elements in the arrays is ");
        for (int i = 0; i < resultArrayLenght; i++)
        {
            if (i < firstArray.Length)
            {
                resultArray[i] += firstArray[i];
            }
            if (i < secondArray.Length)
            {
                resultArray[i] += secondArray[i];
            }
        }
        // if the result could contain numbers bigger than 10
        for (int index = resultArrayLenght - 1; index >= 0; index--)
        {
            if (resultArray[index] != 0)
            {
                Console.Write(resultArray[index]);
            }
        }
        Console.WriteLine();
        int[] tempArray = new int[resultArrayLenght];
        // if the result should be a real sum
        Console.Write("The real sum of the two digits is ");
        for (int index = 0; index < resultArrayLenght; index++)
        {
            if (resultArray[index] > 9)
            {
                tempArray[index] = resultArray[index] % 10;
                resultArray[index + 1] += 1;
            }
            else
            {
                tempArray[index] = resultArray[index];
            }
        }
        for (int index = 0; index < resultArrayLenght; index++)
        {
            resultArray[index] = tempArray[resultArrayLenght - index - 1];
        }
        foreach (var item in resultArray)
        {
            Console.Write(item);
        }
    }

    /// <summary>
    /// Methods that adds the numbers of an integer to array.
    /// </summary>
    /// <param name="digit">Given integer.</param>
    /// <returns>Returns an array with the numbers of the integer</returns>
    public static int[] ConvertIntToArray(BigInteger digit)
    {
        List<int> listOfInts = new List<int>();
        // add the numbers to the array
        while (digit >= 1)
        {
            // takes the last digit
            int lastDigit = (int)(digit % 10);
            // multyply the reversed digit to make room for the last digit
            listOfInts.Add(lastDigit);
            digit = digit / 10;
        }

        // this way the method will work with integers with alot of numbers
        // the lenght is +1 becouse in the description isnt said if the sum should be from numbers 0 to 9 or it can be bigger than 10
        // +1 will give room for the sum if the sum of the last digits is bigger than 10; ex: 99 + 1 = 100
        int[] digitArray = new int[listOfInts.Count + 1];
        // convert the list to an array of integers
        for (int index = 0; index < listOfInts.Count; index++)
        {
            digitArray[index] = listOfInts[index];
        }
        return digitArray;
    }
}

