using System;

class SevenlandNumbers
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int numberToAdd = 0;
        int counter = 0;
        int temp = number;
        if (number == 0)
        {
            temp++;
        }

        while (number != 0)
        {
            if (number % 10 >= 6)
            {
                numberToAdd += 4 * (int)Math.Pow(10, counter);
                number /= 10;
                while (number % 10 >= 6 && number != 0)
                {
                    counter++;
                    number /= 10;
                    numberToAdd += 3 * (int)Math.Pow(10, counter);
                }
                break;
            }
            else
            {
                numberToAdd = 1;
                break;
            }
            counter++;
            number /= 10;
        }
        Console.WriteLine(temp + numberToAdd);
    }
}