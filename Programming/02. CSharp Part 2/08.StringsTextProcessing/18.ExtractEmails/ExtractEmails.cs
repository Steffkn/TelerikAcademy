//Write a program for extracting all email addresses from given text. 
//All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.

using System;
using System.Collections.Generic;
class ExtractEmails
{
    static void Main()
    {
        // text that has emails that are valid
        string text = @"Here are some emails that should be valid - " +
            "niceandsimple@example.com " +
            "very.common@example.com " +
            "a.little.lengthy.but.fine@dept.example.com " +
            "disposable.style.email.with+symbol@example.com " +
            "user@[IPv6:2001:db8:1ff::a0b:dbd0] " +
            @"""much.more unusual""@example.com " +
            @"""very.unusual.@.unusual.com""@example.com " +
            @"""very.(),:;<>[]\"".VERY.\""very@\\\""very\"".unusual""@strange.example.com " +
            "postbox@com (top-level domains are valid hostnames) " +
            "admin@mailserver1 (local domain name with no TLD) " +
            "!#$%&'*+-/=?^_`{}|~@example.org " +
            @"""()<>[]:,;@\\\""!#$%&'*+-/=?^_`{}|~.a""@example.org ";

        List<string> emailList = new List<string>();
        string[] emails = text.Split(' ');

        // regular expression pattern
        string pattern = @"[\w.!#$%&'*=?^_`{|}~\"" ""(),:;<>@[\]]{1,64}@[\w]{2,253}";
        //string pattern = @"([^\s""(),:;<>@[\]]{4,})\@(\w{3,})\.(\w{2,}(?:\.\w{2,})?)";

        foreach (string email in emails)
        {
            // if email that matchs the pattern is found
            if (System.Text.RegularExpressions.Regex.IsMatch(email, pattern))
            {
                // add it to the emailList
                emailList.Add(email);
            }
        }

        // display the emails
        foreach (var email in emailList)
        {
            Console.WriteLine(email);
        }
    }
}

