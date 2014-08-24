USE TelerikAcademy
GO

SELECT COUNT(*) AS [Number of employees with manager]
FROM Employees e
WHERE e.ManagerID IS NOT NULL