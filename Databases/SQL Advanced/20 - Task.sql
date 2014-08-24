USE TelerikAcademy
GO

UPDATE Groups
SET Name = ('3rd Group')
WHERE Name = 'Third Group'
GO

UPDATE Users
SET GroupID = 2
WHERE UserID < 3
GO