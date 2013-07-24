// * We are given an array of integers and a number S. 
// Write a program to find if there exists a subset of the elements of the array that has a sum S. 
// Example:
//    arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)

using System;

class FindSubsetWithSumS
{
    static void Main()
    {

        Console.Write("Enter the wanted sum of the subsets: ");

        long sum = long.Parse(Console.ReadLine());
        long[] giventArray = { 2, 1, 2, 4, 3, 5, 2, 6 };

        int counter = 0;

        // string that will hold the subset if its sum is equal to the given one
        string subset = "";
        // maxSubsetsNumber will be used in binary form for the different combinations of subsets
        int maxSubsetsNumber = (int)Math.Pow(2, giventArray.Length) - 1;

        // the different subsets will be generated from numbers from 1 to maxSubsets
        for (int i = 1; i <= maxSubsetsNumber; i++)
        {
            subset = "";
            // tempSum will be used to check if it will be equal to the given/wanted sum
            long tempSum = 0;
            for (int j = 0; j <= giventArray.Length; j++)
            {
                int mask = 1 << j;
                int nAndMask = i & mask;
                int bit = nAndMask >> j;
                // for every "1" at position "j", in the number "i" in binary form
                if (bit == 1)
                {
                    // adding the j element of the array to the tempSum and subset
                    tempSum = tempSum + giventArray[j];
                    subset = subset + " " + giventArray[j];
                }
            }
            // if the sum of the current subset is equal to sum
            if (tempSum == sum)
            {
                // printing the wanted subset
                Console.WriteLine("Subset with sum {0} ->{1} ", sum, subset);
                counter++;
            }
        }
        // printing the total number of the subsets that has the wanted sum
        Console.WriteLine("Number of subsets with sum {0}: {1}", sum, counter);
    }
}