using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLibrary
{

    public enum Gender
    {
        Male, Female
    }
    public class Student
    {
        public int Id
        {
            get;
            private set;
        }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                // Calculate the age.
                var age = today.Year - DateOfBirth.Year;
                // Go back to the year the person was born in case of a leap year
                if (DateOfBirth > today.AddYears(-age))
                {
                    age--;
                }
                return age;

            }
        }

        public string Name;
        public string Surname;
        private List<double> marks;
        public Gender Gender {
            get;
            private set; }
        public DateTime DateOfBirth
        {
            get;
            set;
        }

        public Student(int id, DateTime dateOfBirth, string name, string surname, Gender gender)
        {
            this.marks = new List<double>();
            this.Id = id;
            this.DateOfBirth = dateOfBirth;
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;
        }



        public string FullName

        {
            get
            {
                // StringBuilder
                //return name + " " + surname;
                return string.Format("{0} {1}", Name, Surname);
            }
        }

        public double AverageMark()
        {
            double sum = 0;
            if (marks.Count != 0)
            {
                foreach (double mark in marks)
                {
                    sum = sum + mark;
                }
                return sum / marks.Count;
            }
            return 0;
        }

        public override string ToString()
        {
            // return base.ToString();
            return string.Format("{5} - {0} {1} ({2} ani / {3}) - Media: {4}", Name, Surname, Age, Gender, AverageMark(), Id);
        }

    }
}
