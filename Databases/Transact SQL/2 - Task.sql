USE Records
GO

CREATE PROC usp_Check_Persons_Balance(@ammount money) AS
	SELECT FirstName + ' ' + LastName AS Fullname
	FROM Persons p 
		INNER JOIN Accounts a
		ON p.PersonID = a.PersonID AND a.Balance > @ammount
GO

EXEC usp_Check_Persons_Balance 500
GO