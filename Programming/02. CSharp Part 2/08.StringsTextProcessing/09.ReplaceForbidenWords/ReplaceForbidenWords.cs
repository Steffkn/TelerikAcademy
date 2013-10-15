//We are given a string containing a list of forbidden words and a text containing some of these words. 
//Write a program that replaces the forbidden words with asterisks. 

//Example:
//Microsoft announced its next generation PHP compiler today. 
//It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
	
//Words: "PHP, CLR, Microsoft"
//The expected result:
//********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.

using System;
using System.Collections.Generic;
using System.Text;

class ReplaceForbidenWords
{
    static void Main()
    {
        StringBuilder text = new StringBuilder();
        text.Append("Microsoft microsoft announced its next generation PHP compiler today,. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.");
        string[] words = text.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<string> forbidenWords = new List<string>() { "Microsoft", "microsoft", "PHP", "CLR"};

        StringBuilder newString = new StringBuilder();

        //forbiden word indicator
        bool forbiden = false;
        // loop trough the text represented as string array
        foreach (var word in words)
        {
            forbiden = false;
            // search for forbiden word in the word from the array
            for (int forbidenIndex = 0; forbidenIndex < forbidenWords.Count; forbidenIndex++)
            {
                // if index is not -1 then a forbiden word is found
                if (word.IndexOf(forbidenWords[forbidenIndex]) != -1)
                {
                    forbiden = true;
                    break;
                }
                    // else the word is not forbiden
            }

            // if the word is forbiden
            if (forbiden)
            {
                // there is better way to do this..
                // if the last char is a dot or comma add it after the *
                if (word[word.Length - 1] == '.')
                {
                    newString.Append(string.Format("{0}.", new String('*', word.Length - 1)));
                }
                else if (word[word.Length - 1] == ',')
                {
                    newString.Append(string.Format("{0},", new String('*', word.Length - 1)));
                }
                else
                {
                    newString.Append(new String('*', word.Length));
                }
            }
                // if the word is not forbiden
            else
            {
                // add it to the SB
                newString.Append(word);
            }
            // add separator
            newString.Append(" ");
        }

        Console.WriteLine(newString);
    }
}

