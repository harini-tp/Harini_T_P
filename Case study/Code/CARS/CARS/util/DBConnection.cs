using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CARS.util
{
    internal class DBConnection
    {
        static SqlConnection connection = null;

        public static SqlConnection getConnection()
        {
            connection = new SqlConnection(@"data source = RAVEN\SQLEXPRESS;initial catalog = CARSDB;integrated security = true;");
            connection.Open();
            return connection;
        }

        public static void TestConnection()
        {
            try
            {
                using (SqlConnection testCon = getConnection())
                {
                    Console.WriteLine("Connection to CARSDB successful");
                    testCon.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection failed: " + ex.Message);
            }
        }
    }
}
