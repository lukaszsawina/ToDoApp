CREATE PROCEDURE [dbo].[spAddNewTask]
	@taskName nvarchar(100),
	@taskDescription text,
	@setDate date,
	@expirationDate date
AS
	
	INSERT INTO dbo.Task (TaskName, Description, SetDate, ExpirationDate) VALUES (@taskName, @taskDescription, @setDate, @expirationDate)

RETURN 0
