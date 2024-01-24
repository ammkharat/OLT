if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateAvailableOpmExcursionImportStatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateAvailableOpmExcursionImportStatus]
GO

/*
CHANGED BY: Komal Sahu(ksahu)
CHANGED ON: 03/31/2017
CHANGED FOR: INC0121679 (1st part of requirement)
DESCRIPTION: To maintain logging, converting 'UPDATE' statement into 'INSERT' statement
*/


CREATE Procedure [dbo].[UpdateAvailableOpmExcursionImportStatus]
    (
			@LastSuccessfulExcursionImportDateTime datetime,
			@LastExcursionImportDateTime datetime,
			@LastExcursionImportStatus int
    )
AS

INSERT INTO OpmExcursionImportStatus(LastSuccessfulExcursionImportDateTime, LastExcursionImportDateTime, LastExcursionImportStatus)
VALUES (@LastSuccessfulExcursionImportDateTime, @LastExcursionImportDateTime, @LastExcursionImportStatus)

GO

GRANT EXEC ON [UpdateAvailableOpmExcursionImportStatus] TO PUBLIC
GO
