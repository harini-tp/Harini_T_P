using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Coding_test
{
    internal class Product
    {
        public int productid {  get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int quantityInStock { get; set; }
        public string type { get; set; }

        public Product(int productid, string productName, string description, int price, int quantityInStock, string type)
        {
            this.productid = productid;
            this.productName = productName;
            this.description = description;
            this.price = price;
            this.quantityInStock = quantityInStock;
            this.type = type;
        }
    }
}
