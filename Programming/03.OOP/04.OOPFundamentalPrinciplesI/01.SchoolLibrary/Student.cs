
public class Student : Human
{
    private int unicNumber;

    public int UnicNumber
    {
        get { return unicNumber; }
        set { unicNumber = value; }
    }

    public Student(string name, int unicNumber)
        : base(name)
    {
        this.UnicNumber = unicNumber;
    }

    public override string ToString()
    {
        return string.Format("{0,-10} {1}",Name, UnicNumber);
    }
}

