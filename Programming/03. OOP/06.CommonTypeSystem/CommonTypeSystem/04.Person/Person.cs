using System.Text;

public class Person
{
    public string Name { get; set; }

    public sbyte? Age { get; set; }

    public Person(string name) : this(name, null) { }

    public Person(string name, sbyte? age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Name: {0}", this.Name);
        if (this.Age == null)
        {
            sb.Append("Age is not specified!");
        }
        else
        {
            sb.AppendFormat("Age: {0}", this.Age);
        }

        return sb.ToString();
    }
}
