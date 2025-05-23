﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.entity
{
    internal class Victims
    {
        public int VictimID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public Victims() { }

        public Victims(int victimID, string firstName, string lastName, DateTime dateOfBirth, string gender, string address, string phoneNumber)
        {
            VictimID = victimID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
