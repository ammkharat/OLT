
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertWorkPermitMudsFunctionalLocation')
	BEGIN
		DROP Procedure [dbo].InsertWorkPermitMudsFunctionalLocation
	END
GO

CREATE Procedure [dbo].[InsertWorkPermitMudsFunctionalLocation]
	(
	@WorkPermitMudsId bigint,
	@FunctionalLocationId bigint	
	)
AS
							
INSERT INTO
	[WorkPermitMudsFunctionalLocation]
	(
	[WorkPermitMudsId],
	[FunctionalLocationId]
	)
VALUES
	(	
	@WorkPermitMudsId,
	@FunctionalLocationId	
	)
	

GRANT EXEC ON [InsertWorkPermitMudsFunctionalLocation] TO PUBLIC
GO
