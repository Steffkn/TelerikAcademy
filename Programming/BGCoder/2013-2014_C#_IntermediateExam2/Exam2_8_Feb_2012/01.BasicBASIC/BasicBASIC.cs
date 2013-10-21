using System;
using System.Collections.Generic;
using System.IO;

// no comments.. i doubt that it can be understood :)
class BasicBASIC
{
    static int v = 0, w = 0, x = 0, y = 0, z = 0;
        
    static void Main()
    {
        List<string> comands = new List<string>();
        string commandLine = string.Empty;
        while ((commandLine = Console.ReadLine()) != "RUN")
        {
            comands.Add(commandLine.Replace(" ", string.Empty));
        }

        string[,] lines = new string[comands.Count, 2];

        for (int index = 0; index < comands.Count; index++)
        {
            int number = 0;
            for (int numberIndex = 0; numberIndex < comands[index].Length; numberIndex++)
            {
                if (int.TryParse(comands[index][numberIndex].ToString(), out number))
                {
                    lines[index, 0] += comands[index][numberIndex];
                }
                else
                {
                    lines[index, 1] = comands[index].Substring(numberIndex);
                    break;
                }
            }
        }

        for (int i = 0; i < lines.GetLength(0); i++)
        {
            if (lines[i, 1].Contains("IF"))
            {
                int conditionStart = lines[i, 1].IndexOf("IF") + 2;
                int conditionEnd = lines[i, 1].IndexOf("THEN");

                string firstArgument = "";
                while (lines[i, 1][conditionStart] != '>' && lines[i, 1][conditionStart] != '=' && lines[i, 1][conditionStart] != '<')
                {
                    firstArgument = firstArgument + lines[i, 1][conditionStart];
                    conditionStart++;
                } 
                string condition = "";
                while (lines[i, 1][conditionStart] == '>' || lines[i, 1][conditionStart] == '=' || lines[i, 1][conditionStart] == '<')
                {
                    condition = condition + lines[i, 1][conditionStart];
                    conditionStart++;
                }

                string secondArgument = "";
                
                while (conditionStart < conditionEnd)
                {
                    secondArgument = secondArgument + lines[i, 1][conditionStart];
                    conditionStart++;
                }

                if (CheckCondition(firstArgument, condition, secondArgument))
                {
                    if (lines[i, 1][conditionEnd + 4] == 'V')
                    {
                        v = (int)CalcCondition(lines[i, 1].Substring(conditionEnd + 4));
                    }
                    else if (lines[i, 1][conditionEnd + 4] == 'W')
                    {
                        w = (int)CalcCondition(lines[i, 1].Substring(conditionEnd + 4));
                    }
                    else if (lines[i, 1][conditionEnd + 4] == 'X')
                    {
                        x = (int)CalcCondition(lines[i, 1].Substring(conditionEnd + 4));
                    }
                    else if (lines[i, 1][conditionEnd + 4] == 'Y')
                    {
                        y = (int)CalcCondition(lines[i, 1].Substring(conditionEnd + 4));
                    }
                    else if (lines[i, 1][conditionEnd + 4] == 'Z')
                    {
                        z = (int)CalcCondition(lines[i, 1].Substring(conditionEnd + 4));
                    }
                        //GOTO
                    else if (lines[i, 1][conditionEnd + 4] == 'G')
                    {
                            int line = FindNumber(lines[i, 1].Substring(conditionEnd + 8));

                            for (int lineIndex = 0; lineIndex < lines.GetLength(0); lineIndex++)
                            {
                                if (int.Parse(lines[lineIndex,0]) == line)
                                {
                                    i = lineIndex - 1;
                                    break;
                                }
                            }
                    }
                    //PRINT
                    else if (lines[i, 1][conditionEnd + 4] == 'P')
                    {
                            if (lines[i, 1][conditionEnd + 9] == 'V')
                            {
                                Console.WriteLine(v);
                            }
                            else if (lines[i, 1][conditionEnd + 9] == 'W')
                            {
                                Console.WriteLine(w);
                            }
                            else if (lines[i, 1][conditionEnd + 9] == 'X')
                            {
                                Console.WriteLine(x);
                            }
                            else if (lines[i, 1][conditionEnd + 9] == 'Y')
                            {
                                Console.WriteLine(y);
                            }
                            else if (lines[i, 1][conditionEnd + 9] == 'Z')
                            {
                                Console.WriteLine(z);
                            }
                    }
                        //CLS
                    else if (lines[i, 1][conditionEnd + 4] == 'C')
                    {
                        Console.Clear();
                    }
                        //STOP
                    else if (lines[i, 1][conditionEnd + 4] == 'S')
                    {
                        return;
                    }
                  
                }

            }
            else if (lines[i, 1].Contains("STOP"))
            {
                return;
            }
            else if (lines[i, 1].Contains("CLS"))
            {
                Console.Clear();
            }
            else if (lines[i, 1].Contains("PRINT"))
            {
                if (lines[i, 1][5] == 'V')
                {
                    Console.WriteLine(v);
                }
                else if (lines[i, 1][5] == 'W')
                {
                    Console.WriteLine(w);
                }
                else if (lines[i, 1][5] == 'X')
                {
                    Console.WriteLine(x);
                }
                else if (lines[i, 1][5] == 'Y')
                {
                    Console.WriteLine(y);
                }
                else if (lines[i, 1][5] == 'Z')
                {
                    Console.WriteLine(z);
                }
                else
                {
                    Console.WriteLine("Nepoznato chislo? {0}", lines[i, 1][5]);
                }
            }
            else if (lines[i, 1][0] == 'V' ||lines[i, 1][0] == 'W' ||lines[i, 1][0] == 'X' ||lines[i, 1][0] == 'Y' ||lines[i, 1][0] == 'Z')
            {
                
                switch (lines[i, 1][0].ToString())
                {
                    case "V":
                        v = (int)CalcCondition(lines[i, 1]);
                        break;
                    case "W":
                        w = (int)CalcCondition(lines[i, 1]);
                        break;
                    case "X":
                        x = (int)CalcCondition(lines[i, 1]);
                        break;
                    case "Y":
                        y = (int)CalcCondition(lines[i, 1]);
                        break;
                    case "Z":
                        z = (int)CalcCondition(lines[i, 1]);
                        break;
                }
                //Console.WriteLine("{0}",CalcCondition(firstArgument,condition,secondArgument));
            }
            
            //Console.WriteLine(lines[i, 0]);
            //Console.WriteLine(lines[i, 1]);
        }
    }

