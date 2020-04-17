CREATE PROCEDURE USP_GetDailyReports
(
 @Date DATETIME
)
AS
BEGIN
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
BEGIN TRY
SELECT dr.Id, SupplierId, sp.LogNumber, (sp.FirstName + ' ' + sp.LastName) as SupplierName, Quantity, Price, [Percentage], DR.CreateDateTime, DR.UpdateDateTime  FROM DailyReports dr
join Suppliers as sp on sp.Id = dr.SupplierId
 --where DR.CreateDateTime = @Date
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