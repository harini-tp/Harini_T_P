using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.entity
{
    internal class Officers
    {
        public int OfficerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BadgeNumber { get; set; }
        public string Rank { get; set; }
        public string ContactInformation { get; set; }
        public int AgencyID { get; set; }

        public Officers() { }

        public Officers(int officerID, string firstName, string lastName, string badgeNumber, string rank, string contactInformation, int agencyID)
        {
            OfficerID = officerID;
            FirstName = firstName;
            LastName = lastName;
            BadgeNumber = badgeNumber;
            Rank = rank;
            ContactInformation = contactInformation;
            AgencyID = agencyID;
        }
    }
}
