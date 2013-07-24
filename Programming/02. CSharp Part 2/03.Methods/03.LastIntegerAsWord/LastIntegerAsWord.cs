//Write a method that returns the last digit of given integer as an English word.
//Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".

using System;
class LastIntegerAsWord
{
    static void Main()
    {
        Console.WriteLine("Enter a digit!");
        int givenInt = int.Parse(Console.ReadLine());

        Console.WriteLine("The last digit of the number {0} is {1}!",givenInt, DigitName(givenInt));
    }

    public static string DigitName(int givenInt)
    {
        string result = "";
        // switch through the possible options
        switch (givenInt % 10)
        {
            case 0: result = "zero"; break;
            case 1: result = "one"; break;
            case 2: result = "two"; break;
            case 3: result = "three"; break;
            case 4: result = "four"; break;
            case 5: result = "five"; break;
            case 6: result = "six"; break;
            case 7: result = "seven"; break;
            case 8: result = "eight"; break;
            case 9: result = "nice"; break;
            default:
                Console.WriteLine("Something went wrong!");
                break;
        }
        // return the resulting string
        return result;
    }
}

