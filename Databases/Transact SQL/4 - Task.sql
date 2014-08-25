USE Records
GO

CREATE PROC usp_Acquire_Interest_To_Account(@AccountID int,	@InterestRate float) AS
	DECLARE @oldSum money = (SELECT Balance FROM Accounts WHERE AccontID = @AccountID)
	DECLARE @NewBalance money
	EXEC @NewBalance = usp_Calculate_Sum_With_Interest @oldSum, @InterestRate, 1

	UPDATE Accounts 
	SET Balance = @NewBalance
	WHERE AccontID = @AccountID
GO

EXEC usp_Acquire_Interest_To_Account 1, 50.00
GO