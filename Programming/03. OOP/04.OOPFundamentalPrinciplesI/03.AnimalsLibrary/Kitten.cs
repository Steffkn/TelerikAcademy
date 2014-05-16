
public class Kitten : Cat
{
    public Kitten(string name, byte age)
        : base(name, age, false) { }

    public override void Talk()
    {
        System.Console.WriteLine("{0} looks at you..", this.Name);
        base.Talk();
    }
}

