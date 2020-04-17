CREATE PROCEDURE USP_GetUserDetails
(
 @UserName nvarchar(50)
 
)
AS
BEGIN
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
BEGIN TRY
SELECT * from [users] where Email = @UserName 
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