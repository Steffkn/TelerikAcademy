namespace _01.BasicBASIC
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static int V = 0, W = 0, X = 0, Y = 0, Z = 0;
        static IList<string> output;

        static void Main()
        {
            output = new List<string>();
            var commands = ReadInput();
            //PrintAllCommands(commands);

            for (int i = 0; i < commands.Count; i++)
            {
                if (commands[i] != null)
                {
                    var result = ExecuteCMD(commands[i]);
                    if (result > 0)
                    {
                        i = result - 1;
                    }
                    else if (result == -1)
                    {
                        break;
                    }
                }
            }
        }

        private static int ExecuteCMD(string inputCMD)
        {
            if (inputCMD.Contains("PRINT"))
            {
                char variable = inputCMD.Substring(inputCMD.IndexOf("PRINT") + 5)[0];

                if (variable == 'X')
                {
                    output.Add(X.ToString());
                }
                else if (variable == 'Y')
                {
                    output.Add(Y.ToString());
                }
                else if (variable == 'Z')
                {
                    output.Add(Z.ToString());
                }
                else if (variable == 'V')
                {
                    output.Add(V.ToString());
                }
                else if (variable == 'W')
                {
                    output.Add(W.ToString());
                }
            }
            else if (inputCMD.Contains("IF"))
            {
                bool ifStatementResult = false;
                var ifStatement = inputCMD.Split(new string[] { "IF", "THEN" }, StringSplitOptions.RemoveEmptyEntries);
                var condition = ifStatement[0];
                var command = ifStatement[1];

                if (condition.Contains(">"))
                {
                    var conditionVariables = condition.Split(new char[] { '>' });
                    int leftPart = GetValue(conditionVariables[0]);
                    int rightPart = GetValue(conditionVariables[1]);

                    ifStatementResult = leftPart > rightPart;
                }
                else if (condition.Contains("<"))
                {
                    var conditionVariables = condition.Split(new char[] { '<' });
                    int leftPart = GetValue(conditionVariables[0]);
                    int rightPart = GetValue(conditionVariables[1]);

                    ifStatementResult = leftPart < rightPart;
                }
                else
                {
                    var conditionVariables = condition.Split(new char[] { '=' });
                    int leftPart = GetValue(conditionVariables[0]);
                    int rightPart = GetValue(conditionVariables[1]);

                    ifStatementResult = leftPart == rightPart;
                }

                if (ifStatementResult)
                {
                    return ExecuteCMD(command);
                }
            }
            else if (inputCMD.Contains("="))
            {
                // 1 V = -5
                // 3 X = Y
                // 4 W = X - Y
                // 5 Z = Z + 1

                string operation = inputCMD;

                var varToAssignTo = operation[0];

                int valueToAssign = 0;
                var cmd = operation.Split(new char[] { '=' })[1];

                if (int.TryParse(cmd, out valueToAssign))
                {
                    AssignValueToVar(varToAssignTo, valueToAssign);
                }
                else
                {
                    if (cmd.Contains("-"))
                    {
                        var expression = cmd.Split(new char[] { '-' });
                        int leftPart = GetValue(expression[0]);
                        int rightPart = GetValue(expression[1]);

                        AssignValueToVar(varToAssignTo, (leftPart) - (rightPart));
                    }
                    else if (cmd.Contains("+"))
                    {
                        var expression = cmd.Split(new char[] { '+' });
                        int leftPart = GetValue(expression[0]);
                        int rightPart = GetValue(expression[1]);

                        AssignValueToVar(varToAssignTo, (leftPart) + (rightPart));
                    }
                    else
                    {
                        AssignValueToVar(varToAssignTo, GetValue(cmd));
                    }
                }
            }
            else if (inputCMD.Contains("GOTO"))
            {
                var lineNumber = inputCMD.Substring(4);
                return Convert.ToInt32(lineNumber);
            }
            else if (inputCMD.Contains("CLS"))
            {
                output = new List<string>();
            }
            else if (inputCMD.Contains("STOP") || inputCMD.Contains("RUN"))
            {
                foreach (var outLine in output)
                {
                    Console.WriteLine(outLine);
                }

                return -1;
            }
            else
            {
                Console.WriteLine("Unknown command! {0}", inputCMD);
                return -1;
            }

            return 0;
        }

        private static int GetValue(string variable)
        {
            int valueInt = 0;

            if (!int.TryParse(variable, out valueInt))
            {
                valueInt = GetValueFromVar(variable[0]);
            }

            return valueInt;
        }

        private static int GetValueFromVar(char variable)
        {
            if (variable == 'X')
            {
                return X;
            }
            else if (variable == 'Y')
            {
                return Y;
            }
            else if (variable == 'Z')
            {
                return Z;
            }
            else if (variable == 'V')
            {
                return V;
            }
            else if (variable == 'W')
            {
                return W;
            }
            else
            {
                return 0;
            }
        }

        private static void AssignValueToVar(char variable, int valueToAssign)
        {
            if (variable == 'X')
            {
                X = valueToAssign;
            }
            else if (variable == 'Y')
            {
                Y = valueToAssign;
            }
            else if (variable == 'Z')
            {
                Z = valueToAssign;
            }
            else if (variable == 'V')
            {
                V = valueToAssign;
            }
            else
            {
                W = valueToAssign;
            }
        }

        private static void PrintAllCommands(IList<string> output)
        {
            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }

        private static IList<string> ReadInput()
        {
            var commands = new List<string>(new string[10005]);
            string cmdLine = Console.ReadLine().Trim();

            while (cmdLine != "RUN")
            {

                var firstSpace = cmdLine.IndexOf(' ');

                if (firstSpace != -1)
                {
                    var cmdLineNumber = cmdLine.Substring(0, firstSpace);
                    var cmdLineValue = cmdLine.Substring(firstSpace);

                    cmdLineValue = cmdLineValue.Replace(" ", string.Empty);

                    int index = 0;
                    int.TryParse(cmdLineNumber, out index);
                    commands[index] = cmdLineValue;
                }
                else
                {
                    commands.Add(cmdLine);
                }

                cmdLine = Console.ReadLine();

            }

            commands.Add(cmdLine);
            return commands;
        }
    }
}
