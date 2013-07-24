// Write a method that counts how many times given number appears in given array. 
// Write a test program to check if the method is working correctly.

using System;
class CountNumberInArrayWithTest
{
    static void Main()
    {
        // array for tests 
        // for more tests just add more lines to the array and add the correct answers to the given answers
        int[,] testArray = {
                            {0, 2, 3, 4, 5, 6, 7, 8, 9},
                            {1, 2, 0, 4, 5, 1, 7, 8, 1},
                            {1, 2, 3, 4, 5, 1, 7, 8, 0},
                            {0, 2, 3, 4, 5, 6, 7, 8, 0},
                            {0, 2, 3, 4, 5, 0, 7, 8, 0},
                           };
        // answers for case that we want to count the zeros
        int[] answersForZeros = { 1, 1, 1, 2, 3 }; // how many 0
        int numberToTest = 0;
        for (int numberTests = 0; numberTests < testArray.GetLength(0); numberTests++)
        {
            // make an array from the matrix
            int[] array = new int[testArray.GetLength(1)];
            for (int index = 0; index < testArray.GetLength(1); index++)
            {
                array[index] = testArray[numberTests, index];
            }

            // if the result from the method is different from the answer that its given
            if (CountNumberInArray(array, numberToTest) != answersForZeros[numberTests])
            {
                // error msg is printed on the console with the number of the test that fialed
                Console.WriteLine("Error at test {0}!", numberTests);
            }
                // if everything is ok
            else
            {
                // this msg is printed on the console, with the number of the test
                Console.WriteLine("Test {0} completed successful", numberTests);
            }
        }

    }

    /// <summary>
    /// Function that counts how many times given number appears in given array. 
    /// </summary>
    /// <param name="array">Given array to check in.</param>
    /// <param name="watedValue">Given number to check for.</param>
    /// <returns>Returns the number of the times that given number appears in given array.</returns>
    public static int CountNumberInArray(int[] array, int watedValue)
    {
        int counter = 0;
        // for each element in the array
        foreach (var value in array)
        {
            // check if the element is the wanted one
            if (value == watedValue)
            {
                // if yes add 1 to the counter
                counter++;
            }
        }
        // return the result
        return counter;
    }
}
