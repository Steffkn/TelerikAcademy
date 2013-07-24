// * Write a class Matrix, to holds a matrix of integers. 
// Overload the operators for adding, subtracting and multiplying of matrices, 
// indexer for accessing the matrix content and ToString().

using System;
    class MatrixClassOverload
    {
        static void Main()
        {
            // declare some arrays
            int[,] firstMatrix = {
                                {1,2},
                                {2,3},
                                {4,5}
                            };
            int[,] secondMatrix = {
                                {1,1},
                                {1,1},
                                {1,1}
                            };
            int[,] thirdMatrix = {
                                {1,1,1},
                                {1,1,1},
                                {1,1,1}
                            };
            int[,] thourthMatrix = {
                                {1,2,3},
                                {4,5,6}
                            };

            // make these arrays Matrixs
            Matrix first = new Matrix(firstMatrix);
            Matrix second = new Matrix(secondMatrix);
            Matrix third = new Matrix(thirdMatrix);
            Matrix fourth = new Matrix(thourthMatrix);
            
            // print the matrixs to the console using overrided method ToString()
            Console.WriteLine("First matrix");
            Console.WriteLine(first.ToString());
            Console.WriteLine("Second matrix");
            Console.WriteLine(second.ToString());
            Console.WriteLine("Third matrix");
            Console.WriteLine(third.ToString());
            Console.WriteLine("Fourth matrix");
            Console.WriteLine(fourth.ToString());

            // some tests of the opperators + - * []
            Console.WriteLine("Some answers \nfirst + second");
            Console.WriteLine(first + second);

            Console.WriteLine("firs - second");
            Console.WriteLine(first - second);

            Console.WriteLine("second - first");
            Console.WriteLine(second - first);

            Console.WriteLine("firs + third (should be an error)");
            Console.WriteLine(first + third);

            Console.WriteLine("third + second (should be an error)");
            Console.WriteLine(third + second);

            Console.WriteLine("second - third (should be an error)");
            Console.WriteLine(second - third);

            Console.WriteLine("first * fourth");
            Console.WriteLine(first * fourth);
            Console.WriteLine("fourth * first");
            Console.WriteLine(fourth * first);

            Console.WriteLine("third * 5");
            Console.WriteLine(third * 5);

            Console.WriteLine("Show first matrix's second row");
            for (int col = 0; col < first.MatrixM; col++)
            {
                Console.Write("{0} ",first[1,col]);
            }
            Console.WriteLine();
        }
    }

