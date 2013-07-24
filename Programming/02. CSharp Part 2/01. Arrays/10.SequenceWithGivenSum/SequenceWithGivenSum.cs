// Write a program that finds in given array of integers a sequence of given sum S (if present). 
// Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}

using System;
class SequenceWithGivenSum
{
    static void Main(string[] args)
    {
        int sumIndex = 0;

        Console.Write("Enter the sum (S): ");
        int S = int.Parse(Console.ReadLine());
        int[] givenArray = { 4, 3, 1, 4, 2, 5, 8 };

        int tempSum = 0;
        for (int i = 0; i < givenArray.Length; i++)
        {
            for (int j = i; j < givenArray.Length; j++)
            {
                // if tempSum is the wanted sum
                if (tempSum == S)
                {
                    // givenArray[i] will be the starting number of the wanted sequence
                    sumIndex = i;
                    break;
                }
                    // if tempSum get bigger than the wanted sum, tempSum is refreshed 
                else if (tempSum > S)
                {
                    tempSum = 0;
                    break;
                }
                    // if tempSum is less than the wanted sum, next digit (from givenArray) is added to tempSum
                else
                {
                    tempSum += givenArray[j];
                }
            }
            // if tempSum is the wanted sum, break the loop
            if (tempSum == S) 
            {
                break;
            }
        }

        // printing the result on the console
        tempSum = 0;
        for (int i = sumIndex; i < givenArray.Length; i++)
        {
            Console.Write("{0} ",givenArray[i]);
            // I do it this way so that we dont have to declare a counter (extra var)
            tempSum += givenArray[i];
            if (tempSum == S)
            {
                break;
            }
        }
    }
}
