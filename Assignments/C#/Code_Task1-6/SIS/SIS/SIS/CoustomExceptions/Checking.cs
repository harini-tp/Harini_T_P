using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.Classes;

namespace SIS.CoustomExceptions
{
    internal class Checking
    {
        public static void CheckDuplicateEnrollment(Student student,Course course)
        {
            foreach(Enrollment enrollment in student.EnrolledCourses)
            {
                if(enrollment.CourseID == course)
                {
                    throw new DuplicateEnrollmentException($"Student {student.FirstName} is already enrolled in {course.CourseName}");
                }
            }
        }

        public static void CheckCourseExists(Course course)
        {
            if (course == null)
            {
                throw new CourseNotFoundException("Course reference is null");
            }

            bool exist = Course.AllCourses.Contains(course);
            if (!exist)
            {
                throw new CourseNotFoundException($"Course {course.CourseName} does not exist in the system");
            }
        }

        public static void CheckStudentExists(Student student)
        {
            bool exists = Student.AllStudents.Contains(student);

            if (!exists)
            {
                throw new StudentNotFoundException($"Student {student.FirstName} {student.LastName} does not exist in the system");
            }
        }

        public static void CheckTeacherExists(Teacher teacher)
        {
            if (!Teacher.AllTeachers.Contains(teacher))
            {
                throw new TeacherNotFoundException($"Teacher {teacher.FirstName} {teacher.LastName} does not exist in the system");
            }
        }

        public static void CheckPaymentValid(decimal amount, DateTime paymentDate)
        {
            if (amount <= 0)
            {
                throw new PaymentValidationException("Payment amount must be greater than zero");
            }

            if (paymentDate > DateTime.Now)
            {
                throw new PaymentValidationException("Payment date cannot be in the future");
            }

            if (paymentDate < new DateTime(2024, 12, 1))
            {
                throw new PaymentValidationException("Payment date must be after 1st December 2024");
            }
        }

        public static void CheckStudentDataValid(string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new InvalidStudentDataException("Name cannot be empty");

            if (dateOfBirth >= DateTime.Now)
                throw new InvalidStudentDataException("Date of birth must be in the past");

            if (!email.Contains("@") || !email.Contains("."))
                throw new InvalidStudentDataException("Email format is invalid");

            if (phoneNumber.Length != 10 || !phoneNumber.All(char.IsDigit))
                throw new InvalidStudentDataException("Phone number must be 10 digits long");
        }

        public static void CheckCourseDataValid(string courseCode, string courseName)
        {
            if (string.IsNullOrWhiteSpace(courseCode) || courseCode.Length < 4)
                throw new InvalidCourseDataException("Course code must be at least 4 characters long");

            if (string.IsNullOrWhiteSpace(courseName))
                throw new InvalidCourseDataException("Course name cannot be empty");
        }

        public static void CheckCourseDataValid(string courseCode, string courseName, string instructor)
        {
            CheckCourseDataValid(courseCode, courseName); // Reuse

            if (string.IsNullOrWhiteSpace(instructor))
                throw new InvalidCourseDataException("Instructor name cannot be empty");
            
        }

        public static void CheckEnrollmentDataValid(Student student, Course course)
        {
            if (student == null)
                throw new InvalidEnrollmentDataException("Student reference cannot be null.");

            if (course == null)
                throw new InvalidEnrollmentDataException("Course reference cannot be null.");
        }

        public static void ValidateTeacherData(string firstName, string lastName, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email))
            {
                throw new InvalidTeacherDataException("Teacher must have a valid first name, last name, and email.");
            }
        }

        public static void ValidateTeacherUpdate(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name) || !name.Contains(" ") || string.IsNullOrWhiteSpace(email))
            {
                throw new InvalidTeacherDataException("Update failed: Name must contain both first and last name, and email must not be empty.");
            }
        }

        public static void CheckSufficientFunds(decimal amount)
        {
            if (amount < 40000)
            {
                throw new InsufficientFundsException($"Payment of {amount} is insufficient, Minimum requirement is 40000 for initial payment");
            }
        }
    }
}
