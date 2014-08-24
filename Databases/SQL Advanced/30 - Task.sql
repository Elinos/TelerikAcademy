USE TelerikAcademy
GO

BEGIN TRAN 
	ALTER TABLE Departments DROP [FK_Departments_Employees]
	DELETE FROM Employees 
	WHERE DepartmentID = (SELECT DepartmentID FROM Departments WHERE Name = 'Sales')
	DELETE FROM Departments 
	WHERE Name = 'Sales'
	ROLLBACK TRAN
GO