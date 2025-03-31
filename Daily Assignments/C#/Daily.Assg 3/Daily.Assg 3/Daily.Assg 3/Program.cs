using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Daily.Assg_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee(123, "Harini", new DateTime(2004, 3, 3), 50000);

            Manager mgr = new Manager(512, "Dharshini", new DateTime(2004, 9, 6), 50000, 4200, 6000);

            Console.WriteLine("=============== Salary Calculation ================");

            Console.WriteLine($"The Salary of employee is {emp.getSalary()}");
            Console.WriteLine($"The Salary of manager is {mgr.getSalary()}");

            Console.WriteLine("====================================================");

            Console.WriteLine("================ Counting Function =================");
            Counter.CountFunction();
            Counter.CountFunction();
            Counter.CountFunction();
            Counter.CountFunction();
            Counter.CountFunction();

            Console.WriteLine("====================================================");

            /*
            public static Distsnce operator ++(Distance d)
            {
                Distance temp = new Distance();
                temp.dist = d.dist + 1;
                return temp;
            }
            */
        }
    }
}
