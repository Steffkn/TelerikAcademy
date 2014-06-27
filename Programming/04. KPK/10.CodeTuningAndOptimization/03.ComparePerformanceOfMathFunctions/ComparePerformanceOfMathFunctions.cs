using System;
using System.Diagnostics;
using System.Linq;

namespace _03.ComparePerformanceOfMathFunctions
{
    class ComparePerformanceOfMathFunctions
    {

        const int IterationCount = (int)1.6E7;

        static readonly Stopwatch stopwatch = new Stopwatch();

        static void DisplayExecutionTime(string title, Action action)
        {
            Console.Write("{0, -20}", title);
            stopwatch.Restart();

            action();

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        static void Main()
        {
            unchecked
            {
                {
                    DisplayExecutionTime("Square root float", () =>
                    {
                        for (float i = 1; i < IterationCount; i++)
                            Math.Sqrt(i);
                    });

                    DisplayExecutionTime("Square root double", () =>
                    {
                        for (double i = 1; i < IterationCount; i++)
                            Math.Sqrt(i);
                    });
                    DisplayExecutionTime("Square root double", () =>
                    {
                        for (double i = 1; i < IterationCount; i++)
                            Math.Sqrt(i);
                    });
                }

                Console.WriteLine();

                {
                    DisplayExecutionTime("Ln float", () =>
                    {
                        for (float i = 1; i < IterationCount; i++)
                            Math.Log(i);
                    });

                    DisplayExecutionTime("Ln double", () =>
                    {
                        for (double i = 1; i < IterationCount; i++)
                            Math.Log(i);
                    });
                }

                Console.WriteLine();

                {
                    DisplayExecutionTime("Sin float", () =>
                    {
                        for (float i = 1; i < IterationCount; i++)
                            Math.Sin(i);
                    });

                    DisplayExecutionTime("Sin double", () =>
                    {
                        for (double i = 1; i < IterationCount; i++)
                            Math.Sin(i);
                    });
                }
            }
        }
    }
}
