IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestLubesLastImportDateTime')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitRequestLubesLastImportDateTime
	END
GO

CREATE Procedure [dbo].QueryPermitRequestLubesLastImportDateTime
AS

SELECT MAX(LastImportedDateTime) as LastImportedDateTime FROM PermitRequestLubes
GO

GRANT EXEC ON QueryPermitRequestLubesLastImportDateTime TO PUBLIC
GO