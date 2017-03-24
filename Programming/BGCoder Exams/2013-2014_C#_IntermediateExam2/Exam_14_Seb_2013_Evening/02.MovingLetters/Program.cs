using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _02.MovingLetters
{
    class Program
    {
        static void Main()
        {
            
            //string text = Console.ReadLine();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string text = "abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz ";
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            string letters = ExtractLetters(words);

            Console.WriteLine(sw.Elapsed);

            string result = Encryption(letters);

            Console.WriteLine(sw.Elapsed);
            Console.WriteLine();
            Console.WriteLine(result);
        }

        static string Encryption(string letters)
        {
            StringBuilder encrypted = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            string result = letters;
            int timesToMove;

            for (int letterIndex = 0; letterIndex < result.Length; letterIndex++)
            {
                encrypted.Append(result);
                timesToMove = result.ToLower()[letterIndex] - (int)'a' + 1;

                while (timesToMove >= result.Length)
                {
                    timesToMove -= result.Length;
                }
                char temp = encrypted[letterIndex];
                encrypted.Remove(letterIndex, 1);

                int counter = letterIndex;
                for (int i = 0; i < timesToMove; i++)
                {
                    counter++;
                    if (counter >= result.Length)
                    {
                        counter = 0;
                    }
                }

                //string before = encrypted.ToString().Substring(0, counter);
                //string after = encrypted.ToString().Substring(counter);
                //result = string.Concat(before, temp, after);
                result = string.Concat(encrypted.ToString().Substring(0, counter), temp, encrypted.ToString().Substring(counter));
                //result = string.Format("{0}{1}{2}", encrypted.ToString().Substring(0, counter), temp, encrypted.ToString().Substring(counter));
                encrypted.Clear();
            }


            return result;
        }

        static string ExtractLetters(string[] words)
        {
            string resultLetters = string.Empty;
            bool done = false;
            bool realyDone = false;

            while (!done)
            {
                for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
                {
                    if (words[wordIndex] != string.Empty)
                    {
                        resultLetters = resultLetters + words[wordIndex][words[wordIndex].Length - 1];
                        if (words[wordIndex].Length > 1)
                        {
                            words[wordIndex] = words[wordIndex].Substring(0, words[wordIndex].Length - 1);
                        
                        }
                        else
                        {
                            words[wordIndex] = string.Empty;
                        
                        }
                    }
                }

                foreach (var word in words)
                {
                    if (word != string.Empty)
                    {
                        done = false;
                        break;
                    }
                    else
                    {
                        done = true;
                    }
                }

            }
            return resultLetters;
        }



    }
}
