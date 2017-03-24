namespace _0._2PrototypePattern
{
    public class ConcretePrototype1 : Prototype
    {
        public string Name { get; set; }

        public ConcretePrototype1(string name)
        {
            this.Name = name;
        }

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone(); // Clones the concrete class.
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
