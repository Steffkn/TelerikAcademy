using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _10.UnitTesting;

namespace UnitTestingTests
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void Student_TestValidStudent()
        {
            string name = "Pesho";
            int number = 10000;
            Student student = new Student(name, number);
            Assert.AreEqual(student.Name, name);
            Assert.AreEqual(student.Number, number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_EmptyStudentName()
        {
            string name = string.Empty;
            int number = 10000;
            Student student = new Student(name, number);
            Assert.AreEqual(student.Name, name);
            Assert.AreEqual(student.Number, number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_NullStudentName()
        {
            string name = null;
            int number = 10000;
            Student student = new Student(name, number);
            Assert.AreEqual(student.Name, name);
            Assert.AreEqual(student.Number, number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Student_StudentNumberLessThan10000()
        {
            string name = "Pesho";
            int number = 9999;
            Student student = new Student(name, number);
            Assert.AreEqual(student.Name, name);
            Assert.AreEqual(student.Number, number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Student_StudentNumberBiggerThan99999()
        {
            string name = "Pesho";
            int number = 100000;
            Student student = new Student(name, number);
            Assert.AreEqual(student.Name, name);
            Assert.AreEqual(student.Number, number);
        }
    }
}
