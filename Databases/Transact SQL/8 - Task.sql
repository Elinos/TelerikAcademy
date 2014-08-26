USE TelerikAcademy
GO

SELECT e.EmployeeID ,e.FirstName + ISNULL(' '+ e.MiddleName, '') + ' ' + e.LastName AS EmployeeName, t.TownID, t.Name as TownName
INTO #TempEmployeesWithTowns
FROM Employees e INNER JOIN Addresses a on e.AddressID = a.AddressID
INNER JOIN Towns t on a.TownID = t.TownID 
CREATE UNIQUE CLUSTERED INDEX Idx_TemEmp ON #TempEmployeesWithTowns(EmployeeID)

DECLARE empCursor CURSOR READ_ONLY FOR
SELECT EmployeeID, EmployeeName, TownID,TownName
FROM #TempEmployeesWithTowns

OPEN empCursor
DECLARE @employeeID int, @employeeName varchar(150), @townID int,  @townName varchar(50)
FETCH NEXT FROM empCursor INTO @employeeID, @employeeName, @townID, @townName

CREATE TABLE #TempEmployeeFromSameTownPairs (FirstEmployeeName varchar(150), SecondEmployeeName varchar(150), TownName varchar(50))
WHILE @@FETCH_STATUS = 0
  BEGIN
	INSERT INTO #TempEmployeeFromSameTownPairs (FirstEmployeeName, SecondEmployeeName, TownName)
	SELECT @employeeName, EmployeeName, @townName FROM #TempEmployeesWithTowns e
	WHERE e.TownID = @townID AND e.EmployeeID <> @employeeID
    FETCH NEXT FROM empCursor INTO @employeeID, @employeeName, @townID, @townName           
  END
CLOSE empCursor
DEALLOCATE empCursor

SELECT TownName, FirstEmployeeName, SecondEmployeeName FROM #TempEmployeeFromSameTownPairs
ORDER BY TownName, FirstEmployeeName, SecondEmployeeName
DROP TABLE #TempEmployeeFromSameTownPairs
DROP TABLE #TempEmployeesWithTowns
GO