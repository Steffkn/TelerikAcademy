//* Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).
using System;

class MergeSortIntExample
{
    static void Main(string[] args)
    {
        //given array
        int[] givenArray = { 1, -3, 6, 4, -1, -4, 12, 0, 17, 5, 9, 8, 2 };
        //help array
        int[] tempArray = new int[givenArray.Length];

        int arraySize = givenArray.Length;
        int compareSize = 1;
        int position = 0;
        int left = 0;
        int right = 0;
        //until the lenght of the tempArray is smaller to or equal the size of the givenArray
        while (compareSize <= arraySize)
        {
            for (int i = 0; i < arraySize; i = i + compareSize * 2)
            {
                while (position < arraySize)
                {
                    //compare the first element of the subarrays
                    if (left < compareSize && right < compareSize && i + right + compareSize < arraySize)
                    {
                        //compare the first elements of the left and right arrays and add the smaller to tempArray array
                        if (givenArray[i + left] <= givenArray[i + right + compareSize])
                        {
                            tempArray[position] = givenArray[i + left];
                            left++;
                        }
                        else
                        {
                            tempArray[position] = givenArray[i + right + compareSize];
                            right++;
                        }
                    }
                    //residual element in the left array, which will be added to the temp array
                    else if (left < compareSize)
                    {
                        tempArray[position] = givenArray[i + left];
                        left++;
                    }
                    //residual element in the right array, which will be added to the temp array
                    else if (right < compareSize)
                    {
                        tempArray[position] = givenArray[i + right + compareSize];
                        right++;
                    }
                    //if there are no elements to be compered in eighter of the two subarrays
                    else
                    {
                        break;
                    }
                    position++;
                }
                right = 0;
                left = 0;
            }
            compareSize *= 2;
            position = 0;
            // tempArray will become the givenArray
            for (int i = 0; i < givenArray.Length; i++)
            {
                givenArray[i] = tempArray[i];
            }
        }

        // print the result
        for (int i = 0; i < givenArray.Length; i++)
        {
            Console.WriteLine(givenArray[i]);
        }
    }
}
