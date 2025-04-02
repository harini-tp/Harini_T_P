using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Assg_4
{
    class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string msg) : base(msg) { }
    }

    class BankAccount
    {
        public string AccountHolder { get; set; }
        public int Balance { get; private set; }

        public BankAccount(string accountHolder, int initialBalance)
        {
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        public void TransferFunds(int amount)
        {
            if (amount > Balance)
            {
                throw new InsufficientFundsException("Insufficient balance for the transfer.");
            }
            Balance -= amount;
            Console.WriteLine($"Transfer successful. New balance: {Balance}");
        }
    }
}
