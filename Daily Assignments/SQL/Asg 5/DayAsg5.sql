SELECT * FROM EMP
SELECT * FROM DEPT


--1
SELECT empno, ename, sal FROM EMP
WHERE sal > (
			SELECT sal FROM EMP 
			WHERE empno = 7566)


--2
SELECT ename, deptno, job FROM EMP 
WHERE job = (
			SELECT job FROM EMP
			WHERE empno = 7876)


--3
SELECT ename, empno, sal FROM EMP 
WHERE mgrid IN(
				SELECT empno FROM EMP t1
				WHERE ename LIKE '[BC]%')



SELECT * FROM Products

SELECT * FROM Categories

--Northwind
--a
SELECT CategoryName, ProductName, UnitPrice 
FROM Products P1
JOIN Categories 
ON P1.CategoryID = Categories.CategoryID
WHERE UnitPrice > (SELECT AVG(UnitPrice) FROM Products P2
					WHERE P2.CategoryID = P1.CategoryID)




--b
SELECT CategoryName, [Number of Disc. product],[Total no of products] FROM Categories C
JOIN (
	SELECT COUNT(ProductName) [Number of Disc. product], CategoryID FROM Products
	GROUP BY CategoryID) X
ON C.CategoryID = X.CategoryID 
JOIN(
	SELECT COUNT(ProductID) [Total no of products], CategoryID FROM Products
	GROUP BY CategoryID) Y
ON C.CategoryID = Y.CategoryID