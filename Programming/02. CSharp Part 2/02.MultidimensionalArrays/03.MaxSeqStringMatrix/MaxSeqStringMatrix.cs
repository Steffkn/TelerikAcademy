// We are given a matrix of strings of size N x M.
// Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal.
// Write a program that finds the longest sequence of equal strings in the matrix. 
using System;
class MaxSeqStringMatrix
{
    static void Main()
    {
        //string[,] stringArray = { 
        //                       {"ha",   "na",   "pp",   "ss"},
        //                       {"lol",  "lol",   "ss",  "na"},
        //                       {"qq",   "ss",   "na",   "pp"},
        //                       {"ss",   "na",   "dd",   "ss"},
        //                       };
        string[,] stringArray = { 
                               {"ha",   "na",   "pp",   "ss"},
                               {"lol",  "ha",   "pp",   "na"},
                               {"qq",   "ss",   "ha",   "pp"},
                               {"ss",   "na",   "dd",   "ha"},
                               };

        string longestSequence = "";
        int maxLenght = 0;
        for (int row = 0; row < stringArray.GetLength(0); row++)
        {
            for (int col = 0; col < stringArray.GetLength(1); col++)
            {
                

                // declare tempString to be equal of the current element of the array
                string tempString = tempString = stringArray[row, col];
                // declare tempCol to hold the number of the col of the next element
                int tempCol = col + 1;
                // counter for the sequence
                int count = 1;
                //searching right of the element stringArray[row,col]
                // if we are in the array and next element (to the right) is equal to current one
                while (tempCol < stringArray.GetLength(1) && stringArray[row,col].Equals(stringArray[row,tempCol]))
                {
                    // adding the element to tempString
                    tempString += ", " + stringArray[row, tempCol];
                    // going at next col
                    tempCol++;
                    // add one more element found to the counter
                    count++;
                }
                // if the sequence is bigger
                if (count > maxLenght)
                {
                    longestSequence = tempString;
                    maxLenght = count;
                }

                // refreshing tempString to be equal of the current element of the array
                tempString = stringArray[row,col];

                // tempRow holds the row of next element
                int tempRow = row + 1;
                count = 1;
                // searching down of the element stringArray[row,col]
                // if we are in the array and next element (down) is equal to current one
                while (tempRow < stringArray.GetLength(0) && stringArray[row, col].Equals(stringArray[tempRow, col]))
                {
                    tempString += ", " + stringArray[tempRow, col];
                    tempRow++;
                    count++;
                }
                if (count > maxLenght)
                {
                    longestSequence = tempString;
                    maxLenght = count;
                }
                // refreshing tempString to be equal of the current element of the array
                tempString = stringArray[row,col];

                tempRow = row + 1;
                tempCol = col + 1;
                count = 1;

                // searching down and right of the element stringArray[row,col]
                // if we are in the array and next element (down and to the right) is equal to current one
                while (tempRow < stringArray.GetLength(0) &&
                    tempCol < stringArray.GetLength(1) &&
                    stringArray[row, col].Equals(stringArray[tempRow, tempCol]))
                {
                    tempString += ", " + stringArray[tempRow, tempCol];
                    tempRow++;
                    tempCol++;
                    count++;
                }
                if (count > maxLenght)
                {
                    longestSequence = tempString;
                    maxLenght = count;
                }

                // refreshing tempString to be equal of the current element of the array
                tempString = stringArray[row, col];

                tempRow = row+1;
                tempCol = col-1;
                count = 1;
                // searching down and left of the element stringArray[row,col]
                // if we are in the array and next element (down and to the left) is equal to current one
                while (tempRow < stringArray.GetLength(0) 
                    && tempCol >= 0 
                    && stringArray[row, col].Equals(stringArray[tempRow, tempCol]))
                {
                    tempString += ", " + stringArray[tempRow, tempCol];
                    tempRow++;
                    tempCol--;
                    count++;
                }
                if (count > maxLenght)
                {
                    longestSequence = tempString;
                    maxLenght = count;
                }

            }
        }
        // printing the result on the console
        Console.WriteLine("Max lengh: {0}", maxLenght);
        Console.WriteLine("-> {0}",longestSequence);

    }
}