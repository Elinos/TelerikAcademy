using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Student : ICloneable, IComparable<Student>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; } 
        public string Address { get; set; }
        public string Phone { get; set; } 
        public string Email { get; set; }
        public string Course { get; set; }
        public Faculty Faculty { get; set; }
        public Specialty Specialty { get; set; }
        public University University { get; set; }

        
        public Student()
        {
            this.FirstName = String.Empty;
            this.MiddleName = String.Empty;
            this.LastName = String.Empty;
            this.SSN = String.Empty;
            this.Address = String.Empty;
            this.Phone = String.Empty;
            this.Email = String.Empty;
            this.Course = String.Empty;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Name: " + this.FirstName + "\n");
            sb.Append("Middle Name: " + this.MiddleName + "\n");
            sb.Append("Last Name: " + this.LastName + "\n");
            sb.Append("SSN: " + this.SSN + "\n");
            sb.Append("Addres: " + this.Address + "\n");
            sb.Append("Phone: " + this.Phone + "\n");
            sb.Append("Email: " + this.Email + "\n");
            sb.Append("Course: " + this.Course + "\n");
            sb.Append("University: " + this.University + "\n");
            sb.Append("Faculty: " + this.Faculty + "\n");
            sb.Append("Specialty: " + this.Specialty + "\n");

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            Student comparison = obj as Student;
            if (comparison == null)
            {
                return false;
            }

            return this.SSN == comparison.SSN;
            
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.SSN.GetHashCode();
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return Student.Equals(student1, student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !Student.Equals(student1, student2);
        }

        public object Clone()
        {
            Student obj = new Student();
            obj.FirstName = this.FirstName.Clone() as string;
            obj.MiddleName = this.MiddleName.Clone() as String;
            obj.LastName = this.LastName.Clone() as String;
            obj.LastName = this.LastName.Clone() as String;
            obj.SSN = this.SSN.Clone() as String;
            obj.Address = this.Address.Clone() as String;
            obj.Email = this.Email.Clone() as String;
            obj.Course = this.Course.Clone() as String;
            obj.Faculty = this.Faculty;
            obj.Specialty = this.Specialty;
            obj.University = this.University;

            return obj;
        }

        public int CompareTo(Student other)
        {
            if (!this.FirstName.Equals(other.FirstName))
            {
                return this.FirstName.CompareTo(other.FirstName);
            }
            else
            {
                if (!this.SSN.Equals(other.SSN))
                {
                    return this.SSN.CompareTo(other.SSN);
                }
            }

            return 0;
        }
    }
}
