using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Daily.Assg_3
{
    internal class Manager : Employee
    {
        protected int Onsite_allowance;
        protected int Bonus;

        public Manager(int ID, string Name, DateTime DOB, int Salary, int Onsite_Allowance, int Bonus) : base(ID, Name, DOB, Salary)
        {
            this.Onsite_allowance = Onsite_Allowance;
            this.Bonus = Bonus;
        }

        public override int getSalary()
        {
            return Onsite_allowance + Bonus + Salary;
        }


    }
}
