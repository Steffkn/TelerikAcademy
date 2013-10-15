//Write a program that deletes from a text file all words that start with the prefix "test". 
//Words contain only the symbols 0...9, a...z, A…Z, _.

using System;
using System.IO;

class DeleteWordsWithPrefix
{
    static void Main()
    {

        string pathToInputFile = @"..\..\input.txt";
        string pathToOutputFile = @"..\..\output.txt";
        string prefix = "test";

        try
        {
            // open stream for reading
            using (StreamReader streamReader = new StreamReader(pathToInputFile))
            {
                // open a stream for writing
                using (StreamWriter streamWriter = new StreamWriter(pathToOutputFile))
                {
                    string line = streamReader.ReadLine();

                    while (line != null)
                    {
                        int index = 0;// = line.IndexOf(wordToReplace);
                        while ((index = line.IndexOf(prefix, index)) >= 0)
                        {
                            // declare a startIndex of the wordsToReplace
                            int startIndex = index;
                            int lettersToRemove = 0;
                            if (index == 0)
                            {
                                startIndex = 1;
                            }
                            if (!IsNotLetter(line[startIndex - 1]) && startIndex != 1)
                            {
                                index++;
                                break;
                            }
                            while (!IsNotLetter(line[index + lettersToRemove]))
                            {
                                lettersToRemove++;
                            }
                            // then its one word and its replaces
                            line = line.Remove(startIndex - 1, lettersToRemove+1);
                            // add 1 to the index so that it doesnt loop forever
                            index=0;
                        }
                        // write to the new output file
                        streamWriter.WriteLine(line);
                        // and read the next line of the input file
                        line = streamReader.ReadLine();
                    }
                }

            }
            Console.WriteLine("Replasing successful!");
        }
        catch (DirectoryNotFoundException dirNotFound)
        {
            Console.WriteLine("Invalid directory!", dirNotFound.Message);
        }
        //catch (ArgumentException argExc)
        //{
        //    Console.WriteLine("Invalid file path!", argExc.Message);
        //}
        //catch (IOException ioExc)
        //{
        //    Console.WriteLine("File error!", ioExc.Message);
        //}
        //catch
        //{
        //    Console.WriteLine("Out of my grasps exception!");
        //}

    }

    /// <summary>
    /// Loop that finds if a char is a letter or not
    /// </summary>
    /// <param name="charToCheck"></param>
    /// <returns></returns>
    private static bool IsNotLetter(char charToCheck)
    {
        // if the letter is upper case
        // its transforemed to lower case by using the string mettod ToLower()
        charToCheck = charToCheck.ToString().ToLower()[0];

        // special chars can be added here:
        if (charToCheck == '_')
        {
            //if the char is underline; if _WordToReplace is given the result will be false and it wont be replaces
            return false;
        }
        for (int charIndex = (int)'a'; charIndex < (int)'z'; charIndex++)
        {
            // if the char is a letter
            if (charToCheck == (char)charIndex)
            {
                return false;
            }
        }

        for (int charIndex = (int)'0'; charIndex < (int)'9'; charIndex++)
        {
            // if the char is a number
            if (charToCheck == (char)charIndex)
            {
                return false;
            }
        }

        // if the char is not a letter from [a-z] and [A-Z]
        return true;
    }
}

