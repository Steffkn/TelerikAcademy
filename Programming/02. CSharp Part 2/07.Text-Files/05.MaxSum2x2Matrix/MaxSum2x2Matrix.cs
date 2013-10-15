using System;
using System.IO;

class MaxSum2x2Matrix
{
    static void Main()
    {
        string pathToInputFile = @"..\..\input.txt";
        string pathToOutputFile = @"..\..\output.txt";
        int result;
        try
        {
            using (StreamReader streamReader = new StreamReader(pathToInputFile))
            {
                string line = streamReader.ReadLine();
                line.Trim();
                int matrixSize = int.Parse(line);
                int[,] matrix = new int[matrixSize, matrixSize];

                for (int row = 0; row < matrixSize; row++)
                {
                    line = streamReader.ReadLine();
                    if (line == null)
                    {
                        throw new ArgumentOutOfRangeException(string.Format("Input file is corupted or too short! It must has {0} lines!", matrixSize + 1));
                    }

                    // take a row of strings from the matrix
                    string[] singleRow = line.Split(' ');

                    for (int col = 0; col < matrixSize; col++)
                    {
                        // try to parse the row to the matrix
                        if (!int.TryParse(singleRow[col], out matrix[row, col]))
                        {
                            throw new FormatException(string.Format("Invalid values were found in the matrix! Check your input file and try again! Error at [{0},{1}]", row + 1, col + 1));
                        }
                    }
                }

                if ((line = streamReader.ReadLine()) != null)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Input file is corupted or too long! It must has {0} lines!", matrixSize + 1));
                }

                result = CalcMaxSum(matrix);

            }

            // write the result to the output file
            using (StreamWriter streamWriter = new StreamWriter(pathToOutputFile))
            {
                streamWriter.Write(result);
            }

            Console.WriteLine("Operation completed successfull!");
            Console.WriteLine("Answer writen to the output file is {0}", result);
        }
        catch (ArgumentOutOfRangeException argOutRange)
        {
            Console.Error.WriteLine(argOutRange.Message);
        }
        catch (FormatException fe)
        {
            Console.Error.WriteLine(fe.Message);
        }
        catch (DirectoryNotFoundException dirNotFound)
        {
            Console.Error.WriteLine("Invalid directory!", dirNotFound.Message);
        }
        catch
        {
            Console.WriteLine("Out of my grasps exception!");
        }
    }

    /// <summary>
    /// Method that finds the biggest sum in the matrix
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns></returns>
    private static int CalcMaxSum(int[,] matrix)
    {
        int maxSum = int.MinValue;
        int maxSumRow = 0;
        int maxSumCol = 0;
        // finding the biggest sum in the matrix
        for (int rowIndex = 0; rowIndex <= matrix.GetLength(0) - 2; rowIndex++)
        {
            for (int colIndex = 0; colIndex <= matrix.GetLength(1) - 2; colIndex++)
            {
                // CalcSum returns the sum of the matrix (2x2) from the given matrix, starting from (rowIndex,colIndex)
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
        return maxSum;
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
        for (int row = stratingRow; row < stratingRow + 2; row++)
        {
            for (int col = startingCol; col < startingCol + 2; col++)
            {
                sum += matrix[row, col];
            }
        }
        // returning the sum
        return sum;
    }

}

