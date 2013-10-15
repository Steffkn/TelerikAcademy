using System;
using System.IO;
using System.Text;

class DeleteOddLines
{
    static void Main()
    {
        string pathToFile = @"..\..\fileToRead.txt";
        try
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader streamReader = new StreamReader(pathToFile))
            {
                bool odd = true;
                string oddLine = streamReader.ReadLine();
                while (oddLine != null)
                {
                    if (!odd)
                    {
                        sb.Append(oddLine);
                        sb.Append(Environment.NewLine);
                    }
                    odd = !odd;
                    oddLine = streamReader.ReadLine();
                }

            }
            using (StreamWriter streamWriter = new StreamWriter(pathToFile))
            {
                streamWriter.Write(sb);
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
