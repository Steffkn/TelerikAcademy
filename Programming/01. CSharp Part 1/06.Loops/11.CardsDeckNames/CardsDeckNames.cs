// Write a program that prints all possible cards from a standard deck of 52 cards (without jokers).
// The cards should be printed with their English names. Use nested for loops and switch-case.

using System;

class CardsDeckNames
{
    static void Main()
    {
        for( int j = 1; j <= 4; j++ )
        {
            for( int i = 1; i <= 13; i++ )
            {
                // priting the names
                switch( i )
                {
                    case 1:
                        Console.Write("Ace");
                        break;
                    case 2:
                        Console.Write("Two");
                        break;
                    case 3:
                        Console.Write("Three");
                        break;
                    case 4:
                        Console.Write("Four");
                        break;
                    case 5:
                        Console.Write("Five");
                        break;
                    case 6:
                        Console.Write("Six");
                        break;
                    case 7:
                        Console.Write("Seven");
                        break;
                    case 8:
                        Console.Write("Eight");
                        break;
                    case 9:
                        Console.Write("Nine");
                        break;
                    case 10:
                        Console.Write("Ten");
                        break;
                    case 11:
                        Console.Write("Jack");
                        break;
                    case 12:
                        Console.Write("Queen");
                        break;
                    case 13:
                        Console.Write("King");
                        break;
                    default:
                        Console.WriteLine("Something went wrong!");
                        return;
                }

                Console.Write(" of ");
                // priting the colors
                switch( j )
                {
                    case 1:
                        Console.WriteLine("spades");
                        break;
                    case 2:
                        Console.WriteLine("hearts");
                        break;
                    case 3:
                        Console.WriteLine("diamonds");
                        break;
                    case 4:
                        Console.WriteLine("clubs");
                        break;
                    default:
                        Console.WriteLine("Something went wrong!");
                        break;
                }
            }
        }
    }
}

