USE TelerikAcademy
GO

SELECT FirstName + ' '+  LastName AS Fullname, Salary, d.Name
FROM Employees e
	INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = (
				  SELECT MIN(Salary)
				  FROM Employees
				  WHERE DepartmentID = e.DepartmentID
				 )
ORDER BY e.Salary