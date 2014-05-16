//Create a class Path to hold a sequence of points in the 3D space. 
//    Create a static class PathStorage with static methods to save and load paths from a text file.
//        Use a file format of your choice.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Space3D
{
    public static class PathStorage
    {
        /// <summary>
        /// Save a path to a file with extension given by the user
        /// </summary>
        /// <param name="file">Name of the file + extension</param>
        /// <param name="path">Path that have to be saved</param>
        public static void SavePath(string file, Path path)
        {
            try
            {
                int index = 0;
                do
                {
                    // append a line to the file
                    File.AppendAllText(file, string.Format("{0}{1}", path.PathToString(index), Environment.NewLine));
                    index++;
                } while (path.PathToString(index) != null);
                // make the user happy
                Console.WriteLine("The file {0} is made! :)", file);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("File's name must be set!");
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine("Invalid arguments {0}!", argEx.Message);
            }
            catch (PathTooLongException pathLong)
            {
                Console.WriteLine("The path to the file is too long {0}!", pathLong.Message);
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine("Directory not found! {0}!", dirNotFound.Message);
            }

        }

        /// <summary>
        /// Method that will load the path from a given file!
        /// </summary>
        /// <param name="filePath">Path to the file + exctension!</param>
        /// <returns>Returns a new Path that is loaded from a file.</returns>
        public static Path LoadPath(string filePath)
        {
            Path newPath = new Path();
            try
            {
                // Read in every line in the file.
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // read a line from a file
                        int pointX;
                        int pointY;
                        int pointZ;

                        // split the row by ','
                        string[] parts = line.Split(',');
                        
                        // check if the numbers can parse
                        if (int.TryParse(parts[0], out pointX) && int.TryParse(parts[1], out pointY) && int.TryParse(parts[2], out pointZ))
                        {
                            // these 3 lines are not needed but its easyer to understand the code this way
                            pointX = int.Parse(parts[0]);
                            pointY = int.Parse(parts[1]);
                            pointZ = int.Parse(parts[2]);
                            // and add them to the path as new point;
                            newPath.AddPoint(new Point3D(pointX, pointY, pointZ));
                        }
                            // if the numbers from the file doesnt pars then someone has manipulated the file manually, or the file is not in the same format
                        else
                        {
                            Console.WriteLine("Someone messed up your file ({0})!!!", filePath);
                        }
                    }
                    // make the user happy
                    Console.WriteLine("The file {0} loaded! :)", filePath);
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Files name must be set!");
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine("Invalid arguments {0}!", argEx.Message);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file is not found - {0}!", filePath);
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("The path to the file is too long - {0}", filePath);
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine("Directory not found! {0}!", dirNotFound.Message);
            }

            // return the path
            return newPath;
        }
    }
}
