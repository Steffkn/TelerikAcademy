using System;
using System.Collections.Generic;
using System.IO;

class SortTextFile
{
    static void Main()
    {
        try
        {
            string pathToInputFile = @"..\..\input.txt";
            string pathToOutputFile = @"..\..\output.txt";
            List<string> words = new List<string>();

            using (StreamReader streamReader = new StreamReader(pathToInputFile))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    words.Add(line);
                    line = streamReader.ReadLine();
                }
                words.Sort();
            }

            using (StreamWriter streamWriter = new StreamWriter(pathToOutputFile))
            {
                for (int i = 0; i < words.Count; i++)
                {
                    streamWriter.WriteLine(words[i]);
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

