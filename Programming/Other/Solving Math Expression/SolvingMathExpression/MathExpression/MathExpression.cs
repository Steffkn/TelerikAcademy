// http://en.wikipedia.org/wiki/Shunting-yard_algorithm

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

class MathExpression
{
    //public static string TrimInput(string input)
    //{
    //    StringBuilder result = new StringBuilder();

    //    for (int i = 0; i < input.Length; i++)
    //    {
    //        if (input[i] != ' ')
    //        {
    //            result
    //        }
    //    }
    //}


    public static List<char> arithmeticOperations = new List<char>() { '+', '-', '*', '/' };
    public static List<char> brackets = new List<char>() { '(', ')' };
    public static List<string> functions = new List<string>() { "pow", "sqrt", "ln" };

    public static List<string> SeparateTokens(string input)
    {
        var result = new List<string>();

        var number = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '-' && (i == 0 || input[i - 1] == ',' || input[i - 1] == '('))
            {
                number.Append('-');
            }
            else if (char.IsDigit(input[i]) || input[i] == '.')
            {
                number.Append(input[i]);
            }
            else if (!char.IsDigit(input[i]) && input[i] == '.' && number.Length != 0)
            {
                number.Append(input[i]);
                i--;
                number.Clear();
            }
            // add funcions here
            if (brackets.Contains(input[i]))
            {
                result.Add(input[i].ToString());
            }
            else if (arithmeticOperations.Contains(input[i]))
            {
                result.Add(input[i].ToString());
            }
            else if (i + 1 < input.Length && input.Substring(i, 2).ToLower() == "ln")
            {
                result.Add("ln");
                i++;
            }
            else if (i + 2 < input.Length && input.Substring(i, 3).ToLower() == "pow")
            {
                result.Add("pow");
                i += 2;
            }
            else if (i + 2 < input.Length && input.Substring(i, 3).ToLower() == "sqrt")
            {
                result.Add("sqrt");
                i += 3;
            }
            else
            {
                throw new ArgumentException("Invalid expression!");
            }
        }

        if (number.Length != 0)
        {
            result.Add(number.ToString());
        }

        return result;
    }

    // other algoritm
    public static int Precedence(string arithmeticOperator)
    {
        if (arithmeticOperator[0] == '+' || arithmeticOperator[0] == '-')
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }


    public static Queue<string> ConvertToReversePolishNotation(List<string> tokens)
    {
        Stack<string> stack = new Stack<string>();
        Queue<string> queue = new Queue<string>();

        for (int i = 0; i < tokens.Count; i++)
        {
            var currentToken = tokens[i];
            double number;

            if (double.TryParse(currentToken, out number))
            {
                queue.Enqueue(currentToken);
            }
            else if (functions.Contains(currentToken))
            {
                stack.Push(currentToken);
            }
            else if (currentToken == ",")
            {
                if (!stack.Contains("(") || stack.Count == 0)
                {
                    throw new ArgumentException("Invalid bracked or function separator!");
                }

                // need to pop the "("
                while (stack.Peek() != "(")
                {
                    queue.Enqueue(stack.Pop());
                }
            }
            else if (arithmeticOperations.Contains(currentToken[0]))
            {
                while (stack.Count != 0 && arithmeticOperations.Contains(stack.Peek()[0]) && Precedence(currentToken) <= Precedence(stack.Peek()))
                {
                    queue.Enqueue(stack.Pop());
                }

                stack.Push(currentToken);
            }
            else if (currentToken == "(")
            {
                stack.Push("(");
            }
            else if (currentToken == ")")
            {
                if (!stack.Contains("(") || stack.Count == 0)
                {
                    throw new ArgumentException("Invalid bracked position!");
                }
                while (stack.Peek() != "(")
                {
                    queue.Enqueue(stack.Pop());
                }
                stack.Pop();

                if (stack.Count != 0 && functions.Contains(stack.Peek()))
                {
                    queue.Enqueue(stack.Pop());
                }

                // dali e taka

                queue.Enqueue(stack.Peek());
            }

        }

        while (stack.Count != 0)
        {
            if (brackets.Contains(stack.Peek()[0]))
            {
                throw new ArgumentException("Invalid bracked position!");
            }
        }
        return queue;
    }

    public static double GetResultFromRPN(Queue<string> queue)
    {
        Stack<double> stack = new Stack<double>();
        while (queue.Count != 0)
        {
            string currentToken = queue.Dequeue();

            double number;

            if (double.TryParse(currentToken, out number))
            {
                stack.Push(number);
            }
            else if(arithmeticOperations.Contains(currentToken[0]) || functions.Contains(currentToken))
            {
                if (currentToken == "+")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(firstValue + secondValue);
                }
                else if (currentToken == "+")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(secondValue - firstValue);
                }
                else if (currentToken == "*")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(firstValue * secondValue);
                }
                else if (currentToken == "+")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(secondValue / firstValue);
                }

                else if (currentToken == "pow")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(Math.Pow(secondValue, firstValue));
                }

                else if (currentToken == "sqrt")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double value = stack.Pop();

                    stack.Push(Math.Sqrt(value));
                }
                else if (currentToken == "ln")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double value = stack.Pop();

                    stack.Push(Math.Log(value));
                }
                
            }

            if (stack.Count == 1)
            {
                return stack.Pop();
            }
            else
            {
                throw new ArgumentException("Invalid algorithmic expression!");
            }
        }


        return 1;
    }


    //1 + 3 + 5 + (ln(20) - 2)
    public static void PutInvariantCulture()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    }

    static void Main()
    {

        PutInvariantCulture();


        string input = Console.ReadLine().Trim();
        string trimmedInput = input.Replace(" ", string.Empty);

        var separatedTockens = SeparateTokens(trimmedInput);

        var reversePolishNotation = ConvertToReversePolishNotation(separatedTockens);

        var finalResult = GetResultFromRPN(reversePolishNotation);
    }
}

