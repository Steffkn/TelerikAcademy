// Find online more information about ASCII (American Standard Code for 
// Information Interchange) and write a program that prints the entire 
// ASCII table of characters on the console.

using System;

class ASCII_table
{
    static void Main(string[] args)
    {
        Console.Write("ASCII table\n");

        for( int charInt = 0; charInt < 128; charInt++ )
        {
            char simbol = (char)charInt;
            string display = string.Empty;
            if( char.IsWhiteSpace(simbol) )
            {
                display = simbol.ToString();
                switch( simbol )
                {
                    case '\t':
                        display = "\\t";
                        break;
                    case ' ':
                        display = "space";
                        break;
                    case '\n':
                        display = "\\n";
                        break;
                    case '\r':
                        display = "\\r";
                        break;
                    case '\v':
                        display = "\\v";
                        break;
                    case '\f':
                        display = "\\f";
                        break;
                }
            }
            else if( char.IsControl(simbol) )
            {
                display = "control";
            }
            else
            {
                display = simbol.ToString();
            }
            Console.Write("{0} \t {1} \n", charInt.ToString(), display);
        }
    }
}
