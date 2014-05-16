using System.Collections;
using System.Collections.Generic;

public class Discipline
{
    private string name;
    private byte numberOfLectures;
    private byte numberOfExercises;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public byte NumberOfLectures
    {
        get { return numberOfLectures; }
        set { numberOfLectures = value; }
    }
    public byte NumberOfExercises
    {
        get { return numberOfExercises; }
        set { numberOfExercises = value; }
    }

    public Discipline(string name, byte numberOfLectures, byte numberOfExcercises)
    {
        this.Name = name;
        this.NumberOfLectures = numberOfLectures;
        this.NumberOfExercises = numberOfExcercises;
    }

    public override string ToString()
    {
        return string.Format("{0} {1}",Name, NumberOfLectures);
    }
}
