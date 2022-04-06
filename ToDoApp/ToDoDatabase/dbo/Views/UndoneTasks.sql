CREATE VIEW [dbo].[UndoneTasks]
	AS 
	SELECT * FROM dbo.Task
	WHERE Status = 'Done'