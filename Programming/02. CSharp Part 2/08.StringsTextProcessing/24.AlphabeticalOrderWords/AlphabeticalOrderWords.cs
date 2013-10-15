//Write a program that reads a list of words, separated by spaces 
//and prints the list in an alphabetical order.

using System;
using System.Collections.Generic;
class AlphabeticalOrderWords
{
    static void Main()
    {
        string text = "Some some text that has Too many words with the letter t and they should be arranged in alphabetical order";

        List<string> listWords = GetListOfWords(text);
        listWords.Sort();
        for (int wordIndex = 0; wordIndex < listWords.Count; wordIndex++)
        {
            Console.WriteLine(listWords[wordIndex]);
        }
    }

    /// <summary>
    /// Method that returns the unic words from a string text. Its not case sensitive.
    /// </summary>
    /// <param name="text"></param>
    /// <returns>List with the unic words</returns>
    static List<string> GetListOfWords(string text)
    {
        string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<string> wordsList = new List<string>();

        // loop trough all the words in the textBuilder
        for (int word = 0; word < words.Length; word++)
        {
            // if the word is not in the list of words
            if (!wordsList.Contains(words[word].ToLower()))
            {
                // add the word to the wordsList 
                wordsList.Add(words[word].ToLower());
            }
        }

        return wordsList;
    }
}

