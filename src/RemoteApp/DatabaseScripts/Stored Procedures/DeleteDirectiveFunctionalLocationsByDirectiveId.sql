  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteDirectiveFunctionalLocationsByDirectiveId')
	BEGIN
		DROP Procedure DeleteDirectiveFunctionalLocationsByDirectiveId
	END

GO

CREATE Procedure dbo.DeleteDirectiveFunctionalLocationsByDirectiveId(@DirectiveId bigint)
AS
DELETE FROM DirectiveFunctionalLocation WHERE DirectiveId = @DirectiveId

RETURN

GO   