//Write a program that reads a string from the console and lists all different words 
//in the string along with information how many times each word is found.

using System;
using System.Collections.Generic;
using System.Text;

class CountWordsInText
{
    static void Main()
    {
        string text = "Some text that has Too many words with the letter 't'!some Some text that has Too many words with the letter 't'!Some text that has Too many words with the letter 't'!";

        StringBuilder textBuilder = new StringBuilder();
        textBuilder.Append(text);

        List<string> wordsList = new List<string>();
        List<int> wordsCount = new List<int>();

        // remove unlanted symbols
        for (int letter = 0; letter < textBuilder.Length; letter++)
        {
            // take only letters
            if (!(textBuilder[letter] >= 'a' && textBuilder[letter] <= 'z' || textBuilder[letter] >= 'A' && textBuilder[letter] <= 'Z'))
            {
                textBuilder.Replace(textBuilder[letter].ToString(), " ");
            }
        }

        string[] words = textBuilder.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // loop trough all the words in the textBuilder
        for (int word = 0; word < words.Length; word++)
        {
            //reset the counter
            int counter = 0;

            // if the word is not in the list of words
            if (!wordsList.Contains(words[word]))
            {
                // loop trought the rest of the words 
                for (int nextWord = word; nextWord < words.Length; nextWord++)
                {
                    // if a word that matches the wanted one is found
                    if (words[word] == words[nextWord])
                    {
                        // add one to the counter
                        counter++;
                    }
                }
                // add the word to the wordsList 
                wordsList.Add(words[word]);
                // and the counted times for that word to other wordsCount list
                wordsCount.Add(counter);
            }
        }

        // print the result on the console
        Console.WriteLine(text);
        Console.WriteLine("Word - Count");
        for (int index = 0; index < wordsList.Count; index++)
        {
            Console.WriteLine("{0} - {1,6}", wordsList[index], wordsCount[index]);
        }
    }
}
