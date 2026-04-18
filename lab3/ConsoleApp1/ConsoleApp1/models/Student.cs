using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.models
{
    public class Student
    {
        public Student(string lastName, string firstName, int course, string studentId, DateTime birthDate)
        {
            
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Course = course;
            this.StudentId = studentId;
            this.BirthDate = birthDate;
        }

        public string LastName {  get; set; }
        public string FirstName { get; set; }
        public int Course {  get; set; }
        public string StudentId { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
