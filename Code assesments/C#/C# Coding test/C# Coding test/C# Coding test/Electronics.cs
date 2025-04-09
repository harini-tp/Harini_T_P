using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Coding_test
{
    internal class Electronics : Product
    {
        public Electronics(int productid, string productName, string description, int price, int quantityInStock, string type, string brand, int warrantyPeriod) : base(productid, productName, description, price, quantityInStock, type)
        {
            this.brand = brand;
            this.warrantyPeriod = warrantyPeriod;
        }

        public string brand {  get; set; }
        public int warrantyPeriod { get; set; }
    }
}
