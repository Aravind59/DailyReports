CREATE PROCEDURE [dbo].[USP_GetSuppliers]
(
 @StationId INT
)
AS
BEGIN
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
BEGIN TRY
SELECT * FROM Suppliers where StationId = @StationId AND IsActive = 1
END TRY
   BEGIN CATCH        
        SELECT ERROR_NUMBER() AS ErrorNumber,
               ERROR_SEVERITY() AS ErrorSeverity,
               ERROR_STATE() AS ErrorState,
               ERROR_PROCEDURE() AS ErrorProcedure,
               ERROR_LINE() AS ErrorLine,
               ERROR_MESSAGE() AS ErrorMessage
    END CATCH
END