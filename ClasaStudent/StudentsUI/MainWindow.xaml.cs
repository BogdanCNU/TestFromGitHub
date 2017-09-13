using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UniversityLibrary;

namespace StudentsUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        University university = new University();
        public MainWindow()
        {
            InitializeComponent();
            comboBoxGender.Items.Add(Gender.Female);
            comboBoxGender.Items.Add(Gender.Male);

            university.AddStudent("Popescu", "Ion", new DateTime(1990, 05, 25), Gender.Male);
            university.AddStudent("Marinescu", "Laurentiu", new DateTime(1987, 10, 24), Gender.Male);
            university.AddStudent("Craioveanu", "Gica", new DateTime(1968, 12, 13), Gender.Male);
            university.AddStudent("Dumitrescu", "Ilie", new DateTime(1971, 02, 12), Gender.Male);

            LoadStudents();
        }

        private void LoadStudents()
        {
            List<Student> students = university.GetAllStudents();
            listBoxStudents.ItemsSource = null;
            listBoxStudents.ItemsSource = students;
        }

        private void listBoxStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student selectedStudent = listBoxStudents.SelectedItem as Student;
            if (selectedStudent != null)
            {
                UpdateButton.Content = "Update";
                textBoxFirstName.Text = selectedStudent.Name;
                textBoxLastName.Text = selectedStudent.Surname;
                comboBoxGender.SelectedItem = selectedStudent.Gender;
                comboBoxGender.IsEnabled = false;
                datePickerDOF.SelectedDate = selectedStudent.DateOfBirth;
                datePickerDOF.IsEnabled = false;

            }
            else
            {
                ResetStudent();
                UpdateButton.Content = "Save";
                comboBoxGender.IsEnabled = true;
                datePickerDOF.IsEnabled = true;
            }
        }

        private void ResetStudent()
        {
            textBoxFirstName.Text = null;
            textBoxLastName.Text = null;
            comboBoxGender.SelectedItem = null;
            datePickerDOF.SelectedDate = null;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Student selectedStudent = listBoxStudents.SelectedItem as Student;
            try
            {
               if( university.DeleteStudent(selectedStudent.Id) == true)
                {
                    MessageBox.Show("Studentul a fost sters");
                    ResetStudent();
                    LoadStudents();
                }
               else
                {
                    MessageBox.Show("Studentul nu a fost sters");
                }
            }
             catch(Exception ex)
            {
                MessageBox.Show("Nu a fost niciun student selectat!");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student selectedStudent = listBoxStudents.SelectedItem as Student;
                if (selectedStudent != null)
                {

                    if (string.IsNullOrEmpty(textBoxFirstName.Text) || string.IsNullOrEmpty(textBoxLastName.Text))
                    {
                        MessageBox.Show("Nu ati introdus numele sau prenumele studentului!");
                    }

                    else if (university.UpdateStudent(selectedStudent.Id, textBoxFirstName.Text, textBoxLastName.Text) == true)
                    {
                        MessageBox.Show("Studentul a fost updatat!");
                        LoadStudents();
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(textBoxFirstName.Text))
                    {
                        MessageBox.Show("Nu ati introdus numele studentului!");
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxLastName.Text))
                    {
                        MessageBox.Show("Nu ati introdus prenumele studentului!");
                        return;
                    }
                    if(comboBoxGender.SelectedItem == null)
                    {
                        MessageBox.Show("Nu ati introdus sexul studentului!");
                        return;
                    }
                    if(datePickerDOF.SelectedDate == null)
                    {
                        MessageBox.Show("Nu ati introdus data nasterii a studentului!");
                        return;
                    }
                    university.AddStudent(textBoxFirstName.Text, textBoxLastName.Text, datePickerDOF.SelectedDate.Value, (Gender)comboBoxGender.SelectedItem);
                    LoadStudents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddNewButton_Click(object sender, RoutedEventArgs e)
        {
            listBoxStudents.SelectedItem = null;
            
            
        }
    }
}
