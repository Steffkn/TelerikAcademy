
public class Frog : Animal
{
    public Frog(string name, byte age, bool isMale)
        : base(name, age, isMale) { }

    public override void Talk()
    {
        System.Console.WriteLine("{0} said: I am just a frog.. 0_0", this.Name);
    }
}

