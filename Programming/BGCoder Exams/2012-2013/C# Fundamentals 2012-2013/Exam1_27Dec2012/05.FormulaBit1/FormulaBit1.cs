using System;

class FormulaBit1
{
    static void Main()
    {
        int[,] grid = new int[8, 8];
        int givenNumber;
        int direction = -1; // -1 = down; +1 = up; 0 = left
        int lenght = 0;
        int turns = 0;
        int[] faster = { 2, 38, 20, 48, 111, 15, 3, 43 };
        for (int i = 0; i < 8; i++)
        {
            givenNumber = int.Parse(Console.ReadLine());
            //givenNumber = faster[i];
            for (int j = 0; j < 8; j++)
            {
                grid[i, 7 - j] = givenNumber & 1;
                givenNumber >>= 1;
            }
        }

        int x = 0;
        int y = 7;
        bool deadEnd = false;
        if (grid[1, 7] == 0 && grid[0, 7] == 0)
        {

            do
            {
                while (direction == -1 && !deadEnd)
                {

                    if (x < 7 && grid[x + 1, y] == 0)
                    {
                        grid[x, y] = 5;
                        lenght++;
                        x++;
                    }
                    else if (y > 0 && grid[x, y - 1] != 0 || (y == 0 && x == 7))
                    {
                        deadEnd = true;
                        break;
                    }
                    else
                    {
                        direction = 0;
                        turns++;
                    }
                }

                while (direction == 0 && !deadEnd)
                {
                    if (y > 0 && grid[x, y - 1] == 0)
                    {
                        grid[x, y] = 5;
                        lenght++;
                        y--;
                    }
                    else if (x > 0 && grid[x - 1, y] != 0 || (y == 0 && x == 7))
                    {
                        deadEnd = true;
                        break;
                    }
                    else
                    {
                        direction = 1;
                        turns++;
                    }
                }

                while (direction == 1 && !deadEnd)
                {
                    if (x > 0 && grid[x - 1, y] == 0)
                    {
                        grid[x, y] = 5;
                        lenght++;
                        x--;
                    }
                    else if (y > 0 && grid[x, y - 1] != 0 || (y == 0 && x == 7))
                    {
                        deadEnd = true;
                        break;
                    }
                    else
                    {
                        direction = 0;
                        turns++;
                    }
                }

                while (direction == 0 && !deadEnd)
                {
                    if (y > 0 && grid[x, y - 1] == 0)
                    {
                        grid[x, y] = 5;
                        lenght++;
                        y--;
                    }
                    else if (x < 7 && grid[x + 1, y] != 0 || (y == 0 && x == 7))
                    {
                        deadEnd = true;
                        break;
                    }
                    else
                    {
                        direction = -1;
                        turns++;
                    }
                }

            } while (!deadEnd);


        }
        else if (grid[0, 7] != 0)
        {
            lenght--;
        }


        if (y == 0 && x == 7)
        {
            Console.WriteLine("{0} {1}", lenght + 1, turns);

        }
        else
        {
            Console.WriteLine("No {0}", lenght + 1);
        }


    }
}