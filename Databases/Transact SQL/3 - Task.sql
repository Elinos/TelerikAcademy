USE Records
GO

CREATE PROC usp_Calculate_Sum_With_Interest(@Sum money,	@InterestRate float, @MonthsCount int) AS
	RETURN @Sum *(POWER(1 + @InterestRate / 100.00, @MonthsCount / 12.00))
GO

DECLARE @ResultSum money 
EXEC @ResultSum = usp_Calculate_Sum_With_Interest 5000, 50.00, 1
SELECT @ResultSum
GO