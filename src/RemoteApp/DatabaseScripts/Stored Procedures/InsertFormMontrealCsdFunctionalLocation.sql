IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormMontrealCsdFunctionalLocation')
	BEGIN
		DROP  Procedure  InsertFormMontrealCsdFunctionalLocation
	END

GO

CREATE Procedure [dbo].[InsertFormMontrealCsdFunctionalLocation]
	(
	@FormMontrealCsdId bigint,
	@FunctionalLocationId bigint	
	)
AS

INSERT INTO 
	[FormMontrealCsdFunctionalLocation]
	(
	[FormMontrealCsdId],
	[FunctionalLocationId]
	)
VALUES
	(	
	@FormMontrealCsdId,
	@FunctionalLocationId	
	)
	

GRANT EXEC ON [InsertFormMontrealCsdFunctionalLocation] TO PUBLIC
GO