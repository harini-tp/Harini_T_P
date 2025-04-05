using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.CoustomExceptions;

namespace SIS.Classes
{
    internal class Enrollment
    {
        public int EnrollmentID {  get; set; }
        public Student StudentID { get; set; }
        public Course CourseID { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public Enrollment(int enrollmentID, Student studentID, Course courseID, DateTime enrollmentDate)
        {
            try
            {
                Checking.CheckEnrollmentDataValid(studentID, courseID);
                EnrollmentID = enrollmentID;
                StudentID = studentID;
                CourseID = courseID;
                EnrollmentDate = enrollmentDate;
            }
            catch (InvalidEnrollmentDataException ex)
            {
                Console.WriteLine($"Enrollment creation failed: {ex.Message}");
            }
        }

        public Student GetStudent()
        {
            return StudentID;
        }

        public Course GetCourse()
        {
            return CourseID;
        }

    }
}
