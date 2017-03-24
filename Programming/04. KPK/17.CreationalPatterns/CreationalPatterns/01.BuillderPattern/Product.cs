using System;
using System.Collections.Generic;

/// <summary>
/// The 'Product' class
/// </summary>
public class Product
{
    /// <summary>
    /// List with parts of the object
    /// </summary>
    private List<string> parts = new List<string>();

    /// <summary>
    /// Add a part to the object
    /// </summary>
    /// <param name="part">Part to be added</param>
    public void Add(string part)
    {
        this.parts.Add(part);
    }

    /// <summary>
    /// Show all parts of the produced object
    /// </summary>
    public void Show()
    {
        Console.WriteLine("\nProduct Parts -------");
        foreach (string part in this.parts)
        {
            Console.WriteLine(part);
        }
    }
}