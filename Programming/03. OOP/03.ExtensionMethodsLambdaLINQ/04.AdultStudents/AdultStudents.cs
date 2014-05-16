using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public Student(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }
}

class AdultStudents
{
    static void Main()
    {
        List<Student> studentsList = new List<Student>();
        studentsList.Add(new Student("Adi", "Dimanova", 19)); // yes
        studentsList.Add(new Student("Ivona", "Pavlova", 22)); // yes
        studentsList.Add(new Student("Nataliq", "Veneva", 18)); // yes 
        studentsList.Add(new Student("Aleksandar", "Tanev", 25));
        studentsList.Add(new Student("Radina", "Stoqnova", 16));
        studentsList.Add(new Student("Daniel", "Hristov", 25));
        studentsList.Add(new Student("Albena", "Hubavela", 17));
        studentsList.Add(new Student("Stefan", "Petrov", 22)); // yes
        studentsList.Add(new Student("Radoslav", "Iordanov", 58));
        studentsList.Add(new Student("Ralica", "Brusarska", 19));// yes

        var result = 
            from student in studentsList
                where student.Age >= 18 && student.Age <= 24
                select student;
        Console.WriteLine("First name and last name of all students with age between 18 and 24:");
        foreach (var student in result)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }
            
    }
}

