using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace C__Coding_test.util
{

    internal class DBUtil
    {
        static SqlConnection connect = null;
        static SqlCommand command;
        static SqlDataReader reader;

        public static SqlConnection getDBConn()
        {
            connect = new SqlConnection(@"data source = RAVEN\SQLEXPRESS;initial catalog = OMSDB;integrated security = true;");
            connect.Open();
            return connect;
        }

        public static void test()
        {
            try
            {
                SqlConnection yes = getDBConn();
                Console.WriteLine("Connection made successfuly");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected erroe : {ex.Message}");
            }
        }
        
    }
}
