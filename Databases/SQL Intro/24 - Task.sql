USE TelerikAcademy
GO

SELECT e.FirstName + ' ' + e.LastName AS [Employee Full Name],
	   d.Name AS [Department], YEAR(e.HireDate) AS [Hire Year]
FROM Employees e
	INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	AND d.Name IN ('Sales', 'Finance')
	AND YEAR(e.HireDate) BETWEEN 1995 AND 2005