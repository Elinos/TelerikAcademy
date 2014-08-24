USE TelerikAcademy
GO

SELECT d.Name, e.JobTitle, AVG(e.Salary) AS [Average Salary]
FROM Employees e
	INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle