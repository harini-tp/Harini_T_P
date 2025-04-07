using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSIS
{
    internal class TeacherOperation
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader reader;

        public static void GetAllTeachers()
        {
            try
            {
                con = Helper.getConnection();
                string query = "SELECT * FROM Teacher";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(
                        $"ID: {reader["teacher_id"]}, Name: {reader["first_name"]} {reader["last_name"]}, " +
                        $"Email: {reader["email"]}");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving teachers: " + ex.Message);
            }
        }

        public static void InsertTeacher()
        {
            try
            {
                con = Helper.getConnection();

                Console.Write("Enter Teacher ID: ");
                int teacherId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine();

                Console.Write("Enter Email: ");
                string email = Console.ReadLine();

                string query = "INSERT INTO Teacher (teacher_id, first_name, last_name, email) " +
                               "VALUES (@teacher_id, @first_name, @last_name, @email)";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@teacher_id", teacherId);
                cmd.Parameters.AddWithValue("@first_name", firstName);
                cmd.Parameters.AddWithValue("@last_name", lastName);
                cmd.Parameters.AddWithValue("@email", email);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Teacher inserted successfully.");
                else
                    Console.WriteLine("Insertion failed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting teacher: " + ex.Message);
            }
        }
    }
}
