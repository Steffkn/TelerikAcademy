// Write a program that finds the maximal sequence of equal elements in an array.
//        Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.

using System;
class PrMaxSeqOfEqualElementsogram
{
    static void Main()
    {
        int[] array = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1};

        // holds the index of the first element of the wanted sequence
        int maxSeqIndex = 0;
        int counter = 1;

        int tempCounter = 1;
        for (int i = 0; i < array.Length - 1; i++)
        {
            // if the "i" element is equal to the "i + 1" element
            if (array[i] == array[i + 1])
            {
                tempCounter++;
            }
            else
            {
                // if there is a bigger sequence
                if (tempCounter > counter)
                {
                    counter = tempCounter;
                    // calculate the index of the sequence
                    maxSeqIndex = i - counter +1;
                }
                tempCounter = 1;
            }
        }
        // if longest sequence is at the end of the array
        if (tempCounter > counter)
        {
            counter = tempCounter;
            maxSeqIndex = array.Length - counter;
        }
        // print the sequence
        Console.Write("{");
        // loop from maxSeqIndex to that index + the count of the elements in the sequence
        for (int i = maxSeqIndex; i < maxSeqIndex + counter; i++)
        {
            Console.Write("{0}",array[i]);
            // if there is atleast 1 more element in the sequence
            if (i < maxSeqIndex + counter - 1)
            {
                Console.Write(", ");
            }
        }
        Console.Write("}");
    }
}

