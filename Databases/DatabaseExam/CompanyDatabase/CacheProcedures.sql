USE Company
GO

CREATE PROC uspCreateCacheTable
AS
CREATE TABLE CacheOfReports
(
	[Employee FullName] nvarchar(300),
	[ProjectName] nvarchar(300),
	[DepartmentName] nvarchar(300),
	StartingDate datetime,
	EndingDate datetime,
	[NumberOfReports] int
)
GO

CREATE PROC uspFillCacheTable
AS
BEGIN TRANSACTION
DELETE FROM CacheOfReports
INSERT INTO CacheOfReports
SELECT e.FirstName + ' ' + e.LastName AS [Employee FullName],
	   p.Name AS [ProjectName], d.Name AS [DepartmentName], ep.StartingDate, ep.EndingDate,
	   (SELECT COUNT(*) FROM Reports r WHERE r.Time BETWEEN ep.StartingDate AND ep.EndingDate AND r.EmployeeID = e.ID) AS [NumberOfReports]
FROM Employees e
JOIN Departments d ON d.ID = e.DepartmentID
JOIN EmployeesProjects ep ON ep.EmployeeID = e.ID
JOIN Projects p ON ep.ProjectID = p.ID
ORDER BY e.ID, p.ID
COMMIT
