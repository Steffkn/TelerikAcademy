using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<string> words = new List<string>();
        for (int wordIndex = 0; wordIndex < n*2; wordIndex++)
        {
            words.Add(Console.ReadLine());
        }

        string[,] crossword = new string[n, n];

        for (int row = 0; row < words.Count; row++)
        {
            for (int col = 0; col < words.Count; col++)
            {
                
            }
        }

    }

    static int SearchWordWith(List<string> words, char letter, int position)
    {
        for (int index = 0; index < words.Count; index++)
        {
            if (words[index][position] == letter)
            {
                return index;
            }
        }
        return -1;
    }


}