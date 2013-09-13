//Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

using System;
using System.Collections.Generic;
class ExtractPalindromes
{
    static void Main(string[] args)
    {
        string text = "Somesss text ala with some ,palindromessemordnilap like ABBA or lamal or exe or anilina.";
        // remove some chars that we dont need but they could bug the program
        text = text.Replace('.', ' ');
        text = text.Replace('!', ' ');
        text = text.Replace('?', ' ');
        text = text.Replace(':', ' ');
        text = text.Replace(',', ' ');
        text = text.Replace('-', ' ');

        // split the text to words and put them in array
        string[] allWords = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Queue<string> palindromes = new Queue<string>();
        
        // for every word in the array
        for (int word = 0; word < allWords.Length; word++)
        {
            Stack<char> palindrom = new Stack<char>();
            int letter = 0;
            // and for every letter in the word; untill the middle letter
            for (; letter < allWords[word].Length / 2; letter++)
            {
                // push the letters to the stack;
                palindrom.Push(allWords[word][letter]);
            }

            // if the word's lenght is odd add 1 to the lenght that we have visited; 
            // just skip the middle letter, and it wont be pushed to the stack after
            if (allWords[word].Length % 2 != 0)
            {
                letter = (allWords[word].Length / 2)+1;
            }

            // for every letter in the word after the middle
            for (; letter < allWords[word].Length; letter++)
            {
                // if the letter is equal to the last leter in the stack
                if (palindrom.Peek() == allWords[word][letter])
                {
                    // pop that letter
                    palindrom.Pop();
                }
                    // else the word is not palindrom
                else
                {
                    // break the loop
                    break;
                }
            }

            // if the stack is empty then the word is palintrom
            if (palindrom.Count == 0)
            {
                // add the word to an queue
                palindromes.Enqueue(allWords[word]);
            }
        }

        // print the elements in the queue of palindromes
        while (palindromes.Count >0)
        {
            Console.WriteLine(palindromes.Dequeue());
        }
    }
}
