USE TelerikAcademy
GO

SELECT m.FirstName + ' ' + m.LastName AS [Manager Fullname], COUNT(*) as [Employees Count]
FROM Employees e
	INNER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(*) = 5