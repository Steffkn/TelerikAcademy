using System;

public class Group
{
    public int GroupNumber { get; set; }

    public string Department { get; set; }

    public Group(int groupNumber, string department)
    {
        this.GroupNumber = groupNumber;
        this.Department = department;
    }
}
