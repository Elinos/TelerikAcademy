USE TelerikAcademy
GO

SELECT TOP 1 t.Name, COUNT(*) AS EmpCount
FROM Employees e
	INNER JOIN Addresses a
	ON e.AddressID = a.AddressID
	INNER JOIN Towns t
	ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY COUNT(*) DESC

