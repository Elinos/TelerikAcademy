USE TelerikAcademy
GO

SELECT d.Name, AVG(e.Salary) AS [Average Salary]
FROM Departments d
	INNER JOIN Employees e
	ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name
ORDER BY [Average Salary]