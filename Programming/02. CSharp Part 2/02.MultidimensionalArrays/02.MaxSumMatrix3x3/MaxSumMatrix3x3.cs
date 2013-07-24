// Write a program that reads a rectangular matrix of size N x M and 
// finds in it the square 3 x 3 that has maximal sum of its elements.

using System;
class MaxSumMatrix3x3
{
    static void Main()
    {
        Console.WriteLine("Enter the dimensions of the array:");
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("M = ");
        int M = int.Parse(Console.ReadLine());
        int maxSum = int.MinValue;
        int maxSumRow = 0;
        int maxSumCol = 0;
        int[,] matrix = new int[N, M];

        // fill the matrix with numbers from the console
        matrix = FillMatrix(N, M);

        // a matrix for testing
        //int[,] matrix = {
        //                    {1,2,3,4,6,1},
        //                    {1,2,3,4,6,0},
        //                    {10,20,30,40,6,0},
        //                    {1,2,3,4,6,0},
        //                    {5,4,7,2,6,11}
        //                };


        // finding the biggest sum in the matrix
        for (int rowIndex = 0; rowIndex <= matrix.GetLength(0) - 3; rowIndex++)
        {
            for (int colIndex = 0; colIndex <= matrix.GetLength(1) - 3; colIndex++)
            {
                // CalcSum returns the sum of the matrix (3x3) from the given matrix, starting from (rowIndex,colIndex)
                int tempSum = CalcSum(matrix, rowIndex, colIndex);
                // if the sum is bigger than the previose max sum
                if (tempSum > maxSum)
                {
                    // new cordinates for the biggest matrix
                    maxSumRow = rowIndex;
                    maxSumCol = colIndex;
                    // new maximal sum
                    maxSum = tempSum;
                }
            }
        }
        Console.WriteLine();
        // Printing the given matrix on the console 
        PrintFromMatrix(matrix, 0, 0, 99); // the fourth var is for the size of the matrix that will be printed 99 is bigger that the given matrix's size so this line can print hole matrix

        // printing on the console the maximal sum and the coordinates where it starts
        Console.WriteLine(maxSum + "  x: " + maxSumRow + " y: " + maxSumCol);
        // printing on the console the matrix (3x3) with the maximal sum
        PrintFromMatrix(matrix, maxSumRow, maxSumCol, 3);
    }

    /// <summary>
    /// Method that fills a matrix from the users input.
    /// </summary>
    /// <param name="N">Matrix's rows</param>
    /// <param name="M">Matrix's cols</param>
    /// <returns>Returns new matrix[N,M]</returns>
    static int[,] FillMatrix(int N, int M)
    {
        int[,] newMatrix = new int[N, M];
        Console.WriteLine("Enter tha matrix [{0},{1}]", N, M);
        for (int row = 0; row < N; row++)
        {
            Console.WriteLine("Row {0}", row);
            for (int col = 0; col < M; col++)
            {
                Console.Write("Col {0}: ", col);
                newMatrix[row, col] = int.Parse(Console.ReadLine());
            }
        }
        // retunring the new matrix
        return newMatrix;
    }

    /// <summary>
    /// Calculates the sum of a square matrix in a given matrix
    /// </summary>
    /// <param name="matrix">Given matrix from which we read.</param>
    /// <param name="stratingRow">Starting row of the matrix that we want to sum its elements.</param>
    /// <param name="startingCol">Starting col of the matrix that we want to sum its elements.</param>
    /// <returns></returns>
    static int CalcSum(int[,] matrix, int stratingRow, int startingCol)
    {
        // the sum of the lements
        int sum = 0;
        // strating from [startingRow, startingCol], reading the elements until the 'lenght'-th element
        // its sure that it cant get out of range of the given matrix because its checked before this method is called
        for (int row = stratingRow; row < stratingRow + 3; row++)
        {
            for (int col = startingCol; col < startingCol + 3; col++)
            {
                sum += matrix[row, col];
            }
        }
        // returning the sum
        return sum;
    }

    /// <summary>
    /// Printing a square matrix with lenght 'lenght' on the console from a given matrix and starting point.
    /// </summary>
    /// <param name="matrix">A given matrix to read from.</param>
    /// <param name="startRow">A starting row to read from.</param>
    /// <param name="startCol">A starting col to read from.</param>
    /// <param name="lenght">The lenght of the matrix that we want to print.</param>
    static void PrintFromMatrix(int[,] matrix, int startRow, int startCol, int lenght)
    {
        // strating from [startRow, startCol], reading the elements until the 'lenght'-th element or the end of the row/col
        for (int row = startRow; row < startRow + lenght && row < matrix.GetLength(0); row++)
        {
            for (int col = startCol; col < startCol + lenght && col < matrix.GetLength(1); col++)
            {
                // printing the element with a tab after it
                Console.Write("{0}\t", matrix[row, col]);
            }
            Console.WriteLine();
        }

    }
}
