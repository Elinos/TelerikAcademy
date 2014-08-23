USE TelerikAcademy
GO

SELECT e.FirstName, e.LastName, a.AddressText as Address
FROM Employees e
	INNER JOIN Addresses a
	ON e.AddressID = a.AddressID