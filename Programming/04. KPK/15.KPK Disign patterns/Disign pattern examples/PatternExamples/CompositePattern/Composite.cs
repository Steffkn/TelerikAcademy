using System;
using System.Collections.Generic;

/// <summary>
/// The 'Composite' class
/// </summary>
public class Composite : Component
{
    /// <summary>
    /// List of childComponents
    /// </summary>
    private List<Component> children = new List<Component>();

    /// <summary>
    /// Initializes a new instance of the Composite class
    /// </summary>
    /// <param name="name">Name of the component</param>
    public Composite(string name)
        : base(name)
    {
    }

    /// <summary>
    /// Add a component
    /// </summary>
    /// <param name="component">Component of type Component to be added</param>
    public override void Add(Component component)
    {
        this.children.Add(component);
    }

    /// <summary>
    /// Remove a component
    /// </summary>
    /// <param name="component">Component of type Component to be removed</param>
    public override void Remove(Component component)
    {
        this.children.Remove(component);
    }

    /// <summary>
    /// Display the item with proper indenting
    /// </summary>
    /// <param name="depth">Depth of the leaf</param>
    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + this.name);

        // Recursively display child nodes
        foreach (Component component in this.children)
        {
            component.Display(depth + 2);
        }
    }
}
