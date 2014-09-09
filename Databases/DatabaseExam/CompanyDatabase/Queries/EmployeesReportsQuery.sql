USE Company
GO

SELECT e.FirstName + ' ' + e.LastName AS [Employee FullName],
	   p.Name AS [ProjectName], d.Name AS [DepartmentName], ep.StartingDate, ep.EndingDate,
	   (SELECT COUNT(*) FROM Reports r WHERE r.Time BETWEEN ep.StartingDate AND ep.EndingDate AND r.EmployeeID = e.ID) AS [NumberOfReports]
FROM Employees e
JOIN Departments d ON d.ID = e.DepartmentID
JOIN EmployeesProjects ep ON ep.EmployeeID = e.ID
JOIN Projects p ON ep.ProjectID = p.ID
ORDER BY e.ID, p.ID