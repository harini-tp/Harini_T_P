SELECT * FROM EMP

SELECT * FROM DEPT

--1
SELECT DISTINCT(DEPT.dname) 'Department name' FROM EMP
JOIN DEPT ON EMP.deptno = DEPT.deptno 

--2
SELECT ename 'Name', sal 'Salary' FROM EMP
WHERE sal > 1500 AND deptno IN (10, 30)

--3
SELECT ename 'Name', job, sal 'Salary' FROM EMP
WHERE job in ('MANAGER', 'ANALYST') AND sal NOT IN (1000, 3000, 5000)

--4
SELECT ename 'Name',sal 'Salary', comm FROM EMP
WHERE comm > (sal * 1.10)

--5
SELECT ename 'Name' FROM EMP
WHERE ename LIKE '%L%L%' AND (deptno = 30 OR mgrid = 7782)

--6
SELECT ename 'Name' FROM EMP
WHERE DATEDIFF(YEAR, hiredate, GETDATE()) > 30
AND DATEDIFF(YEAR, hiredate, GETDATE()) < 40
--to get the total number of employees
SELECT COUNT(ename) FROM EMP
WHERE ename IN 
(
SELECT ename 'Name' FROM EMP
WHERE DATEDIFF(YEAR, hiredate, GETDATE()) > 30
AND DATEDIFF(YEAR, hiredate, GETDATE()) < 40
)

--7
SELECT dname 'Dept Name', EMP.ename 'Name' FROM EMP
JOIN DEPT ON EMP.deptno = DEPT.deptno
ORDER BY dname, ename DESC

--8
SELECT DATEDIFF(YEAR, hiredate, GETDATE()) AS 'In years'
FROM EMP
WHERE ename = 'MILLER'

--9
SELECT * FROM EMP 
WHERE ename LIKE '%_____%'

--10
CREATE TABLE emp10
(
empno INT PRIMARY KEY,
ename VARCHAR(30)
)
INSERT INTO emp10 (empno, ename)
(
SELECT empno, ename FROM EMP
WHERE deptno = 10
)
SELECT * FROM emp10

SELECT * FROM EMP

SELECT * FROM DEPT