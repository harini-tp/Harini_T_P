using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.Classes;

namespace SIS.Task
{
    internal class Task_3
    {

        Student student1 = new Student(101, "Caitlyn", "Kiraman", new DateTime(2000, 5, 15), "cait@mail.com", "1234567890");
        Student student2 = new Student(102, "David", "Johnson", new DateTime(1999, 8, 22), "dave@mail.com", "9876543210");
        Student student3 = new Student(107, "April", "Smith", new DateTime(2000, 10, 1), "april@mail.com", "9591529583");
        Student student4 = new Student(100, "Beth", "Michel", new DateTime(1999, 5, 12), "beth@mail.com", "9754283655");

        Course math = new Course(201, "Algebra", "MATH101", "");
        Course bio = new Course(201, "Biology", "BIO401", "");
        Course history = new Course(201, "History", "HIS74", "");

        Teacher teacher1 = new Teacher(1, "Jayce", "Norten", "jay@mail.com", "Algebra");
        Teacher teacher2 = new Teacher(2, "Haley", "Fields", "haley@mail.com", "History");
        Teacher teacher3 = new Teacher(3, "Roy", "Wells", "roy@mail.com", "Biology");



        public void TestStudent()
        {           
            student1.EnrollInCourse(bio);
            student2.EnrollInCourse(history);
            student3.EnrollInCourse(math);
            student3.EnrollInCourse(history);
            student4.EnrollInCourse(math);

            student1.MakePayment(60000, new DateTime(2025, 1, 5));
            student2.MakePayment(50000, new DateTime(2025, 1, 24));
            student3.MakePayment(65000, new DateTime(2025, 2, 15));
            student3.MakePayment(70000, new DateTime(2025, 2, 15));
            student4.MakePayment(65000, new DateTime(2025, 2, 3));
            
            Console.WriteLine($"Student Info : \n");
            student2.DisplayStudentInfo();
            Console.WriteLine($"Student Info : \n");
            student4.DisplayStudentInfo();
            
            List<string> enrolledcourses = student3.GetEnrolledCourses();
            Console.WriteLine("April's Enrolled courses :\n");
            foreach( string enrolledCourse in enrolledcourses )
            {
                Console.WriteLine(enrolledCourse);
            }

            List<Payment> paymenthistory = student3.GetPaymentHistory();
            Console.WriteLine("\nApril's Payment history :\n");
            foreach (Payment paymentHistory in paymenthistory)
            {
                Console.WriteLine($"paymentID : {paymentHistory.PaymentID}\nName : {paymentHistory.StudentID.FirstName}\nAmount : {paymentHistory.Amount}\nMade on : {paymentHistory.PaymentDate.ToShortDateString()}\n\n");
            }
            
        }

        public void TestCourse()
        {
            math.AssignTeacher(teacher2);
            history.AssignTeacher(teacher3);
            bio.AssignTeacher(teacher1);

            bio.DisplayCourseInfo();

            student1.EnrollInCourse(bio);
            student2.EnrollInCourse(history);
            student3.EnrollInCourse(math);
            student3.EnrollInCourse(history);
            student4.EnrollInCourse(math);

            List<Enrollment> courseEnrolled = math.GetEnrollments();
            Console.WriteLine("The enrollments for the course Math :\n");
            foreach( Enrollment enrollment in courseEnrolled )
            {
                Console.WriteLine($"Enrollment ID : {enrollment.EnrollmentID}\nName : {enrollment.StudentID.FirstName}\nCourse Name : {enrollment.CourseID.CourseName}\nEnrolled on : {enrollment.EnrollmentDate.ToShortDateString()}\n\n");
            }

            Console.WriteLine($"The instructor for the course History is : {history.GetTeacher()}");
        }

