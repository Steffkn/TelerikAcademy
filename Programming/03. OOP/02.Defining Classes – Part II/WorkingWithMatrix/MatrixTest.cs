using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generics;

namespace WorkingWithMatrix
{
    class MatrixTest
    {
        static void Main()
        {

            int[,] matrix1 =
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            int[,] matrix2 =
            {
                {9, 8, 7},
                {6, 5, 4},
                {3, 2, 1}
            };

            Matrix<decimal> DecimalMatrix = new Matrix<decimal>(3, 3);
            Console.WriteLine(DecimalMatrix);
            Matrix<double> DoubleMatrix = new Matrix<double>(5, 5);
            Console.WriteLine(DoubleMatrix);

            Matrix<int> Matrix1 = new Matrix<int>(matrix1);
            Matrix<int> Matrix2 = new Matrix<int>(matrix2);

            Console.WriteLine("Addition ");
            Console.WriteLine(Matrix1 + Matrix2);
            Console.WriteLine("Subtraction ");
            Console.WriteLine(Matrix1 - Matrix2);
            Console.WriteLine("Multiplication ");
            Console.WriteLine(Matrix1 * Matrix2);
            Console.WriteLine("Multiplication by 10 (Matrix1)");
            Console.WriteLine(10 * Matrix1);

            if( Matrix1 )
            {
                Console.WriteLine("Matrix1 contains non-zero items!");
            }
            else
            {
                Console.WriteLine("Matrix1 contains zero items!");
            }


        }
    }
}
