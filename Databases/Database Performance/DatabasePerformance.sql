CREATE TABLE Logs(
LogId INT PRIMARY KEY IDENTITY,
[Date] DATETIME NOT NULL,
[Text] VARCHAR(50)
)
GO

CREATE PROC usp_Populate_Table_Logs
AS
DECLARE @counter INT
SET @counter = 0
WHILE(@counter < 10000000)
BEGIN
	INSERT INTO Logs
	VALUES (GETDATE(), @counter)
	SET @counter = @counter + 1
END
GO

EXEC usp_Populate_Table_Logs

CHECKPOINT; DBCC DROPCLEANBUFFERS;

-- Done for 14 sec first time for me, 7 every other time
SELECT LogId, [Date]
FROM Logs
WHERE [Date] BETWEEN '2013-07-19 17:04:46.623' AND '2013-07-19 17:04:48.512'

CREATE INDEX IDX_Logs_Date ON Logs([Date])
--DROP INDEX IDX_Logs_Date ON Logs

-- Done for 0 sec for me with index
SELECT LogId, [Date]
FROM Logs
WHERE [Date] BETWEEN '2013-07-19 17:04:46.623' AND '2013-07-19 17:04:48.512'

CREATE FULLTEXT CATALOG LogsFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Logs([Text])
KEY INDEX PK_Logs_LogId
ON LogsFullTextCatalog
WITH CHANGE_TRACKING AUTO

CHECKPOINT; DBCC DROPCLEANBUFFERS;

SELECT * FROM Logs
WHERE CONTAINS([Text], '1231')