using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        //// if n = 0 or 1
        char[] letters = new char[n];
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            letters[i] = Console.ReadLine().ToString()[0];
        }

        Permute p = new Permute();

        p.setper(letters);
        Console.WriteLine(p.GetCount());

    }

    class Permute
    {
        List<string> listOfWords = new List<string>();
        int count = 0;
        private void swap(ref char a, ref char b)
        {
            if (a == b) return;
            a ^= b;
            b ^= a;
            a ^= b;
        }

        public void setper(char[] list)
        {
            int x = list.Length - 1;
            go(list, 0, x);
        }

        private void go(char[] list, int k, int m)
        {

            int i;
            if (k == m)
            {
                if (FindEquals(list))
                {

                    StringBuilder word = new StringBuilder();
                    word.Append(list);

                    if (listOfWords.Count == 0)
                    {
                        listOfWords.Add(word.ToString());
                    }
                    for (int wordsIdex = 0; wordsIdex < listOfWords.Count; wordsIdex++)
                    {
                        for (int letter = 0; letter < list.Length; letter++)
                        {
                            if (listOfWords[wordsIdex][letter] != list[letter])
                            {

                                listOfWords.Add(word.ToString());
                                count++;
                            }
                        }
                    }

                }
                //Console.Write(list);
                //Console.WriteLine(" ");
            }
            else
                for (i = k; i <= m; i++)
                {
                    swap(ref list[k], ref list[i]);
                    go(list, k + 1, m);
                    swap(ref list[k], ref list[i]);
                }
        }
        public int GetCount()
        {
            return count;
        }

        private bool FindEquals(char[] list)
        {
            for (int i = 0; i < list.Length - 1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }

}