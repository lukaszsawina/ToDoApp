CREATE PROCEDURE [dbo].[spChangeTaskStatus]
	@TaskId int,
	@Status nvarchar(50)
AS
	UPDATE dbo.Task 
	SET Task.Status = @Status 
	WHERE Task.Id = @TaskId
