USE Company
GO

SELECT d.Name, COUNT(e.ID) AS [Total Employees]
FROM Departments d
JOIN Employees e ON d.ID = e.DepartmentID
GROUP BY d.Name
ORDER BY COUNT(e.ID) DESC