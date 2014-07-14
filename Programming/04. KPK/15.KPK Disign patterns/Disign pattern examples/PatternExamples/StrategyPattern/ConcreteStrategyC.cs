using System;

/// <summary>
/// A 'ConcreteStrategy' class
/// </summary>
public class ConcreteStrategyC : Strategy
{
    /// <summary>
    /// Algorithm implementation
    /// </summary>
    public override void AlgorithmInterface()
    {
        Console.WriteLine("Strategy B Called ConcreteStrategyC.AlgorithmInterface()");
    }
}