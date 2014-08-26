USE TelerikAcademy
IF OBJECT_ID('ufn_StringComprisedOf') IS NOT NULL DROP FUNCTION ufn_StringComprisedOf 
GO 

CREATE FUNCTION ufn_StringComprisedOf(@inputString nvarchar(50), @letterSet nvarchar(100))
  RETURNS BIT
AS
  BEGIN
	DECLARE @inputStringLenght int
	DECLARE @currentIndex int
	DECLARE @input nvarchar(50)
	DECLARE @pattern nvarchar(100)
	SET @inputStringLenght = LEN(@inputString)
	SET @currentIndex = 1
	SET @input = LOWER(@inputString)
	SET @pattern = LOWER(@letterSet)

	WHILE @currentIndex <= @inputStringLenght
	  BEGIN
		IF(CHARINDEX(SUBSTRING(@input,@currentindex,1),@pattern)=0)
		  BEGIN
			RETURN 0
		  END
		SET @currentIndex = @currentIndex +1
	  END
	RETURN 1
  END
GO


IF OBJECT_ID('ufn_EmployeesAndTownsNameComprisedOf') IS NOT NULL DROP FUNCTION ufn_EmployeesAndTownsNameComprisedOf 
GO 

CREATE FUNCTION ufn_EmployeesAndTownsNameComprisedOf(@letterSet nvarchar(100))
  RETURNS @reulst_table TABLE (name nvarchar(50))
AS
BEGIN

DECLARE empCursor CURSOR READ_ONLY FOR
  SELECT Name FROM (
  SELECT FirstName AS Name FROM Employees
  UNION
  SELECT MiddleName AS Name FROM Employees
  UNION
  SELECT LastName AS Name FROM Employees
  UNION
  SELECT Name AS Name FROM Towns
  ) AS Names
  WHERE Name IS NOT NULL

OPEN empCursor
DECLARE @name nvarchar(50)
FETCH NEXT FROM empCursor INTO @name

DECLARE @nameLen int, @currentIndex int

WHILE @@FETCH_STATUS = 0
  BEGIN
	IF(dbo.ufn_StringComprisedOf(@name,@letterSet)=1)
	  BEGIN
	    INSERT INTO @reulst_table
		VALUES (@name)
	  END
    FETCH NEXT FROM empCursor 
    INTO @name
  END

CLOSE empCursor
DEALLOCATE empCursor
  RETURN
END
GO

SELECT * FROM ufn_EmployeesAndTownsNameComprisedOf('oistmiahf')
GO