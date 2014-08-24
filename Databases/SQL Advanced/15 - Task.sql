USE TelerikAcademy
GO

CREATE TABLE Users ( 
 UserID int IDENTITY, 
 Username nvarchar(50) NOT NULL UNIQUE,
 Password nvarchar(50) NULL,
 Fullname nvarchar(100) NOT NULL,
 LastLogin datetime,  
 CONSTRAINT PK_Users PRIMARY KEY(UserID),
 CONSTRAINT CH_User_Password_LEN CHECK (LEN([Password]) >= 5), 
) 