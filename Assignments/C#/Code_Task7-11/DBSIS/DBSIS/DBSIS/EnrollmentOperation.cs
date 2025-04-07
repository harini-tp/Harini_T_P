using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSIS
{
    internal class EnrollmentOperation
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader reader;

        public static void GetAllEnrollments()
        {
            try
            {
                con = Helper.getConnection();
                string query = "SELECT * FROM Enrollments";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(
                        $"Enrollment ID: {reader["enrollment_id"]}, Student ID: {reader["student_id"]}, " +
                        $"Course ID: {reader["course_id"]}, " +
                        $"Date: {Convert.ToDateTime(reader["enrollment_date"]).ToString("yyyy-MM-dd")}");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving enrollments: " + ex.Message);
            }
        }

        public static void InsertEnrollment()
        {
            try
            {
                con = Helper.getConnection();

                Console.Write("Enter Enrollment ID: ");
                int enrollmentId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Student ID: ");
                int studentId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Course ID: ");
                int courseId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Enrollment Date (yyyy-MM-dd): ");
                string dateInput = Console.ReadLine();
                DateTime enrollmentDate = Convert.ToDateTime(dateInput).Date;

                string query = "INSERT INTO Enrollments (enrollment_id, student_id, course_id, enrollment_date) " +
                               "VALUES (@enrollment_id, @student_id, @course_id, @enrollment_date)";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@enrollment_id", enrollmentId);
                cmd.Parameters.AddWithValue("@student_id", studentId);
                cmd.Parameters.AddWithValue("@course_id", courseId);
                cmd.Parameters.AddWithValue("@enrollment_date", enrollmentDate);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Enrollment inserted successfully.");
                else
                    Console.WriteLine("Insertion failed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting enrollment: " + ex.Message);
            }
        }

        public static void InsertEnrollment(int enrollmentId, int studentId, int courseId, DateTime enrollmentDate)
        {
            try
            {
                con = Helper.getConnection();

                string query = "INSERT INTO Enrollments (enrollment_id, student_id, course_id, enrollment_date) " +
                               "VALUES (@enrollment_id, @student_id, @course_id, @enrollment_date)";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@enrollment_id", enrollmentId);
                cmd.Parameters.AddWithValue("@student_id", studentId);
                cmd.Parameters.AddWithValue("@course_id", courseId);
                cmd.Parameters.AddWithValue("@enrollment_date", enrollmentDate);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Enrollment inserted successfully.");
                else
                    Console.WriteLine("Enrollment insertion failed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting enrollment: " + ex.Message);
            }
        }
    }
}
