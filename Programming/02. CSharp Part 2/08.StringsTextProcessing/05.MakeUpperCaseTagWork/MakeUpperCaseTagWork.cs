//You are given a text. Write a program that changes the text in all regions 
//surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. 
//Example:
//We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.

//Result
//We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.

using System;
using System.Text;
class MakeUpperCaseTagWork
{
    static void Main()
    {
        Console.WriteLine("Enter text to work in:");
        string text = Console.ReadLine();
        string upperCaseTag = "<upcase>";
        string upperCaseEndTag = "</upcase>";
        int upCaseIndex = 0;

        StringBuilder stringBuilderText = new StringBuilder();
        stringBuilderText.Append(text);

        // untill the end of the loop is reached
        while (upCaseIndex != -1)
        {
            // find the place of the open tag
            upCaseIndex = text.IndexOf(upperCaseTag, upCaseIndex);
            // find the end of the open tag
            int upCaseEndIndex = upCaseIndex + upperCaseTag.Length;
            // if there is no tag found, break the loop
            if (upCaseIndex == -1)
            {
                break;
            }
            // find the starting place of the close tag
            upCaseIndex = text.IndexOf(upperCaseEndTag, upCaseIndex);

            // loop trought the elements in the string builder from the starting place of the open tag to the start place of the closing tag
            for (; upCaseEndIndex <= upCaseIndex; upCaseEndIndex++)
            {
                // and make the letters at these possitions to uppercase
                stringBuilderText[upCaseEndIndex] = stringBuilderText[upCaseEndIndex].ToString().ToUpper()[0];
            }
        }
        // remove the tags
        stringBuilderText.Replace(upperCaseTag, string.Empty);
        stringBuilderText.Replace(upperCaseEndTag, string.Empty);
        Console.WriteLine(stringBuilderText);
    }
}

