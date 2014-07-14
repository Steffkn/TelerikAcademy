using System;

/// <summary>
/// A 'ConcreteStrategy' class
/// </summary>
public class ConcreteStrategyB : Strategy
{
    /// <summary>
    /// Algorithm implementation
    /// </summary>
    public override void AlgorithmInterface()
    {
        Console.WriteLine("Strategy B Called ConcreteStrategyB.AlgorithmInterface()");
    }
}