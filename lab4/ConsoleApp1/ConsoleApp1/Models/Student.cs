using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public enum EducationForm
    {
        budgetary,
        contractual
    }

    public class Student
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public EducationForm educationForm { get; set; }

        public Student(string surname , string name , EducationForm educationForm)
        {
            this.Surname = surname;
            this.Name = name;
            this.educationForm = educationForm;
        }

        public override string ToString() =>
            $"{Surname,-15} | {Name,-10} | {educationForm.ToString()}";
    }
}

