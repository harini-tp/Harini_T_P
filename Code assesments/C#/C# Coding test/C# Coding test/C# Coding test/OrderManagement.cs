using System.Threading.Channels;
using C__Coding_test.util;

namespace C__Coding_test
{
    internal class OrderManagement
    {
        static void Main(string[] args)
        {
            DBUtil.getDBConn();
            DBUtil.test();

            int j = 0;
            while(j != 6)
            {
                Console.WriteLine($"Enter your choice number from 1 to 6 :" +
                    "\n1. create user\n 2. create product\n 3. get all product" +
                    "\n 4. get order by user \n 5. exit");

                j = Convert.ToInt32(Console.ReadLine());

                switch (j)
                {
                    case 1:
                        Query.createUser();
                        break;

                    case 2:
                        Query.createProduct();
                        break;

                    case 3:
                        Query.cancelOrder();
                        break;

                    case 4:
                        Query.getAllProducts(); 
                        break;

                    case 5:
                        Query.getOrderbyUser();
                        break;

                    case 6:
                        Console.WriteLine("\n\nThank you");
                        break;

                    default :
                        Console.WriteLine("Enter a proper value");
                        break;

                }

            }
            
        }
    }
}
