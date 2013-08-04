using System;

class A_nacci
{
    static void Main()
    {
        string firstLetter = Console.ReadLine();
        string secondLetter = Console.ReadLine();
        int lines = int.Parse(Console.ReadLine());
        int indexer = (int)'A' - 1;
        int first = firstLetter[0] - indexer;
        int second = secondLetter[0] - indexer;
        int third = first + second;

        Console.WriteLine("{0}", (char)(first + indexer));
        for (int i = 2; i <= lines; i++)
        {
            Console.Write("{0}", (char)(second + indexer));
            if (third > 26)
            {
                third %= 26;
            }
            Console.Write(new String(' ', i - 2));

            Console.WriteLine("{0}", (char)(third + indexer));

            first = second;
            second = third;
            third = first + second;
            if (third > 26)
            {
                third %= 26;
            }
            first = second;
            second = third;
            third = first + second;
        }
    }
}
