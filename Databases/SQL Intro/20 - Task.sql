USE TelerikAcademy
GO

SELECT e.FirstName, e.LastName, m.FirstName + ' ' + m.LastName AS [Manager Full Name]
FROM Employees e
	INNER JOIN Employees m
	ON e.ManagerID = m.EmployeeID