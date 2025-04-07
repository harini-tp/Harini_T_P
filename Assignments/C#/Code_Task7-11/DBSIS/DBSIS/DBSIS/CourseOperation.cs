using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBSIS
{
    internal class CourseOperation
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader reader;

        public static void GetAllCourses()
        {
            try
            {
                con = Helper.getConnection();
                string query = "SELECT * FROM Courses";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(
                        $"ID: {reader["course_id"]}, Name: {reader["course_name"]}, " +
                        $"Credits: {reader["credits"]}, Teacher ID: {reader["teacher_id"]}");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving courses: " + ex.Message);
            }
        }

        public static void UpdateCourseTeacher()
        {
            try
            {
                con = Helper.getConnection();

                Console.Write("Enter Course ID to update: ");
                int courseId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter New Teacher ID: ");
                int teacherId = Convert.ToInt32(Console.ReadLine());

                string query = "UPDATE Courses SET teacher_id = @teacher_id WHERE course_id = @course_id";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@teacher_id", teacherId);
                cmd.Parameters.AddWithValue("@course_id", courseId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Course updated successfully");
                else
                    Console.WriteLine("Update failed. Check if course exists");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating course: " + ex.Message);
            }
        }

        public static void UpdateCourseTeacher(int courseId, int teacherId)
        {
            try
            {
                con = Helper.getConnection();

                string query = "UPDATE Courses SET teacher_id = @teacher_id WHERE course_id = @course_id";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@teacher_id", teacherId);
                cmd.Parameters.AddWithValue("@course_id", courseId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Course updated successfully");
                else
                    Console.WriteLine("Update failed, Check if course exists");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating course: " + ex.Message);
            }
        }

        public static void InsertCourse()
        {
            try
            {
                con = Helper.getConnection();

                Console.Write("Enter Course ID: ");
                int courseId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Course Name: ");
                string courseName = Console.ReadLine();

                Console.Write("Enter Credits: ");
                int credits = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Teacher ID: ");
                int teacherId = Convert.ToInt32(Console.ReadLine());

                string query = "INSERT INTO Courses (course_id, course_name, credits, teacher_id) " +
                               "VALUES (@course_id, @course_name, @credits, @teacher_id)";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@course_id", courseId);
                cmd.Parameters.AddWithValue("@course_name", courseName);
                cmd.Parameters.AddWithValue("@credits", credits);
                cmd.Parameters.AddWithValue("@teacher_id", teacherId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Course inserted successfully");
                else
                    Console.WriteLine("Insertion failed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting course: " + ex.Message);
            }
        }
    }
}
