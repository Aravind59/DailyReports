CREATE PROCEDURE [dbo].[Usp_AddDailyReport]
(
@Id int,
@SupplierId int,
@Quantity real,
@Percentage real,
@Price real
)
AS
BEGIN
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
IF(@Id = 0)
BEGIN
INSERT INTO DailyReports VALUES(@SupplierId, @Quantity, @Percentage, @Price, GETDATE(), NULL)
END
ELSE
BEGIN
UPDATE DailyReports SET SupplierId = @SupplierId, Quantity = @Quantity, [Percentage] = @Percentage, Price = @Price, UpdateDateTime = GETDATE() WHERE Id = @Id
END
END