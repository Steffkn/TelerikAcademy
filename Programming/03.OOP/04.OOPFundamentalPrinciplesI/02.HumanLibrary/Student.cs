
public class Student : Human
{
    private float grade;

    public float Grade
    {
        get { return grade; }
        set { grade = value; }
    }

    public Student(string firstName, string lastName, float grade)
        : base(firstName, lastName)
    {
        this.Grade = grade;
    }
}

