// Write program that asks for a digit and depending on the input shows 
// the name of that digit (in English) using a switch statement.

// No constrains for this task.. 
// this program should work correct for numbers from -999 999 999 to 999 999 999

// PS: I think that I overdid it after I saw the last tanks from the homework
using System;

class NameOfNumber
{
    static void Main()
    {
        int number;
        string[] thousandMilian = { " thousand ", " milian " };

        Console.WriteLine("Enter an integer");
        // a valid integer is needed
        if( !int.TryParse(Console.ReadLine(), out number) )
        {
            Console.WriteLine("Invalid value!");
        }
        else
        {
            int tempNumber = Math.Abs(number); // holding the absolute value of "number" in case we need "number" later 
            int index = 0;  // this index will be used with thousandMilian
            string name = "";   // string for the number's name

            // if the number is 0
            if( tempNumber == 0 )
            {
                name = "zero";
            }
            // while the number is bigger than 0
            while( tempNumber != 0 )
            {
                // if the number is from 10 to 19
                if( ( tempNumber / 10 ) % 10 != 1 )
                {
                    // if the number isnt from 10 to 19
                    // adding the name of the first digit before the string "name"
                    switch( tempNumber % 10 )
                    {
                        case 1:name = "one" + name;break;
                        case 2:name = "two" + name;break;
                        case 3:name = "tree" + name;break;
                        case 4:name = "four" + name;break;
                        case 5:name = "five" + name; break;
                        case 6:name = "six" + name;break;
                        case 7:name = "seven" + name;break;
                        case 8:name = "eigth" + name;break;
                        case 9:name = "nine" + name;break;
                    }
                }
                else
                {
                    // if the number is from 10 to 19
                    // adding the name of the digit before the string "name"
                    switch( tempNumber % 10 )
                    {
                        case 0:name = "ten" + name;break;
                        case 1:name = "eleven" + name; break;
                        case 2:name = "twelve" + name;break;
                        case 3:name = "thirteen" + name;break;
                        case 4:name = "fourteen" + name;break;
                        case 5:name = "fifteen" + name;break;
                        case 6:name = "sixteen" + name;break;
                        case 7:name = "seventeen" + name;break;
                        case 8:name = "eighteen" + name;break;
                        case 9:name = "nineteen" + name;break;
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
                        case 2:name = "twenty " + name;break;
                        case 3:name = "thirty " + name;break;
                        case 4:name = "fourty " + name;break;
                        case 5:name = "fifty " + name;break;
                        case 6:name = "sixty " + name;break;
                        case 7:name = "seventy " + name;break;
                        case 8:name = "eighty " + name;break;
                        case 9:name = "ninety " + name;break;
                        default:
                            break;
                    }

                }
                // dividing the number by 10
                tempNumber /= 10;

                // if the first digit of the new number is not 0
                if( tempNumber % 10 != 0 )
                {
                    if( name != "" && ( tempNumber > 0 ) )
                    {
                        name = " and " + name;
                    }
                    // adding the name of the first digit of the new number as hundreds before the string "name"
                    switch( tempNumber % 10 )
                    {
                        case 1:name = "one hundred" + name;break;
                        case 2:name = "two hundred" + name;break;
                        case 3:name = "tree hundred" + name;break;
                        case 4:name = "four hundred" + name;break;
                        case 5:name = "five hundred" + name;break;
                        case 6:name = "six hundred" + name;break;
                        case 7:name = "seven hundred" + name;break;
                        case 8:name = "eigth hundred" + name;break;
                        case 9:name = "nine hundred" + name;break;
                    }
                }
                    // if the number is bigger than 999, "tempNumber" will be bigger than 0 and string "and" will be added before the string "name"
                else if( tempNumber > 0 )
                {
                    // in case there is a number like 100 1000 1100 ex. "and" wond be added because this will break our name
                    if( name != "" )
                    {
                        name = "and " + name;
                    }
                }

                // dividing the number by 10
                tempNumber = tempNumber / 10;

                // if tempNumber is bigger than 1000 that means that "thousand" or "millian" string will be added to name
                if( tempNumber > 0 && tempNumber % 1000 != 0 )
                {
                    name = thousandMilian[index] + name;
                    // switching from thousand to millian
                    index++;
                }
                else
                {
                    index++;
                }
            }// end of while
            // if negative number is given as input string "negative" will be added before printing the name 
            if( number < 0 )
            {
                name = "negative " + name;
            }            

            // this makes the first letter of the string "name" to upper case
            name = name[0].ToString().ToUpper() + name.Substring(1);

            // printing the name of the digit
            Console.WriteLine("The number is {0}", name);

        }// end of else
    }
}
