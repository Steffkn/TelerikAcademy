//Write a program to check if in a given expression the brackets are put correctly.
//Example of correct expression: ((a+b)/5-d).
//Example of incorrect expression: )(a+b)).

using System;
using System.Collections.Generic;
class CheckTheBrackets
{
    static void Main()
    {
        Console.Write("Enter the math expression: ");
        string expression = Console.ReadLine();
        Stack<char> bracketsStack = new Stack<char>();

        // loop trough the elements of the string
        for (int charIndex = 0; charIndex < expression.Length; charIndex++)
        {
            // if a openning bracke is found
            if (expression[charIndex] == '(')
            {
                // push that bracket to the stack
                bracketsStack.Push(expression[charIndex]);
            }
                // if closing bracket is found
            else if (expression[charIndex] == ')')
            {
                // if the stack is empty then the expression is wrong;show the msg and break the loop
                if (bracketsStack.Count == 0)
                {
                    // adding the last char so that the stack wont be empty
                    bracketsStack.Push(expression[charIndex]);
                    // break the loop with not empty stack -> will counse the wrong brackets message 
                    break;
                }
                // take out a ) bracket
                bracketsStack.Pop();
            }
        }

        // if the stack is empty then the expression is correct
        if (bracketsStack.Count == 0)
        {
            Console.WriteLine("The expression has well placed brackets!");
        }
            // else the expression is wrong or the brackets are missplaces
        else
        {
            Console.WriteLine("Wrong brackets position!");
        }
    }
}

