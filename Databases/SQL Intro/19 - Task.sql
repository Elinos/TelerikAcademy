USE TelerikAcademy
GO

SELECT e.FirstName, e.LastName, a.AddressText as Address
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID
