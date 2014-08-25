USE Records
GO

CREATE PROC usp_DepositMoney(@AccountID int, @amount money) AS
	BEGIN TRANSACTION
		DECLARE @oldBalance money = (SELECT Balance FROM Accounts WHERE AccontID = @AccountID)
		DECLARE @newBalance money = @oldBalance + @amount

		UPDATE Accounts 
		SET Balance = @newBalance
		WHERE AccontID = @AccountID
	COMMIT TRANSACTION
GO

EXEC usp_DepositMoney 1, 500
GO