CREATE PROCEDURE [dbo].[Usp_UpsertStation]
(
@Id int,
@StationName NVARCHAR(100),
@StationCode  NVARCHAR(50),
@Address NVARCHAR(150),
@MobileNumber NVARCHAR(20),
@IsActive bit
)
AS
BEGIN
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
IF(@Id = 0)
BEGIN
INSERT INTO Stations([Name], [StationCode], [MobileNumber], [Address], [IsActive], [CreateDateTime]) VALUES(@StationName, @StationCode, @MobileNumber, @Address, 1, GETDATE())
SELECT SCOPE_IDENTITY()
END
ELSE
BEGIN
UPDATE Stations SET [Name] = @StationName, StationCode = @StationCode, [Address] = @Address, MobileNumber = @MobileNumber, IsActive = @IsActive , UpdateDateTime = GETDATE() WHERE Id = @Id
SELECT @Id
END
END