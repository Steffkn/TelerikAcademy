using System;

/// <summary>
/// The 'Leaf' class
/// </summary>
public class Leaf : Component
{
    /// <summary>
    /// Initializes a new instance of the Leaf class
    /// </summary>
    /// <param name="name">Name of the leaf</param>
    public Leaf(string name)
        : base(name)
    {
    }

    /// <summary>
    /// Add a component
    /// </summary>
    /// <param name="c">Component of type Component to be added</param>
    public override void Add(Component c)
    {
        Console.WriteLine("Cannot add to a leaf");
    }

    /// <summary>
    /// Remove a component
    /// </summary>
    /// <param name="c">Component of type Component to be removed</param>
    public override void Remove(Component c)
    {
        Console.WriteLine("Cannot remove from a leaf");
    }

    /// <summary>
    /// Display the item with proper indenting
    /// </summary>
    /// <param name="depth">Depth of the leaf</param>
    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + this.name);
    }
}
