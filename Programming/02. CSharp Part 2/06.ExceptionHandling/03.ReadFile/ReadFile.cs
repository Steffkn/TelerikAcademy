using System;
using System.IO;
class ReadFile
{
    static void Main()
    {

        try
        {
            Console.WriteLine("Enter the full path of the file you want to read or just the file name if its in this directory");
            string filePathName = Console.ReadLine();

            Console.WriteLine();

            // print the name of the file with some dashes before and after is path
            Console.WriteLine("{0} File: {1} {2}", new String('-', 16), filePathName, new String('-', 16));

            // read the file and print it on the console
            Console.WriteLine(File.ReadAllText(filePathName));

            // print End of file with name of the file and some dashes before and after is path
            Console.WriteLine("{0} End of file: {1} {2}", new String('-', 16), filePathName, new String('-',16));

        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("File path is wrong!");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("File path cant be empty!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found!");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("File path is not found!");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("File path is too long!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You dont have permission to access that file (unauthorized)!");
        }
        catch (System.Security.SecurityException)
        {
            Console.WriteLine("You dont have permission to access that file (security reasons)!");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Problem with the mothod ReadAllText()");
        }
        catch (IOException)
        {
            Console.WriteLine("File could not be used (I/O error)!");
        }
        finally
        {
            Console.WriteLine("Thank you for using this application!");
        }
    }
}