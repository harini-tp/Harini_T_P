SELECT * FROM EMP

SELECT * FROM DEPT


--1
SELECT ename 'Managers' FROM EMP 
WHERE job = 'MANAGER'

--2
SELECT ename 'Name', sal 'Salary' FROM EMP
WHERE sal > 1000

--3
SELECT ename 'Name', sal 'Salary' FROM EMP
WHERE ename <> 'JAMES'

--4
SELECT * FROM EMP
WHERE ename LIKE 'S%'

--5
SELECT * FROM EMP
WHERE ename LIKE '%A%'

--6
SELECT * FROM EMP
WHERE ename LIKE '__L%'

--7
SELECT ename 'Name', (sal/30) 'Daily Salary' FROM EMP
WHERE ename = 'JONES'

--8
SELECT SUM(sal) 'Total Monthly Salary' FROM EMP

--9
SELECT AVG(sal*12) 'Average Anual Salary' FROM EMP 

--10
SELECT ename 'Name', job, sal 'Salary', deptno FROM EMP 
WHERE job <> 'SALESMAN' AND deptno <> 30