CREATE PROCEDURE [dbo].[spChangeTask]
	@TaskId int,
	@TaskName nvarchar(100),
	@TaskExpirationDate date,
	@TaskStatus nvarchar(50)
AS
	UPDATE dbo.Task
	SET TaskName = @TaskName, ExpirationDate = @TaskExpirationDate, Status = @TaskStatus
	WHERE Id = @TaskId
RETURN 0
