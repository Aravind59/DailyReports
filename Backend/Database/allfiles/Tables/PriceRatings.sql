CREATE TABLE [dbo].[PriceRatings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[LowerBound] INT,
	[UpperBound] INT,
	[Price] REAL 
)
