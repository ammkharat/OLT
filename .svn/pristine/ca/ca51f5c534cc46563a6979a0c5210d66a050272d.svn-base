IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertWorkPermitMontrealFunctionalLocation')
	BEGIN
		DROP  Procedure  InsertWorkPermitMontrealFunctionalLocation
	END

GO

CREATE Procedure [dbo].[InsertWorkPermitMontrealFunctionalLocation]
	(
	@WorkPermitMontrealId bigint,
	@FunctionalLocationId bigint	
	)
AS
							
INSERT INTO
	[WorkPermitMontrealFunctionalLocation]
	(
	[WorkPermitMontrealId],
	[FunctionalLocationId]
	)
VALUES
	(	
	@WorkPermitMontrealId,
	@FunctionalLocationId	
	)
	

GRANT EXEC ON [InsertWorkPermitMontrealFunctionalLocation] TO PUBLIC
GO