using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSIS
{
    internal class Tasks
    {
        public static void task_7()
        {
            /*
            Helper.getConnection();
            Helper.TestConnection();
            */


            //StudentOperation.GetAllStudents();
            //CourseOperation.GetAllCourses();
            //EnrollmentOperation.GetAllEnrollments();
            //TeacherOperation.GetAllTeachers();
            //PaymentOperation.GetAllPayments();

            //StudentOperation.InsertStudent();
            //EnrollmentOperation.InsertEnrollment();
            //PaymentOperation.InsertPayment();
            //StudentOperation.UpdateStudent();
            //TeacherOperation.InsertTeacher();
            CourseOperation.UpdateCourseTeacher();
            //CourseOperation.InsertCourse();

            //Query.Transaction();
            //Query.DynamicQuery();
        }

        public static void task_8()
        {
            Query.EnrollStudentInCourses();
        }

        public static void task_9()
        {
            Query.AssignTeacherToCourse();
        }

        public static void task_10()
        {
            Query.RecordPayment();
        }

        public static void task_11()
        {
            Query.GenerateEnrollmentReport();
        }

    }
}
