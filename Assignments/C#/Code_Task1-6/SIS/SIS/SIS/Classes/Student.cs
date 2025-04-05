using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.CoustomExceptions;

namespace SIS.Classes
{
    internal class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Enrollment> EnrolledCourses { get; set; }
        public List<Payment> PaymentHistory { get; set; }

        private static int enroll_id = 0;                   //For ID increment
        private static int payment_id = 0;
        public static List<Student> AllStudents { get; private set; } = new List<Student>();

        public Student(int studentID, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            try
            {
                Checking.CheckStudentDataValid(firstName, lastName, dateOfBirth, email, phoneNumber);

                StudentID = studentID;
                FirstName = firstName;
                LastName = lastName;
                DateOfBirth = dateOfBirth;
                Email = email;
                PhoneNumber = phoneNumber;
                EnrolledCourses = new List<Enrollment>();
                PaymentHistory = new List<Payment>();
                AllStudents.Add(this);
            }
            catch (InvalidStudentDataException ex)
            {
                Console.WriteLine($"Student creation failed: {ex.Message}");
            }
        }

        public void EnrollInCourse(Course course)
        {
            try
            {
                Checking.CheckStudentExists(this);
                Checking.CheckCourseExists(course);
                Checking.CheckDuplicateEnrollment(this, course);
                Enrollment enrollment = new Enrollment(++enroll_id, this, course, DateTime.Now);
                EnrolledCourses.Add(enrollment);           //Updating the list in student class
                course.EnrolledCourses.Add(enrollment);    //Updating the list in course class
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine($"Enrollment failed: {ex.Message}");
            }
            catch (CourseNotFoundException ex)
            {
                Console.WriteLine($"Enrollment failed: {ex.Message}");
            }
            catch (DuplicateEnrollmentException ex)
            {
                Console.WriteLine($"Enrollment failed : {ex.Message}");
            }
        }

        public void UpdateStudentInfo(string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            try
            {
                Checking.CheckStudentDataValid(firstName, lastName, dateOfBirth, email, phoneNumber);

                FirstName = firstName;
                LastName = lastName;
                DateOfBirth = dateOfBirth;
                Email = email;
                PhoneNumber = phoneNumber;
            }
            catch (InvalidStudentDataException ex)
            {
                Console.WriteLine($"Update failed: {ex.Message}");
            }
        }

        public void MakePayment(decimal amount, DateTime paymentDate)
        {
            try
            {
                Checking.CheckStudentExists(this);
                Checking.CheckPaymentValid(amount, paymentDate);  

                Payment payment = new Payment(payment_id++, this, amount, paymentDate);
                PaymentHistory.Add(payment);      //Updating the payment list
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine($"Payment failed: {ex.Message}");
            }
            catch (PaymentValidationException ex)
            {
                Console.WriteLine($"Payment failed: {ex.Message}");
            }
        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine($"Student ID: {StudentID}\nName: {FirstName} {LastName}\nDOB: {DateOfBirth.ToShortDateString()}\nEmail: {Email}\nPhone: {PhoneNumber}\n");
        }

        public List<string> GetEnrolledCourses()
        {
            List<string> courses = new List<string>();
            foreach (var enrollment in EnrolledCourses)
            {
                courses.Add(enrollment.CourseID.CourseName);
            }
            return courses;
        }

        public List<Payment> GetPaymentHistory()
        {
            return PaymentHistory;
        }

        
    }
}
