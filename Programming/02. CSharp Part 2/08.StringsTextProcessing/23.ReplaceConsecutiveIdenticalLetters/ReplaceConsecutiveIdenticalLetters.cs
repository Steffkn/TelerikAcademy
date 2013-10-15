//Write a program that reads a string from the console and replaces 
//all series of consecutive identical letters with a single one. 
//Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".

using System;
using System.Text;
class ReplaceConsecutiveIdenticalLetters
{
    static void Main()
    {
        // words that have to have two identical letters in it, like the word "too" and "letter", and all symbols that are repeated will be destroyed
        string text = "Sooooome ttttttttttttteeexttttttttttttt tttttttttttthaaaaatttttttttt haaaaas TTTTTTTTTTTTTooo maaaaaany woooords with ttttttttthe letttttter 't'!";
        
        StringBuilder textBuilder = new StringBuilder();
        if (text.Length > 0)
        {
            Console.WriteLine("Text:");
            Console.WriteLine(text);
            // add first letter to the stringbuilder
            textBuilder.Append(text[0]);
            // loop trough the letters in the text
            for (int letterIndex = 0; letterIndex < text.Length; letterIndex++)
            {
                // if the current letter is different from the last one already in the textBuilder
                if (text[letterIndex] != textBuilder[textBuilder.Length - 1])
                {
                    // add that letter to the textBuilder
                    textBuilder.Append(text[letterIndex]);
                }
            }
        }
            // if the text string is empty
        else
        {
            // add this msg to the textBuilder
            textBuilder.Append("Empty text field!");
        }

        // show the result
        Console.WriteLine("Result:");
        Console.WriteLine(textBuilder);

    }
}
