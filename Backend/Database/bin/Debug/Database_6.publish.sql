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
PRINT N'Dropping [dbo].[FK_dbo.Users_UserId]...';


GO
ALTER TABLE [dbo].[Suppliers] DROP CONSTRAINT [FK_dbo.Users_UserId];


GO
PRINT N'Starting rebuilding table [dbo].[Users]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Users] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [UserName]       NVARCHAR (100) NULL,
    [Email]          NVARCHAR (50)  NULL,
    [Password]       NVARCHAR (250) NULL,
    [IsActive]       BIT            NULL,
    [IsAdmin]        BIT            NULL,
    [CreateDateTime] DATETIME       NOT NULL,
    [UpdateDateTime] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Users])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Users] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Users] ([Id], [UserName], [Email], [Password], [IsActive], [CreateDateTime], [UpdateDateTime])
        SELECT   [Id],
                 [UserName],
                 [Email],
                 [Password],
                 [IsActive],
                 [CreateDateTime],
                 [UpdateDateTime]
        FROM     [dbo].[Users]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Users] OFF;
    END

DROP TABLE [dbo].[Users];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Users]', N'Users';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[FK_dbo.Users_UserId]...';


GO
ALTER TABLE [dbo].[Suppliers] WITH NOCHECK
    ADD CONSTRAINT [FK_dbo.Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Altering [dbo].[USP_UpsertUser]...';


GO
ALTER PROCEDURE [dbo].[USP_UpsertUser]
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
GO
PRINT N'Refreshing [dbo].[USP_GetUserDetails]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[USP_GetUserDetails]';


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Suppliers] WITH CHECK CHECK CONSTRAINT [FK_dbo.Users_UserId];


GO
PRINT N'Update complete.';


GO
