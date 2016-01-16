using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class StudentsGroup
{
    static void Main()
    {
        List<Student> students = new List<Student>();

        students.Add(new Student("Petyr",
            "Petrov",
            "121314032",
            "088-888-888",
            "p.petrov@abv.bg",
            new List<int>() { 4, 3, 4, 6 },
            1));
        students.Add(new Student("Georgi",
            "Georgiev",
            "121306033",
            "088-777-777",
            "g.georg@abv.bg",
            new List<int>() { 3, 3, 2, 2 },
            2));
        students.Add(new Student("Ivan",
            "Ivanov",
            "121314034",
            "088-999-999",
            "ivanov@abv.bg",
            new List<int>() { 3, 4, 3, 4 },
            1));
        students.Add(new Student("Kristina",
            "Krysteva",
            "121306069",
            "027654321",
            "krissi@gmail.com",
            new List<int>() { 5, 6, 6, 6 },
            2));
        students.Add(new Student("Dimitrinka",
            "Dimitrova",
            "121314096",
            "088-555-555",
            "dimitrova@abv.bg",
            new List<int>() { 6, 6, 6, 6 },
            1));
        students.Add(new Student("Zornica",
            "Shtiparova",
            "121314030",
            "021234567",
            "zori@yahoo.com",
            new List<int>() { 6, 2, 6, 6 },
            3));

        /// Problem 9. Student groups
        IEnumerable<Student> studentsGroup2LINQ = from student in students
                                                  where student.GroupNumber == 2
                                                  orderby student.FirstName ascending
                                                  select student;

        foreach (var studentFrom2 in studentsGroup2LINQ)
        {
            Console.WriteLine("Student LINQ: {0} {1}", studentFrom2.FirstName, studentFrom2.LastName);
        }

        /// Problem 10. Student groups extensions
        IEnumerable<Student> studentsGroup2 = students.Where(s => s.GroupNumber == 2)
            .OrderBy(s => s.FirstName);

        foreach (var studentFrom2 in studentsGroup2)
        {
            Console.WriteLine("Student extension: {0} {1}", studentFrom2.FirstName, studentFrom2.LastName);
        }

        // Problem 11. Extract students by email

        IEnumerable<Student> studentsByEmail = from student in students
                                               where student.Email.EndsWith("abv.bg")
                                               orderby student.FirstName ascending
                                               select student;

        foreach (var studentByMail in studentsByEmail)
        {
            Console.WriteLine("Student by mail: {0} {1} - {2}", studentByMail.FirstName, studentByMail.LastName, studentByMail.Email);
        }

        /// Problem 12. Extract students by phone

        IEnumerable<Student> studentsByTelephone = from student in students
                                                   where student.Tel.StartsWith("02")
                                                   orderby student.FirstName ascending
                                                   select student;

        foreach (var studentsByTel in studentsByTelephone)
        {
            Console.WriteLine("Student by mail: {0} {1} - {2}", studentsByTel.FirstName, studentsByTel.LastName, studentsByTel.Tel);
        }

        /// Problem 13. Extract students by marks
        /// 

        var studentsByMarks = from student in students
                              where student.Marks.Contains(6)
                              orderby student.FirstName ascending
                              select new { FullName = student.FirstName + " " + student.LastName, Marks = student.Marks };

        foreach (var studentsByMark in studentsByMarks)
        {
            Console.Write("Student by marks (6): {0} ", studentsByMark.FullName);
            foreach (var mark in studentsByMark.Marks)
            {
                Console.Write("{0} ", mark);
            }
            Console.WriteLine();
        }

        /// Problem 14. Extract students with two marks
        /// 
        var studentsWith2F = students.Where(s => FindMarks(s.Marks, 2) == 2)
            .OrderBy(s => s.FirstName);

        foreach (var studentsByMark in studentsWith2F)
        {
            Console.Write("Student by marks (2): {0} {1} ", studentsByMark.FirstName, studentsByMark.FirstName);
            foreach (var mark in studentsByMark.Marks)
            {
                Console.Write("{0} ", mark);
            }
            Console.WriteLine();
        }



        /// Problem 15. Extract marks - 
        /// Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
        /// 

        var studentsByMarksFrom2006 = students.Where(s => s.FN.ToString().Substring(4, 2).Equals("06"))
            .OrderBy(s => s.FirstName);

        foreach (var studentByMarks in studentsByMarksFrom2006)
        {
            Console.WriteLine("Student by FN 2006: {0} {1} - {2}", studentByMarks.FirstName, studentByMarks.LastName, studentByMarks.FN);
        }

        /// Problem 16.* Groups

        Group mathematics = new Group(1, "Mathematics");
        Group physics = new Group(2, "Physics");
        Group history = new Group(3, "History");

        //var studentsFromMath = from student in students
        //                       join math in mathematics on 
        //                       orderby student.FirstName ascending
        //                       select new { FullName = student.FirstName + " " + student.LastName, Marks = student.Marks };


        /// Problem 18. Grouped by GroupNumber
        /// 

        List<Group> groupsList = new List<Group>();
        groupsList.Add(mathematics);
        groupsList.Add(physics);
        groupsList.Add(history);

        foreach (var department in groupsList)
        {
            var studentsByGroups = from student in students
                                   where student.GroupNumber == department.GroupNumber
                                   orderby student.FirstName ascending
                                   select student;

            foreach (var studentByGroup in studentsByGroups)
            {
                Console.WriteLine("Group: {0} Student: {1} {2}", studentByGroup.GroupNumber, studentByGroup.FirstName, studentByGroup.LastName);
            }
        }
        /// Problem 19. Grouped by GroupName extensions extension methods
        /// 

        foreach (var department in groupsList)
        {
            var studentsByGroups = students.Where(s => s.GroupNumber == department.GroupNumber)
                .OrderBy(s => s.FirstName);

            foreach (var studentByGroup in studentsByGroups)
            {
                Console.WriteLine("Group: {0} Student: {1} {2}", studentByGroup.GroupNumber, studentByGroup.FirstName, studentByGroup.LastName);
            }
        }
    }

    public static int FindMarks(List<int> marks, int markToFind)
    {
        int count = 0;
        foreach (var mark in marks)
        {
            if (mark == markToFind)
            {
                count++;
            }
        }
        return count;
    }
}
