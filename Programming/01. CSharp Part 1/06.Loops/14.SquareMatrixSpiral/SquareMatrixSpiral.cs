//* Write a program that reads a positive integer number N (N < 20) from console 
// and outputs in the console the numbers 1 ... N numbers arranged as a spiral.

using System;

class SquareMatrixSpiral
{
    static void Main()
    {
        int arraySize;
        bool flag;
        do
        {
            // input with checking for correct values
            Console.WriteLine("Enter the size of the spiral array!");
            Console.WriteLine("-> ");

            flag = int.TryParse(Console.ReadLine(), out arraySize);
            if( flag )
            {
                if( arraySize < 2 & arraySize >= 20 )
                {
                    Console.WriteLine("Array's size must be from 2 to 19!");
                    flag = false;
                }
            }
            else
            {
                Console.WriteLine("Incorrect value!");
            }
        } while( !flag );

        int[,] matrix = new int[arraySize, arraySize];

        int i = 0, j = 0, innerRolCol = 0, counter = 1;
        // innerRolCol moves inside the matrix

        do
        {
            for( ; i < arraySize - innerRolCol - 1; i++ )
            {
                matrix[j, i] = counter++;
            }
            for( ; j < arraySize - innerRolCol - 1; j++ )
            {
                matrix[j, i] = counter++;
            }
            for( ; i > innerRolCol; i-- )
            {
                matrix[j, i] = counter++;
            }
            for( ; j > innerRolCol + 1; j-- )
            {
                matrix[j, i] = counter++;
            }
            innerRolCol++;
            if( counter >= arraySize * arraySize )
            {
                matrix[j, i] = counter;
                break;
            }
        } while( true );

        /* output */
        for( int x = 0; x < arraySize; x++ )
        {
            for( int y = 0; y < arraySize; y++ )
            {
                Console.Write("{0}\t", matrix[x, y]);
            }
            Console.WriteLine();
        }
    }
}

