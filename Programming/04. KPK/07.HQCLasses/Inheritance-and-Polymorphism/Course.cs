namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Course
    {
        private string name;

        private string teacherName;

        private IList<string> students;

        public Course(string courseName)
        {
            this.Name = courseName;
            this.TeacherName = string.Empty;
            this.Students = new List<string>();
        }

        public Course(string courseName, string teacherName)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = new List<string>();
        }

        public Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Course name is null or empty!");
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Course's teacher name is null or empty!");
                }

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value ?? new List<string>();
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (this.TeacherName != string.Empty)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            string studentsAsString = string.Empty;

            if (this.Students.Count > 0)
            {
                studentsAsString = "{ " + string.Join(", ", this.Students) + " }";
            }
            else
            {
                studentsAsString = "{ }";
            }

            return studentsAsString;
        }
    }
}
