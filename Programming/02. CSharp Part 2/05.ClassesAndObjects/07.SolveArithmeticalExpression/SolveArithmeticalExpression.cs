//* Write a program that calculates the value of given arithmetical expression. The expression can contain the following elements only:
//Real numbers, e.g. 5, 18.33, 3.14159, 12.6
//Arithmetic operators: +, -, *, / (standard priorities)
//Mathematical functions: ln(x), sqrt(x), pow(x,y)
//Brackets (for changing the default priorities)
//    Examples:
//    (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)  ~ 10.6
//    pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)  ~ 21.22
//    Hint: Use the classical "shunting yard" algorithm and "reverse Polish notation".

// THIS WAS MADE IN CLASS AND ITS NOT MY SOLUTION 
// ADDED COMENTS, SIN and COS FUNCTIONS IN EXPRESSIONS
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

class SolveArithmeticalExpression
{
    public static List<char> operations = new List<char>() { '+', '-', '*', '/' };
    public static List<char> brackets = new List<char>() { '(', ')' };
    public static List<string> functions = new List<string>() { "pow", "sqrt", "ln", "sin", "cos" };

    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string expression = Console.ReadLine().Trim();
        Calculate(expression);
    }



    /// <summary>
    /// Method that will find and return a list of the different tokens of the expression.
    /// </summary>
    /// <param name="expression"></param>
    /// <returns>Returns a list of tokens from the expression.</returns>
    public static List<string> SeparateTokens(string expression)
    {
        var result = new List<string>();
        var number = new StringBuilder();

        //loop trough the expression
        for (int i = 0; i < expression.Length; i++)
        {
            // if "-"is found and its a part of the number
            if (expression[i] == '-' && (i == 0 || expression[i - 1] == ',' || expression[i - 1] == '('))
            {
                // add it to the number
                number.Append('-');
            }
                // if the char is digit or a dot
            else if (char.IsDigit(expression[i]) || expression[i] == '.')
            {
                // add it to the number
                number.Append(expression[i]);
            }
                // if the char is different from a digit, dot and the lenght of number is different than zero
            else if (!char.IsDigit(expression[i]) && expression[i] != '.' && number.Length != 0)
            {
                // add the number to the result, clear the number and go back one step
                result.Add(number.ToString());
                number.Clear();
                i--;
            }
                // if the char is a bracket
            else if (brackets.Contains(expression[i]))
            {
                // add it to the result
                result.Add(expression[i].ToString());
            }
                // if the char is operator
            else if (operations.Contains(expression[i]))
            {
                // add it to the result
                result.Add(expression[i].ToString());
            }
                // if the char is a comma
            else if (expression[i] == ',')
            {
                // add it to the result
                result.Add(",");
            }
                // if a string "ln" is reached
            else if (i + 1 < expression.Length && expression.Substring(i, 2).ToLower() == "ln")
            {
                // add ln to the result and move one step fordward because of the 'n' in "ln"; its already added
                result.Add("ln");
                i++;
            }
            // if a string "pow" is reached
            else if (i + 2 < expression.Length && expression.Substring(i, 3).ToLower() == "pow")
            {
                // add "pow" to the result and move two steps fordward because of the "ow" in "pow"; its already added
                result.Add("pow");
                i += 2;
            }
            // if a string "sqrt" is reached
            else if (i + 3 < expression.Length && expression.Substring(i, 4).ToLower() == "sqrt")
            {
                // add "sqrt" to the result and move three steps fordward because of the "qrt" in "sqrt"; its already added
                result.Add("sqrt");
                i += 3;
            }
            // if a string "sin" is reached
            else if (i + 2 < expression.Length && expression.Substring(i, 3).ToLower() == "sin")
            {
                // add "sin" to the result and move two steps fordward because of the "in" in "sin"; its already added
                result.Add("sin");
                i += 2;
            }
            // if a string "cos" is reached
            else if (i + 2 < expression.Length && expression.Substring(i, 3).ToLower() == "cos")
            {
                // add "cos" to the result and move two steps fordward because of the "os" in "cos"; its already added
                result.Add("cos");
                i += 2;
            }
                // else the expression is incorrect! show an error msg
            else
            {
                throw new ArgumentException("Invalid expression");
            }
        }

        // add the last number to the result; this happens when there is only 1 number left in the expression
        if (number.Length != 0)
        {
            result.Add(number.ToString());
        }

        return result;
    }

    /// <summary>
    /// Method that finds the operator's precedence.
    /// </summary>
    /// <param name="operators"></param>
    /// <returns>Returns 1 if the operator is + or - and 2 if its multiplication and division </returns>
    public static int Precedence(string operators)
    {
        if (operators == "+" || operators == "-")
        {
            return 1;
        }
        else // "*" or "/"
        {
            return 2;
        }
    }

    /// <summary>
    /// Method that exequtes reverse polish notation.
    /// </summary>
    /// <param name="tokens"></param>
    /// <returns></returns>
    public static Queue<string> ReversePolishNotation(List<string> tokens)
    {
        Stack<string> stack = new Stack<string>();
        Queue<string> queue = new Queue<string>();

        // loop through the tokens
        for (int i = 0; i < tokens.Count; i++)
        {
            var currentToken = tokens[i];
            double number;

            // if the current token is a double value
            if (double.TryParse(currentToken, out number))
            {
                // enqueue it to the queue
                queue.Enqueue(currentToken);
            }
            // if the current token is some function
            else if (functions.Contains(currentToken))
            {
                // push it to the stack
                stack.Push(currentToken);
            }
            // if the current token is a comma
            else if (currentToken == ",")
            {
                // check if there is "(" in the stack or if the stack has anything in it
                if (!stack.Contains("(") || stack.Count == 0)
                {
                    // if not trow exception
                    throw new ArgumentException("Invalid brackets or function separator");
                }
                // loop while the top element in the stack is not "("
                while (stack.Peek() != "(")
                {
                    // enqueue the top element from the stack to the queue and delete it from the stack
                    queue.Enqueue(stack.Pop());
                }
            }
            // if the current token is an operator
            else if (operations.Contains(currentToken[0]))
            {
                // loop while the stack is not empty 
                // and the top element from the stack is an operator 
                // and that operator has lower precedence than the one at the top of the stack
                while (stack.Count != 0 && operations.Contains(stack.Peek()[0]) && Precedence(currentToken) <= Precedence(stack.Peek()))
                {
                    // add the element from the stack to the queue
                    queue.Enqueue(stack.Pop());
                }
                // push that token to the stack
                stack.Push(currentToken);
            }
                // if the current token is opening bracked
            else if (currentToken == "(")
            {
                // push it to the stack
                stack.Push("(");
            }
            // if the current token is closing bracked
            else if (currentToken == ")")
            {
                // if the stack doesnt have an opening bracked or its empty throw exception
                if (!stack.Contains("(") || stack.Count == 0)
                {
                    throw new ArgumentException("Invalid brackets position");
                }
                // while the current token is not opening bracked
                while (stack.Peek() != "(")
                {
                    // add the element from the stack to the queue
                    queue.Enqueue(stack.Pop());
                }
                // remove the opening bracked
                stack.Pop();

                // if the stack is not empty and the top element is a function
                if (stack.Count != 0 && functions.Contains(stack.Peek()))
                {
                    // add the function from the stack to the queue and delete it from the stack
                    queue.Enqueue(stack.Pop());
                }
            }
        }

        // while the stack is not empty
        while (stack.Count != 0)
        {
            // if a bracket is found throw exception
            if (brackets.Contains(stack.Peek()[0]))
            {
                throw new ArgumentException("Invalid brackets position");
            }
            // add all elements left in the stack to the queue
            queue.Enqueue(stack.Pop());
        }

        // return the queue
        return queue;
    }



    public static double GetResultFromRPN(Queue<string> queue)
    {
        Stack<double> stack = new Stack<double>();

        // while the queue of numbers and operators is not empty
        while (queue.Count != 0)
        {
            string currentToken = queue.Dequeue();
            double number;

            // if the current token from the queue is a double var
            if (double.TryParse(currentToken, out number))
            {
                // push it to the stack
                stack.Push(number);
            }
                // if the token is an operator or a function
            else if (operations.Contains(currentToken[0]) || functions.Contains(currentToken))
            {
                // if its a plus
                if (currentToken == "+")
                {
                    // and if there are less than two elements in the stack throw exception
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    // add first 2 elements in the stack and push the result to the stack
                    stack.Push(firstValue + secondValue);
                }
                // if its a minus
                else if (currentToken == "-")
                {
                    // and if there are less than two elements in the stack throw exception
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    // substract first 2 elements in the stack and push the result to the stack
                    stack.Push(secondValue - firstValue);
                }
                else if (currentToken == "*")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();
                    // multyply first 2 elements in the stack and push the result to the stack
                    stack.Push(secondValue * firstValue);
                }
                else if (currentToken == "/")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    // divide first 2 elements in the stack and push the result to the stack
                    stack.Push(secondValue / firstValue);
                }
                    // if the token is pow function
                else if (currentToken == "pow")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    // pow the second value and add it to the stack
                    stack.Push(Math.Pow(secondValue, firstValue));
                }
                // if the token is sqrt function
                else if (currentToken == "sqrt")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double value = stack.Pop();
                    // make sqrt with the first element in the stack and push it to the stack
                    stack.Push(Math.Sqrt(value));
                }
                    // added sin
                else if (currentToken == "sin")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double value = stack.Pop();
                    // calc sin with the first element in the stack and push it to the stack
                    stack.Push(Math.Sin(value));
                }
                    // added cos
                else if (currentToken == "cos")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double value = stack.Pop();

                    // calc cos with the first element in the stack and push it to the stack
                    stack.Push(Math.Cos(value));
                }
                else if (currentToken == "ln")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double value = stack.Pop();

                    // make ln with the first element in the stack and push it to the stack
                    stack.Push(Math.Log(value));
                }
            }
        }
        // return the end result of the expression
        if (stack.Count == 1)
        {
            return stack.Pop();
        }
        else
        {
            // or trow exception if there is more than 1 elements in the stack
            throw new ArgumentException("Invalid expression");
        }
    }


    /// <summary>
    /// Method that calculates the expreseion
    /// </summary>
    /// <param name="expression">Given expresion</param>
    public static void Calculate(string expression)
    {
        // while the user doesnt type end
        while (expression.ToLower() != "end")
        {
            try
            {
                // trim the spaces from the expression
                expression = expression.Replace(" ", string.Empty);

                // find the separated tokens
                var separatedTokens = SeparateTokens(expression);

                // find the result of the reverse polish notation
                var reversePolishNotation = ReversePolishNotation(separatedTokens);

                // find the final result 
                var finalResult = GetResultFromRPN(reversePolishNotation);

                // and print to the console
                Console.WriteLine(finalResult);
            }
                // if error is found throl exeption
            catch (ArgumentException exeption)
            {
                Console.WriteLine(exeption.Message);
            }

            // take next expression
            expression = Console.ReadLine().Trim();
        }
    }


}

