using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string pahtToWordsFile = @"..\..\words.txt";
        string pathToTextFile = @"..\..\fileWithText.txt";
        try
        {
            List<string> wordList = new List<string>();

            using (StreamReader streamReader = new StreamReader(pahtToWordsFile))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    wordList.Add(line.Replace(" ",string.Empty));
                    line = streamReader.ReadLine();
                }
            }

            StringBuilder sb = new StringBuilder();
            using (StreamReader streamReader = new StreamReader(pathToTextFile))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    for (int wordIndex = 0; wordIndex < wordList.Count; wordIndex++)
                    {
                        string wordToReplace = wordList[wordIndex];

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
                            if (startIndex == 1 || (IsNotLetter(line[startIndex - 1]) && IsNotLetter(line[index + wordToReplace.Length])))
                            {
                                // then its one word and its replaces
                                line = line.Remove(index, wordToReplace.Length);
                                //line = line.Insert(index, wordToReplaceWith);
                            }
                            // add 1 to the index so that it doesnt loop forever
                            index++;
                        }
                    }
                    sb.Append(line.Trim());
                    // and read the next line of the input file
                    line = streamReader.ReadLine();
                }
            }
            using (StreamWriter streamWriter = new StreamWriter(pathToTextFile))
            {
                // write to the new output file
                streamWriter.WriteLine(sb);
            }

            Console.WriteLine("The file {0} is writen successfull!");
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