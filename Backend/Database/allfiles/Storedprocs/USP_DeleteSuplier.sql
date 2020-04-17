CREATE PROCEDURE [dbo].[USP_DeleteSuplier]
(
@SuplierId int,
@IsActive bit
)
AS
BEGIN
UPDATE Suppliers SET IsActive = @IsActive WHERE Id = @SuplierId
END
