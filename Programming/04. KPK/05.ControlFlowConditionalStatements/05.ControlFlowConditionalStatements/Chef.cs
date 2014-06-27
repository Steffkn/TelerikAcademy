
using System;
namespace _05.ControlFlowConditionalStatements
{

    public class Chef
    {
        private Bowl GetBowl()
        {
            //... 
            return new Bowl();
        }
        private Carrot GetCarrot()
        {
            //...
            return new Carrot();
        }

        private Potato GetPotato()
        {
            //...
            return new Potato();
        }

        private void Cut(Vegetable vegetable)
        {
            //...
        }

        public void Cook()
        {
            Potato potato = GetPotato();
            Carrot carrot = GetCarrot();
            Bowl bowl = GetBowl();

            Peel(potato);
            Cut(potato);
            bowl.Add(potato);

            Peel(carrot);
            Cut(carrot);
            bowl.Add(carrot);

        }

        private void Peel(Vegetable vegetable)
        {
            throw new NotImplementedException();
        }

    }
}