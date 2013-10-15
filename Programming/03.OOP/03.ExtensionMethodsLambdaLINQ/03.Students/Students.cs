using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Student(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}

class Students
{
    static void Main(string[] args)
    {
        List<Student> studentsList = new List<Student>();
        studentsList.Add(new Student("Adi", "Dimanova")); // yes
        studentsList.Add(new Student("Ivona", "Pavlova")); // yes
        studentsList.Add(new Student("Nataliq", "Veneva")); // yes
        studentsList.Add(new Student("Aleksandar", "Tanev"));  // yes
        studentsList.Add(new Student("Radina", "Stoqnova")); // yes
        studentsList.Add(new Student("Daniel", "Hristov")); // yes
        studentsList.Add(new Student("Albena", "Hubavela")); // yes
        studentsList.Add(new Student("Stefan", "Petrov"));
        studentsList.Add(new Student("Radoslav", "Iordanov"));
        studentsList.Add(new Student("Ralica", "Brusarska"));

        var selection =
            from student in studentsList
            where student.FirstName.CompareTo(student.LastName) < 0
            select student;
        foreach (var item in selection)
        {
            Console.WriteLine(item.FirstName + " " + item.LastName);
        }
    }
}


