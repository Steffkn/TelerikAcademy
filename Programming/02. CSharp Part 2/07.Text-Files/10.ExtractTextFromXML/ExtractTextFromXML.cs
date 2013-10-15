// Write a program that extracts from given XML file all the text without the tags. Example:
//<?xml version="1.0"><student><name>Pesho</name><age>21</age><interests count="3"><interest> Games</instrest><interest>C#</instrest><interest> Java</instrest></interests></student>

using System;
using System.IO;
using System.Text;

class ExtractTextFromXML
{
    static void Main()
    {
        string pathToFile = @"..\..\fileToRead.xml";
        try
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader streamReader = new StreamReader(pathToFile))
            {
                // read a line
                string line = streamReader.ReadLine();
                //untill a end of file is reached
                while (line != null)
                {
                    // loop trough that line
                    for (int index = 0; index < line.Length; index++)
                    {
                        // if '<' is found
                        if (line[index] == '<')
                        {
                            //untill '>' is found
                            while (line[index] != '>')
                            {
                                // skip the rest
                                index++;
                            }
                            // add a space if next element is not '<'
                            if (index < line.Length-1 && line[index + 1] != '<' )
                            {
                                sb.Append(" ");
                            }
                        }
                            // else we have a text that is needed
                        else
                        {
                            // if that char is not a space
                            if (line[index] != ' ')
                            {
                                // add it to the string builder
                                sb.Append(line[index]);
                            }
                        }
                    }
                    // read next line
                    line = streamReader.ReadLine();
                }
                // print the result
                Console.WriteLine(sb.ToString().Trim());
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
        catch (IndexOutOfRangeException indexRange)
        {
            Console.WriteLine(indexRange.Message);
        }
        catch
        {
            Console.WriteLine("Out of my grasps exception!");
        }
    }
}

