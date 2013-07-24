//* Write a program that reads three integer numbers N, K and S and an array of N elements from the console. 
//Find in the array a subset of K elements that have sum S or indicate about its absence.

using System;

class FindSubsetOfKElemSumS
{
    static void Main()
    {
        Console.Write("Enter the lenght of the array:");
        int N = int.Parse(Console.ReadLine());
        Console.Write("Enter the wanted sum of the subsets: ");
        long sum = long.Parse(Console.ReadLine());
        Console.Write("Enter the number of elements of the subset that should have the sum {0}:" , sum);
        int K = int.Parse(Console.ReadLine());

        
        long[] givenArray = new long[N];
        Console.WriteLine("Enter the elements of the array"); 
        for (int i = 0; i < givenArray.Length; i++)
        {
            Console.WriteLine("Element[{0}] = ", i + 1);
            givenArray[i] = long.Parse(Console.ReadLine());
        }
        int counter = 0;

        // string that will hold the subset if its sum is equal to the given one
        string subset = "";
        // maxSubsetsNumber will be used in binary form for the different combinations of subsets
        int maxSubsetsNumber = (int)Math.Pow(2, givenArray.Length) - 1;

        // the different subsets will be generated from numbers from 1 to maxSubsets
        for (int i = 1; i <= maxSubsetsNumber; i++)
        {
            subset = "";
            // tempSum will be used to check if it will be equal to the given/wanted sum
            long tempSum = 0;
            int numberOfElements = K;
            for (int j = 0; j <= givenArray.Length; j++)
            {
                int mask = 1 << j;
                int nAndMask = i & mask;
                int bit = nAndMask >> j;
                // for every "1" at position "j", in the number "i" in binary form
                if (bit == 1 && numberOfElements >= 0)
                {
                    // adding the j element of the array to the tempSum and subset
                    tempSum = tempSum + givenArray[j];
                    subset = subset + " " + givenArray[j];
                    numberOfElements--;
                }
                    // subsets with more elemets than numberOfElements will be skiped 
                else if (numberOfElements < 0)
                {
                    break;
                }
            }
            // if the sum of the current subset is equal to sum and the number of elements in the subset is equal to numberOfElements
            if (tempSum == sum && numberOfElements == 0)
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