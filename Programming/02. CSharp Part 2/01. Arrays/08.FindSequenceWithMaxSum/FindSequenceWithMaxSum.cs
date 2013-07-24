// Write a program that finds the sequence of maximal sum in given array. 
// Example:
//	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}
//	Can you do it with only one loop (with single scan through the elements of the array)?

using System;

class FindSequenceWithMaxSum
{
    static void Main()
    {
        int maxIndex = 0;
        int maxSum = 0;
        int tempSum = 0;

        // the given array
        int[] tempArray = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        
        for (int i = 0; i < tempArray.Length; i++)
        {
            tempSum += tempArray[i];
            if (tempSum <= 0)
            {
                maxIndex = i + 1;
                tempSum = 0;
            }
            else if (maxSum < tempSum)
            {
                maxSum = tempSum;
            }

        }

        // refresh tempSum = 0
        tempSum = 0;
        // console output
        Console.Write("{");
        for (int i = maxIndex; i < tempArray.Length; i++)
        {
            tempSum += tempArray[i];
            if (tempSum < maxSum)
            {
                Console.Write("{0}, ", tempArray[i]);
            }
            else
            {
                Console.Write("{0}", tempArray[i]);
                break;
            }
        }
        Console.WriteLine("}");
    }
}
