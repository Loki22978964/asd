using System;
using System.Collections.Generic;
using System.Linq;

namespace lab5.Model
{
    public class Student : IComparable<Student>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Group { get; set; }
        public double AverageGrade { get; set; }
        public string Sport { get; set; }

        public Student(string lastName, string firstName, string group, double avg, string sport)
        {
            LastName = lastName;
            FirstName = firstName;
            Group = group;
            AverageGrade = avg;
            Sport = sport;
        }

        public int CompareTo(Student? other)
        {
            return AverageGrade.CompareTo(other.AverageGrade);
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} | Group: {Group} | AverageGrade: {AverageGrade:F2} | Sport: {Sport}";
        }
    }
}
