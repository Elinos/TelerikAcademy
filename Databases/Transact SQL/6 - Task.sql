USE Records
GO

CREATE TABLE Logs (
LogID int IDENTITY,
AccountID int,
OldSum money,
NewSum money
CONSTRAINT PK_LogID PRIMARY KEY(LogID)
)
GO

CREATE TRIGGER tr_Sum_Updated ON Accounts
AFTER UPDATE AS
	IF UPDATE(Balance)
	BEGIN
		DECLARE @AccountID int = (SELECT AccontID FROM inserted)
		DECLARE @OldSum money = (SELECT Balance FROM deleted)
		DECLARE @NewSum money = (SELECT Balance FROM inserted)

		INSERT INTO Logs (AccountID, OldSum, NewSum)
		VALUES (@AccountID, @OldSum, @NewSum)
	END
GO

UPDATE Accounts
SET Balance = 50
WHERE AccontID = 1

SELECT * FROM Logs
GO