using System;
using System.Linq;

namespace _10.UnitTesting
{
    public class School
    {
        static void Main() {
            Course course = new Course();
            Student pesho = new Student("Pesho", 10000);

            course.AddStudent(pesho);
            course.RemoveStudent(pesho);
        }
    }
}
