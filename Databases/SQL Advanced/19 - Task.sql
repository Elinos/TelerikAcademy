USE TelerikAcademy
GO

INSERT INTO Groups (Name)
VALUES('Third Group'), ('Forth Group')
GO

INSERT INTO Users (Username, Password, Fullname, LastLogin, GroupID)
VALUES
 ('Ivan', 'ivanpass', 'Ivan Marinov', '2000-06-15 10:00:00.000', 1),
 ('Paul', 'paulpass', 'Paul Tompson', '2011-12-05 12:00:00.000', 2),
 ('Steven', 'stevenpass', 'Steven Carter', '2010-01-01 09:00:00.000', 1),
 ('May', 'maypass', 'May Evans', '2013-04-12 00:00:00.000', 2)
GO