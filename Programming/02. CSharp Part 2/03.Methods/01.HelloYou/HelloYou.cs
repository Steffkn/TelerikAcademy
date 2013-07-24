// Write a method that asks the user for his name and prints “Hello, <name>” 
// (for example, “Hello, Peter!”). Write a program to test this method.

using System;
class HelloYou
{
    static void Main()
    {
        // call the method
        PrintHelloName();
    }

    public static void PrintHelloName()
    {
        Console.WriteLine("Tell me your name please: ");

        // take the name will all letters at lower case
        string name = Console.ReadLine().ToLower();

        // making the first letter of the name capital
        Console.WriteLine("Hello, {0}!", name[0].ToString().ToUpper() + name.Substring(1));
    }
}

