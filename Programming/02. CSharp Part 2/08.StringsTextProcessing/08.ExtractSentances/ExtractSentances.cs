//Write a program that extracts from a given text all sentences containing given word.
//        Example: The word is "in". The text is:
// We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

//The expected result is:
//We are living in a yellow submarine.
//We will move out of it in 5 days.

//Consider that the sentences are separated by "." and the words – by non-letter symbols.

using System;
using System.Collections.Generic;
using System.Text;
class ExtractSentances
{
    static void Main(string[] args)
    {
        StringBuilder text = new StringBuilder();
        text.Append("We are living in a yellow submarine. We don't have in, inanything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.");
        StringBuilder oneSentence = new StringBuilder();
        string word = string.Empty;
        word = "in";
        List<string> sentences = new List<string>();

        // find a sentance
        for (int index = 0; index < text.Length; index++)
        {
            oneSentence.Append(text[index]);
            // if the last char from the text is a dot we add the sentence to the list
            // here we can add other separators like '!', '?'
            if (text[index] == '.')
            {
                // add the sentence to the list
                sentences.Add(oneSentence.ToString());
                // clear the sentence
                oneSentence.Clear();
            }
        }

        // find the word in the sentence
        bool wholeWOrd = false;
        // for every sentence
        for (int index = 0; index < sentences.Count; index++)
        {
            int beforeWord = 0;
            // while a "word" is found
            while (beforeWord != -1)
            {
                // find the index of the char before the word
                beforeWord = sentences[index].ToString().IndexOf(word, beforeWord + 1);
                // find the index of the char after the word
                int afterWord = beforeWord + word.Length;
                // if the index is -1 then the word is not found and the loop breaks
                if (beforeWord == -1)
                {
                    break;
                }
                // whole word indicator
                wholeWOrd = true;
                // search for letters before and after the word
                for (int letterIndex = (int)'a'; letterIndex < (int)'z'; letterIndex++)
                {
                    // take the sentace convert it to string and take the char at position beforeWord and afterWord
                    // if these chars are letters then its not a whole word and the for loop will break
                    if (sentences[index].ToString()[beforeWord - 1] == (char)letterIndex || sentences[index].ToString()[afterWord] == (char)letterIndex)
                    {
                        wholeWOrd = false;
                        break;
                    }
                    // else the "word" is whole word
                }
                for (int letterIndex = (int)'A'; letterIndex < (int)'Z'; letterIndex++)
                {
                    // take the sentace convert it to string and take the char at position beforeWord and afterWord
                    // if these chars are letters then its not a whole word and the for loop will break
                    if (sentences[index].ToString()[beforeWord - 1] == (char)letterIndex || sentences[index].ToString()[afterWord] == (char)letterIndex)
                    {
                        wholeWOrd = false;
                        break;
                    }
                    // else the "word" is whole word
                }
                // break the while loop when we find a whole word
                if (wholeWOrd)
                {
                    break;
                }
            }
            // if a whole word "word" is found the sentence is printed on the console
            if (wholeWOrd)
            {
                Console.WriteLine(sentences[index].Trim());
            }
        }

    }
}

