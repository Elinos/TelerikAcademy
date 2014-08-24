USE TelerikAcademy
GO

SELECT AVG(Salary) AS [Avergage Salary in Sales]
FROM Employees e
	INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'