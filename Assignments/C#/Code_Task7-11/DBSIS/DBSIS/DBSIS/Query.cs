using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSIS
{
    internal class Query
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader reader;

        public static void Transaction()
        {
            
            SqlTransaction transaction = null;

            try
            {
                con = Helper.getConnection();
                transaction = con.BeginTransaction();

                Console.Write("Enter Enrollment ID: ");
                int enrollmentId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Student ID: ");
                int studentId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Course ID: ");
                int courseId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Enrollment Date (yyyy-MM-dd): ");
                DateTime enrollmentDate = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Enter Payment ID: ");
                int paymentId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Payment Amount: ");
                int amount = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Payment Date (yyyy-MM-dd): ");
                DateTime paymentDate = Convert.ToDateTime(Console.ReadLine());

                // First Enrollment Part
                string enrollQuery = "INSERT INTO Enrollments (enrollment_id, student_id, course_id, enrollment_date) " +
                                     "VALUES (@enrollment_id, @student_id, @course_id, @enrollment_date)";

                SqlCommand enrollCmd = new SqlCommand(enrollQuery, con, transaction);
                enrollCmd.Parameters.AddWithValue("@enrollment_id", enrollmentId);
                enrollCmd.Parameters.AddWithValue("@student_id", studentId);
                enrollCmd.Parameters.AddWithValue("@course_id", courseId);
                enrollCmd.Parameters.AddWithValue("@enrollment_date", enrollmentDate);

                enrollCmd.ExecuteNonQuery();

                // Next Payment
                string paymentQuery = "INSERT INTO Payments (payment_id, student_id, amount, payment_date) " +
                                      "VALUES (@payment_id, @student_id, @amount, @payment_date)";

                SqlCommand paymentCmd = new SqlCommand(paymentQuery, con, transaction);
                paymentCmd.Parameters.AddWithValue("@payment_id", paymentId);
                paymentCmd.Parameters.AddWithValue("@student_id", studentId);
                paymentCmd.Parameters.AddWithValue("@amount", amount);
                paymentCmd.Parameters.AddWithValue("@payment_date", paymentDate);

                paymentCmd.ExecuteNonQuery();

                // Commit if all goes well
                transaction.Commit();
                Console.WriteLine("Enrollment and payment recorded successfully.");
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                Console.WriteLine("Transaction failed: " + ex.Message);
            }
        }

        public static void DynamicQuery()
        {
            try
            {
                con = Helper.getConnection();

                Console.Write("Enter columns to view from Student table(e.g. first_name, email): ");
                string columns = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(columns))
                {
                    Console.WriteLine("No columns entered");
                    return;
                }

                Console.Write("Enter WHERE condition (e.g., last_name = 'Doe') or press Enter to skip : ");
                string whereCondition = Console.ReadLine();

                Console.Write("Enter ORDER BY column (optional): ");
                string orderBy = Console.ReadLine();

                string query = $"SELECT {columns} FROM Students";

                if (!string.IsNullOrWhiteSpace(whereCondition))
                    query += $" WHERE {whereCondition}";

                if (!string.IsNullOrWhiteSpace(orderBy))
                    query += $" ORDER BY {orderBy}";

                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();

                Console.WriteLine("\nQuery Results:");

                if (!reader.HasRows)
                {
                    Console.WriteLine("No records found");
                }
                else
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader[i] + "  ");
                        }
                        Console.WriteLine();
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing query: " + ex.Message);
            }
        }


        public static void EnrollStudentInCourses()
        {
            try
            {
                con = Helper.getConnection();

                Console.WriteLine("Insert New Student :");
                StudentOperation.InsertStudent();

                Console.Write("\nEnter the Student ID you just used: ");
                int studentId = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nHow many courses do you want to add and enroll the student in? ");
                int courseCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < courseCount; i++)
                {
                    Console.WriteLine($"\nInsert Course {i + 1} :");
                    CourseOperation.InsertCourse();

                    Console.Write("Enter the Course Name you just added: ");
                    string courseName = Console.ReadLine();

                    string getCourseIdQuery = "SELECT course_id FROM Courses WHERE course_name = @course_name";
                    cmd = new SqlCommand(getCourseIdQuery, con);
                    cmd.Parameters.AddWithValue("@course_name", courseName);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int courseId = Convert.ToInt32(reader["course_id"]);
                        reader.Close();

                        Console.Write("Enter Enrollment ID: ");
                        int enrollmentId = Convert.ToInt32(Console.ReadLine());

                        DateTime enrollmentDate = DateTime.Now.Date; 

                        EnrollmentOperation.InsertEnrollment(enrollmentId, studentId, courseId, enrollmentDate);
                    }
                    else
                    {
                        reader.Close();
                        Console.WriteLine("Course not found, Skipping enrollment");
                    }
                }

                Console.WriteLine("\nAll enrollments completed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during enrollment flow: " + ex.Message);
            }
        }

        public static void AssignTeacherToCourse()
        {
            try
            {
                con = Helper.getConnection();

                Console.WriteLine("Insert Teacher Details:");
                TeacherOperation.InsertTeacher();

                Console.WriteLine("\nInsert Course Details:");
                CourseOperation.InsertCourse();

                Console.Write("\nEnter teacher's email to fetch their ID: ");
                string teacherEmail = Console.ReadLine();

                string getTeacherIdQuery = "SELECT teacher_id FROM Teacher WHERE email = @teacher_email";
                cmd = new SqlCommand(getTeacherIdQuery, con);
                cmd.Parameters.AddWithValue("@teacher_email", teacherEmail);

                int teacherId = -1;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    teacherId = Convert.ToInt32(reader["teacher_id"]);
                    reader.Close();
                }
                else
                {
                    reader.Close();
                    Console.WriteLine("Teacher not found");
                    return;
                }

                Console.Write("\nEnter Course name to fetch its ID: ");
                string courseCode = Console.ReadLine();

                string getCourseIdQuery = "SELECT course_id FROM Courses WHERE course_name = @course_code";
                cmd = new SqlCommand(getCourseIdQuery, con);
                cmd.Parameters.AddWithValue("@course_code", courseCode);

                int courseId = -1;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    courseId = Convert.ToInt32(reader["course_id"]);
                    reader.Close();
                }
                else
                {
                    reader.Close();
                    Console.WriteLine("Course not found");
                    return;
                }

                CourseOperation.UpdateCourseTeacher(courseId, teacherId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during teacher assignment flow: " + ex.Message);
            }
        }

        public static void RecordPayment()
        {
            try
            {
                Console.WriteLine("Recording Payment for Student:");

                Console.Write("Enter Payment ID: ");
                int paymentId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Student ID: ");
                int studentId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Payment Amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter Payment Date (yyyy-MM-dd): ");
                DateTime paymentDate = Convert.ToDateTime(Console.ReadLine());

                PaymentOperation.InsertPayment(paymentId, studentId, amount, paymentDate);

                Console.WriteLine("Payment process complete.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in payment flow: " + ex.Message);
            }
        }

        public static void GenerateEnrollmentReport()
        {
            try
            {
                con = Helper.getConnection();

                Console.Write("Enter Course Name to generate enrollment report: ");
                string courseName = Console.ReadLine();

                string getCourseIdQuery = "SELECT course_id FROM Courses WHERE course_name = @course_name";
                cmd = new SqlCommand(getCourseIdQuery, con);
                cmd.Parameters.AddWithValue("@course_name", courseName);
                reader = cmd.ExecuteReader();

                int courseId = -1;
                if (reader.Read())
                {
                    courseId = Convert.ToInt32(reader["course_id"]);
                }
                else
                {
                    Console.WriteLine("Course not found.");
                    reader.Close();
                    return;
                }
                reader.Close();

                string reportQuery = @"SELECT s.student_id, s.first_name, s.last_name, e.enrollment_date 
                               FROM Enrollments e 
                               JOIN Students s ON e.student_id = s.student_id 
                               WHERE e.course_id = @course_id";

                cmd = new SqlCommand(reportQuery, con);
                cmd.Parameters.AddWithValue("@course_id", courseId);
                reader = cmd.ExecuteReader();

                Console.WriteLine($"\nEnrollment Report for '{courseName}':");
                Console.WriteLine("--------------------------------------------------");

                bool hasRows = false;
                while (reader.Read())
                {
                    hasRows = true;
                    Console.WriteLine($"Student ID: {reader["student_id"]}, " +
                                      $"Name: {reader["first_name"]} {reader["last_name"]}, " +
                                      $"Enrollment Date: {Convert.ToDateTime(reader["enrollment_date"]).ToString("yyyy-MM-dd")}");
                }


                if (!hasRows)
                    Console.WriteLine("No students enrolled in this course.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error generating enrollment report: " + ex.Message);
            }
        }
    }
}
