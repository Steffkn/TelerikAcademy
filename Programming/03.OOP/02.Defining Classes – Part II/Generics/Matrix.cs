using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Matrix<T>
            where T : struct
    {
        private T[,] matrix;

        private int rows;
        private int cols;


        public int Rows
        {
            get { return rows; }
        }

        public int Cols
        {
            get { return cols; }
        }



        public Matrix(int row, int col)
        {
            if (row <= 0 || col <= 0)
            {
                throw new ArgumentException("Matrix's dimensions must be positive integers.");
            }
            this.rows = row;
            this.cols = col;
            this.matrix = new T[row, col];
        }

        public Matrix(T[,] someMatrix)
        {
            if (someMatrix == null || someMatrix.GetLength(0) == 0 || someMatrix.GetLength(1) == 0)
            {
                throw new ArgumentNullException("The two-dimensional initialization array must contain at least one item.");
            }

            this.rows = someMatrix.GetLength(0);
            this.cols = someMatrix.GetLength(1);
            this.matrix = (T[,])someMatrix.Clone();
        }

        public T this[int row, int col]
        {
            get
            {
                if ((row >= 0 && row < rows) && (col >= 0 && col < cols))
                {
                    return this.matrix[row, col];
                }
                else
                {
                    throw new ArgumentOutOfRangeException(String.Format("Cell ({0}, {1}) is invalid!", row, col));
                }
            }
            set
            {
                if (row >= 0 && row < rows && col >= 0 && col < cols)
                {
                    this.matrix[row, col] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(String.Format("Cell ({0}, {1}) is invalid.", row, col));
                }
            }
        }


        public static Matrix<T> operator +(Matrix<T> Matrix1, Matrix<T> Matrix2)
        {
            return Add(Matrix1, Matrix2);
        }
        public static Matrix<T> operator -(Matrix<T> Matrix)
        {
            return Multiply(-1, Matrix);
        }
        public static Matrix<T> operator -(Matrix<T> Matrix1, Matrix<T> Matrix2)
        {
            return Add(Matrix1, -Matrix2);
        }

        public static Matrix<T> operator *(Matrix<T> Matrix1, Matrix<T> Matrix2)
        {
            return Multiply(Matrix1, Matrix2);
        }

        public static Matrix<T> operator *(int c, Matrix<T> Matrix)
        {
            return Multiply(c, Matrix);
        }


        /// <summary>
        /// Method that add two matrixes
        /// </summary>
        /// <param name="Matrix1">First matrix</param>
        /// <param name="Matrix2">Second matrix</param>
        /// <returns>Returns the result as a new matrix, trows exceptions if the matrixes are null or the matrixes cant be added</returns>
        private static Matrix<T> Add(Matrix<T> Matrix1, Matrix<T> Matrix2)
        {
            if (Matrix1 == null || Matrix2 == null)
            {
                throw new ArgumentNullException("Matrices are not initialized!");
            }

            if ((Matrix1.rows != Matrix2.rows) || (Matrix1.cols != Matrix2.cols))
            {
                throw new ArgumentException("Matrices must have the same dimensions!");
            }
            // if everything is ok
            Matrix<T> result = new Matrix<T>(Matrix1.rows, Matrix1.cols);

            for (int row = 0; row < result.rows; row++)
            {
                for (int col = 0; col < result.cols; col++)
                {
                    result[row, col] = (dynamic)Matrix1[row, col] + Matrix2[row, col];
                }
            }
            return result;
        }

        /// <summary>
        /// Method that multiply a matrix with a number
        /// </summary>
        /// <param name="c">Multyplier</param>
        /// <param name="Matrix">Given matrix</param>
        /// <returns>Returns new matrix or trows exception if the matrix is not given</returns>
        private static Matrix<T> Multiply(int c, Matrix<T> Matrix)
        {
            if (Matrix == null)
            {
                throw new ArgumentNullException("Matrix is not initialized.");
            }

            Matrix<T> result = new Matrix<T>(Matrix.rows, Matrix.cols);

            for (int row = 0; row < Matrix.rows; row++)
            {
                for (int col = 0; col < Matrix.cols; col++)
                {
                    result[row, col] = (dynamic)Matrix[row, col] * c;
                }
            }
            return result;
        }

        // Multiply 2 matrices
        /// <summary>
        /// Method that multiply 2 matrices
        /// </summary>
        /// <param name="Matrix1">Matrix 1</param>
        /// <param name="Matrix2">Matrix 2</param>
        /// <returns>Result is new matrix or exception if a matrix is null or they cant be multiplied</returns>
        private static Matrix<T> Multiply(Matrix<T> Matrix1, Matrix<T> Matrix2)
        {
            if (Matrix1 == null || Matrix2 == null)
            {
                throw new ArgumentNullException("Matrices are not initialized.");
            }

            if (Matrix1.cols != Matrix2.rows)
            {
                throw new ArgumentException("Invalid dimensions of matrices!");
            }

            Matrix<T> result = new Matrix<T>(Matrix1.rows, Matrix2.cols);

            for (int row = 0; row < result.rows; row++)
            {
                for (int col = 0; col < result.cols; col++)
                {
                    result[row, col] = default(T);
                    for (int i = 0; i < Matrix1.cols; i++)
                    {
                        result[row, col] += (dynamic)Matrix1[row, i] * Matrix2[i, col];
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Method that implement the true operator (check for non-zero elements).
        /// </summary>
        /// <param name="someMatrix">Given matrix</param>
        /// <returns></returns>
        public static bool operator true(Matrix<T> someMatrix)
        {
            if (someMatrix.rows == 0 || someMatrix.cols == 0 || someMatrix == null)
            {
                return false;
            }

            for (int row = 0; row < someMatrix.rows; row++)
            {
                for (int col = 0; col < someMatrix.cols; col++)
                {
                    if (!someMatrix[row, col].Equals(default(T)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Method that implement the false operator (check for non-zero elements).
        /// </summary>
        /// <param name="someMatrix"></param>
        /// <returns></returns>
        public static bool operator false(Matrix<T> someMatrix)
        {
            if (someMatrix.rows == 0 || someMatrix.cols == 0 || someMatrix == null)
            {
                return true;
            }

            for (int row = 0; row < someMatrix.rows; row++)
            {
                for (int col = 0; col < someMatrix.cols; col++)
                {
                    if (!someMatrix[row, col].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Override ToString()
        /// </summary>
        /// <returns>Returns matrix as text</returns>
        public override string ToString()
        {
            int row;
            int col;
            int maxLength = Int32.MinValue;
            for (row = 0; row < rows; row++)
            {
                for (col = 0; col < cols; col++)
                {
                    int length = this.matrix[row, col].ToString().Length;
                    if (maxLength < length)
                    {
                        maxLength = length;
                    }
                }
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(Environment.NewLine);

            for (row = 0; row < rows; row++)
            {
                stringBuilder.Append(" |");

                for (col = 0; col < cols; col++)
                {
                    stringBuilder.Append(this.matrix[row, col].ToString().PadLeft(maxLength + 1, ' '));
                }

                stringBuilder.AppendFormat("{0,2}" + Environment.NewLine, '|');
            }

            return stringBuilder.ToString();
        }
    }
}
