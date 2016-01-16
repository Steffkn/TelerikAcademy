using System;
using System.Text;
public class Student : ICloneable, IComparable<Student>
{
    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }

    public string SSN { get; set; }

    public string Address { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public int Course { get; set; }

    public Specialties Specialty { get; set; }

    public Universities University { get; set; }

    public Faculties Faculty { get; set; }

    public Student()
    {

    }

    public override bool Equals(object obj)
    {
        // If parameter is null return false.
        if (obj == null)
        {
            return false;
        }

        // If parameter cannot be cast to Point return false.
        Student student = obj as Student;
        if (student == null)
        {
            return false;
        }

        // Just in case we search for exact match
        return (this.FirstName.Equals(student.FirstName)
            && this.MiddleName.Equals(student.MiddleName)
            && this.LastName.Equals(student.LastName)
            && this.SSN.Equals(student.SSN)
            && this.Address.Equals(student.Address)
            && this.Phone.Equals(student.Phone)
            && this.Email.Equals(student.Email)
            && this.Course.Equals(student.Course)
            && this.University == student.University
            && this.Faculty == student.Faculty
            && this.Specialty == student.Specialty);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Name: {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
        sb.AppendFormat("University: {0} Faculty: {1} Specialty {2} SSN {3} Course {4}", this.University, this.Faculty, this.Specialty, this.SSN, this.Course);
        sb.AppendFormat("Address: {0} Email: {1} Phone {2}", this.Address, this.Email, this.Phone);

        return sb.ToString();
    }

    // i am not sure if this is right way to override GetHashCode
    public override int GetHashCode()
    {
        unchecked
        {
            var result = 0;
            result = result ^ this.FirstName.GetHashCode();
            result = result ^ this.MiddleName.GetHashCode();
            result = result ^ this.LastName.GetHashCode();
            result = result ^ this.Address.GetHashCode();

            return result;
        }
    }

    public static bool operator ==(Student studentA, Student studentB)
    {
        bool result = false;
        if (studentA != null && studentB != null)
        {
            result = studentA.Equals(studentB);
        }

        return result;
    }

    public static bool operator !=(Student studentA, Student studentB)
    {
        bool result = false;
        if (studentA != null && studentB != null)
        {
            result = !studentA.Equals(studentB);
        }
        return result;
    }

    public object Clone()
    {
        Student newStudent = new Student()
        {
            FirstName = this.FirstName,
            MiddleName = this.MiddleName,
            LastName = this.LastName,
            SSN = this.SSN,
            Address = this.Address,
            Phone = this.Phone,
            Email = this.Email,
            Course = this.Course,
            University = this.University,
            Faculty = this.Faculty,
            Specialty = this.Specialty,
        };

        return newStudent;
    }

    public int CompareTo(Student other)
    {
        int result;
        // names SSN
        if (this.Equals(other))
        {
            result = 0;
        }
        else if (this.FirstName.CompareTo(other.FirstName) != 0)
        {
            result = this.FirstName.CompareTo(other.FirstName);
        }
        else if (this.MiddleName.CompareTo(other.MiddleName) != 0)
        {
            result = this.MiddleName.CompareTo(other.MiddleName);
        }
        else if (this.LastName.CompareTo(other.LastName) != 0)
        {
            result = this.LastName.CompareTo(other.LastName);
        }
        else if (this.SSN.CompareTo(other.SSN) != 0)
        {
            result = this.SSN.CompareTo(other.SSN);
        }
        else
        {
            // if other everything is equal then they will be marked as the same person
            result = 1;
        }
        return result;
    }
}
