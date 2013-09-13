using System;
using System.Net;
class DownloadFile
{
    static void Main()
    {
        try
        {
            // using will close everything
            using (WebClient webClient = new WebClient())
            {
                Console.Write("Enter URL to the file: ");
                string url = Console.ReadLine();

                // take the index of the url where the name of the file starts
                int startIndexFileName = url.LastIndexOf('/') + 1; // +1 to skip the dash

                // get the name of the file we want to download
                string fileName = url.Substring(startIndexFileName);

                // download the file
                Console.WriteLine("Wait while downloading...");
                webClient.DownloadFile(url, fileName);
                Console.WriteLine("Download completed!");
            }
        }

        catch (ArgumentNullException)
        {
            Console.WriteLine("Invalid url!");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("File's url cant be empty!");
        }

        catch (System.Net.WebException)
        {
            Console.WriteLine("No internet access or the file does not exist!");
        }

	catch (NotSupportedException)
	{
	    Console.WriteLine("The method has been called simultaneously on multiple threads.");
 	}

    }
}

