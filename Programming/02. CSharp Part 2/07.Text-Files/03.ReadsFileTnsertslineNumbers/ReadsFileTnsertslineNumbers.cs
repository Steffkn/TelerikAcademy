using System;
using System.IO;

class ReadsFileTnsertslineNumbers
{
    static void Main()
    {
        string pathToFile = @"..\..\firstFile.txt";
        string pathToFileWithLines = @"..\..\firstFileWithLines.txt";

        try
        {
            using (StreamWriter streamWriter = new StreamWriter(pathToFileWithLines))
            {
                using (StreamReader streamReader = new StreamReader(pathToFile))
                {
                    string line = streamReader.ReadLine();
                    int countLines = 1;
                    while (line != null)
                    {
                        streamWriter.WriteLine(string.Format("{0}: {1}", countLines, line));
                        countLines++;
                        line = streamReader.ReadLine();
                    }
                }
            }
            Console.WriteLine("Operation completed successfull!");
        }
        catch (DirectoryNotFoundException dirNotFound)
        {
            Console.WriteLine("Invalid directory!",dirNotFound.Message);
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

