using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.CoustomExceptions;

namespace SIS.Classes
{
    internal class Teacher
    {
        public int TeacherID {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Expertise { get; set; }
        public List<Course> AssignedCourses { get; set; }
        public static List<Teacher> AllTeachers { get; private set; } = new List<Teacher>();

        public Teacher(int teacherID, string firstName, string lastName, string email, string expertise)
        {
            try
            {
                Checking.ValidateTeacherData(firstName, lastName, email);
                TeacherID = teacherID;
                FirstName = firstName;
                LastName = lastName;
                Email = email;
                Expertise = expertise;
                AssignedCourses = new List<Course>();
                AllTeachers.Add(this);
            }
            catch (InvalidTeacherDataException ex)
            {
                Console.WriteLine($"Teacher creation failed: {ex.Message}");
            }
        }
        public void UpdateTeacherInfo(string name, string email, string expertise)
        {
            try
            {
                Checking.ValidateTeacherUpdate(name, email);
                FirstName = name.Split(' ')[0];
                LastName = name.Split(' ')[1];
                Email = email;
                Expertise = expertise;
            }
            catch (InvalidTeacherDataException ex)
            {
                Console.WriteLine($"Teacher update failed: {ex.Message}");
            }
        }

        public void DisplayTeacherInfo()
        {
            Console.WriteLine($"Teacher ID: {TeacherID}\nName: {FirstName} {LastName}\nEmail: {Email}\n\n");
        }

        public List<Course> GetAssignedCourse()
        {
            return AssignedCourses;
        }
    }
}
