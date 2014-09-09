USE Company
GO

SELECT FirstName + ' ' + LastName AS [FullName], YearSalary
FROM Employees
WHERE YearSalary BETWEEN 100000 AND 150000
ORDER BY YearSalary ASC