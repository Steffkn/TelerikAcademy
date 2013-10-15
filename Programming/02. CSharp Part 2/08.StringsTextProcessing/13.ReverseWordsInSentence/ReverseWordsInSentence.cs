//Write a program that reverses the words in given sentence.
//      Example: "C# is not C++, not PHP and not Delphi!" 
//-> "Delphi not and PHP, not C++ not is C#!".

using System;
using System.Collections.Generic;
using System.Text;

class ReverseWordsInSentence
{
    static void Main()
    {
        StringBuilder sentence = new StringBuilder();
        Console.WriteLine("Enter a sentence to reverse:");
        //sentence.Append("C# is not C++, not PHP ,and not Delphi!!!");
        sentence.Append(Console.ReadLine());
        // show the sentence
        Console.WriteLine("Sentence: {0}", sentence);

        StringBuilder endOfSentence = new StringBuilder();
        Queue<int> listComma = new Queue<int>();
        char end;

        // add the back of the sentece to a StringBuilder
        for (int index = sentence.Length - 1; index >= 0; index--)
        {
            // take the end char
            end = sentence[index];
            // if its . ! or ? add it to the endOfSentence StringBuilder
            if (end == '.' || end == '!' || end == '?')
            {
                endOfSentence.Append(end);
                // and remove it from the sentece
                sentence.Remove(index, 1);
            }
                // else a letter or other char is found (that we dont want) so the loop breaks
            else
            {
                break;
            }
        }

        // break the sentence to words and put them in string array
        string[] words = sentence.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        StringBuilder reversed = new StringBuilder();

        // loop trough the words in the string array, starting from the last one
        for (int index = words.Length - 1; index >= 0; index--)
        {
            // if a comma is found infront of the word
            if (words[index][0] == ',')
            {
                // remove the comma from the word
                words[index] = words[index].Replace(",", string.Empty);
                // add the coma with a white space infront of it to the reversed StringBuilder
                reversed.Append(string.Concat(words[index], " ,"));
            }
            // else if a comma is found at the end of the word
            else if (words[index][words[index].Length - 1] == ',')
            {
                // remove the comma from the word
                words[index] = words[index].Replace(",", string.Empty);
                // and add the comma to the reversed StringBuilder before the word and a white space after the word
                reversed.Append(string.Concat(",", words[index], " "));
            }
                // if the word doesn't contains a comma
            else
            {
                // just add it to the reversed StringBuilder
                reversed.Append(string.Concat(words[index], " "));
            }
        }
        // remove the last white space in the last word
        reversed.Remove(reversed.Length - 1, 1);
        // add the end of the sentence (. ! or ?)
        reversed.Append(endOfSentence);

        // print the result
        Console.WriteLine(reversed);
    }
}
