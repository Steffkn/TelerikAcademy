using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<string> words = new List<string>();
        for (int wordIndex = 0; wordIndex < n * 2; wordIndex++)
        {
            words.Add(Console.ReadLine());
        }

        var sortedWords = words.OrderBy(x => x).ToList();

        string[,] crossword = new string[n, n];

        foreach (var word in sortedWords)
        {
            if (SearchWordWith(sortedWords, word[0], 1) != -1)
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