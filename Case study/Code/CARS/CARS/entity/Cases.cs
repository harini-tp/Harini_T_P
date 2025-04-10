using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.entity
{
    internal class Cases
    {
        public int CaseId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Incidents> Incidents { get; set; }

        public Cases() { }

        public Cases(int caseId, string description, DateTime createdDate, List<Incidents> incidents)
        {
            CaseId = caseId;
            Description = description;
            CreatedDate = createdDate;
            Incidents = incidents;
        }
    }
}
