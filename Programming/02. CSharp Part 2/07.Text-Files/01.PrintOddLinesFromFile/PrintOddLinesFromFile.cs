using System;
using System.IO;
class PrintOddLinesFromFile
{
    static void Main()
    {
        string pathToFile = @"..\..\fileToRead.txt";
        try
        {
            using (StreamReader streamReader = new StreamReader(pathToFile))
            {
                bool odd = true;
                string oddLine = streamReader.ReadLine();
                while (oddLine != null)
                {
                    if (odd)
                    {
                        Console.WriteLine(oddLine);
                    }
                    odd = !odd;
                    oddLine = streamReader.ReadLine();
                }
            }
        }
        catch (DirectoryNotFoundException dirNotFound)
        {
            Console.WriteLine("Invalid directory!", dirNotFound.Message);
        }
        catch (ArgumentException argExc)
        {
            Console.WriteLine("Invalid file path!", argExc.Message);
        }
        catch (IOException ioExc)
        {
            Console.WriteLine("File error!", ioExc.Message);
        }
        catch
        {
            Console.WriteLine("Out of my grasps exception!");
        }
    }
}
