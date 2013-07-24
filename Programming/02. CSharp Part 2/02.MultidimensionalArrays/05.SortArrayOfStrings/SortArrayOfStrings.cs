// You are given an array of strings. Write a method that sorts the array 
// by the length of its elements (the number of characters composing them).

using System;
class SortArrayOfStrings
{
    static void Main()
    {
        string[] stringArray = { "Gotham", "the", "deserves!", "am", "hero", "that", "I" }; // from the movie The Dark Knight (2008)

        // stringArray will get sorted by lenght
        stringArray = SortStringArrayByLenght(stringArray);
   
        // printing the result on the console
        foreach (var item in stringArray)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
    }

    static string[] SortStringArrayByLenght(string[] elements)
    {
        // flag is true if there is a shift in the string array
        bool flag = true;
        while (flag)
        {
            // set the flag to false so that if there is no shift in the string array, the loop will break;
            flag = false;
            // for loop that will go trough all the elements in the array
            for (int i = 0; i < elements.Length - 1; i++)
            {
                // switching the positions of 2 elemts if the first one has bigger lenght that the second one
                if (elements[i].Length > elements[i + 1].Length)
                {
                    // switching 2 elements
                    string tmp = elements[i];
                    elements[i] = elements[i + 1];
                    elements[i + 1] = tmp;
                    // there is a switch of elemts -> the flag = true -> the while loop will loop one more time
                    flag = true;
                }
            }
        }
        // returning the sorted array
        return elements;
    }
}
