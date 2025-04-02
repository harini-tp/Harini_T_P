using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Assg_4
{
    internal interface IStudent
    {
        int StudentId { get; set; }
        string Name { get; set; }
        double Fees { get; set; }
        void ShowDetails();
    }

    class DayScholar : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Fees { get; set; }

        public DayScholar(int studentId, string name, int fees)
        {
            StudentId = studentId;
            Name = name;
            Fees = fees;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Student ID: {StudentId}\nName: {Name}\nFees: {Fees}");
        }
    }

    class Hosteler : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Fees { get; set; }
        public int AccommodationFees { get; set; }

        public Hosteler(int studentId, string name, int fees, int accommodationFees)
        {
            StudentId = studentId;
            Name = name;
            Fees = fees;
            AccommodationFees = accommodationFees;
        }

        public void ShowDetails()
        {
            double totalFees = Fees + AccommodationFees;
            Console.WriteLine($"Student ID: {StudentId}\nName: {Name}\nFees: {Fees}\nAccommodation Fees: {AccommodationFees}\nTotal Fees: {totalFees}");
        }
    }
}
