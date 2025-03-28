using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Assg_2
{
    internal class JaggedArray
    {
        public static void jagged()
        {
            Console.WriteLine("Enter the number of rows : ");
            int i = Convert.ToInt32(Console.ReadLine());
            int[][] jag = new int[i][];

            for (int j = 0; j < i; j++)
            {
                Console.WriteLine($"Enter the number of column in row {j} :");
                int l = Convert.ToInt32(Console.ReadLine());
                jag[j] = new int[l];
                Console.WriteLine($"Enter the values :");
                for (int k = 0; k < l; k++)
                {
                    jag[j][k] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine();

            for (int j = 0;j < jag.Length; j++)
            {
                for (int k = 0;k < jag[j].Length; k++)
                {
                    Console.Write(jag[j][k] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
