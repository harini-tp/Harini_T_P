using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.CoustomExceptions;

namespace SIS.Classes
{
    internal class Course
    {
        public int CourseID {  get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string InstructorName { get; set; }
        public List<Enrollment> EnrolledCourses { get; set; }
        public static List<Course> AllCourses { get; private set; } = new List<Course>();

        public Course(int courseID, string courseName, string courseCode, string instructorName)
        {
            try
            {
                Checking.CheckCourseDataValid(courseCode, courseName); 
                CourseID = courseID;
                CourseName = courseName;
                CourseCode = courseCode;
                InstructorName = instructorName;
                EnrolledCourses = new List<Enrollment>();
                AllCourses.Add(this);
            }
            catch (InvalidCourseDataException ex)
            {
                Console.WriteLine($"Course creation failed: {ex.Message}");
            }
        }

        public void AssignTeacher(Teacher teacher)
        {
            try
            {
                Checking.CheckCourseExists(this);
                Checking.CheckTeacherExists(teacher);
                InstructorName = teacher.FirstName + " " + teacher.LastName;
                teacher.AssignedCourses.Add(this);   //Updates list in Teacher class
            }
            catch (CourseNotFoundException ex)
            {
                Console.WriteLine($"Teacher assignment failed: {ex.Message}");
            }
            catch (TeacherNotFoundException ex)
            {
                Console.WriteLine($"Teacher assignment failed: {ex.Message}");
            }
        }

        public void UpdateCourseInfo(string courseCode, string courseName, string instructor)
        {
            try
            {
                Checking.CheckCourseDataValid(courseCode, courseName, instructor);
                CourseName = courseName;
                CourseCode = courseCode;
                InstructorName = instructor;
            }
            catch (InvalidCourseDataException ex)
            {
                Console.WriteLine($"Course update failed: {ex.Message}");
            }
        }

        public void DisplayCourseInfo()
        {
            Console.WriteLine($"Course ID: {CourseID}\nName: {CourseName}\nCode: {CourseCode}\nInstructor: {InstructorName}\n\n");
        }

        public List<Enrollment> GetEnrollments()
        {
            return EnrolledCourses;
        }

        public string GetTeacher()
        {
            return InstructorName;
        }

    }
}
