using System;

/// <summary>
/// StrategyPattern startup class for Structural Strategy Design Pattern.
/// </summary>
public class StrategyPattern
{
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    public static void Main()
    {
        Context context;

        // Three contexts following different strategies
        context = new Context(new ConcreteStrategyA());
        context.ContextInterface();
        context = new Context(new ConcreteStrategyB());
        context.ContextInterface();
        context = new Context(new ConcreteStrategyC());
        context.ContextInterface();

        // Wait for user
        Console.ReadKey();
    }
}
