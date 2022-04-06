CREATE TABLE [dbo].[Task]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TaskName] NVARCHAR(100) NOT NULL, 
    [Description] TEXT NULL, 
    [SetDate] DATE NOT NULL, 
    [ExpirationDate] DATE NULL, 
    [Status] NVARCHAR(50) NOT NULL
)
