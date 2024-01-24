  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteFormMontrealCsdFunctionalLocationsByFormMontrealCsdId')
	BEGIN
		DROP  Procedure  DeleteFormMontrealCsdFunctionalLocationsByFormMontrealCsdId
	END

GO

CREATE Procedure dbo.DeleteFormMontrealCsdFunctionalLocationsByFormMontrealCsdId
	(	
	@FormMontrealCsdId bigint
	)
AS
DELETE FROM FormMontrealCsdFunctionalLocation WHERE FormMontrealCsdId = @FormMontrealCsdId

RETURN

GO   