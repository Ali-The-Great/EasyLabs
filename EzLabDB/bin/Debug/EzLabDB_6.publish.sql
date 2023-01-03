﻿/*
Deployment script for EzLabDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "EzLabDB"
:setvar DefaultFilePrefix "EzLabDB"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\"

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
PRINT N'Creating Procedure [dbo].[spAppointment_Insert]...';


GO
CREATE PROCEDURE [dbo].[spAppointment_Insert]
    @user_id int,
    @test_id int,
    @appointment_date date,
    @appointment_time time(7)

AS
Begin
	insert into dbo.[Appointment] (user_id ,test_id,appointment_date,appointment_time) 
	values (@user_id ,@test_id,@appointment_date,@appointment_time)
RETURN 0
End
GO
PRINT N'Creating Procedure [dbo].[spTest_id]...';


GO
CREATE PROCEDURE [dbo].[spTest_id]
AS
BEGIN
    SELECT test_type,test_id FROM dbo.[Test]
RETURN 0
END
GO
PRINT N'Creating Procedure [dbo].[spUser_id]...';


GO
CREATE PROCEDURE [dbo].[spUser_id]
AS
BEGIN
    SELECT mail,user_Id FROM dbo.[User]
RETURN 0
END
GO
PRINT N'Update complete.';


GO