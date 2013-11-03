
public class Cat : Animal
{
    public Cat(string name, byte age, bool isMale)
        : base(name, age, isMale) { }

    public override void Talk()
    {
        System.Console.WriteLine("{0} said: Miaaaaaaaaaaaaaaaaaaaaaaaaaw!", this.Name);
    }
}

