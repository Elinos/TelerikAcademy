USE TelerikAcademy
GO

SELECT COUNT(*) AS [Number of employees in Sales]
FROM Employees e
	INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'