USE TelerikAcademy
GO

SELECT t.Name, COUNT(e.ManagerID) AS ManagersCount
FROM Employees e
	INNER JOIN Addresses a ON e.AddressID = a.AddressID
	INNER JOIN Towns t ON t.TownID = a.TownID
WHERE e.EmployeeID in (SELECT DISTINCT ManagerID FROM Employees)
GROUP BY t.Name
ORDER BY COUNT(e.ManagerID) DESC
