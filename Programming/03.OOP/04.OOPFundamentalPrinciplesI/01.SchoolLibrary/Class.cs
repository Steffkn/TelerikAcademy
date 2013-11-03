using System.Collections;
using System.Collections.Generic;

public class Class
{
    private string identifier;
    private ICollectionSchool<Teacher> teachers = new ICollectionSchool<Teacher>();
    private ICollectionSchool<Student> students = new ICollectionSchool<Student>();

    public string Identifier
    {
        get { return identifier; }
        set { identifier = value; }
    }
    public ICollectionSchool<Teacher> Teachers
    {
        get { return teachers; }
        set { teachers = value; }
    }

    public ICollectionSchool<Student> Students
    {
        get { return students; }
        set { students = value; }
    }

    /// <summary>
    /// Class constructor.
    /// </summary>
    /// <param name="textIdentifier">Name of the class</param>
    public Class(string identifier)
    {
        this.Identifier = identifier;
    }

    public override string ToString()
    {
        System.Console.WriteLine("Paralelka {0}", identifier);
        System.Console.WriteLine("Uchiteli");
        Teachers.PrintItems();
        System.Console.WriteLine("Uchenici");
        Students.PrintItems();
        return null;
    }

}
