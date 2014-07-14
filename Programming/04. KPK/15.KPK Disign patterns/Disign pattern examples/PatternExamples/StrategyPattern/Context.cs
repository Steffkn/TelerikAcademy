/// <summary>
/// The 'Context' class
/// </summary>
public class Context
{
    /// <summary>
    /// The strategy that we will slap depending on our needs
    /// </summary>
    private Strategy strategy;

    /// <summary>
    /// Initializes a new instance of the Context class
    /// </summary>
    /// <param name="strategy">The strategy (algorithm) we use</param>
    public Context(Strategy strategy)
    {
        this.strategy = strategy;
    }

    /// <summary>
    /// Call the algorithm
    /// </summary>
    public void ContextInterface()
    {
        this.strategy.AlgorithmInterface();
    }
}