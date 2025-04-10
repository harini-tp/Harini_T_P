using CARS.entity;
using CARS.util;
using CARS.dao;

namespace CARS.main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CrimeAnalysisServiceImpl service = new CrimeAnalysisServiceImpl();
            //DBConnection.getConnection();
            //DBConnection.TestConnection();

            /*
            try
            {
                Console.WriteLine("\n--- Create a New Incident ---");

                Console.Write("Enter Incident ID: ");
                int incidentId = Convert.ToInt32(Console.ReadLine());
                //service.CheckIdExist(incidentId);

                Console.Write("Enter Incident Type: ");
                string incidentType = Console.ReadLine();

                Console.Write("Enter Date of Incident (yyyy-mm-dd): ");
                DateTime incidentDate = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Enter Latitude: ");
                float latitude = Convert.ToSingle(Console.ReadLine());

                Console.Write("Enter Longitude: ");
                float longitude = Convert.ToSingle(Console.ReadLine());

                Console.Write("Enter Description: ");
                string description = Console.ReadLine();

                Console.WriteLine("Enter the status:");
                string status = Console.ReadLine();

                Console.Write("Enter Victim ID: ");
                int victimID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Suspect ID: ");
                int suspectID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Agency ID: ");
                int agencyID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Case ID (Hit enter on no caseID): ");
                string caseID = Console.ReadLine();

                int? caseId = string.IsNullOrEmpty(caseID) ? (int?)null : Convert.ToInt32(caseID);

                Incidents newIncident = new Incidents(incidentId, incidentType, incidentDate, latitude, longitude, description, status, victimID, suspectID, agencyID, caseId);

                bool success = service.CreateIncident(newIncident);

                Console.WriteLine(success ? "Incident added successfully" : "Failed to add incident");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
            */
            /*
            try
            {
                Console.WriteLine("\n--- Update Incident Status ---");
                Console.Write("Enter Incident ID: ");
                int incidentId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter new Status: ");
                string status = Console.ReadLine();

                bool updated = service.updateIncidentStatus(status, incidentId);

                Console.WriteLine(updated? "Incident status updated successfully" : "Failed to update incident status");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
            */
            /*
            try
            {
                Console.WriteLine("--- Get Incidents in Date Range ---");
                Console.Write("Enter start date (yyyy-mm-dd): ");
                DateTime startDate = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Enter end date (yyyy-mm-dd): ");
                DateTime endDate = Convert.ToDateTime(Console.ReadLine());

                List<Incidents> incidentsInRange = service.getIncidentsInDateRange(startDate, endDate);

                if (incidentsInRange.Count == 0)
                {
                    Console.WriteLine("No incidents found in the given date range.");
                }
                else
                {
                    foreach (var incident in incidentsInRange)
                    {
                        Console.WriteLine($"\nIncident ID: {incident.IncidentId}\nIncident Type: {incident.IncidentType}\n" +
                            $"Date: {incident.IncidentDate.ToShortDateString()}\nLatitude: {incident.Latitude}\n" +
                            $"Longitude: {incident.Longitude}\nLongitude: {incident.Longitude}\nStatus: {incident.Status}\n" +
                            $"Victim ID: {incident.VictimID}\nSuspect ID: {incident.SuspectID}\nAgency ID: {incident.AgencyID}\n" +
                            $"Case ID: {(incident.CaseID.HasValue ? incident.CaseID.ToString() : "NULL")}");

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
            */
            /*
            try
            {
                Console.WriteLine("--- Search Incidents by Type ---");
                Console.Write("Enter Incident Type to search (e.g Robbery, Theft): ");
                string type = Console.ReadLine();

                List<Incidents> results = service.searchIncidents(type);

                if (results.Count > 0)
                {
                    Console.WriteLine("Incidents matching the type:");
                    foreach (var incident in results)
                    {
                        Console.WriteLine($"ID: {incident.IncidentId}, Type: {incident.IncidentType}, " +
                            $"Date: {incident.IncidentDate.ToShortDateString()}, Status: {incident.Status}");
                    }
                }
                else
                {
                    Console.WriteLine("No incidents found with the given type.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during incident search: " + ex.Message);
            }
            */
            /*
            try
            {
                Console.WriteLine("--- Report Generation ---");
                Console.Write("Enter Incident ID to generate report: ");
                int incidentId = Convert.ToInt32(Console.ReadLine());

                Incidents incident = service.GetIncidentById(incidentId);

                if (incident != null)
                {
                    Console.WriteLine("\nIncident Found:");
                    Console.WriteLine($"ID: {incident.IncidentId}, Type: {incident.IncidentType}, Date: {incident.IncidentDate}");

                    Reports report = service.GenerateIncidentReport(incident);

                    if (report != null)
                    {
                        Console.WriteLine("\n--- Report Details ---");
                        Console.WriteLine($"Report ID: {report.ReportID}");
                        Console.WriteLine($"Incident ID: {report.IncidentID}");
                        Console.WriteLine($"Officer ID: {report.ReportingOfficerID}");
                        Console.WriteLine($"Report Date: {report.ReportDate.ToShortDateString()}");
                        Console.WriteLine($"Details: {report.ReportDetails}");
                        Console.WriteLine($"Status: {report.Status}");
                    }
                    else
                    {
                        Console.WriteLine("No report found for the given incident");
                    }
                }
                else
                {
                    Console.WriteLine("Incident not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            */
            /*
            try
            {
                Console.WriteLine("\n--- Creating New Case ---");
                Console.Write("Enter Case ID: ");
                int caseId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Case Description: ");
                string description = Console.ReadLine();

                List<Incidents> selectedIncidents = new List<Incidents>();

                Console.Write("Enter number of incidents to associate with this case: ");
                int count = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < count; i++)
                {
                    Console.Write($"Enter Incident ID {i + 1}: ");
                    int incidentId = Convert.ToInt32(Console.ReadLine());

                    
                    Incidents incident = new Incidents();
                    incident.IncidentId = incidentId;

                    selectedIncidents.Add(incident);
                }

                Cases newCase = service.createCase(caseId, description, selectedIncidents);

                if (newCase != null)
                {
                    Console.WriteLine("\nCase Created Successfully!");
                    Console.WriteLine($"Case ID: {newCase.CaseId}");
                    Console.WriteLine($"Description: {newCase.Description}");
                    Console.WriteLine($"Created Date: {newCase.CreatedDate.ToShortDateString()}");
                    Console.WriteLine("Associated Incidents:");
                    foreach (var inc in newCase.Incidents)
                    {
                        Console.WriteLine($"- Incident ID: {inc.IncidentId}");
                    }
                }
                else
                {
                    Console.WriteLine("Case creation failed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            */
            /*
            try
            {
                Console.WriteLine("\n--- Get Details of a Specific Case ---");

                // Ask only for the Case ID
                Console.Write("Enter Case ID: ");
                int caseId = Convert.ToInt32(Console.ReadLine());

                // Call the service to fetch the case details by Case ID
                Cases caseDetails = service.getCaseDetails(caseId);

                // Display the case details if found
                if (caseDetails != null)
                {
                    Console.WriteLine("\nCase Details:");
                    Console.WriteLine($"Case ID: {caseDetails.CaseId}");
                    Console.WriteLine($"Description: {caseDetails.Description}");
                    Console.WriteLine($"Created Date: {caseDetails.CreatedDate.ToShortDateString()}");

                    Console.WriteLine("\nRelated Incidents:");
                    foreach (var incident in caseDetails.Incidents)
                    {
                        Console.WriteLine($"Incident ID: {incident.IncidentId}, Incident Type: {incident.IncidentType}, Date: {incident.IncidentDate.ToShortDateString()}");
                    }
                }
                else
                {
                    Console.WriteLine("Case not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            */
            /*
            try
            {
                Console.WriteLine("\n--- Update Case Details ---");

                Console.Write("Enter Case ID to update: ");
                int caseId = Convert.ToInt32(Console.ReadLine());

                Cases existingCase = service.getCaseDetails(caseId);

                if (existingCase == null)
                {
                    Console.WriteLine("Case not found.");
                    return;
                }

                Console.WriteLine("Select the field to update:");
                Console.WriteLine("1. Description");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter new Description: ");
                        string newDescription = Console.ReadLine();
                        existingCase.Description = newDescription;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        return;
                }

                bool success = service.updateCaseDetails(existingCase);
                Console.WriteLine(success ? "Case updated successfully." : "Failed to update case.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
            */
            /*
            try
            {
                Console.WriteLine("\n--- Get All Cases with Incidents ---");

                List<Cases> allCases = service.getAllCases();

                if (allCases.Count == 0)
                {
                    Console.WriteLine("No cases found.");
                    return;
                }

                Console.WriteLine("List of all cases:");
                foreach (var caseItem in allCases)
                {
                    Console.WriteLine($"Case ID: {caseItem.CaseId}, Description: {caseItem.Description}, Created Date: {caseItem.CreatedDate}");

                    if (caseItem.Incidents != null && caseItem.Incidents.Count > 0)
                    {
                        Console.WriteLine("Incidents:");
                        foreach (var incident in caseItem.Incidents)
                        {
                            Console.WriteLine($"Incident ID: {incident.IncidentId}, Type: {incident.IncidentType}, Date: {incident.IncidentDate}, Description: {incident.Description}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No incidents for this case.");
                    }

                    Console.WriteLine(); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
            */

        }
    }
}
