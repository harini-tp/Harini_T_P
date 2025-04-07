using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBSIS
{
    internal class StudentOperation
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader reader;
        public static void GetAllStudents()
        {
            try
            {
                con = Helper.getConnection();
                string query = "SELECT * FROM Students";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(
                         $"ID: {reader["student_id"]}, Name: {reader["first_name"]} {reader["last_name"]}, " +
                         $"DOB: {Convert.ToDateTime(reader["date_of_birth"]).ToString("yyyy-MM-dd")}, " +
                         $"Email: {reader["email"]}, Phone: {reader["phone_number"]}");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving students: " + ex.Message);
            }
        }

        public static void InsertStudent()
        {
            try
            {
                con = Helper.getConnection();

                Console.Write("Enter Student ID: ");
                int studentId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine();

                Console.Write("Enter Date of Birth (yyyy-MM-dd): ");
                string dobInput = Console.ReadLine();
                DateTime dob = Convert.ToDateTime(dobInput).Date;

                Console.Write("Enter Email: ");
                string email = Console.ReadLine();

                Console.Write("Enter Phone Number: ");
                string phone = Console.ReadLine();

                string query = "INSERT INTO Students (student_id, first_name, last_name, date_of_birth, email, phone_number) " +
                               "VALUES (@student_id, @first_name, @last_name, @date_of_birth, @email, @phone_number)";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@student_id", studentId);
                cmd.Parameters.AddWithValue("@first_name", firstName);
                cmd.Parameters.AddWithValue("@last_name", lastName);
                cmd.Parameters.AddWithValue("@date_of_birth", dob);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone_number", phone);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Student inserted successfully..");
                else
                    Console.WriteLine("Insertion failed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting student: " + ex.Message);
            }
        }

        public static void UpdateStudent()
        {
            try
            {
                con = Helper.getConnection();

                Console.Write("Enter Student ID to update: ");
                int studentId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter New First Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter New Last Name: ");
                string lastName = Console.ReadLine();

                Console.Write("Enter New Date of Birth (yyyy-MM-dd): ");
                string dobInput = Console.ReadLine();
                DateTime dob = Convert.ToDateTime(dobInput).Date;

                Console.Write("Enter New Email: ");
                string email = Console.ReadLine();

                Console.Write("Enter New Phone Number: ");
                string phone = Console.ReadLine();

                string query = "UPDATE Students SET first_name = @first_name, last_name = @last_name, " +
                               "date_of_birth = @date_of_birth, email = @email, phone_number = @phone_number " +
                               "WHERE student_id = @student_id";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@first_name", firstName);
                cmd.Parameters.AddWithValue("@last_name", lastName);
                cmd.Parameters.AddWithValue("@date_of_birth", dob);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone_number", phone);
                cmd.Parameters.AddWithValue("@student_id", studentId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Student updated successfully");
                else
                    Console.WriteLine("Update failed. Check if student exists");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating student: " + ex.Message);
            }
        }

        public static void RunDynamicStudentQuery()
        {
            try
            {
                con = Helper.getConnection();

                Console.Write("Enter columns to view (e.g., first_name, email): ");
                string columns = Console.ReadLine();

                Console.Write("Enter WHERE condition (e.g., last_name = 'Doe') or press Enter to skip: ");
                string whereCondition = Console.ReadLine();

                Console.Write("Enter ORDER BY column (e.g., student_id) or press Enter to skip: ");
                string orderBy = Console.ReadLine();

                string query = $"SELECT {columns} FROM Students";

                if (!string.IsNullOrWhiteSpace(whereCondition))
                    query += $" WHERE {whereCondition}";

                if (!string.IsNullOrWhiteSpace(orderBy))
                    query += $" ORDER BY {orderBy}";

                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();

                
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader.GetName(i) + ": " + reader[i] + "  ");
                    }
                    Console.WriteLine();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error running dynamic query: " + ex.Message);
            }
        }
    }
}
