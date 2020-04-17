CREATE TABLE [dbo].[Stations]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[StationCode] VARCHAR(50),
	[Name] VARCHAR(100),	
	[Address] VARCHAR(150),
	[MobileNumber] VARCHAR(15),
	[IsActive] BIT,
	[PostCode] VARCHAR(50),
	[CreateDateTime] DATETIME NOT NULL,
	[UpdateDateTime] DATETIME NULL	
)
