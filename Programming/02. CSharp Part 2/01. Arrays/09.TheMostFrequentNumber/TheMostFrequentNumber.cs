// Write a program that finds the most frequent number in an array. Example:
//    {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)


using System;
class TheMostFrequentNumber
{
    static void Main()
    {
        int[] givenArray = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
        int maxCounted = 0;
        int maxNumber = 0;

        for (int i = 0; i < givenArray.Length; i++)
        {
            // counter for the curent number
            int counter = 0;
            // we start from the 'i' number becouse there is no reasont to check the previouse number again
            // it is not the perfect algorithm becouse there will be some extra math (no checking for already counted numbers)
            for (int j = i; j < givenArray.Length; j++)
            {

                if (givenArray[i] == givenArray[j])
                {
                    counter++;
                }
                if (maxCounted < counter)
                {
                    maxNumber = givenArray[i];
                    maxCounted = counter;
                }
            }
        }

        Console.WriteLine("{0} ({1} times)", maxNumber, maxCounted);
    }
}
