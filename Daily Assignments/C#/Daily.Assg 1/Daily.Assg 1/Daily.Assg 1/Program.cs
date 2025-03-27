using System.Threading.Channels;

namespace Daily.Assg_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Write a C# Sharp program to accept two integers and check whether they are equal or not. \r\n");
            CheckEqual();
            Console.WriteLine("2. Write a C# Sharp program to check whether a given number is positive or negative. ");
            PositiveNegative();
            Console.WriteLine("3. Write a C# Sharp program that takes two numbers as input and performs all operations (+,-,*,/) on them and displays the result of that operation.");
            Operations();
            Console.WriteLine("4. Write a C# Sharp program that prints the multiplication table of a number as input.\r\n");
            MultiTable();
            Console.WriteLine("5.  Write a C# program to compute the sum of two given integers. If two values are the same, return the triple of their sum.");
            EqualSum();

            Console.Read();
        }

        public static void CheckEqual()
        {
            int a, b;
            Console.WriteLine("Input First Number :");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input Second Number :");
            b = Convert.ToInt32(Console.ReadLine());
            /*
            if (a == b)
            {
                Console.WriteLine($"{a} and {b} are Equal");
            }
            else
            {
                Console.WriteLine($"{a} and {b} are Not Equal");
            }
            */
            String result = (a == b) ? ($"{a} and {b} are Equal") : ($"{a} and {b} are Not Equal");
            Console.WriteLine(result);
        }

        public static void PositiveNegative()
        {
            int a;
            Console.WriteLine("Enter a Value");
            a = Convert.ToInt32(Console.ReadLine());
            if (a > 0)
            {
                Console.WriteLine($"{a} is a Positive Number");
            }
            else
            {
                Console.WriteLine($"{a} is a Negative Number");
            }
        }

        public static void Operations()
        {
            int a, b;
            char c;
            Console.WriteLine("Input First Number :");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input Operation");
            c = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Input Second Number :");
            b = Convert.ToInt32(Console.ReadLine());

            switch(c)
            {
                case '+':
                    Console.WriteLine($"{a} {c} {b} = {a + b}");
                    break;

                case '-':
                    Console.WriteLine($"{a} {c} {b} = {a - b}");
                    break;

                case '*':
                    Console.WriteLine($"{a} {c} {b} = {a * b}");
                    break;

                case '/':
                    Console.WriteLine($"{a} {c} {b} = {a / b}");
                    break;

                default:
                    Console.WriteLine("enter a valid symbol");
                    break;
            }
        }

        public static void MultiTable()
        {
            int a;
            Console.WriteLine("Enter a Value");
            a = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{a} * {i} = {a * i}");
            }
        }

        public static void EqualSum() 
        {
            int a, b;
            Console.WriteLine("Input First Number :");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input Second Number :");
            b = Convert.ToInt32(Console.ReadLine());
            int ans = (a == b) ? ((a + b) * 3) : (a + b);
            Console.WriteLine(ans);
        }
    }
}
