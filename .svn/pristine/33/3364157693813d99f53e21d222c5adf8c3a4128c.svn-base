IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormOilsandsTrainingFunctionalLocation')
	BEGIN
		DROP  Procedure  InsertFormOilsandsTrainingFunctionalLocation
	END

GO

CREATE Procedure [dbo].[InsertFormOilsandsTrainingFunctionalLocation]
	(
	@FormOilsandsTrainingId bigint,
	@FunctionalLocationId bigint	
	)
AS

INSERT INTO 
	[FormOilsandsTrainingFunctionalLocation]
	(
	[FormOilsandsTrainingId],
	[FunctionalLocationId]
	)
VALUES
	(	
	@FormOilsandsTrainingId,
	@FunctionalLocationId	
	)
	

GRANT EXEC ON [InsertFormOilsandsTrainingFunctionalLocation] TO PUBLIC
GO