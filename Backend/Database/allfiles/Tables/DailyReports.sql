CREATE TABLE [dbo].[DailyReports]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[SupplierId] INT NOT NULL,
	[Quantity] FLOAT DEFAULT 0,
	[Percentage] REAL DEFAULT 0,
	[Price] REAL DEFAULT 0,
	[CreateDateTime] DATETIME NOT NULL,
	[UpdateDateTime] DATETIME NULL	
)
GO

ALTER TABLE [dbo].[DailyReports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DailyReports_dbo.Suppliers_SupplierId] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Suppliers] ([Id])
GO