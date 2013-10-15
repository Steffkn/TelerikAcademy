using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
class CompareTwoFiles
{
    static void Main()
    {
        string pathToFirstFile = @"..\..\firstFile.txt";
        string pathToSecondFile = @"..\..\secondtFile.txt";
        Queue<int> equal = new Queue<int>();
        Queue<int> notEqual = new Queue<int>();
        try
        {

            using (StreamReader firstSReader = new StreamReader(pathToFirstFile))
            {
                using (StreamReader secondSReader = new StreamReader(pathToSecondFile))
                {
                    string firstFileLine = firstSReader.ReadLine();
                    string secondFileLine = secondSReader.ReadLine();
                    int count = 0;
                    while (firstFileLine != null || secondFileLine != null)
                    {
                        if (firstFileLine.Equals(secondFileLine))
                        {
                            equal.Enqueue(++count);
                        }
                        else
                        {
                            notEqual.Enqueue(++count);
                        }
                        firstFileLine = firstSReader.ReadLine();
                        secondFileLine = secondSReader.ReadLine();
                    }
                }
            }

            // print the equal line son the console
            while (equal != null && equal.Count != 0)
            {
                Console.WriteLine("Equal lines: {0}", equal.Dequeue());
            }
            // print the not equal lines on the console
            while (notEqual != null && notEqual.Count != 0)
            {
                Console.WriteLine("Not equal lines: {0}", notEqual.Dequeue());
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

