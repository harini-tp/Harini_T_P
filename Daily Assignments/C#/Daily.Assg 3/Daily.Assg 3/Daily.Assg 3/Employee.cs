using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Assg_3
{
    internal class Employee
    {
        protected int ID;
        protected string Name;
        protected DateTime DOB;
        protected int Salary;

        public Employee(int ID, string Name, DateTime DOB, int Salary)
        {
            this.ID = ID;
            this.Name = Name;   
            this.DOB = DOB;
            this.Salary = Salary;
        }

        public virtual int getSalary()
        {
            return Salary;
        }

    }
}
