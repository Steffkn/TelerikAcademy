// We are given 5 integer numbers. Write a program that checks if the sum of 
// some subset of them is 0. Example: 3, -2, 1, 1, 8  1+1-2=0.


using System;

class SumOfSubset
{
    static void Main()
    {
        int[] value = new int[5];
        int counter = 0;

        for( int i = 0; i < 5; i++)
        {
            Console.Write("Write number{0}: ", i);

            if( !int.TryParse(Console.ReadLine(), out value[i]) )
            {
                Console.WriteLine("Incorect value!");
            }
        }

        // checker will be used in his binary form 
        // i is from 3 to 31 because we have to check for avery possible composition of the given 5 numbers 
        // ex. 11111 - is the composition of all 5 given numbers
        for( int i = 3; i <= 31; i++ )
        {
            int index = 0;  // will hold the current position in the array
            int checker = i;
            int sum = 0;

            // untill the checker equals 0
            while( checker != 0 )
            {
                // if the first binary digit of the checker is 1
                if( (checker & 1) == 1 )
                {
                    // adding the sum of the value at position index
                    // for every 1 in checker this will be executed
                    // if checker is 5 -> 101 the sum will be made from the first and the third value in the array
                    sum += value[index];
                }
                // shifting checkre right by 1
                checker >>= 1;
                // increasing the index
                index++;
            }
            // if the sum is 0, adding 1 to counter
            if( sum == 0 )
            {
                counter++;
            }
        }


        Console.WriteLine("There are {0} subset with the sum of 0", counter);

    }
}


