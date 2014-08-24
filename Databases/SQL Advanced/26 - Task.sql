USE TelerikAcademy
GO

SELECT d.Name, e.JobTitle,
	   e.FirstName + ' ' + e.LastName AS [Full Name],
	   MIN(e.Salary) AS [Minimum Salary]
FROM Employees e
	INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName, e.LastName