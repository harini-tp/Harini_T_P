using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CARS.entity;
using CARS.util;
using CARS.exception;
using System.Data.Common;

namespace CARS.dao
{
    internal class CrimeAnalysisServiceImpl
    {
        SqlConnection con = null;
        SqlCommand cmd;
        SqlDataReader reader;
        private List<Cases> caseList = new List<Cases>();

        public bool CreateIncident(Incidents incident)
        {
            bool isInserted = false;

            try
            {
                using (con = DBConnection.getConnection())
                {
                    string query = @"INSERT INTO Incidents 
                    (IncidentID, IncidentType, IncidentDate, Latitude, Longitude, Description, Status, VictimID, SuspectID, AgencyID, CaseID) 
                     VALUES (@IncidentID, @IncidentType, @IncidentDate, @Latitude, @Longitude, @Description, @Status, @VictimID, @SuspectID, @AgencyID, @CaseID)";

                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@IncidentID", incident.IncidentId);
                    cmd.Parameters.AddWithValue("@IncidentType", incident.IncidentType);
                    cmd.Parameters.AddWithValue("@IncidentDate", incident.IncidentDate);
                    cmd.Parameters.AddWithValue("@Latitude", incident.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", incident.Longitude);
                    cmd.Parameters.AddWithValue("@Description", incident.Description);
                    cmd.Parameters.AddWithValue("@Status", incident.Status);
                    cmd.Parameters.AddWithValue("@VictimID", incident.VictimID);
                    cmd.Parameters.AddWithValue("@SuspectID", incident.SuspectID);
                    cmd.Parameters.AddWithValue("@AgencyID", incident.AgencyID);

                    if (incident.CaseID.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@CaseID", incident.CaseID.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CaseID", DBNull.Value);
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();
                    isInserted = rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while inserting incident: " + ex.Message);
            }

            return isInserted;
        }


        public bool updateIncidentStatus(string status, int incidentId)
        {
            try
            {
                using (con = DBConnection.getConnection())
                {
                    string query = "UPDATE Incidents SET Status = @Status WHERE IncidentID = @IncidentID";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@IncidentID", incidentId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating incident status: " + ex.Message);
                return false;
            }
        }

        public List<Incidents> getIncidentsInDateRange(DateTime startDate, DateTime endDate)
        {
            List<Incidents> incidentsList = new List<Incidents>();

            try
            {
                using (con = DBConnection.getConnection())
                {
                    string query = "SELECT * FROM Incidents WHERE IncidentDate BETWEEN @StartDate AND @EndDate";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Incidents inc = new Incidents();

                        inc.IncidentId = Convert.ToInt32(reader["IncidentID"]);
                        inc.IncidentType = Convert.ToString(reader["IncidentType"]);
                        inc.IncidentDate = Convert.ToDateTime(reader["IncidentDate"]);
                        inc.Latitude = Convert.ToSingle(reader["Latitude"]);
                        inc.Longitude = Convert.ToSingle(reader["Longitude"]);
                        inc.Description = Convert.ToString(reader["Description"]);
                        inc.Status = Convert.ToString(reader["Status"]);
                        inc.VictimID = Convert.ToInt32(reader["VictimID"]);
                        inc.SuspectID = Convert.ToInt32(reader["SuspectID"]);
                        inc.AgencyID = Convert.ToInt32(reader["AgencyID"]);
                        inc.CaseID = reader["CaseID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["CaseID"]);

                        incidentsList.Add(inc);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching incidents: " + ex.Message);
            }

            return incidentsList;
        }

        public List<Incidents> searchIncidents(string incidentType)
        {
            List<Incidents> matchingIncidents = new List<Incidents>();

            try
            {
                using (con = DBConnection.getConnection())
                {
                    string query = "SELECT * FROM Incidents WHERE IncidentType LIKE @IncidentType";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@IncidentType", "%" + incidentType + "%");

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Incidents inc = new Incidents();

                        inc.IncidentId = Convert.ToInt32(reader["IncidentID"]);
                        inc.IncidentType = Convert.ToString(reader["IncidentType"]);
                        inc.IncidentDate = Convert.ToDateTime(reader["IncidentDate"]);
                        inc.Latitude = Convert.ToSingle(reader["Latitude"]);
                        inc.Longitude = Convert.ToSingle(reader["Longitude"]);
                        inc.Description = Convert.ToString(reader["Description"]);
                        inc.Status = Convert.ToString(reader["Status"]);
                        inc.VictimID = Convert.ToInt32(reader["VictimID"]);
                        inc.SuspectID = Convert.ToInt32(reader["SuspectID"]);
                        inc.AgencyID = Convert.ToInt32(reader["AgencyID"]);
                        inc.CaseID = reader["CaseID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["CaseID"]);

                        matchingIncidents.Add(inc);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while searching incidents: " + ex.Message);
            }

            return matchingIncidents;
        }

        public Incidents GetIncidentById(int incidentId)
        {
            Incidents incident = null;

            try
            {
                using (con = DBConnection.getConnection())
                {
                    string query = "SELECT * FROM Incidents WHERE IncidentID = @IncidentID";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@IncidentID", incidentId);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        incident = new Incidents();

                        incident.IncidentId = Convert.ToInt32(reader["IncidentID"]);
                        incident.IncidentType = Convert.ToString(reader["IncidentType"]);
                        incident.IncidentDate = Convert.ToDateTime(reader["IncidentDate"]);
                        incident.Latitude = Convert.ToSingle(reader["Latitude"]);
                        incident.Longitude = Convert.ToSingle(reader["Longitude"]);
                        incident.Description = Convert.ToString(reader["Description"]);
                        incident.Status = Convert.ToString(reader["Status"]);
                        incident.VictimID = Convert.ToInt32(reader["VictimID"]);
                        incident.SuspectID = Convert.ToInt32(reader["SuspectID"]);
                        incident.AgencyID = Convert.ToInt32(reader["AgencyID"]);
                        incident.CaseID = reader["CaseID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["CaseID"]);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching incident: " + ex.Message);
            }

            return incident;
        }

        public Reports GenerateIncidentReport(Incidents incident)
        {
            Reports report = null;

            using (con = DBConnection.getConnection())
            {
                string query = "SELECT * FROM Reports WHERE IncidentID = @IncidentID";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IncidentID", incident.IncidentId);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    report = new Reports
                    {
                        ReportID = Convert.ToInt32(reader["ReportID"]),
                        IncidentID = Convert.ToInt32(reader["IncidentID"]),
                        ReportingOfficerID = Convert.ToInt32(reader["ReportingOfficerID"]),
                        ReportDate = Convert.ToDateTime(reader["ReportDate"]),
                        ReportDetails = Convert.ToString(reader["ReportDetails"]),
                        Status = Convert.ToString(reader["Status"])
                    };
                }

            }

            return report;
        }

        public Cases createCase(int caseId, string description, List<Incidents> incidents)
        {
            Cases newCase = null;
            DateTime createdDate = DateTime.Now;

            try
            {
                using (con = DBConnection.getConnection())
                {

                    string insertQuery = "INSERT INTO Cases (CaseID, Description, CreatedDate) VALUES (@CaseID, @Description, @CreatedDate)";
                    using (cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@CaseID", caseId);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@CreatedDate", createdDate);
                        cmd.ExecuteNonQuery();
                    }

                    foreach (var incident in incidents)
                    {
                        string updateQuery = "UPDATE Incidents SET CaseID = @CaseID WHERE IncidentID = @IncidentID";
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                        {
                            updateCmd.Parameters.AddWithValue("@CaseID", caseId);
                            updateCmd.Parameters.AddWithValue("@IncidentID", incident.IncidentId);
                            updateCmd.ExecuteNonQuery();
                        }
                    }

                    newCase = new Cases
                    {
                        CaseId = caseId,
                        Description = description,
                        CreatedDate = createdDate,
                        Incidents = incidents
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating the case: " + ex.Message);
            }

            return newCase;
        }

        public Cases getCaseDetails(int caseId)
        {
            Cases caseDetails = null;

            try
            {
                using (con = DBConnection.getConnection())
                {
                    string query = "SELECT * FROM Cases WHERE CaseID = @CaseID";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CaseID", caseId);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        caseDetails = new Cases
                        {
                            CaseId = Convert.ToInt32(reader["CaseID"]),
                            Description = Convert.ToString(reader["Description"]),
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                            Incidents = getIncidentsForCase(caseId) 
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching case details: " + ex.Message);
            }

            return caseDetails;
        }
        
        public List<Incidents> getIncidentsForCase(int caseId)
        {
            List<Incidents> incidentsList = new List<Incidents>();

            try
            {
                using (SqlConnection con = DBConnection.getConnection())
                {
                    string query = "SELECT * FROM Incidents WHERE CaseID = @CaseID";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CaseID", caseId);

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Incidents inc = new Incidents
                        {
                            IncidentId = Convert.ToInt32(reader["IncidentID"]),
                            IncidentType = Convert.ToString(reader["IncidentType"]),
                            IncidentDate = Convert.ToDateTime(reader["IncidentDate"]),
                            Latitude = Convert.ToSingle(reader["Latitude"]),
                            Longitude = Convert.ToSingle(reader["Longitude"]),
                            Description = Convert.ToString(reader["Description"]),
                            Status = Convert.ToString(reader["Status"]),
                            VictimID = Convert.ToInt32(reader["VictimID"]),
                            SuspectID = Convert.ToInt32(reader["SuspectID"]),
                            AgencyID = Convert.ToInt32(reader["AgencyID"]),
                            CaseID = reader["CaseID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["CaseID"])
                        };

                        incidentsList.Add(inc);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching incidents: " + ex.Message);
            }

            return incidentsList;
        }
        

        public bool updateCaseDetails(Cases caseToUpdate)
        {
            bool updateSuccess = false;

            try
            {
                using (con = DBConnection.getConnection())
                {
                    string query = "UPDATE Cases SET Description = @Description WHERE CaseID = @CaseID";

                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Description", caseToUpdate.Description);
                    cmd.Parameters.AddWithValue("@CaseID", caseToUpdate.CaseId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    updateSuccess = rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating case: " + ex.Message);
            }

            return updateSuccess;
        }

        public List<Cases> getAllCases()
        {
            List<Cases> casesList = new List<Cases>();

            try
            {
                using (con = DBConnection.getConnection())
                {
                    string query = "SELECT * FROM Cases";

                    cmd = new SqlCommand(query, con);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Cases caseItem = new Cases
                        {
                            CaseId = Convert.ToInt32(reader["CaseID"]),
                            Description = Convert.ToString(reader["Description"]),
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                            Incidents = getIncidentsForCase(Convert.ToInt32(reader["CaseID"]))
                        };

                        casesList.Add(caseItem);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching cases: " + ex.Message);
            }

            return casesList;
        }


        public void CheckIdExist(int id)
        {
            con = DBConnection.getConnection();
            string query = "SELECT COUNT(1) FROM Incidents WHERE IncidentID = @incidentid";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@incidentid", id);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count == 0)
            {
                throw new IncidentNumberNotFound("The entered incident number is not in the database");
            }
        }

    }
}
