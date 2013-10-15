//Write a program that parses an URL address given in the format:
//  [protocol]://[server]/[resource]
// and extracts from it the [protocol], [server] and [resource] elements. 
//For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
//        [protocol] = "http"
//        [server] = "www.devbg.org"
//        [resource] = "/forum/index.php"

using System;
using System.Text;

class ExtractFromURL
{
    static void Main()
    {
        //string url = "http://www.devbg.org/forum/index.php";
        string url = Console.ReadLine();

        StringBuilder protocol = new StringBuilder();
        StringBuilder server = new StringBuilder();
        StringBuilder resource = new StringBuilder();
        
        int index = 0;

        // extract the protocol
        for (; index < url.Length; index++)
        {
            // if : is reached break the operation
            if (url[index] == ':')
            {
                break;
            }
            // else append a letter to the protocol
            protocol.Append(url[index]);
        }

        // skip the // from the url
        while (url[index] == ':' || url[index] == '/')
        {
            index++;
        }

        // extract the server
        for (; index < url.Length; index++)
        {
            // untill / is reached 
            if (url[index] == '/')
            {
                break;
            }
            // add the symbols to the server
            server.Append(url[index]);
        }

        // the rest is the resource
        for (; index < url.Length; index++)
        {
            // add it to the resource
            resource.Append(url[index]);
        }

        // print the result
        Console.WriteLine("protocol - {0}", protocol);
        Console.WriteLine("server - {0}", server);
        Console.WriteLine("resource - {0}", resource);
    }
}