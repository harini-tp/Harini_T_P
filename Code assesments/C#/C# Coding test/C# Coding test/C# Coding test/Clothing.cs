using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Coding_test
{
    internal class Clothing : Product
    {
        public Clothing(int productid, string productName, string description, int price, int quantityInStock, string type, string size, string colour) : base(productid, productName, description, price, quantityInStock, type)
        {
            this.size = size;
            this.colour = colour;
        }

        public string size {  get; set; }
        public string colour { get; set; }
    }
}
