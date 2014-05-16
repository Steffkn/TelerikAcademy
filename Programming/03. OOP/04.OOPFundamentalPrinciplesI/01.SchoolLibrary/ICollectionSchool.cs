
using System.Collections;
using System.Collections.Generic;

public class ICollectionSchool<T>
{
    private ICollection<T> items = new List<T>();

    public ICollection<T> Items
    {
        get { return items; }
        set { ; }
    }

    /// <summary>
    /// Add item to the list.
    /// </summary>
    /// <param name="item">Item that we want to add to the list.</param>
    public void AddItem(T item)
    {
        this.Items.Add(item);
    }

    /// <summary>
    /// Delete a item from the list.
    /// </summary>
    /// <param name="item">Item that we want to remove from the list.</param>
    public void RemoveItem(T item)
    {
        this.Items.Remove(item);
    }

    /// <summary>
    /// Clear the list of items.
    /// </summary>
    public void RemoveAllItems()
    {
        this.Items.Clear();
    }

    /// <summary>
    /// Prints all items from the list ( format '"{0} - {1}", number, item').
    /// </summary>
    public void PrintItems()
    {
        foreach (var item in Items)
        {
            System.Console.WriteLine("{0}",item);
        }
    }

}
