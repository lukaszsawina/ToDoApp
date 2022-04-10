CREATE PROCEDURE [dbo].[spAddNewTask]
	@taskName nvarchar(100),
	@setDate date,
	@expirationDate date
AS
	
	INSERT INTO dbo.Task (TaskName, SetDate, ExpirationDate) VALUES (@taskName, @setDate, @expirationDate)

RETURN 0
