IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonLastImportDateTime')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitRequestEdmontonLastImportDateTime
	END
GO

CREATE Procedure [dbo].QueryPermitRequestEdmontonLastImportDateTime
AS

SELECT MAX(LastImportedDateTime) as LastImportedDateTime FROM PermitRequestEdmonton
GO

GRANT EXEC ON QueryPermitRequestEdmontonLastImportDateTime TO PUBLIC
GO