USE TelerikAcademy
GO

SELECT AVG(Salary) AS [Avergage Salary in Department #1]
FROM Employees
WHERE DepartmentID = 1