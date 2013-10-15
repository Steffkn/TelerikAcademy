using System;
using System.IO;

// It works with bigger files .. tested with 97,8 MB file
class ReplaceStartWithFinish
{
    static void Main()
    {
        string pathToInputFile = @"..\..\input.txt";
        string pathToOutputFile = @"..\..\output.txt";
        string wordToReplace = "Start";
        string wordToReplaceWith = "Finish";
        try
        {
            using (StreamReader streamReader = new StreamReader(pathToInputFile))
            {
                using (StreamWriter streamWriter = new StreamWriter(pathToOutputFile))
                {
                    string line = streamReader.ReadLine();

                    while (line != null)
                    {
                        line = line.Replace(wordToReplace, wordToReplaceWith);
                        streamWriter.WriteLine(line);
                        line = streamReader.ReadLine();
                    }
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

