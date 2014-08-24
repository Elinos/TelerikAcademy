USE TelerikAcademy
GO

INSERT INTO Users
(Username, Password, Fullname, LastLogin)
SELECT FirstName + LOWER(LastName),
	   FirstName + LOWER(LastName),
	   FirstName + ' ' + LastName,
	   NULL
FROM Employees