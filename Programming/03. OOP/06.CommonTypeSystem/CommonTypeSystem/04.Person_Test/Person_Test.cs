using System;

public class Person_Test
{
    static void Main()
    {
        var Ivan = new Person("Ivan");
        var Qvor = new Person("Qvor", 24);
        var Petyr = new Person("Exception", 127);
        //var Qvor = new Person("Qvor", 400);
        Console.WriteLine(Ivan.ToString());
        Console.WriteLine(Qvor.ToString());
    }
}
