USE TelerikAcademy
GO

CREATE VIEW V_Get_Users_Logged_Today AS
SELECT *
FROM Users
WHERE CONVERT(date, LastLogin) = CONVERT(date, GETDATE())