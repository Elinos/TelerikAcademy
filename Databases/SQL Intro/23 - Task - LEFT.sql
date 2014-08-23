USE TelerikAcademy
GO

SELECT e.FirstName + ' ' + e.LastName AS [Employee Full Name],
	   ISNULL(m.FirstName + ' ' + m.LastName, 'No manager') AS [Manager Full Name]
FROM Employees e
	LEFT JOIN Employees m
	ON e.ManagerID = m.EmployeeID