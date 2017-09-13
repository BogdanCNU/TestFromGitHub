using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLibrary
{
    public class University
    {
        private List<Student> students = new List<Student>();
        private int nextId = 1;

        public void AddStudent(string name, string surname, DateTime dateOfBirth, Gender gender)
        {
            Student student = new Student(nextId++, dateOfBirth, name, surname, gender);
            students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public bool DeleteStudent(int id)
        {
            foreach (Student student in students)
            {
                if (student.Id == id)
                {
                    students.Remove(student);
                    return true;
                }
            }
            return false;
        }

        public bool UpdateStudent(int id, string newName, string newSurname)
        {
            foreach (Student student in students)
            {
                if (student.Id == id)
                {
                    student.Name = newName;
                    student.Surname = newSurname;
                    return true;
                }
            }
            return false;
        }

    }
}
