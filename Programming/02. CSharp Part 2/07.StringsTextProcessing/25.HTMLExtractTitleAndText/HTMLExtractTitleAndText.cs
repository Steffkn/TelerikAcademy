//Write a program that extracts from given HTML file its title (if available), 
//and its body text without the HTML tags. 
//Example:
//<html>
//  <head><title>News</title></head>
//  <body><p><a href="http://academy.telerik.com">Telerik
//    Academy</a>aims to provide free real-world practical
//    training for young people who want to turn into
//    skillful .NET software engineers.</p></body>
//</html>

using System;
using System.Text;
class HTMLExtractTitleAndText
{
    static void Main()
    {
        string htmlSource = @"<html><head><title>News</title></head><body><p><a href=""http://academy.telerik.com\"">TelerikAcademy</a> aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body></html>";

        // get the title
        string title = GetTitle(htmlSource);
        // get the text inside the body tags
        string text = GetText(htmlSource);


        Console.WriteLine(title);
        Console.WriteLine(text);

    }

    static string GetText(string htmlSource)
    {
        StringBuilder text = new StringBuilder();
        string openTag = "<body>";
        string closeTag = "</body>";

        // find the index of the openning tag
        int bodyIndex = htmlSource.IndexOf(openTag);
        // find the index of the closing tag
        int bodyEndIndex = htmlSource.IndexOf(closeTag);

        // if the tag is found
        if (bodyIndex != -1)
        {
            // add the content between the tags to the title
            for (int index = bodyIndex + openTag.Length; index < bodyEndIndex && index < htmlSource.Length; index++)
            {
                if (htmlSource[index] == '>')
                {
                    // skip the '>'
                    index++;

                    // end of the text index
                    int endOfText = htmlSource.IndexOf("<", index);
                    // loop untill the index gets to the closing body tag
                    // and untill the index doesnt reach the end of the whole string
                    // and untill the index doesnt reach the end of the text index
                    for (; index < bodyEndIndex && index < htmlSource.Length && index < endOfText; index++)
                    {
                        // add the char to the string builder
                        text.Append(htmlSource[index]);
                    }
                }
            }
        }
        // if the tag is not found add the string to the text (instead of it)
        else
        {
            text.Append("No body set!");
        }

        // if the tag is found but its content is empty add this string to the text (instead of it)
        if (text.Length == 0)
        {
            text.Append("Empty body tag!");
        }

        // return the tittle as string
        return text.ToString();
    }



    /// <summary>
    /// Method that extracts the title from HTML document
    /// </summary>
    /// <param name="htmlSource">The sourse of the HTML document</param>
    /// <returns>Returns the title if there is any or apropriate msg instead of the title</returns>
    static string GetTitle(string htmlSource)
    {
        StringBuilder title = new StringBuilder();
        string openTag = "<title>";
        string closeTag = "</title>";

        // find the index of the openning tag
        int titleIndex = htmlSource.IndexOf(openTag);
        // find the index of the closing tag
        int titleEndIndex = htmlSource.IndexOf(closeTag);

        // if the tag is found
        if (titleIndex != -1)
        {
            // add the content between the tags to the title
            for (int index = titleIndex + openTag.Length; index < titleEndIndex && index < htmlSource.Length; index++)
            {
                title.Append(htmlSource[index]);
            }
        }
        // if the tag is not found add the string to the title (instead of it)
        else
        {
            title.Append("No title set!");
        }

        // if the tag is found but its content is empty add this string to the title (instead of it)
        if (title.Length == 0)
        {
            title.Append("Empty title tag!");
        }

        // return the tittle as string
        return title.ToString();
    }
}

