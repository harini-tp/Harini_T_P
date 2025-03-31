using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Assg_3
{
    internal class Counter
    {
        private static int count = 0;
        public static void CountFunction()
        {
            count++;
            Console.WriteLine($"Now the function has been called for {count} time(s)");
        }

    }

}
