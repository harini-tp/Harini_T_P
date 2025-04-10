using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CARS.entity;

namespace CARS.dao
{
    internal interface ICrimeAnalysisService
    {
        bool CreateIncident(Incidents incident);

        bool UpdateIncidentStatus(string status, int incidentId);

        List<Incidents> GetIncidentsInDateRange(DateTime startDate, DateTime endDate);

        List<Incidents> SearchIncidents(string incidentType);

        Reports GenerateIncidentReport(Incidents incident);

        Cases CreateCase(string caseDescription, List<Incidents> incidents);

        Cases GetCaseDetails(int caseId);

        bool UpdateCaseDetails(Cases updatedCase);

        List<Cases> GetAllCases();
    }
}
