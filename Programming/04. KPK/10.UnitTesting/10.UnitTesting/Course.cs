using System;
using System.Linq;
using System.Collections.Generic;

namespace _10.UnitTesting
{
    public class Course
    {
        public List<Student> students = new List<Student>();
        public List<Student> Students
        {
            get { return this.students; }
            set
            {
                if (value.Count >= 30 || value.Count <= 0)
                {
                    throw new ArgumentOutOfRangeException("The students must be less than 30 and NOT less than 1!");
                }
                else
                {
                    this.students = value;
                }
            }
        }

        public void AddStudent(Student newStudent)
        {
            if (newStudent == null)
            {
                throw new ArgumentNullException("Null student cannot be added to the list of students!");
            }
            else if (this.Students.Contains(newStudent))
            {
                throw new ArgumentException("The student is already in the list!");
            }
            else if (HasStudentWithNumber(newStudent.Number))
            {
                throw new ArgumentException("A student with this number exists!");
            }
            else if (this.Students.Count >= 29)
            {
                throw new ArgumentOutOfRangeException("The course is full!");
            }
            this.Students.Add(newStudent);
        }

        public void RemoveStudent(Student studentToRemove)
        {
            if (studentToRemove == null)
            {
                throw new ArgumentNullException("Null student cannot be removed from the list of students!");
            }
            else if (!this.Students.Contains(studentToRemove))
            {
                throw new ArgumentException("The student is not in the course!");
            }
            this.Students.Remove(studentToRemove);
        }

        public bool HasStudentWithNumber(int number)
        {
            foreach (var student in this.Students)
            {
                if(student.Number == number)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
