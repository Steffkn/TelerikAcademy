using System;

class TestAnimal
{
    static void Main()
    {
        // declare some cats dogs and frogs
        Cat[] cats =
            {
                new Kitten("Katarina", 2),
                new Tomcat("Haro", 9),
                new Kitten("Suzi", 3),
                new Tomcat("Djaro", 10)
            };
        Dog[] dogs =
            {
                new Dog("Martin", 5 , true),
                new Dog("Dragan", 6 , true),
                new Dog("Petkan", 7 , true),
                new Dog("Shisho", 8 , true)
            };
        Frog[] frogs =
            {
                new Frog("Pesho", 1 , true),
                new Frog("Venci", 2 , true),
                new Frog("Stoqn", 3 , true),
                new Frog("Kiko", 4 , true)
            };

        // a vert funny way to do it :D
        Console.WriteLine("Average age of cats: {0} ", Animal.Average(cats));
        Console.WriteLine("Average age of {0}: {1} ", dogs[0].AnimalKind().ToLower(), Animal.Average(dogs));
        Console.WriteLine("Average age of {0}: {1} ", frogs[0].AnimalKind().ToLower(), Animal.Average(frogs));
        Console.WriteLine();

        // make them talk!
        frogs[0].Talk();
        cats[0].Talk();
        cats[1].Talk();
        dogs[0].Talk();
    }
}
