using System;
using System.Diagnostics;
using System.Linq;

namespace _02.ComparePerformanceOfOperations
{
    class ComparePerformanceOfOperations
    {

        const int IterationCount = (int)1E8;

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
            // Decimal is always checked
            unchecked
            {
                {
                    DisplayExecutionTime("Add int", () =>
                    {
                        int count = 0;

                        for (int i = 1; i < IterationCount; i++)
                            count += i;
                    });

                    DisplayExecutionTime("Add long", () =>
                    {
                        long count = 0;

                        for (int i = 1; i < IterationCount; i++)
                            count += i;
                    });

                    DisplayExecutionTime("Add float", () =>
                    {
                        float count = 0;

                        for (int i = 1; i < IterationCount; i++)
                            count += i;
                    });

                    DisplayExecutionTime("Add double", () =>
                    {
                        double count = 0;

                        for (int i = 1; i < IterationCount; i++)
                            count += i;
                    });

                    DisplayExecutionTime("Add decimal", () =>
                    {
                        decimal count = 0;

                        for (int i = 1; i < IterationCount; i++)
                            count += i;
                    });
                }

                Console.WriteLine();

                {
                    DisplayExecutionTime("Subract int", () =>
                    {
                        int count = 0;

                        for (int i = 1; i < IterationCount; i++)
                            count--;
                    });

                    DisplayExecutionTime("Subract long", () =>
                    {
                        long count = 0;

                        for (int i = 1; i < IterationCount; i++)
                            count--;
                    });

                    DisplayExecutionTime("Subract float", () =>
                    {
                        float count = 0;

                        for (int i = 1; i < IterationCount; i++)
                            count--;
                    });

                    DisplayExecutionTime("Subract double", () =>
                    {
                        double count = 0;

                        for (int i = 1; i < IterationCount; i++)
                            count--;
                    });

                    DisplayExecutionTime("Subract decimal", () =>
                    {
                        decimal count = 0;

                        for (int i = 1; i < IterationCount; i++)
                            count--;
                    });
                }

                Console.WriteLine();

                {
                    DisplayExecutionTime("Increment int", () =>
                    {
                        int count = 0;

                        for (int i = 1; i < IterationCount; i++)
                            count++;
                    });

                    DisplayExecutionTime("Increment long", () =>
                    {
                        long count = 0;

                        for (int i = 1; i < IterationCount; i++)
                            count++;
                    });

                    DisplayExecutionTime("Increment float", () =>
                    {
                        float count = 0;

                        for (int i = 1; i < IterationCount; i++)
                            count++;
                    });

                    DisplayExecutionTime("Increment double", () =>
                    {
                        double count = 0;

                        for (int i = 1; i < IterationCount; i++)
                            count++;
                    });

                    DisplayExecutionTime("Increment decimal", () =>
                    {
                        decimal count = 0;

                        for (int i = 1; i < IterationCount; i++)
                            count++;
                    });
                }

                Console.WriteLine();

                {
                    DisplayExecutionTime("Multiply int", () =>
                    {
                        int count = 1;

                        for (int i = 1; i < IterationCount; i++)
                            count *= i;
                    });

                    DisplayExecutionTime("Multiply long", () =>
                    {
                        long count = 1;

                        for (int i = 1; i < IterationCount; i++)
                            count *= i;
                    });

                    DisplayExecutionTime("Multiply float", () =>
                    {
                        float count = 1;

                        for (int i = 1; i < IterationCount; i++)
                            count *= i;
                    });

                    DisplayExecutionTime("Multiply double", () =>
                    {
                        double count = 1;

                        for (int i = 1; i < IterationCount; i++)
                            count *= i;
                    });

                    DisplayExecutionTime("Multiply decimal", () =>
                    {
                        decimal count = 1;

                        for (int i = 1; i < IterationCount; i++)
                            count *= 1.000000000001m;
                    });
                }

                Console.WriteLine();

                {
                    DisplayExecutionTime("Divide int", () =>
                    {
                        int count = int.MaxValue;

                        for (int i = 1; i < IterationCount; i++)
                            count /= i;
                    });

                    DisplayExecutionTime("Divide long", () =>
                    {
                        long count = long.MaxValue;

                        for (int i = 1; i < IterationCount; i++)
                            count /= i;
                    });

                    DisplayExecutionTime("Divide float", () =>
                    {
                        float count = float.MaxValue;

                        for (int i = 1; i < IterationCount; i++)
                            count /= i;
                    });

                    DisplayExecutionTime("Divide double", () =>
                    {
                        double count = double.MaxValue;

                        for (int i = 1; i < IterationCount; i++)
                            count /= i;
                    });

                    DisplayExecutionTime("Divide decimal", () =>
                    {
                        decimal count = decimal.MaxValue;

                        for (int i = 1; i < IterationCount; i++)
                            count /= i;
                    });
                }
            }
        }
    }
}
