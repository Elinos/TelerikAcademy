USE TelerikAcademy
GO

SELECT d.Name, t.Name, COUNT(*) as [Employees Count]
FROM Departments d
	INNER JOIN Employees e
	ON d.DepartmentID = e.DepartmentID
	INNER JOIN Addresses a
	ON a.AddressID = e.AddressID
	INNER JOIN Towns t
	ON t.TownID = a.TownID
GROUP BY d.Name, t.Name