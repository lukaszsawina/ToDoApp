CREATE VIEW [dbo].[DoneTask]
	AS 
	SELECT * FROM dbo.Task
	WHERE Status = 'Done'
