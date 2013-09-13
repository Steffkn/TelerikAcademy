//Write a program that reads a string, reverses it and prints the result at the console.
//Example: "sample" -> "elpmas".

using System;
using System.Text;

class ReverseString
{
    static void Main()
    {
        Console.Write("Enter the string that will be reversed: ");
        string normalString = Console.ReadLine();

        StringBuilder reversedString = new StringBuilder();

        for (int letterPosition = normalString.Length - 1; letterPosition >= 0; letterPosition--)
        {
            reversedString.Append(normalString[letterPosition]);
        }

        Console.WriteLine(reversedString.ToString());
    }
}

