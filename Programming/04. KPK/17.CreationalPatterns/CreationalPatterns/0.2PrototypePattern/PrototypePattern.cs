namespace _0._2PrototypePattern
{
    public class PrototypePattern
    {
        static void Main()
        {
            var prototypeType1 = new ConcretePrototype1("Beatles");
            var clonedPrototype = prototypeType1.Clone();
            System.Console.WriteLine(clonedPrototype.ToString());

            
            var prototypeType2 = new ConcretePrototype2(18);
            var clonedPrototypeType2 = prototypeType2.Clone();
            System.Console.WriteLine(clonedPrototypeType2.ToString());
        }
    }
}