    public static bool CheckCondition(string firstArgument, string condition, string secondArgument)
    {
        int? firstArgumentInt = null;
        int? secondArgumentInt = null;
        int temp;

        if (int.TryParse(firstArgument, out temp))
        {
            firstArgumentInt = temp;
        }
        else
        {
            switch (firstArgument)
            {
                case "V":
                    firstArgumentInt = v;
                    break;
                case "W":
                    firstArgumentInt = w;
                    break;
                case "X":
                    firstArgumentInt = x;
                    break;
                case "Y":
                    firstArgumentInt = y;
                    break;
                case "Z":
                    firstArgumentInt = z;
                    break;
            }
        }
        if (int.TryParse(secondArgument, out temp))
        {
            secondArgumentInt = temp;
        }
        else
        {
            switch (secondArgument)
            {
                case "V":
                    secondArgumentInt = v;
                    break;
                case "W":
                    secondArgumentInt = w;
                    break;
                case "X":
                    secondArgumentInt = x;
                    break;
                case "Y":
                    secondArgumentInt = y;
                    break;
                case "Z":
                    secondArgumentInt = z;
                    break;
            }
        }
        bool result = false;
        for (int conditionIndex = 0; conditionIndex < condition.Length; conditionIndex++)
        {
            if (condition[conditionIndex] == '<')
            {
                result = firstArgumentInt < secondArgumentInt;
            }
            if (condition[conditionIndex] == '=')
            {
                result = firstArgumentInt == secondArgumentInt;
            }
            if (condition[conditionIndex] == '>')
            {
                result = firstArgumentInt > secondArgumentInt;
            }
        }

        return result;
    }

    public static int? CalcCondition(string line)
    {
        int? firstArgumentInt = null;
        int? secondArgumentInt = null;
        int? result = null; 
        int temp;
        int conditionStart = 2;
        int conditionEnd = line.Length;

       
        string firstArgument = "";
        while ( conditionStart != conditionEnd && line[conditionStart] != '+' && line[conditionStart] != '-' && line[conditionStart] != '*' && line[conditionStart] != '/' )
        {
            firstArgument = firstArgument + line[conditionStart];
            conditionStart++;
        }
        string condition = "";
        while (conditionStart != conditionEnd && (line[conditionStart] == '+' || line[conditionStart] == '-' || line[conditionStart] == '*' || line[conditionStart] == '/'))
        {
            condition = condition + line[conditionStart];
            conditionStart++;
        }

        string secondArgument = "";

        while (conditionStart < conditionEnd)
        {
            secondArgument = secondArgument + line[conditionStart];
            conditionStart++;
        }

        if (int.TryParse(firstArgument, out temp))
        {
            firstArgumentInt = temp;
        }
        else
        {
            switch (firstArgument)
            {
                case "V":
                    firstArgumentInt = v;
                    break;
                case "W":
                    firstArgumentInt = w;
                    break;
                case "X":
                    firstArgumentInt = x;
                    break;
                case "Y":
                    firstArgumentInt = y;
                    break;
                case "Z":
                    firstArgumentInt = z;
                    break;
                //default:
                //    return int.Parse(condition + secondArgument);
            }
        }
        if (int.TryParse(secondArgument, out temp))
        {
            secondArgumentInt = temp;
        }
        else
        {
            switch (secondArgument)
            {
                case "V":
                    secondArgumentInt = v;
                    break;
                case "W":
                    secondArgumentInt = w;
                    break;
                case "X":
                    secondArgumentInt = x;
                    break;
                case "Y":
                    secondArgumentInt = y;
                    break;
                case "Z":
                    secondArgumentInt = z;
                    break;
                //default:
                //    return int.Parse(firstArgument);
            }
        }
        if (secondArgumentInt == null)
        {
            return firstArgumentInt;
        }
        else if (firstArgumentInt == null)
        {
            if (condition == "-")
            {
                secondArgumentInt *= -1;
            }
            return secondArgumentInt;
        }
        else
        {
            for (int conditionIndex = 0; conditionIndex < condition.Length; conditionIndex++)
            {
                if (condition[conditionIndex] == '+')
                {
                    result = (firstArgumentInt + secondArgumentInt);
                }
                else if (condition[conditionIndex] == '-')
                {
                    result = (firstArgumentInt - secondArgumentInt);
                }
            }
        }


        return result;
    }

    public static int FindNumber(string line)
    {
        int number = 0;
        int temp;
        for (int numberIndex = 0; numberIndex < line.Length; numberIndex++)
        {
            if (int.TryParse(line[numberIndex].ToString(), out temp))
            {
                number = number * 10 + temp;
            }
            else
            {
                break;
            }
        }

        return number;
    }

}

