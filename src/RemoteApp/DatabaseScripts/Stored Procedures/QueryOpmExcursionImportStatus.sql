IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryOpmExcursionImportStatus')
	BEGIN
		DROP PROCEDURE [dbo].QueryOpmExcursionImportStatus
	END
GO

/*
CHANGED BY: Komal Sahu(ksahu)
CHANGED ON: 03/31/2017
CHANGED FOR: INC0121679 (1st part of requirement)
DESCRIPTION: Updating the stored procedure [dbo].[QueryOpmExcursionImportStatus] as data insertion logic in table OpmExcursionImportStatus has been changed.
*/



CREATE Procedure [dbo].QueryOpmExcursionImportStatus
AS

SELECT TOP 1 
	eis.*

FROM OpmExcursionImportStatus eis 
Order By LastSuccessfulExcursionImportDateTime desc, LastExcursionImportDateTime desc
GO

GRANT EXEC ON QueryOpmExcursionImportStatus TO PUBLIC
GO