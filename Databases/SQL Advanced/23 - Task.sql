USE TelerikAcademy
GO

UPDATE Users
SET Password = NULL
WHERE UserID IN (SELECT UserID
				 FROM Users
				 WHERE LastLogin < '20100310')