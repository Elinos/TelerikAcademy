USE TelerikAcademy;
GO

sp_configure 'clr enabled', 1
GO

RECONFIGURE
GO

CREATE ASSEMBLY StrConcat
FROM 'D:\Programming\TelerikAcademy\Databases\Transact SQL\StrConcat.dll';
GO

CREATE AGGREGATE StrConcat (@input nvarchar(200)) RETURNS nvarchar(max)
EXTERNAL NAME StrConcat.Concatenate;
GO

SELECT dbo.StrConcat(FirstName + ' ' + LastName)
FROM Employees;
GO