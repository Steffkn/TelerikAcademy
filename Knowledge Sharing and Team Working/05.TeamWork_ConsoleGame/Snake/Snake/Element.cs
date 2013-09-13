using System;

class Element
{
    public int row { get; set; }
    public int col { get; set; }
    public char symbol { get; set; }

    public Element(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

    public Element(int row, int col, char symbol)
    {
        this.row = row;
        this.col = col;
        this.symbol = symbol;
    }

    public void Display()
    {
        Console.SetCursorPosition(col, row);
        Console.Write(symbol);
    }

    public void ChangeCoordinates(int row, int col)
    {
        this.row = row;
        this.col = col;
    }
}

