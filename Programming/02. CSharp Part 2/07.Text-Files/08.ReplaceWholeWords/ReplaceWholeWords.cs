using System;
using System.IO;

// It works with bigger files .. tested with 97,8 MB file
class ReplaceWholeWords
{
    static void Main()
    {
        string pathToInputFile = @"..\..\input.txt";
        string pathToOutputFile = @"..\..\output.txt";
        string wordToReplace = "Start";
        string wordToReplaceWith = "Finish";

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
                        while ((index = line.IndexOf(wordToReplace, index)) >= 0)
                        {
                            // declare a startIndex of the wordsToReplace
                            int startIndex = index;
                            // if the index is 0 ; if the word is at the beginning of the row line[-1] will crash the exe
                            if (index == 0)
                            {
                                // 1 is added to the startIndex
                                startIndex++;
                            }
                            // if the char before the word is NOT a letter and the char after the word is not a letter
                            if (IsNotLetter(line[startIndex - 1]) && IsNotLetter(line[index + wordToReplace.Length]))
                            {
                                // then its one word and its replaces
                                line = line.Remove(index, wordToReplace.Length);
                                line = line.Insert(index, wordToReplaceWith);
                            }
                            // add 1 to the index so that it doesnt loop forever
                            index++;
                        }
                        // write to the new output file
                        streamWriter.WriteLine(line);
                        // and read the next line of the input file
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
        //if(charToCheck == '_' )
        //{
              // if the char is underline; if _WordToReplace is given the result will be false and it wont be replaces
        //    return false;
        //}
        for (int charIndex = (int)'a'; charIndex < (int)'z'; charIndex++)
        {
            // if the char is a letter
            if (charToCheck == (char)charIndex)
            {
                return false;
            }
        }

        // if the char is not a letter from [a-z] and [A-Z]
        return true;
    }
}

