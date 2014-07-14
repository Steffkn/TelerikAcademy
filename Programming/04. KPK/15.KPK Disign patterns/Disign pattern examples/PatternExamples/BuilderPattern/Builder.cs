using System;

/// <summary>
/// The 'Builder' abstract class
/// </summary>
public abstract class Builder
{
    /// <summary>
    /// Method to build part A
    /// </summary>
    public abstract void BuildPartA();

    /// <summary>
    /// Method to build part B
    /// </summary>
    public abstract void BuildPartB();

    /// <summary>
    /// Method that returns the result object
    /// </summary>
    /// <returns>The newly constructed object</returns>
    public abstract Product GetResult();
}