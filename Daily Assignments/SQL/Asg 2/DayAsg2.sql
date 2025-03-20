
CREATE TABLE DEPT
(
deptno INT PRIMARY KEY,
dname VARCHAR(25),
loc VARCHAR(25)
)

CREATE TABLE EMP
(
empno INT PRIMARY KEY,
ename VARCHAR(25),
job VARCHAR(25),
mgrid INT,
hiredate DATE,
sal INT, 
comm INT,
deptno INT FOREIGN KEY REFERENCES DEPT(deptno)
)

INSERT INTO DEPT (deptno, dname, loc) VALUES
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON')

INSERT INTO EMP (empno, ename, job, mgrid, hiredate, sal, comm, deptno) VALUES
(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10)

SELECT * FROM EMP
SELECT * FROM DEPT 


--1
SELECT ename AS 'Name' FROM EMP WHERE ename LIKE 'A%'

--2
SELECT ename AS 'No manager for' FROM EMP 
WHERE mgrid IS NULL

--3
SELECT empno AS 'ID', ename AS 'Name', sal 'Salary' FROM EMP 
WHERE sal BETWEEN 1200 AND 1400 

--4
SELECT ename 'Name', sal AS original, (sal*1.10) AS payrise FROM EMP 
JOIN DEPT ON DEPT.deptno = EMP.deptno
WHERE DEPT.dname = 'RESEARCH'


--without join
SELECT ename 'Name', sal AS original, (sal*1.10) AS payrise FROM EMP 
WHERE deptno = 20

--5
SELECT count(job) AS 'Number of clerk' FROM EMP 
WHERE job = 'CLERK'

--6
SELECT job, AVG(sal) AS 'Average salary' FROM EMP GROUP BY job
SELECT job, COUNT(empno) 'No of Employee' FROM EMP GROUP BY job

--7
SELECT TOP 1 ename 'Name', sal 'Salary' FROM EMP
ORDER BY sal 
SELECT TOP 1 ename, sal FROM EMP
ORDER BY sal DESC

SELECT ename, sal FROM EMP WHERE sal = (
SELECT MIN(sal) FROM EMP)
SELECT ename, sal FROM EMP WHERE sal = (
SELECT MAX(sal) FROM EMP)

--8
SELECT DEPT.deptno 'Dept ID', dname 'Department Name', loc 'Location' 
FROM DEPT 
FULL JOIN EMP ON DEPT.deptno = EMP.deptno
WHERE EMP.deptno IS NULL

--9
SELECT ename 'Name', sal 'Salary' FROM EMP 
WHERE job = 'ANALYST' AND sal > 1200 AND deptno = 20
ORDER BY ename 

--10
SELECT DEPT.deptno 'Dept ID', dname 'Name', SUM(EMP.sal) AS Total FROM DEPT 
LEFT JOIN EMP ON DEPT.deptno = EMP.deptno
GROUP BY dname, DEPT.deptno 

--11
SELECT ename 'Name', sal 'Salary' FROM EMP 
WHERE ename = 'MILLER' OR ename = 'SMITH'

--12
SELECT ename 'Name' FROM EMP WHERE ename LIKE '[AM]%'

--13
SELECT ename 'Name', (sal*12) AS 'Yearly salary' FROM EMP 
WHERE ename = 'SMITH'

--14
SELECT ename 'Name', sal 'Salary' FROM EMP 
WHERE sal NOT BETWEEN 1500 AND 2850

--15
SELECT mgrid, count(empno) 'Count' FROM EMP
GROUP BY mgrid
HAVING count(empno) > 2
--if we need the name
SELECT M.ENAME AS 'Name', COUNT(E.EMPNO) AS 'Total employee'
FROM EMP E
JOIN EMP M ON E.Mgrid = M.EMPNO
GROUP BY M.ENAME
HAVING COUNT(E.EMPNO) > 2

