﻿/*
Deployment script for SampleDb

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "SampleDb"
:setvar DefaultFilePrefix "SampleDb"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER01\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER01\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creating [dbo].[USP_UpsertSupplier]...';


GO
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
GO
PRINT N'Creating [dbo].[USP_UpsertUser]...';


GO
CREATE PROCEDURE [dbo].[USP_UpsertUser]
(
@Id int,
@UserName NVARCHAR(100),
@Email  NVARCHAR(50),
@Password NVARCHAR(150),
@IsActive bit
)
AS
BEGIN
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
IF(@Id = 0)
BEGIN
INSERT INTO Users([UserName], [Email], [Password], [IsActive], [CreateDateTime]) VALUES(@UserName, @Email, @Password, 1, GETDATE())
SELECT SCOPE_IDENTITY()
END
ELSE
BEGIN
UPDATE Users SET [UserName] = @UserName, [Email] = @Email, [Password] = @Password, IsActive = @IsActive , UpdateDateTime = GETDATE() WHERE Id = @Id
SELECT @Id
END
END
GO
PRINT N'Update complete.';


GO