using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.CoustomExceptions;

namespace SIS.Classes
{
    internal class Payment
    {
        public int PaymentID {  get; set; }
        public Student StudentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public Payment(int paymentID, Student studentID, decimal amount, DateTime paymentDate)
        {
            try
            {
                Checking.CheckSufficientFunds(amount);

                PaymentID = paymentID;
                StudentID = studentID;
                Amount = amount;
                PaymentDate = paymentDate;
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Payment failed: {ex.Message}");
            }
        }

        public Student GetStudent()
        {
            return StudentID;
        }

        public decimal GetPaymentAmount()
        {
            return Amount;
        }
        public DateTime GetPaymentDate()
        {
            return PaymentDate;
        }
    }
}
