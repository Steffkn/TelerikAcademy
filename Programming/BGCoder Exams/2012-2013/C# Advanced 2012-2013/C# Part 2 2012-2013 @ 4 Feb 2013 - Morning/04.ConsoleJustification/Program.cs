using System;
using System.Collections.Generic;
using System.Text;
class Program
{
    static void Main()
    {
        int linesOfText = int.Parse(Console.ReadLine());
        int lineWidth = int.Parse(Console.ReadLine());

        List<string> justiviedText = new List<string>();
        StringBuilder text = new StringBuilder();

        for (int i = 0; i < linesOfText; i++)
        {
            text.Append(Console.ReadLine());
        }

        string[] words = text.ToString().Split(new char[]{' ', '\n'}, StringSplitOptions.RemoveEmptyEntries);

        for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
        {
            string line = words[wordIndex];
            while (line.Length <= lineWidth)
            {
                if (wordIndex == words.Length)
                {
                    break;
                }
                int nextWordLenght = words[wordIndex+1].Length;

                if ((line.Length + nextWordLenght + 1) <= lineWidth)
                {
                    line = string.Format("{0} {1}", line, words[wordIndex+1]);
                    wordIndex++;
                }
                else
                {
                    break;
                }
            }
            justiviedText.Add(line);
        }


        foreach (var item in justiviedText)
        {
            Console.WriteLine(item);
        }
    }

}