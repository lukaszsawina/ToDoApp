/*
Deployment script for TaskDatabase

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "TaskDatabase"
:setvar DefaultFilePrefix "TaskDatabase"
:setvar DefaultDataPath "C:\Users\lukis\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\lukis\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column [dbo].[Task].[Description] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Task])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Altering Table [dbo].[Task]...';


GO
ALTER TABLE [dbo].[Task] DROP COLUMN [Description];


GO
PRINT N'Refreshing View [dbo].[DoneTask]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[DoneTask]';


GO
PRINT N'Refreshing View [dbo].[FullTask]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[FullTask]';


GO
PRINT N'Refreshing View [dbo].[UndoneTasks]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[UndoneTasks]';


GO
PRINT N'Altering Procedure [dbo].[spAddNewTask]...';


GO
ALTER PROCEDURE [dbo].[spAddNewTask]
	@taskName nvarchar(100),
	@setDate date,
	@expirationDate date
AS
	
	INSERT INTO dbo.Task (TaskName, SetDate, ExpirationDate) VALUES (@taskName, @setDate, @expirationDate)

RETURN 0
GO
PRINT N'Altering Procedure [dbo].[spChangeTask]...';


GO
ALTER PROCEDURE [dbo].[spChangeTask]
	@TaskId int,
	@TaskName nvarchar(100),
	@TaskExpirationDate date,
	@TaskStatus nvarchar(50)
AS
	UPDATE dbo.Task
	SET TaskName = @TaskName, ExpirationDate = @TaskExpirationDate, Status = @TaskStatus
	WHERE Id = @TaskId
RETURN 0
GO
PRINT N'Refreshing Procedure [dbo].[spChangeTaskStatus]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[spChangeTaskStatus]';


GO
PRINT N'Update complete.';


GO
