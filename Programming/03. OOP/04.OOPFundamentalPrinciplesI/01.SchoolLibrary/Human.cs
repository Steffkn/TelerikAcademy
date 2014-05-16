public class Human
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Human(string name)
    {
        this.Name = name;
    }
}
