using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _10.UnitTesting;
using System.Collections.Generic;

namespace UnitTestingTests
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Assign30Students()
        {
            List<Student> listOfStudents = new List<Student>();
            Course course = new Course();
            for (int i = 0; i < 31; i++)
            {
                listOfStudents.Add(new Student("Pesho", 10000 + i));
            }
            course.Students = listOfStudents;
        }

        [TestMethod]
        public void AssignLessThan30Students()
        {
            List<Student> listOfStudents = new List<Student>();
            Course course = new Course();
            for (int i = 0; i < 29; i++)
            {
                listOfStudents.Add(new Student("Pesho", 10000 + i));
            }
            course.Students = listOfStudents;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AssignNullStudents()
        {
            Course course = new Course();
            course.Students = null;
        }

        [TestMethod]
        public void AddStudent_AddNormalStudent()
        {
            string name = "Pesho";
            int number = 10001;
            Student newStudent = new Student(name, number);
            Course course = new Course();

            course.AddStudent(newStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddStudent_AddInvalidStudent()
        {
            Course course = new Course();
            string name = "Pesho";
            int number = 100000;
            Student newStudent = new Student(name, number);

            course.AddStudent(newStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStudent_AddNullStudent()
        {
            string name = "Pesho";
            int number = 10000;
            Student newStudent = new Student(name, number);
            Course course = new Course();
            newStudent = null;
            course.AddStudent(newStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudent_AddSameStudent2Times()
        {
            string name = "Pesho";
            int number = 10000;
            Student newStudent = new Student(name, number);
            Course course = new Course();
            course.AddStudent(newStudent);
            course.AddStudent(newStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudent_AddStudentWithExistingNumber()
        {
            Student pesho = new Student("Pesho", 10100);
            Student gosho = new Student("Gosho", 10100);

            Course course = new Course();

            course.AddStudent(pesho);
            course.AddStudent(gosho);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddStudent_Add30thStudent()
        {
            Course course = new Course();
            for (int i = 0; i < 31; i++)
            {
                Student pesho = new Student("Pesho", 10000 + i);
                course.AddStudent(pesho);
            }
        }

        [TestMethod]
        public void RemoveStudent_RemoveStudent()
        {
            string name = "Pesho";
            int number = 10000;
            Student newStudent = new Student(name, number);
            Course course = new Course();
            course.AddStudent(newStudent);
            course.RemoveStudent(newStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveStudent_RemoveNullStudent()
        {
            string name = "Pesho";
            int number = 10000;
            Student newStudent = new Student(name, number);
            Course course = new Course();
            newStudent = null;
            course.RemoveStudent(newStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveStudent_RemoveUnexistingStudent()
        {
            Student pesho = new Student("Pesho", 10100);
            Student gosho = new Student("Gosho", 10100);

            Course course = new Course();

            course.AddStudent(pesho);
            course.RemoveStudent(gosho);
        }

        [TestMethod]
        public void HasStudentWithNumber_ReturnsTrue()
        {
            Course course = new Course();
            Student pesho = new Student("Pesho", 10000);
            course.AddStudent(pesho);
            Assert.IsTrue(course.HasStudentWithNumber(10000));
        }

        [TestMethod]
        public void HasStudentWithNumber_ReturnsFalse()
        {
            Course course = new Course();
            Student pesho = new Student("Pesho", 10000);
            course.AddStudent(pesho);
            Assert.IsFalse(course.HasStudentWithNumber(10001));
        }

    }
}
