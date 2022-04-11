CREATE PROCEDURE [dbo].[spAddNewTask]
	@taskName nvarchar(100),
	@setDate nvarchar(50),
	@expirationDate nvarchar(50)
AS
	
	INSERT INTO dbo.Task (TaskName, SetDate, ExpirationDate, Status) VALUES (@taskName, @setDate, @expirationDate, 'Undone')

RETURN 0
