CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[UserName] NVARCHAR(100),
	[Email] NVARCHAR(50),
	[Password] NVARCHAR(250),
	[IsActive] BIT,
	[IsAdmin] BIT,
	[CreateDateTime] DATETIME NOT NULL,
	[UpdateDateTime] DATETIME NULL	
)
GO

