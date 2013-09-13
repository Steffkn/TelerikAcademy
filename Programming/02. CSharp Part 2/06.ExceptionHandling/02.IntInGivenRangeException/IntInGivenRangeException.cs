using System;
class IntInGivenRangeException
{
    static void Main()
    {
        // ask 10 times for a number
        for (int index = 1; index < 11; index ++)
        {
            Console.Write("Line {0} -> ",index);
            int number = ReadNumber(1, 100);
        }
    }

    /// <summary>
    /// Method that reads a number from the console and checks if its in a given range
    /// </summary>
    /// <param name="start">Starting point of the range</param>
    /// <param name="end">Ending point of the range</param>
    /// <returns>Returns the number if its a valid number</returns>
    static int ReadNumber(int start, int end)
    {
        Console.Write("Enter an integer in range [{0},{1}]: ", start, end);
        int number = 0;
        try
        {
            // parse the number
            number = int.Parse(Console.ReadLine());

            // if that number is not in a given range throw exception
            if (number < start || number > end)
            {
                throw new ArgumentOutOfRangeException();
            }

        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine(String.Format("The integer should be in range [{0},{1}]!", start, end));
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number entered!");
        }
        return number;
    }
}

