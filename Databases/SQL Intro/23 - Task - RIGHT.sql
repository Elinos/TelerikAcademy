USE TelerikAcademy
GO

SELECT e.FirstName + ' ' + e.LastName AS [Employee Full Name],
	   ISNULL(m.FirstName + ' ' + m.LastName, 'No manager') AS [Manager Full Name]
FROM Employees m
	RIGHT JOIN Employees e
	ON e.ManagerID = m.EmployeeID
