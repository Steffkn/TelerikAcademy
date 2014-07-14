using System;

/// <summary>
/// A 'ConcreteStrategy' class
/// </summary>
public class ConcreteStrategyA : Strategy
{
    /// <summary>
    /// Algorithm implementation
    /// </summary>
    public override void AlgorithmInterface()
    {
        Console.WriteLine("Strategy A Called by ConcreteStrategyA.AlgorithmInterface()");
    }
}