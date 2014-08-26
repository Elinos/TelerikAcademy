USE [TelerikAcademy]
GO

SELECT e.FirstName + ISNULL(' '+ e.MiddleName, '') + ' ' + e.LastName AS EmployeeName, t.TownID
INTO #TempEmployeesWithTowns
FROM Employees e INNER JOIN Addresses a on e.AddressID = a.AddressID
INNER JOIN Towns t on a.TownID = t.TownID 
CREATE INDEX Idx_TemTown ON #TempEmployeesWithTowns(TownID)


DECLARE townCursor CURSOR READ_ONLY FOR
SELECT TownID, Name FROM Towns
OPEN townCursor
DECLARE @townID int, @townName varchar(50)
FETCH NEXT FROM townCursor INTO @townID, @townName
WHILE @@FETCH_STATUS = 0
  BEGIN
    DECLARE empCursor CURSOR READ_ONLY FOR
	SELECT EmployeeName FROM #TempEmployeesWithTowns
	WHERE TownID = @townID

	OPEN empCursor
	DECLARE @employeeName varchar(150), @employeesList varchar(MAX)
	SET @employeesList = ''
	FETCH NEXT FROM empCursor INTO @employeeName

	WHILE @@FETCH_STATUS = 0	
	  BEGIN
		SET @employeesList = CONCAT(@employeesList, @employeeName, ', ')
		FETCH NEXT FROM empCursor INTO @employeeName
	  END  
	CLOSE empCursor
	DEALLOCATE empCursor
	SET @employeesList = LEFT(@employeesList, LEN(@employeesList) - 1)
	PRINT @townName + ' -> ' + @employeesList
	FETCH NEXT FROM townCursor INTO @townID, @townName         
  END
CLOSE townCursor
DEALLOCATE townCursor
DROP TABLE #TempEmployeesWithTowns
GO