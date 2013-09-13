//Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. 
//Sample input:
//Hi!
//Output:
//\u0048\u0069\u0021

using System;
class ConvertStringToUnicodeLiteral
{
    static void Main()
    {
        string text = Console.ReadLine();

        //loop trough the text
        for (int index = 0; index < text.Length; index++)
        {
            // print the char in the format \u+(char in hex) with 0 infront if its lenght is less than 4
            Console.Write(string.Format("\\u{0:X4}",(int)text[index]));
        }
        Console.WriteLine();
    }
}

