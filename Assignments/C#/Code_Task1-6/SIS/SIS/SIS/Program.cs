using SIS.Task;
using SIS.Classes;

namespace SIS
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Sis sis = new Sis();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Student Information System ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Enroll Student in Course");
                Console.WriteLine("4. Add Teacher");
                Console.WriteLine("5. Display All Teachers");
                Console.WriteLine("6. Add Course");
                Console.WriteLine("7. Display All Courses");
                Console.WriteLine("8. Assign Teacher to Course");
                Console.WriteLine("9. Make Student Payment");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        sis.AddStudent();
                        break;
                    case "2":
                        sis.DisplayAllStudents();
                        break;
                    case "3":
                        sis.EnrollStudentInCourse();
                        break;
                    case "4":
                        sis.AddTeacher();
                        break;
                    case "5":
                        sis.DisplayAllTeachers();
                        break;
                    case "6":
                        sis.AddCourse();
                        break;
                    case "7":
                        sis.DisplayAllCourses();
                        break;
                    case "8":
                        sis.AssignTeacherToCourse();
                        break;
                    case "9":
                        sis.MakeStudentPayment();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Exiting the system");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again");
                        break;
                }
            }

                //task_3();
                //task_4();
        }

        public static void task_3()
        {
            Task_3 tc = new Task_3();
            //tc.TestStudent();
            //tc.TestCourse();
            //tc.TestEnroll();
            //tc.TestTeacher();
            //tc.TestPayment();
            //tc.TestSis();
        }

        public static void task_4()
        {
            Task_4 tc4 = new Task_4();
            //tc4.Exception1();
            //tc4.Exception2();
            //tc4.Exception3();
            //tc4.Exception4();
            //tc4.Exception5();
            //tc4.Exception6();
            //tc4.Exception7();
            //tc4.Exception8();
            //tc4.Exception9();
            //tc4.Exception10();
        }
    }
}
