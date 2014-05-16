// Using the extension methods OrderBy() and ThenBy() with lambda expressions 
// sort the students by first name and last name in descending order. 
// Rewrite the same with LINQ.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

class ArangeStudensByNames
{
    static void Main()
    {
        List<Student> studentsList = new List<Student>();
        studentsList.Add(new Student("Adi", "Dimanova"));
        studentsList.Add(new Student("Ivona", "Pavlova")); 
        studentsList.Add(new Student("Nataliq", "Veneva"));
        studentsList.Add(new Student("Aleksandar", "Tanev")); 
        studentsList.Add(new Student("Radina", "Stoqnova"));
        studentsList.Add(new Student("Daniel", "Hristov")); 
        studentsList.Add(new Student("Albena", "Hubavela")); 
        studentsList.Add(new Student("Stefan", "Petrov"));
        studentsList.Add(new Student("Radoslav", "Iordanov"));
        studentsList.Add(new Student("Ralica", "Brusarska"));

        int counter = 1;
        Console.WriteLine("Not ordered");
        foreach (var student in studentsList)
        {
            Console.WriteLine("{0} {1} {2}", counter++, student.FirstName, student.LastName);
        }

        // order with OrderBy() and ThenBy()
        Console.WriteLine();
        Console.WriteLine("Descending order");
        var students = studentsList
            .OrderByDescending(x => x.FirstName)
            .ThenByDescending(y => y.LastName)
            .ToList();
        counter = 1;
        foreach (var student in students)
        {
            Console.WriteLine("{0} {1} {2}", counter++, student.FirstName, student.LastName);
        }

        // order with LINQ expression
        Console.WriteLine();
        Console.WriteLine("Descending order - LINQ");
        var studentsLINQ =
            (from student in studentsList
             orderby student.FirstName descending, student.LastName descending
                select student)
             .ToList();

        counter = 1;
        foreach (var student in studentsLINQ)
        {
            Console.WriteLine("{0} {1} {2}", counter++, student.FirstName, student.LastName);
        }
    }
}

