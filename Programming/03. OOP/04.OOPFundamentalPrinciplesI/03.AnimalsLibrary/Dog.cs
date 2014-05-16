
public class Dog : Animal
{
    public Dog(string name, byte age, bool isMale)
        : base(name, age, isMale) { }

    public override void Talk()
    {
        System.Console.WriteLine("{0} said: BARK BARK BARK.. BARK!", this.Name);
    }
}
