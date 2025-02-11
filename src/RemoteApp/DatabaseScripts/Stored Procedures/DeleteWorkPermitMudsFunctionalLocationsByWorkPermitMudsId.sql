
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteWorkPermitMudsFunctionalLocationsByWorkPermitMudsId')
	BEGIN
		DROP Procedure [dbo].DeleteWorkPermitMudsFunctionalLocationsByWorkPermitMudsId
	END
GO



CREATE Procedure [dbo].[DeleteWorkPermitMudsFunctionalLocationsByWorkPermitMudsId]
	(	
	@WorkPermitMudsId bigint
	)
AS
DELETE FROM WorkPermitMudsFunctionalLocation WHERE WorkPermitMudsId = @WorkPermitMudsId

RETURN
GO


GRANT EXEC ON DeleteWorkPermitMudsFunctionalLocationsByWorkPermitMudsId TO PUBLIC
GO

