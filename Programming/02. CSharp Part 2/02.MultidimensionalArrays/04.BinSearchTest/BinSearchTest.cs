// Write a program, that reads from the console an array of N integers and an integer K, 
// sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

using System;

using System.Collections.Generic;
class BinSearchTest
{
    static void Main()
    {
        Console.WriteLine("Enter an array (anything else than integer to end):");
        int number = 0 ;
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
        
        Console.Write("Enter K (bigger than the smallest element of the array): ");
        int K = int.Parse(Console.ReadLine());

        // sorting the array using MergeSort method from the previouse homework
        intArray = MergeSort(intArray);

        // prints on the console the sorted array
        foreach (var item in intArray)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();

        // if K doesnt exist in the array BinSearch will return a negative index
        // if K does exist int the array BinSearch will return the exact index of that number in the array
        int resultIndex = Array.BinarySearch(intArray, K);

        if (resultIndex < 0)
        {
            Console.WriteLine("Result {0}",intArray[resultIndex*(-1) - 2]);
        }
        else
        {
            Console.WriteLine("Result {0}", intArray[resultIndex]);
        }
    }

    static int[] MergeSort(int[] givenArray) 
    {
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
        
        return givenArray;
    }

}

