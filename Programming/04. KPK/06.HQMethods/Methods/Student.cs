using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student otherStudent)
        {
            bool isOlder = false;
            if (this.BirthDay > otherStudent.BirthDay)
            {
                isOlder = true;
            }
            return isOlder;
        }
    }
}
