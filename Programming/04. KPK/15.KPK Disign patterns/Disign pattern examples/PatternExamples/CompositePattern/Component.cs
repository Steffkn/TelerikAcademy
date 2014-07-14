/// <summary>
/// The 'Component' abstract class
/// </summary>
public abstract class Component
{
    /// <summary>
    /// Name of the component
    /// </summary>
    protected string name;

    /// <summary>
    /// Initializes a new instance of the Component class
    /// </summary>
    /// <param name="name">Name of the component</param>
    public Component(string name)
    {
        this.name = name;
    }

    /// <summary>
    /// Add a component
    /// </summary>
    /// <param name="c">Component to be added</param>
    public abstract void Add(Component c);

    /// <summary>
    /// Remove a component
    /// </summary>
    /// <param name="c">Component to be remove</param>
    public abstract void Remove(Component c);

    /// <summary>
    /// Display the component and its children with proper indenting
    /// </summary>
    /// <param name="depth">Depth of the component</param>
    public abstract void Display(int depth);
}
