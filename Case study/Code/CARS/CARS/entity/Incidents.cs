using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.entity
{
    internal class Incidents
    {
        public int IncidentId { get; set; }
        public string IncidentType { get; set; }
        public DateTime IncidentDate { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int VictimID { get; set; }
        public int SuspectID { get; set; }
        public int AgencyID { get; set; }
        public int? CaseID { get; set; }

        public Incidents() { }


        public Incidents(int incidentId,string incidentType, DateTime incidentDate, float latitude, float longitude, string description, string status, int victimID, int suspectID, int agencyID, int? caseID)
        {
            IncidentId = incidentId;
            IncidentType = incidentType;
            IncidentDate = incidentDate;
            Latitude = latitude;
            Longitude = longitude;
            Description = description;
            Status = status;
            VictimID = victimID;
            SuspectID = suspectID;
            AgencyID = agencyID;    
            CaseID = caseID;
        }
    }
}
