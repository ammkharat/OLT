IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestMontrealLastImportDateTime')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitRequestMontrealLastImportDateTime
	END
GO

CREATE Procedure [dbo].QueryPermitRequestMontrealLastImportDateTime
AS

SELECT MAX(LastImportedDateTime) as LastImportedDateTime FROM PermitRequestMontreal
GO

GRANT EXEC ON QueryPermitRequestMontrealLastImportDateTime TO PUBLIC
GO