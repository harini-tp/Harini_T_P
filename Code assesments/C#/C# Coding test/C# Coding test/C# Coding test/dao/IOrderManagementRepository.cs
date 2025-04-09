using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Coding_test.dao
{
    internal class OrderProcessor
    {
        interface IOrderManagementRepository
        {
            public void createOrder(User user, List<Product> product);
            public void cancelOrder(int userId, int orderId);
            public void createProduct(User user, Product product);
            public void createUser(User user);
            public void getAllProducts();
            public void getOrderByUser(User user);
        }
    }
}
