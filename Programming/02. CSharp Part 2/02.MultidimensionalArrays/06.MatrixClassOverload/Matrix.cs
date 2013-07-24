using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Matrix
{
    private int matrixN = 2;
    private int matrixM = 2;
    private int[,] matrix;

    // encapsulation
    public int MatrixN
    {
        get { return matrixN; }
    }

    public int MatrixM
    {
        get { return matrixM; }
    }
    // empty constructor
    public Matrix() { }
    // Constructor that wants an integer array as parameter
    public Matrix(int[,] matrix)
    {
        this.matrixN = matrix.GetLength(0);
        this.matrixM = matrix.GetLength(1);
        this.matrix = matrix;
    }
    // indexer for accessing the matrix content 
    public int this[int x, int y]
    {
        get
        {
            return matrix[x, y];
        }
        set
        {
            matrix[x, y] = value;
        }
    }

    /// <summary>
    /// Add 2 matrixs
    /// </summary>
    /// <param name="a">First matrix</param>
    /// <param name="b">Second matrix</param>
    /// <returns>New matrix that holds the results</returns>
    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.matrixN != b.matrixN || a.matrixM != b.matrixM)
        {

            Console.WriteLine("You cannot add matrix with different size");
            return null;
        }
        int[,] newMatrix = new int[a.matrixN, a.matrixM];

        // matrix 'a' has same size as matrix 'b'
        for (int i = 0; i < a.matrixN; i++)
        {
            for (int j = 0; j < a.matrixM; j++)
            {
                newMatrix[i, j] = a[i, j] + b[i, j];
            }
        }

        return new Matrix(newMatrix);
    }

    /// <summary>
    /// Substract matrix b from matrix a
    /// </summary>
    /// <param name="a">First matrix.</param>
    /// <param name="b">Second matrix.</param>
    /// <returns>Returns new matrix with the result.</returns>
    public static Matrix operator -(Matrix a, Matrix b)
    {
        if (a.matrixN != b.matrixN || a.matrixM != b.matrixM)
        {
            Console.WriteLine("You cannot substract matrix with different size");
            return null;
        }
        int[,] newMatrix = new int[a.matrixN, a.matrixM];

        // matrix 'a' has same size as matrix 'b'
        for (int i = 0; i < a.matrixN; i++)
        {
            for (int j = 0; j < a.matrixM; j++)
            {
                newMatrix[i, j] = a[i, j] - b[i, j];
            }
        }

        return new Matrix(newMatrix);
    }
    /// <summary>
    /// Multiply two matrixes. Required sizes: A[N,M] B[M,N]
    /// </summary>
    /// <param name="a">First matrix.</param>
    /// <param name="b">Second matrix.</param>
    /// <returns>Returns new matrix with the result.</returns>
    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.matrixN != b.matrixM || a.matrixM != b.matrixN)
        {
            Console.WriteLine("You cannot multiply these matrixs. Required sizes: A[N,M] B[M,N]");
        }
        int[,] newMatrix = new int[a.matrixN, a.matrixM];

        // matrix 'a' has size that allows it to multiply with matrix 'b'
        for (int i = 0; i < a.matrixN; i++)
        {
            for (int j = 0; j < a.matrixM; j++)
            {
                newMatrix[i, j] = a[i, j] * b[j, i];
            }
        }

        return new Matrix(newMatrix);
    }

   /// <summary>
   /// Multiply a matrix with a integer.
   /// </summary>
   /// <param name="a">Matrix.</param>
   /// <param name="number">Multiplier (int).</param>
   /// <returns>Returns new matrix with the result.</returns>
    public static Matrix operator *(Matrix a, int number)
    {
        for (int i = 0; i < a.matrixN; i++)
        {
            for (int j = 0; j < a.matrixM; j++)
            {
                a[i, j] *= number;
            }
        }
        return a;
    }

    /// <summary>
    /// Overrided ToString method.
    /// </summary>
    /// <returns>Returns the matrix as a formated string.</returns>
    public override string ToString()
    {
        string str = "";
        for (int row = 0; row < this.matrixN; row++)
        {
            str += "| ";
            for (int col = 0; col < this.matrixM - 1; col++)
            {
                str += this.matrix[row, col] + "\t";
            }
            str += this.matrix[row, this.matrixM - 1] + " |" + Environment.NewLine;
        }

        return str;
    }
}

