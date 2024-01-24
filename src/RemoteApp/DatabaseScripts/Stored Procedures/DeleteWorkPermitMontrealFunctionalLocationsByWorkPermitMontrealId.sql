  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteWorkPermitMontrealFunctionalLocationsByWorkPermitMontrealId')
	BEGIN
		DROP  Procedure  DeleteWorkPermitMontrealFunctionalLocationsByWorkPermitMontrealId
	END

GO

CREATE Procedure dbo.DeleteWorkPermitMontrealFunctionalLocationsByWorkPermitMontrealId
	(	
	@WorkPermitMontrealId bigint
	)
AS
DELETE FROM WorkPermitMontrealFunctionalLocation WHERE WorkPermitMontrealId = @WorkPermitMontrealId

RETURN

GO   
