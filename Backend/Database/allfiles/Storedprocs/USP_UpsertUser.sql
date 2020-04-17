CREATE PROCEDURE [dbo].[USP_UpsertUser]
(
@Id int,
@UserName NVARCHAR(100),
@Email  NVARCHAR(50),
@Password NVARCHAR(150),
@IsActive BIT,
@IsAdmin BIT
)
AS
BEGIN
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
IF(@Id = 0)
BEGIN
INSERT INTO Users([UserName], [Email], [Password], [IsActive], [CreateDateTime], [IsAdmin]) VALUES(@UserName, @Email, @Password, 1, GETDATE(), @IsAdmin)
SELECT SCOPE_IDENTITY()
END
ELSE
BEGIN
UPDATE Users SET [UserName] = @UserName, [Email] = @Email, [Password] = @Password, IsActive = @IsActive , UpdateDateTime = GETDATE() WHERE Id = @Id
SELECT @Id
END
END