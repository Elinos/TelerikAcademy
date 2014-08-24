USE TelerikAcademy
GO

CREATE TABLE Groups ( 
 GroupID int IDENTITY, 
 Name nvarchar(50) NOT NULL UNIQUE,
 CONSTRAINT PK_Groups PRIMARY KEY(GroupID)
) 