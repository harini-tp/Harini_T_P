using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C__Coding_test.util;

namespace C__Coding_test
{
    internal class Query
    {
        static SqlConnection connect = null;
        static SqlCommand command;
        static SqlDataReader reader;
        public static void createUser()
        {
            connect = DBUtil.getDBConn();
            
            Console.WriteLine("Enter userID :");
            int userid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter username : ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password : ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter role :");
            string role = Console.ReadLine();


            string query = "insert into [User] (userId, username, password, role) values" +
                "(@userid, @username, @password, @role)";

            command = new SqlCommand(query, connect);

            command.Parameters.AddWithValue("@userid", userid);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@role", role);


            int reader = command.ExecuteNonQuery();

            if(reader == 0)
                Console.WriteLine("something went wrong");
            else
                Console.WriteLine("Added Successfully");
        }

        public static void createProduct()
        {
            connect = DBUtil.getDBConn();

            Console.WriteLine("Enter productID :");
            int productid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter productName : ");
            string productname = Console.ReadLine();
            Console.WriteLine("Enter discription : ");
            string discript = Console.ReadLine();
            Console.WriteLine("Enter price :");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter quantityInStock :");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter type :");
            string role = Console.ReadLine();

            string query = "insert into Product (productId, productName, description, price, quantityInStock, type) values" +
                "(@productid, @productname, @discript, @price, @quantity, @role)";

            command = new SqlCommand(query, connect);

            command.Parameters.AddWithValue("@productid", productid);
            command.Parameters.AddWithValue("@productname", productname);
            command.Parameters.AddWithValue("@discript", discript);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@role", role);


            int read = command.ExecuteNonQuery();

            if (read == 0)
                Console.WriteLine("something went wrong");
            else
                Console.WriteLine("Added Successfully");
        }

        public static void getAllProducts()
        {
            connect = DBUtil.getDBConn();

            string query = "select * from Product";
            command = new SqlCommand(query, connect);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader.GetName(i) + ": " + reader[i] + "  ");
                }
                Console.WriteLine();
            }

        }

        public static void getOrderbyUser()
        {

        }

        public static void cancelOrder()
        {

        }
    }
}
