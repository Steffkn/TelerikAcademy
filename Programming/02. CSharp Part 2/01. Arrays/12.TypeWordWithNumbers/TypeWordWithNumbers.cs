// Write a program that creates an array containing all letters from 
// the alphabet (A-Z). Read a word from the console and print the index 
// of each of its letters in the array.


using System;

class TypeWordWithNumbers
{
    static void Main()
    {
        Console.WriteLine("Type a word");
        char[] alphabet = { 'A','B','C','D','E','F','G','H','I','G',
                              'K','L','M','N','O','P','Q','R','S','T',
                              'U','V','W','X','Y','Z' };

        string word = Console.ReadLine().ToUpper();

        for (int wordIndex = 0; wordIndex < word.Length; wordIndex++)
        {


            for (int i = 0; i < 26; i++)
            {
                if (word[wordIndex].Equals(alphabet[i]))
                {
                    Console.Write("{0} ", i);
                }
            }
        }

    }
}

