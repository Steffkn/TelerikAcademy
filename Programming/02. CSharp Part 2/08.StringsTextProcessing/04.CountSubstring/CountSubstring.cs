//Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
//        Example: The target substring is "in". The text is as follows:

//We are living in an yellow submarine. We don't 
//have anything else. Inside the submarine is 
//very tight. So we are drinking all the day. 
//We will move out of it in 5 days.

//The result is: 9.

using System;
class CountSubstring
{
    static void Main()
    {
        Console.WriteLine("Enter text to search in:");
        string text = Console.ReadLine();
        Console.WriteLine("Enter string to search for:");
        string searchFor = Console.ReadLine();
        int index = 0;
        int counter = 0;

        // while the end of the string is reached
        while (index != -1)
        {
            // find new index starting from the last index as position in the string
            index = text.IndexOf(searchFor, index + 1);
            // count ine more time
            counter++;
        }

        //show the result of the search
        Console.WriteLine("The resull is {0}", counter);
    }
}

