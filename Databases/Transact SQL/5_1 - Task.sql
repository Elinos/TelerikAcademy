USE Records
GO

CREATE PROC usp_WithdrawMoney(@AccountID int,	@amount money) AS
	BEGIN TRANSACTION
		DECLARE @oldBalance money = (SELECT Balance FROM Accounts WHERE AccontID = @AccountID)

		IF @amount > @oldBalance
		BEGIN
			ROLLBACK
			RAISERROR('Insufficient Funds!', 16, 1);
		END
		ELSE
		BEGIN
			DECLARE @newBalance money = @oldBalance - @amount

			UPDATE Accounts 
			SET Balance = @newBalance
			WHERE AccontID = @AccountID
			COMMIT TRANSACTION
		END
GO

EXEC usp_WithdrawMoney 1, 500
GO