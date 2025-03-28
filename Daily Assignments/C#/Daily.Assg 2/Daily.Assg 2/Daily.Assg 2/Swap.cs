using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Daily.Assg_2
{
    internal class Swap
    {
        public static void swaping()
        {
            int a, b, c;
            Console.WriteLine("Enter the value of a :");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the value of b :");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Before the swap a : {a} and b : {b}");
            c = a;
            a = b;
            b = c;
            Console.WriteLine($"After the swap a : {a} and b : {b}");

        }
    }
}
