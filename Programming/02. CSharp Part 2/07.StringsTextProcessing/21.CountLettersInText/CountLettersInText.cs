// Write a program that reads a string from the console and prints all different letters in 
// the string along with information how many times each letter is found. 

using System;
using System.Collections.Generic;
using System.Text;

class CountLettersInText
{
    static void Main()
    {
        string text = "Some text that has Too many words with the letter 't'!";

        StringBuilder textBuilder = new StringBuilder();
        textBuilder.Append(text);

        List<char> lettersList = new List<char>();
        List<int> lettersCount = new List<int>();

        // loop trough all the letters in the textBuilder
        for (int letter = 0; letter < textBuilder.Length; letter++)
        {
            //reset the letter and counter
            letter = 0;
            int counter = 0;

            // count only letters
            if (textBuilder[letter] >= 'a' && textBuilder[letter] <= 'z' || textBuilder[letter] >= 'A' && textBuilder[letter] <= 'Z')
            {
                // loop trought the rest of the letters 
                for (int nextLetter = letter; nextLetter < textBuilder.Length; nextLetter++)
                {
                    // if a letter that matches the wanted one is found
                    if (textBuilder[letter] == textBuilder[nextLetter])
                    {
                        // add one to the counter
                        counter++;
                    }
                }
                // add the letter to the letterList 
                lettersList.Add(textBuilder[letter]);
                // and the counted times for that letter to other letterCount list
                lettersCount.Add(counter);
            }
            //remove the letter from the text
            textBuilder.Replace(textBuilder[letter].ToString(), string.Empty);
        }

        // print the result on the console
        Console.WriteLine(text);
        Console.WriteLine("Letter - Count");
        for (int index = 0; index < lettersList.Count; index++)
        {
            Console.WriteLine("{0} - {1,6}", lettersList[index], lettersCount[index]);
        }
    }
}