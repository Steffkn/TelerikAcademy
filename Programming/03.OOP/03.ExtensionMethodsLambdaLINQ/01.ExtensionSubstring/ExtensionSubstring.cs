using System;
using System.Text;

public static class ExtensionSubstring
{
    static void Main()
    {
        string simple = "dasda";
        simple.Substring(1,2);
        StringBuilder simpleString = new StringBuilder();
        simpleString.Append("Some simple string");
        Console.WriteLine(simpleString.SubString(5, 6)); // "simple"
        Console.WriteLine(simpleString.SubString(12, 6)); // "string"

    }
  
    /// <summary>
    /// Extension method: Substring of a StringBuilder
    /// </summary>
    /// <param name="strBuilder">Given string builder</param>
    /// <param name="index">Starting index</param>
    /// <param name="length">Lenght of the string</param>
    /// <returns>Returns substring from a given StringBuilder as new StringBuilder.</returns>
    public static StringBuilder SubString(this StringBuilder strBuilder, int index, int length)
    {
        // find the end index 
        int endPoint = index + length;
        StringBuilder result = new StringBuilder(length);
        for (int i = index; i < endPoint && i < strBuilder.Length ; i++)
        {
            result.Append(strBuilder[i]);
        }
        return result;
    }
}
