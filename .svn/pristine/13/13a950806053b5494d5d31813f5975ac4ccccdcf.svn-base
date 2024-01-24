if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateUnavailableOpmExcursionImportStatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateUnavailableOpmExcursionImportStatus]
GO

/*
CHANGED BY: Komal Sahu(ksahu)
CHANGED ON: 03/31/2017
CHANGED FOR: INC0121679 (1st part of requirement)
DESCRIPTION: To maintain logging, converting 'UPDATE' statement into 'INSERT' statement
*/


CREATE Procedure [dbo].[UpdateUnavailableOpmExcursionImportStatus]
    (
			@LastExcursionImportDateTime datetime,
			@LastExcursionImportStatus int
    )
AS

INSERT INTO OpmExcursionImportStatus(LastExcursionImportDateTime,LastExcursionImportStatus)
VALUES (@LastExcursionImportDateTime, @LastExcursionImportStatus)

GO

GRANT EXEC ON [UpdateUnavailableOpmExcursionImportStatus] TO PUBLIC
GO
