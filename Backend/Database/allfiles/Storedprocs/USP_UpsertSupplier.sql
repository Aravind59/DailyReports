CREATE PROCEDURE [dbo].[USP_UpsertSupplier]
(
@Id int,
@StationId int,
@UserId int null,
@Address NVARCHAR(150),
@MobileNumber NVARCHAR(20),
@LogNumber NVARCHAR(50),
@FirstName NVARCHAR(50),
@LastName NVARCHAR(50),
@IsActive bit
)
AS
BEGIN
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
IF(@Id = 0)
BEGIN
INSERT INTO Suppliers([StationId], [UserId] ,[FirstName], [LastName], [LogNumber], [MobileNumber], [Address], [IsActive], [CreateDateTime]) VALUES(@StationId, @UserId,@FirstName, @LastName, @LogNumber, @MobileNumber, @Address, 1, GETDATE())
SELECT SCOPE_IDENTITY()
END
ELSE
BEGIN
UPDATE Suppliers SET StationId = @StationId, UserId = @UserId, FirstName = @FirstName, LastName = @LastName, LogNumber = @LogNumber, [Address] = @Address, MobileNumber = @MobileNumber, IsActive = @IsActive , UpdateDateTime = GETDATE() WHERE Id = @Id
SELECT @Id
END
END