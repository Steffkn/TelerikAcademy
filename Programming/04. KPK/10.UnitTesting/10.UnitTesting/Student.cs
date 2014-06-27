using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.UnitTesting
{
    public class Student
    {
        private string name;
        private int number;

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Enter name!");
                }
                else if (value == null)
                {
                    throw new ArgumentNullException("The name cannot be null!");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public int Number
        {
            get { return this.number; }
            private set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("The number must be between 10000 and 99999!");
                }
                else
                {
                    this.number = value;
                }
            }
        }

        public Student(string name, int number)
        {
            this.Name = name;
            this.Number = number;
        }
    }
}
