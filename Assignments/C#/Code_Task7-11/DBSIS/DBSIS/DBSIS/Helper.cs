using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBSIS
{
    internal class Helper
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader reader;

        public static SqlConnection getConnection()
        {
            con = new SqlConnection(@"data source = RAVEN\SQLEXPRESS;initial catalog = SISDB;integrated security = true;");
            con.Open();
            return con;
        }

        public static void TestConnection()
        {
            try
            {
                using (SqlConnection testCon = getConnection())
                {
                    Console.WriteLine("Connection to SISDB successful");
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
