public class Tomcat : Cat
{
    public Tomcat(string name, byte age)
        : base(name, age, true) { }

    public override void Talk()
    {
        System.Console.WriteLine("{0} got his tail straight in the air..", this.Name);
        base.Talk();
    }
}