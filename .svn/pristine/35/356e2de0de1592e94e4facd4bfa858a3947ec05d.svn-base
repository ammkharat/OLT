IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertPermitRequestMontrealFunctionalLocation')
	BEGIN
		DROP  Procedure  InsertPermitRequestMontrealFunctionalLocation
	END

GO

CREATE Procedure [dbo].[InsertPermitRequestMontrealFunctionalLocation]
	(
	@PermitRequestMontrealId bigint,
	@FunctionalLocationId bigint	
	)
AS
							
INSERT INTO
	[PermitRequestMontrealFunctionalLocation]
	(
	[PermitRequestMontrealId],
	[FunctionalLocationId]
	)
VALUES
	(	
	@PermitRequestMontrealId,
	@FunctionalLocationId	
	)
	

GRANT EXEC ON [InsertPermitRequestMontrealFunctionalLocation] TO PUBLIC
GO