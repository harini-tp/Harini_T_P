CREATE DATABASE CmsDB

-- Create tables
CREATE TABLE Crime (
CrimeID INT PRIMARY KEY,
IncidentType VARCHAR(255),
IncidentDate DATE,
Locations VARCHAR(255),
Descriptions TEXT,
C_Status VARCHAR(20)
);
CREATE TABLE Victim (
VictimID INT PRIMARY KEY,
CrimeID INT,
Names VARCHAR(255),
Age INT,
ContactInfo VARCHAR(255),
Injuries VARCHAR(255),
FOREIGN KEY (CrimeID) REFERENCES Crime(CrimeID)
);
CREATE TABLE Suspect (
SuspectID INT PRIMARY KEY,
CrimeID INT,
Names VARCHAR(255),
Age INT,
Descriptions TEXT,
CriminalHistory TEXT,
FOREIGN KEY (CrimeID) REFERENCES Crime(CrimeID)
);

--DROP TABLE Crime
--DROP TABLE Victim
--DROP TABLE Suspect

-- Insert sample data
INSERT INTO Crime (CrimeID, IncidentType, IncidentDate, Locations, Descriptions, C_Status)
VALUES
(1, 'Robbery', '2023-09-15', '123 Main St, Cityville', 'Armed robbery at a convenience store', 'Open'),
(2, 'Homicide', '2023-09-20', '456 Elm St, Townsville', 'Investigation into a murder case', 'Under
Investigation'),
(3, 'Theft', '2023-09-10', '789 Oak St, Villagetown', 'Shoplifting incident at a mall', 'Closed');
INSERT INTO Victim (VictimID, CrimeID, Names, Age, ContactInfo, Injuries)
VALUES
(1, 1, 'John Doe', 20, 'johndoe@example.com', 'Minor injuries'),
(2, 2, 'Jane Smith', 35, 'janesmith@example.com', 'Deceased'),
(3, 3, 'Alice Johnson', 34, 'alicejohnson@example.com', 'None');
INSERT INTO Suspect (SuspectID, CrimeID, Names, Age, Descriptions, CriminalHistory)
VALUES
(1, 1, 'Robber 1', 20, 'Armed and masked robber', 'Previous robbery convictions'),
(2, 2, 'Unknown', NULL, 'Investigation ongoing', NULL),
(3, 3, 'Suspect 1', 48, 'Shoplifting suspect', 'Prior shoplifting arrests');

/*
ALTER TABLE Victim
ADD Age INT

ALTER TABLE Suspect
ADD Age INT

INSERT INTO Victim (Age)
VALUES (20), (35), (43)

INSERT INTO Suspect (Age)
VALUES (20), (35), (43)
*/

SELECT * FROM Crime
SELECT * FROM Victim
SELECT * FROM Suspect


--1   All open incident

SELECT * FROM Crime 
WHERE C_Status = 'Open'






--2    Total no. of incident

SELECT COUNT(IncidentType) [No of Incidents] FROM Crime




--3  Unique incidents

SELECT DISTINCT(IncidentType) [Types of Incidents] FROM Crime





--4      incidents that occurred between '2023-09-01' and '2023-09-10'.

SELECT * FROM Crime 
WHERE IncidentDate BETWEEN '2023-09-01' AND '2023-09-10'



--5  List persons involved in incidents in descending order of age.

SELECT v.Names[Victims in desc], s.Names[Suspects in desc] FROM Victim v
JOIN Suspect s ON v.CrimeID = s.CrimeID
JOIN Crime c ON s.CrimeID = c.CrimeID
ORDER BY v.Age DESC, s.Age DESC

-- Displays for both victims and suspects in desc order







--6    average age of persons involved in incidents.

SELECT AVG(v.Age) [Victims Average], AVG(s.Age) [Suspects Average] FROM Victim v
JOIN Suspect s ON v.CrimeID = s.CrimeID
JOIN Crime c ON s.CrimeID = c.CrimeID

--i have taken avg for both victim and suspects




--7   List incident types and their counts, only for open cases

SELECT IncidentType, COUNT(IncidentType) [Count] FROM Crime
GROUP BY IncidentType, C_Status
HAVING C_Status = 'Open'





--8    Find persons with names containing 'Doe'.

SELECT v.Names FROM Victim v
JOIN Suspect s ON v.CrimeID = s.CrimeID
WHERE v.Names LIKE '%Doe%'




--9   names of persons involved in open cases and closed cases.

SELECT v.Names[Victims], s.Names[Suspects] FROM Victim v
JOIN Suspect s ON v.CrimeID = s.CrimeID
JOIN Crime c ON s.CrimeID = c.CrimeID
WHERE c.C_Status = ('Open') OR c.C_Status = ('Closed')



--10    incident types where there are persons aged 30 or 35 involved.

SELECT c.IncidentType FROM Crime c
JOIN Suspect s ON c.CrimeID = s.CrimeID
JOIN Victim v ON v.CrimeID = c.CrimeID
WHERE v.Age IN (30, 35) OR s.Age IN (30, 35)



SELECT * FROM Crime
SELECT * FROM Victim
SELECT * FROM Suspect

--11 persons involved in incidents of the same type as 'Robbery'.

SELECT v.Names[Victims], s.Names[Suspects] FROM Victim v
JOIN Suspect s ON v.CrimeID = s.CrimeID
JOIN Crime c ON s.CrimeID = c.CrimeID
WHERE IncidentType = 'Robbery'





--12   incident types with more than one open case.

SELECT IncidentType FROM Crime c1
WHERE 1 >
        (SELECT COUNT(C_Status) FROM Crime c2
		WHERE c2.IncidentType = c1.IncidentType)

--    Returns nothing as there is no incident type
--    with more than one open cases





--13  all incidents with suspects whose names also appear as victims in other incidents.
SELECT c.IncidentType, s.Names FROM Crime c
JOIN Suspect s ON c.CrimeID = s.CrimeID
WHERE s.Names IN (
                 SELECT Names FROM Victim v
                 WHERE v.CrimeID <> s.CrimeID)

--No such names exist in both suspect and victm so no output




--14    Retrieve all incidents along with victim and suspect details.

SELECT c.IncidentType,  v.*, c.* FROM Victim v
JOIN Suspect s ON v.CrimeID = s.CrimeID
JOIN Crime c ON s.CrimeID = c.CrimeID





--15  incidents where the suspect is older than any victim.

SELECT c.IncidentType FROM Crime c
JOIN Suspect s ON c.CrimeID = s.CrimeID
--JOIN Victim v ON v.CrimeID = c.CrimeID
WHERE s.Age > ANY (
                   SELECT Age FROM Victim)


--16   Find suspects involved in multiple incidents:
SELECT Names FROM Suspect 
WHERE SuspectID IN (
                   SELECT ID FROM(
                                  SELECT SuspectID [ID], COUNT(CrimeID) [Counts] FROM Suspect
				                  GROUP BY SuspectID
				                  HAVING COUNT(CrimeID) > 1) [Count])

-- ruturns no output as there is no suspect in multiple incident




--17   incidents with no suspects involved.

SELECT c.IncidentType FROM Crime c
WHERE NOT EXISTS (
                  SELECT 1 FROM Suspect s WHERE 
				  s.CrimeID = c.CrimeID)

--No output as all incident has a suspect





--18 List all cases where at least one incident is of type 'Homicide' and all other incidents are of type 'Robbery'.

SELECT TOP 1 * FROM Crime WHERE IncidentType = 'Homicide'
UNION ALL
SELECT * FROM Crime WHERE IncidentType = 'Robbery'





--19   Retrieve a list of all incidents and the associated suspects, showing suspects for each incident, or
       --'No Suspect' if there are none.

SELECT s.Names [Suspect Name], c.IncidentType FROM Crime c
JOIN Suspect s ON c.CrimeID = s.CrimeID
UNION ALL
SELECT 'No Suspect' [Suspect Name], c.IncidentType FROM Crime c
JOIN Suspect s ON c.CrimeID = s.CrimeID
WHERE s.SuspectID IS NULL

--every incident has a suspect so no suspect will not be displayed



--20  all suspects who have been involved in incidents with incident types 'Robbery' or 'Assault'

SELECT s.Names FROM Crime c
JOIN Suspect s ON c.CrimeID = s.CrimeID
WHERE c.IncidentType IN ('Robbery', 'Assault')



                 

