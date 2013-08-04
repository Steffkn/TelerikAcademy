using System;
class ExcelColumns
{
    static void Main()
    {
        int letterNumber = int.Parse(Console.ReadLine());
 
        int shift = (int)'A' - 1;
        string letter;
        int letterIndex;
        long columnIndex = 0;
        for( int i = 0; i < letterNumber; i++ )
        {
            columnIndex *= 26;
            letter = Console.ReadLine();
            letterIndex = (int)letter[0] - shift;
 
            columnIndex += letterIndex;
        }
 
        Console.WriteLine(columnIndex);
    }
}