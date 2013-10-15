using System;
using System.IO;
class ConcatenatesTwoTextFiles
{
    static void Main()
    {
        string pathToFirstFile = @"..\..\firstFile.txt";
        string pathToSecondFile = @"..\..\secondtFile.txt";
        string pathToSConcatenatedFile = @"..\..\ConcatenatedFile.txt";
        try
        {
            using (StreamWriter streamWriter = new StreamWriter(pathToSConcatenatedFile))
            {
                using (StreamReader streamReader = new StreamReader(pathToFirstFile))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        streamWriter.WriteLine(line);
                        line = streamReader.ReadLine();
                    }
                }

                using (StreamReader streamReader = new StreamReader(pathToSecondFile))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        streamWriter.WriteLine(line);
                        line = streamReader.ReadLine();
                    }
                }
            }

            Console.WriteLine("The file {0} is writen successfull!", pathToSConcatenatedFile);
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

