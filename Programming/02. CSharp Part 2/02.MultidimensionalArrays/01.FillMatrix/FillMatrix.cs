// Write a program that fills and prints a matrix of size (n, n)

using System;
class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[,] multiArray = new int[N, N];

        Console.WriteLine("Matrix type A");
        multiArray = MakeMatrix(N, 'a');
        PrintArray(multiArray);
        Console.WriteLine();

        Console.WriteLine("Matrix type B");
        multiArray = MakeMatrix(N, 'b');
        PrintArray(multiArray);
        Console.WriteLine();

        Console.WriteLine("Matrix type C");
        multiArray = MakeMatrix(N, 'c');
        PrintArray(multiArray);
        Console.WriteLine();

        Console.WriteLine("Matrix type D");
        multiArray = MakeMatrix(N, 'd');
        PrintArray(multiArray);
        Console.WriteLine();

    }

    public static int[,] MakeMatrix(int N, char option)
    {
        int[,] multiArray = new int[N, N];
        int count = 1;
        switch (option)
        {
            case 'a':
                for (int row = 0; row < N; row++)
                {
                    for (int col = 0; col < N; col++)
                    {
                        multiArray[row, col] = (row + 1) + N * col;
                    }
                }

                //count = 1;
                //for (int col = 0; col < N;col++)
                //{
                //    for (int row = 0; row < N;row++)
                //    {
                //        multiArray[row, col] = count++;

                //    }
                //}

                break;
            case 'b':
                for (int row = 0; row < N; row++)
                {
                    for (int col = 0; col < N; col++)
                    {
                        // math expresion that will generate the multiArray 'b'
                        //multiArray[row, col] = (row + 1) +
                        //   N * col * ((col + 1) % 2) +
                        //   (N * (col + 1) - (2 * row) - 1) * (col % 2);

                        // is equal to this
                        if (col % 2 == 0)
                        {
                            multiArray[row, col] = (row + 1) + N * col;
                        }
                        else
                        {
                            multiArray[row, col] = (row + 1) +
                                (N * (col + 1) - (2 * row) - 1);
                        }
                    }
                }
                break;
            case 'c':
                for (int row = N - 1; row >= 0; row--)
                {
                    for (int col = 0; col < N - row; col++)
                    {
                        multiArray[row + col, col] = count++;
                    }
                }
                for (int col = 1; col < N; col++)
                {
                    for (int row = 0; row < N - col; row++)
                    {
                        multiArray[row, col + row] = count++;
                    }
                }
                break;
            case 'd':
                N = N - 1;
                for (int index = 0; index <= N / 2; index++)
                {
                    for (int row = index; row < N - index; row++)
                    {
                        multiArray[row, index] = count++;
                    }
                    for (int col = index; col < N - index; col++)
                    {
                        multiArray[N - index, col] = count++;
                    }
                    for (int row = N - index; row > index; row--)
                    {
                        multiArray[row, N - index] = count++;
                    }
                    for (int col = N - index; col > index; col--)
                    {
                        multiArray[index, col] = count++;
                    }

                    if (N % 2 == 0)
                    {
                        multiArray[N / 2, N / 2] = count;
                    }
                }
                break;
            default:
                Console.WriteLine("Invalid option selected");
                break;
        }
        return multiArray;
    }

    static void PrintArray(int[,] multiArray)
    {
        int N = multiArray.GetLength(0);
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write("{0}\t", multiArray[i, j]);
            }
            Console.WriteLine();
        }
    }
}

