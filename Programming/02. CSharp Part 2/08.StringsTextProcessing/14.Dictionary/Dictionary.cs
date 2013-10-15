//A dictionary is stored as a sequence of text lines containing words and their explanations. 
//Write a program that enters a word and translates it by using the dictionary. 

using System;
using System.Collections.Generic;
using System.Text;

class Dictionary
{
    static void Main()
    {
        List<string> dictionary = new List<string>();
        dictionary.Add(".NET - platform for applications from Microsoft");
        dictionary.Add("CLR - managed execution environment for .NET");
        dictionary.Add("namespace - hierarchical organization of classes");

        string[,] dictionaryArray = new string[dictionary.Count, 2];
        Console.WriteLine("Enter a word to search for:");
        string word = Console.ReadLine();

        // add the words and their discriptions to array
        for (int index = 0; index < dictionary.Count; index++)
        {
            // find the dash that separates the words from their discriptions
            int dashIndex = dictionary[index].IndexOf(" - ");
            // add the word
            dictionaryArray[index, 0] = dictionary[index].Substring(0, dashIndex).Trim();
            // add the discription
            dictionaryArray[index, 1] = dictionary[index].Substring(dashIndex + 1).Trim();
        }

        // search for the word in the array
        for (int index = 0; index < dictionary.Count; index++)
        {
            // if the word is found
            if (word.ToUpper() == dictionaryArray[index, 0].ToUpper())
            {
                //Console.WriteLine(dictionaryArray[index, 0]);
                // print the discription to the console and break the loop
                Console.WriteLine("description: {0}", dictionaryArray[index, 1]);
                break;
            }
            // if the last index is reached then the word was not found
            if (index == dictionary.Count - 1)
            {
                // show this message 
                Console.WriteLine("The word '{0}' was not found!", word);
            }
        }

    }
}