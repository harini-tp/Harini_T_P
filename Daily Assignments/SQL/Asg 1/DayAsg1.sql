
--First creating the relations

CREATE TABLE Clients
(
Client_ID INT PRIMARY KEY,
C_Name VARCHAR(40) NOT NULL,
C_Address VARCHAR(30),
C_Email VARCHAR(30) UNIQUE,
C_Phone BIGINT,
C_Business VARCHAR(20) NOT NULL
)


/*DROP TABLE Clients : to delete a table (for my ref) */

CREATE TABLE Departments
(
D_DeptNo int PRIMARY KEY,
D_Name VARCHAR(15) NOT NULL,
D_Loc VARCHAR(20)
)


CREATE TABLE Employees
(
E_ID INT PRIMARY KEY,
E_Name VARCHAR(20) NOT NULL,
E_Job VARCHAR(15),
E_Salary INT CHECK (E_Salary > 0),
E_DeptNo INT FOREIGN KEY REFERENCES Departments(D_DeptNo)
)


CREATE TABLE Projects
(
Project_ID INT PRIMARY KEY,
Descr VARCHAR(20) NOT NULL,
P_Start_Date DATE,
Planned_End_Date DATE,
Actual_End_Date DATE,
Budget INT CHECK (Budget > 0),
Client_ID INT FOREIGN KEY REFERENCES Clients(Client_ID),
CONSTRAINT deadline CHECK (Actual_End_Date > Planned_End_Date)
)


CREATE TABLE EmpProjectTasks
(
Project_ID int,
EmpNo int,
E_Start_Date DATE,
E_End_Date DATE,
Task VARCHAR(25) NOT NULL,
Status VARCHAR(15) NOT NULL,
PRIMARY KEY (Project_ID,EmpNo),
FOREIGN KEY (Project_ID) REFERENCES Projects(Project_ID),
FOREIGN KEY (EmpNo) REFERENCES Employees(E_ID)
)


--Now populating the relations

INSERT INTO Clients VALUES 
(1001, 'ACME Utilities', 'Noida', 'contact@acmeutil.com', 9567880032, 'Manufacturing'),
(1002, 'Trackon Consultants', 'Mumbai', 'consult@trackon.com', 8734210090, 'Consultant'),
(1003, 'MoneySaver Distributors', 'Kolkata', 'save@moneysaver.com', 7799886655, 'Reseller'),
(1004, 'Lawful Corp', 'Chennai', 'justice@lawful.com', 9210342219, 'Professional')


INSERT INTO Employees VALUES 
(7001, 'Sandeep', 'Analyst', 25000, 10),
(7002, 'Rajesh', 'Designer', 30000, 10),
(7003, 'Madhav', 'Developer', 40000, 20),
(7004, 'Manoj', 'Developer', 40000, 20),
(7005, 'Abhay', 'Designer', 35000, 10),
(7006, 'Uma', 'Tester', 30000, 30),
(7007, 'Gita', 'Tech. Writer', 30000, 40),
(7008, 'Priya', 'Tester', 35000, 30),
(7009, 'Nutan', 'Developer', 45000, 20),
(7010, 'Smita', 'Analyst', 20000, 10),
(7011, 'Anand', 'Project Mgr', 65000, 10)

INSERT INTO Departments VALUES 
(10, 'Design', 'Pune'),
(20, 'Development', 'Pune'),
(30, 'Testing', 'Mumbai'),
(40, 'Document', 'Mumbai')

INSERT INTO Projects VALUES 
(401, 'Inventory', '2011-04-01', '2011-10-01', '2011-10-31', 150000, 1001),
(402, 'Accounting', '2011-08-01', '2012-01-01', NULL, 500000, 1002),
(403, 'Payroll', '2011-10-01', '2011-12-31', NULL, 75000, 1003),
(404, 'Contact Mgmt', '2011-11-01', '2011-12-31', NULL, 50000, 1004)


INSERT INTO EmpProjectTasks VALUES 
(401, 7001, '2011-04-01', '2011-04-20', 'System Analysis', 'Completed'),
(401, 7002, '2011-04-21', '2011-05-30', 'System Design', 'Completed'),
(401, 7003, '2011-06-01', '2011-07-15', 'Coding', 'Completed'),
(401, 7004, '2011-07-18', '2011-09-01', 'Coding', 'Completed'),
(401, 7006, '2011-09-03', '2011-09-15', 'Testing', 'Completed'),
(401, 7009, '2011-09-18', '2011-10-05', 'Code Change', 'Completed'),
(401, 7008, '2011-10-06', '2011-10-16', 'Testing', 'Completed'),
(401, 7007, '2011-10-06', '2011-10-22', 'Documentation', 'Completed'),
(401, 7011, '2011-10-22', '2011-10-31', 'Sign off', 'Completed'),
(402, 7010, '2011-08-01', '2011-08-20', 'System Analysis', 'Completed'),
(402, 7002, '2011-08-22', '2011-09-30', 'System Design', 'Completed'),
(402, 7004, '2011-10-01', NULL, 'Coding', 'In Progress')

--now to display them

SELECT * FROM Clients

SELECT * FROM Employees

SELECT * FROM Departments

SELECT * FROM Projects

SELECT * FROM EmpProjectTasks