        public void TestEnroll()
        {
            student1.EnrollInCourse(bio);
            student2.EnrollInCourse(history);
            student3.EnrollInCourse(math);
            student3.EnrollInCourse(history);
            student4.EnrollInCourse(math);

            student1.MakePayment(60000, new DateTime(2025, 1, 5));
            student2.MakePayment(50000, new DateTime(2025, 1, 24));
            student3.MakePayment(65000, new DateTime(2025, 2, 15));
            student3.MakePayment(70000, new DateTime(2025, 2, 15));
            student4.MakePayment(65000, new DateTime(2025, 2, 3));

            
            foreach (var enrolls in student3.EnrolledCourses)
            {
                Console.WriteLine($"The enrollment number {enrolls.EnrollmentID} : made by student {enrolls.StudentID.FirstName}");
            }

            Console.WriteLine("\n\n");

            Console.WriteLine($"The enrollments made by student {student3.FirstName} :");
            foreach(var enrolls in student3.EnrolledCourses )
            {
                Console.WriteLine(enrolls.CourseID.CourseName);
            }

        }

        public void TestTeacher()
        {
            teacher2.DisplayTeacherInfo();

            math.AssignTeacher(teacher2);
            history.AssignTeacher(teacher3);
            bio.AssignTeacher(teacher3);

            Console.WriteLine($"The courses handled by {teacher3.FirstName} :");
            List<Course> course = teacher3.GetAssignedCourse();
            foreach (var assigned in course)
            {
                Console.WriteLine(assigned.CourseName);
            }
        }

        public void TestPayment()
        {
            student1.EnrollInCourse(bio);
            student2.EnrollInCourse(history);
            student3.EnrollInCourse(math);
            student3.EnrollInCourse(history);
            student4.EnrollInCourse(math);

            student1.MakePayment(60000, new DateTime(2025, 1, 5));
            student2.MakePayment(50000, new DateTime(2025, 1, 24));
            student3.MakePayment(65000, new DateTime(2025, 2, 15));
            student3.MakePayment(70000, new DateTime(2025, 2, 15));
            student4.MakePayment(65000, new DateTime(2025, 2, 3));

            foreach (var pay in student3.PaymentHistory)
            {
                Console.WriteLine($"The payment id {pay.PaymentID} was made by {pay.StudentID.FirstName}");
            }

            Console.WriteLine("\n\n");

            foreach (var pay in student3.PaymentHistory)
            {
                Console.WriteLine($"The student {pay.StudentID.FirstName} has paid {pay.Amount}");
            }

            Console.WriteLine("\n\n");

            foreach (var pay in student3.PaymentHistory)
            {
                Console.WriteLine($"The student {pay.StudentID.FirstName} has made payments on {pay.PaymentDate.ToShortDateString()}");
            }
        }

        public void TestSis()
        {

            student1.EnrollInCourse(bio);
            student2.EnrollInCourse(history);
            student3.EnrollInCourse(math);
            student3.EnrollInCourse(history);
            student4.EnrollInCourse(math);

            student1.MakePayment(60000, new DateTime(2025, 1, 5));
            student2.MakePayment(50000, new DateTime(2025, 1, 24));
            student3.MakePayment(65000, new DateTime(2025, 2, 15));
            student3.MakePayment(70000, new DateTime(2025, 2, 15));
            student4.MakePayment(65000, new DateTime(2025, 2, 3));

            Sis info = new Sis();

            Console.WriteLine($"The students enrolled in {math.CourseName} are :");
            List<string> report = info.GenerateEnrollmentReport(math);
            foreach(string name in report)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\n\n");

            Console.WriteLine($"The student {student2.FirstName} has made the payments : ");
            List<string> payments = info.GeneratePaymentReport(student2);
            foreach (string rec in payments)
            {
                Console.WriteLine(rec);
            }

            Console.WriteLine("\n\n");

            (int enrollmentCount, decimal totalPayments) = info.CalculateCourseStatistics(math);
            Console.WriteLine($"The stats for the course {math.CourseName}:");
            Console.WriteLine($"Total Enrollments: {enrollmentCount}");
            Console.WriteLine($"Total Payments Collected: {totalPayments}");

        }
    }
}
