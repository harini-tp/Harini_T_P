using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSIS
{
    internal class PaymentOperation
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader reader;

        public static void GetAllPayments()
        {
            try
            {
                con = Helper.getConnection();
                string query = "SELECT * FROM Payments";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(
                        $"Payment ID: {reader["payment_id"]}, Student ID: {reader["student_id"]}, " +
                        $"Amount: {reader["amount"]}, " +
                        $"Date: {Convert.ToDateTime(reader["payment_date"]).ToString("yyyy-MM-dd")}");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving payments: " + ex.Message);
            }
        }

        public static void InsertPayment()
        {
            try
            {
                con = Helper.getConnection();

                Console.Write("Enter Payment ID: ");
                int paymentId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Student ID: ");
                int studentId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Payment Amount: ");
                int amount = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Payment Date (yyyy-MM-dd): ");
                string paymentDateInput = Console.ReadLine();
                DateTime paymentDate = Convert.ToDateTime(paymentDateInput).Date;

                string query = "INSERT INTO Payments (payment_id, student_id, amount, payment_date) " +
                               "VALUES (@payment_id, @student_id, @amount, @payment_date)";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@payment_id", paymentId);
                cmd.Parameters.AddWithValue("@student_id", studentId);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@payment_date", paymentDate);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Payment recorded successfully");
                else
                    Console.WriteLine("Payment insertion failed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting payment: " + ex.Message);
            }
        }

        public static void InsertPayment(int paymentId, int studentId, decimal amount, DateTime paymentDate)
        {
            try
            {
                con = Helper.getConnection();

                string query = "INSERT INTO Payments (payment_id, student_id, amount, payment_date) " +
                               "VALUES (@payment_id, @student_id, @amount, @payment_date)";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@payment_id", paymentId);
                cmd.Parameters.AddWithValue("@student_id", studentId);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@payment_date", paymentDate);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Payment recorded successfully");
                else
                    Console.WriteLine("Failed to record payment");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error recording payment: " + ex.Message);
            }
        }
    }
}
