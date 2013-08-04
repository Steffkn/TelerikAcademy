//* Write a program that converts a number in the range [0...999] to a text 
// corresponding to its English pronunciation. Examples:
//    0 -> "Zero"
//    273 ->  "Two hundred seventy three"
//    400 -> "Four hundred"
//    501 -> "Five hundred and one"
//    711 -> "Seven hundred and eleven"

using System;
class NameOfNumber2
{
    static void Main()
    {
        int number;

        Console.WriteLine("Enter an integer");
        // a valid integer is needed
        if( !int.TryParse(Console.ReadLine(), out number) )
        {
            Console.WriteLine("Invalid value!");
        }
        else
        {
            int tempNumber = number; // holding the value of "number" in case we need "number" later 
            string name = "";   // string for the number's name

            if( number == 0 )
            {
                name = "zero";
            }
            // if the number is not from 10 to 19
            else if( ( tempNumber / 10 ) % 10 != 1 )
            {
                // if the number isnt from 10 to 19
                // adding the name of the first digit before the string "name"
                switch( tempNumber % 10 )
                {
                    case 1:
                        name = "one";
                        break;
                    case 2:
                        name = "two";
                        break;
                    case 3:
                        name = "tree";
                        break;
                    case 4:
                        name = "four";
                        break;
                    case 5:
                        name = "five";
                        break;
                    case 6:
                        name = "six";
                        break;
                    case 7:
                        name = "seven";
                        break;
                    case 8:
                        name = "eigth";
                        break;
                    case 9:
                        name = "nine";
                        break;
                }
                if( ( tempNumber / 10 ) % 10 == 0 && tempNumber > 100)
                {

                    name = "and " + name;
                }
            }
            else
            {
                
                
                // if the number is from 10 to 19
                // adding the name of the digit before the string "name"
                switch( tempNumber % 10 )
                {
                    case 0:
                        name = "ten";
                        break;
                    case 1:
                        name = "eleven";
                        break;
                    case 2:
                        name = "twelve";
                        break;
                    case 3:
                        name = "thirteen";
                        break;
                    case 4:
                        name = "fourteen";
                        break;
                    case 5:
                        name = "fifteen";
                        break;
                    case 6:
                        name = "sixteen";
                        break;
                    case 7:
                        name = "seventeen";
                        break;
                    case 8:
                        name = "eighteen";
                        break;
                    case 9:
                        name = "nineteen";
                        break;
                }
                if( number > 100 )
                {
                    
                    name = "and " + name;
                }
            }
            // dividing the number by 10
            tempNumber /= 10;

            // if the first digit of the new number is not 0
            if( tempNumber % 10 != 0 )
            {
                // adding the name of the first digit of the new number before the string "name"
                switch( tempNumber % 10 )
                {
                    case 2:
                        name = "twenty " + name;
                        break;
                    case 3:
                        name = "thirty " + name;
                        break;
                    case 4:
                        name = "fourty " + name;
                        break;
                    case 5:
                        name = "fifty " + name;
                        break;
                    case 6:
                        name = "sixty " + name;
                        break;
                    case 7:
                        name = "seventy " + name;
                        break;
                    case 8:
                        name = "eighty " + name;
                        break;
                    case 9:
                        name = "ninety " + name;
                        break;
                    default:
                        break;
                }

            }
            // dividing the number by 10
            tempNumber /= 10;

            // if the first digit of the new number is not 0
            if( tempNumber % 10 != 0 )
            {
                if( name != "" )
                {
                    name = " " + name;
                }
                // adding the name of the first digit of the new number as hundreds before the string "name"
                switch( tempNumber % 10 )
                {
                    case 1:
                        name = "one hundred" + name;
                        break;
                    case 2:
                        name = "two hundred" + name;
                        break;
                    case 3:
                        name = "tree hundred" + name;
                        break;
                    case 4:
                        name = "four hundred" + name;
                        break;
                    case 5:
                        name = "five hundred" + name;
                        break;
                    case 6:
                        name = "six hundred" + name;
                        break;
                    case 7:
                        name = "seven hundred" + name;
                        break;
                    case 8:
                        name = "eigth hundred" + name;
                        break;
                    case 9:
                        name = "nine hundred" + name;
                        break;
                }
            }
            // this makes the first letter of the string "name" to upper case
            name = name[0].ToString().ToUpper() + name.Substring(1);

            // printing the name of the digit
            Console.WriteLine("The number is {0}", name);
        }
    }
}