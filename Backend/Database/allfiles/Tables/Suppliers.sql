CREATE TABLE [dbo].[Suppliers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[StationId] INT NOT NULL,
	[UserId] INT NULL,
	[LogNumber] VARCHAR(50),
	[FirstName] VARCHAR(50),
	[LastName] VARCHAR(50),
	[Address] VARCHAR(150),
	[MobileNumber] VARCHAR(15),
	[CreateDateTime] DATETIME NOT NULL,
	[UpdateDateTime] DATETIME NULL	,
	[IsActive] bit
)
GO

ALTER TABLE [dbo].[Suppliers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Stations_StationId] FOREIGN KEY([StationId])
REFERENCES [dbo].[Stations] ([Id])
GO

ALTER TABLE [dbo].[Suppliers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO