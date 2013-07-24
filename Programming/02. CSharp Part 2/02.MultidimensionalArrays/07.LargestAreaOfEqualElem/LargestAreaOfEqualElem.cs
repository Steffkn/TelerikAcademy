// Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size. 
using System;
class LargestAreaOfEqualElem
{
    static char[,] matrix = {
                                 {'1','3','2','2','2','4'},
                                 {'3','3','3','2','4','4'},
                                 {'4','3','1','2','3','3'},
                                 {'4','3','1','3','3','1'},
                                 {'4','3','3','3','1','1'},
                             };
    // array that holds already visited items
    static bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];

    // possible directions
    static int[] directionX = { -1, 1, 0, 0 };
    static int[] directionY = { 0, 0, -1, 1 };

    static void Main(string[] args)
    {
        int counter = 1;
        int max = 0;

        ShowMatrix(matrix);
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                counter = DepthFirstSearch(matrix, row, col, matrix[row, col]);
                if (counter > max)
                {
                    max = counter;
                }
            }
        }
        Console.WriteLine("The largest area of equal neighbor elements is {0}", max);
    }

    /// <summary>
    /// DepthFirstSearch algorith
    /// </summary>
    /// <param name="matrix">Matrix with elements</param>
    /// <param name="row">Starting row</param>
    /// <param name="col">Starting col</param>
    /// <param name="wantedItem">The item we are searching for.</param>
    /// <returns>Returnst the number of items found.</returns>
    static int DepthFirstSearch(char[,] matrix, int row, int col, char wantedItem)
    {
        // if we have already visited this cell
        if (visited[row, col])
        {
            return 0;
        }
        else
        {
            // mark the cell as visited
            visited[row, col] = true;
            int counted = 0;
            int countedX = row;
            int countedY = col;

            for (int i = 0; i < 4; i++)
            {
                // change direction
                int newX =  row + directionX[i];
                int newY = col + directionY[i];

                //if we are outside of our matrix
                if (newX == -1 || newX >= matrix.GetLength(0) ||
                    newY == -1 || newY >= matrix.GetLength(1))
                {
                    continue;
                }

                //if neighbour value is the same, "DFS" it
                if (matrix[newX, newY] == wantedItem)
                {
                    counted += DepthFirstSearch(matrix, newX, newY, wantedItem);
                }

            }

            return counted + 1;
        }
    }

    /// <summary>
    /// Method that shows the matrix.
    /// </summary>
    /// <param name="matrix">Matrix that we want to show.</param>
    static void ShowMatrix(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

}

