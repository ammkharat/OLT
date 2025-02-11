
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestMudsLastImportDateTime')
	BEGIN
		DROP Procedure [dbo].QueryPermitRequestMudsLastImportDateTime
	END
GO

CREATE Procedure [dbo].[QueryPermitRequestMudsLastImportDateTime]  
AS  
  
SELECT MAX(LastImportedDateTime) as LastImportedDateTime FROM PermitRequestMuds
GO

GRANT EXEC ON QueryPermitRequestMudsLastImportDateTime TO PUBLIC
GO
