using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLibrary;

namespace ClasaStudent
{
    class Program
    {
        static University university = new University();
        public static void ReadStudent()
        {
            Console.WriteLine("Introduceti numele studentului:");
            string name = Console.ReadLine();
            Console.WriteLine("Introduceti prenumele studentului:");
            string surname = Console.ReadLine();
            Console.WriteLine("Introduceti anul nasterii:");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduceti luna nasteri:");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduceti data nasterii:");
            int day = Convert.ToInt32(Console.ReadLine());
            DateTime dateOfBirth = new DateTime(year, month, day);
            Gender gender = Gender.Female;
            bool isCorectFormat = false;
            do
            {
                Console.WriteLine("Introduceti sexul studentului (M/F):");
                string genderAsString = Console.ReadLine().ToUpper().Trim();

                if (genderAsString == "M")
                {
                    gender = Gender.Male;
                    isCorectFormat = true;
                }
                else if (genderAsString == "F")
                {
                    gender = Gender.Female;
                    isCorectFormat = true;

                }
                else
                {
                    isCorectFormat = false;
                    Console.WriteLine("Format invalid!");
                    Console.WriteLine("Introduceti din nou cu mai multa atentie!");

                }
            } while (isCorectFormat != true);
            university.AddStudent(name, surname, dateOfBirth, gender);
        }

        public static void ShowStudents()
        {
            List<Student> students = university.GetAllStudents();
            if (students.Count != 0)
            {
                foreach (Student student in students)
                {
                    Console.WriteLine(student.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Lista nu contine studenti!");
            }
        }

        public static void DeleteStudent()
        {
            Console.WriteLine("Introduceti id-ul studentului pe care doriti sa-l stergeti!");
            string idAsString = Console.ReadLine();
            int id = Convert.ToInt32(idAsString);
            if (university.DeleteStudent(id) == true)
            {
                Console.WriteLine("Studentul a fost sters!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Id-ul nu a fost gasit!");
                Console.WriteLine();
            }
        }

        public static void UpdateStudent()
        {
            Console.WriteLine("Introduceti id-ul studentului caruia doriti sa ii schimbati numele!");
            string idAsString = Console.ReadLine();
            int id = Convert.ToInt32(idAsString);
            Console.WriteLine("Introduceti noul nume");
            string newName = Console.ReadLine();
            Console.WriteLine("Introduceti noul prenume");
            string newSurname = Console.ReadLine();
            if (university.UpdateStudent(id, newName, newSurname) == true)
            {
                Console.WriteLine("Numele a fost schimbat!");
            }
            else
            {
                Console.WriteLine("Id-ul nu a fost gasit!");
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int option;
            do
            {
                Console.WriteLine("Alegeti o varianta:");
                Console.WriteLine("1 - Adaugare student");
                Console.WriteLine("2 - Afisare toti studentii");
                Console.WriteLine("3 - Stergere student dupa id");
                Console.WriteLine("4 - Updatare nume student dupa id");
                Console.WriteLine("0 - Exit");
                Console.Write("Optiunea dvs.este:");
                string line = Console.ReadLine();
                option = Convert.ToInt32(line);
                Console.WriteLine();
                switch (option)
                {
                    case 0:
                        Console.WriteLine("Case 0");
                        break;
                    case 1:
                        Console.WriteLine("Adaugarea studentului:");
                        Console.WriteLine();
                        ReadStudent();
                        break;
                    case 2:
                        Console.WriteLine("Afisarea studentilor:");
                        Console.WriteLine();
                        ShowStudents();
                        break;
                    case 3:
                        Console.WriteLine("Stergerea studentului:");
                        Console.WriteLine();
                        DeleteStudent();
                        break;
                    case 4:
                        Console.WriteLine("Update nume");
                        Console.WriteLine();
                        UpdateStudent();
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            } while (option != 0);
        }

    }
}
