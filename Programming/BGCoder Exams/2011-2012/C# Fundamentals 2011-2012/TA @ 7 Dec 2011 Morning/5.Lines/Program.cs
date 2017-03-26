namespace _5.Lines
{
    using System;

    class Program
    {
        static void Main()
        {
            string[] numbers = new string[8];

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                numbers[i] = Convert.ToString(number, 2).PadLeft(8, '0');
            }

            int maxLenght = 0;
            int currentLenght = 0;
            int count = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                currentLenght = 0;
                for (int y = 0; y < 8; y++)
                {
                    if (numbers[i][y] == '1')
                    {
                        currentLenght++;
                        if (currentLenght > maxLenght)
                        {
                            maxLenght = currentLenght;
                            count = 1;
                        }
                        else if (currentLenght == maxLenght)
                        {
                            count++;
                        }
                    }
                    else
                    {
                        if (currentLenght > maxLenght)
                        {
                            maxLenght = currentLenght;
                            count = 1;
                        }
                        else
                        {

                            currentLenght = 0;
                        }
                    }
                }
            }


            foreach (var item in numbers)
            {
                if (true)
                {

                }
                Console.WriteLine("{0}", item);
            }

            Console.WriteLine();

            for (int y = 0; y < 8; y++)
            {
                currentLenght = 0;

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i][y] == '1')
                    {
                        currentLenght++;
                        if (currentLenght > maxLenght)
                        {
                            maxLenght = currentLenght;
                            count = 1;
                        }
                        else if (currentLenght == maxLenght)
                        {
                            count++;
                        }
                    }
                    else
                    {
                        if (currentLenght > maxLenght)
                        {
                            maxLenght = currentLenght;
                            count = 1;
                        }
                        else
                        {

                            currentLenght = 0;
                        }
                    }

                    //Console.Write(numbers[i][y]);
                }
            }


            Console.WriteLine(maxLenght);
            Console.WriteLine(count);
        }
    }
}
