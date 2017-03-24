using System;

class Sheets
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        for (int sheetNumber = 10; sheetNumber >= 0; sheetNumber--)
        {

            if ((N & 1) != 1)
            {
                Console.WriteLine("A" + sheetNumber);
            }
            N = N >> 1;
        }
    }
}