namespace _0._2PrototypePattern
{
    public class ConcretePrototype2 : Prototype
    {
        public int Years { get; set; }

        public ConcretePrototype2(int years)
        {
            this.Years = years;
        }

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone(); // Clones the concrete class.
        }
        
        public override string ToString()
        {
            return string.Format("I am {0}!", this.Years);
        }
    }
}