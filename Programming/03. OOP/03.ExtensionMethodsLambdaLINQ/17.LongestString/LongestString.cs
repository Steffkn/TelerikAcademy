using System;
using System.Linq;

class LongestString
{
    static void Main()
    {
        string[] strings = { "as", "asdf", "asdfg", "asdfgh", "asd" };

        var result = (from str in strings
                      select str).Max();

        Console.WriteLine(result);
    }
}