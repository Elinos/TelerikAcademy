USE TelerikAcademy
GO

SELECT COUNT(*) AS [Number of employees without manager]
FROM Employees e
WHERE e.ManagerID IS NULL