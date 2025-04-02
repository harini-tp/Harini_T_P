namespace Daily.Assg_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------- Seconds finder --------------------");
            Seconds sec = new Seconds();
            sec.Hour = 1;
            Console.WriteLine(sec.Hour);
            sec.Hour = 4;
            Console.WriteLine(sec.Hour);
            Console.WriteLine("------------------------------------------------------\n\n");

            Console.WriteLine("------------------ Furniture -------------------------");
            
            Chair chair = new Chair();
            chair.GetDetails("Sandal Wood", "Brown", 4);
            chair.Display();

            BookShelf bookshelf = new BookShelf();
            bookshelf.GetDetails("Teak Wood", "Blue", 5);
            bookshelf.Display();

            //Furniture furniture = new Furniture(); //cant create a object of abstract type

            Console.WriteLine("------------------------------------------------------\n\n");

            Console.WriteLine("------------------ String program -------------------------");

            string name = Console.ReadLine();
            Console.WriteLine($"Count of the name is {name.Length}");

            string rev = new string(name.Reverse().ToArray());
            Console.WriteLine($"The reverse of the name is {rev}");

            Console.Write("Enter first word: ");
            string word1 = Console.ReadLine();
            Console.Write("Enter second word: ");
            string word2 = Console.ReadLine();

            Console.WriteLine(string.Equals(word1, word2, StringComparison.OrdinalIgnoreCase)
                ? "The words are the same."
                : "The words are different.");
        
            Console.WriteLine("------------------------------------------------------\n\n");

            Console.WriteLine("------------------ Student detail -------------------------");

            Student student = new Student(101, "Catlyin", "10th", "2nd", "Science");
            student.GetMarks();
            student.DisplayData();
            student.DisplayResult();

            Console.WriteLine("------------------------------------------------------\n\n");

            Console.WriteLine("------------------ Student detail -------------------------");

            DayScholar dayScholar = new DayScholar(101, "Vi", 50000);
            Hosteler resident = new Hosteler(102, "Yuki", 50000, 20000);

            Console.WriteLine("Day Scholar Details:");
            dayScholar.ShowDetails();

            Console.WriteLine("\nHosteler Details:");
            resident.ShowDetails();

            Console.WriteLine("------------------------------------------------------\n\n");

            Console.WriteLine("------------------ Account detail -------------------------");
            
            BankAccount account = new BankAccount("Miles", 5000);

            try
            {
                Console.Write("Enter amount to transfer: ");
                int amount = Convert.ToInt32((Console.ReadLine()));
                account.TransferFunds(amount);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a numeric value.");
            }

            Console.WriteLine("------------------------------------------------------\n\n");
        }
    }
}
