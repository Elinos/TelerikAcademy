USE TelerikAcademy
GO

SELECT e.FirstName, e.LastName,
	   m.FirstName + ' ' + m.LastName AS [Manager Full Name],
	   a.AddressText as Address
FROM Employees e
	INNER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
	INNER JOIN Addresses a
	ON e.AddressID = a.AddressID