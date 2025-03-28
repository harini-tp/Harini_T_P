using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Assg_2
{
    internal class Arrays
    {
        public static void array()
        {
            Console.WriteLine("Enter the number of values : ");
            int a = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[a];
            Console.WriteLine("Enter the values : ");
            for (int i = 0; i < a; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("The Average is : {0}", (arr.Average()));
            Console.WriteLine("The Maximum is : {0}", (arr.Max()));
            Console.WriteLine("The Minimum is : {0}", (arr.Min()));
        }

        public static void array2()
        {
            Console.WriteLine("Enter the number of values : ");
            int a = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[a];
            Console.WriteLine("Enter the values : ");
            for (int i = 0; i < a; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("The Total is : {0}", (arr.Sum()));
            Console.WriteLine("The Average is : {0}", (arr.Average()));
            Console.WriteLine("The Maximum is : {0}", (arr.Max()));
            Console.WriteLine("The Minimum is : {0}", (arr.Min()));
            Console.WriteLine("The Ascending order is : ");
            Array.Sort(arr);
            for (int i = 0; i < a; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("The Desending order is : ");
            Array.Reverse(arr);
            for (int i = 0; i < a; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        public static void copyarray()
        {
            Console.WriteLine("Enter the number of values : ");
            int a = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[a];
            Console.WriteLine("Enter the values : ");
            for (int i = 0; i < a; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int[] arr2 = new int[a];
            for (int i = 0; i < a; i++)
            {
                arr2[i] = arr[i]; 
            }
            Console.WriteLine("From the copied array : ");
            for (int i = 0; i < a; i++)
            {
                Console.Write(arr2[i] + " ");
            }
        }
    }
}
