using System.Collections;
using System.Collections.Generic;

public class Teacher : Human
{
    private ICollectionSchool<Discipline> disciplines = new ICollectionSchool<Discipline>();

    
    // just for the encapsulation (i dont think it is needed)
    /// <summary>
    /// Constrictor for all the disciplines.
    /// </summary>
    public ICollectionSchool<Discipline> Disciplines 
    { 
        get { return disciplines; }
        set { disciplines = value; } 
    }

    /// <summary>
    /// Constructor of the teacher (must have atleast one discipline)
    /// </summary>
    /// <param name="name">Teachers name</param>
    /// <param name="discipline">Discipline that the teacher teaches at</param>
    public Teacher(string name, Discipline discipline) : base(name) 
    { 
        this.Disciplines.AddItem(discipline); 
    }

    public override string ToString()
    {
        // i couldnt do it smarter option B is not an option bcoz i dont like the output
        System.Console.WriteLine("{0}", Name);
        System.Console.WriteLine("Disciplini: ");
        Disciplines.PrintItems();
        return null;

        // option B
        //Disciplines.PrintItems(); // disciplines first
        //return string.Format("{0}", Name); // teacher's name second

    }
}
