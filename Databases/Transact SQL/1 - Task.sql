USE Records
GO

CREATE TABLE Persons (
PersonID int IDENTITY,
FirstName nvarchar(50) NOT NULL,
LastName nvarchar(50) NOT NULL,
SSN nvarchar(50) NOT NULL
CONSTRAINT PK_PersonsID PRIMARY KEY(PersonID)
)
GO

CREATE TABLE Accounts (
AccontID int IDENTITY,
PersonID int,
Balance money DEFAULT 0,
CONSTRAINT PK_AccountID PRIMARY KEY(AccontID),
CONSTRAINT FK_PersonID FOREIGN KEY (PersonID)
	REFERENCES Persons(PersonID)
)
GO

INSERT INTO Persons (FirstName, LastName, SSN)
VALUES ('Pesho', 'Ivanov', '987-65-4329'), ('Maria', 'Stefanova', '843-55-0234')
GO

CREATE PROC usp_Select_Persons_Fullnames AS
	SELECT FirstName + ' ' + LastName AS Fullname
	FROM Persons
GO

EXEC usp_Select_Persons_Fullnames
GO
