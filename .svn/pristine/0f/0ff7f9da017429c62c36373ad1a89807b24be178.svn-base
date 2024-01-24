IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertTrainingBlockFunctionalLocation')
	BEGIN
		DROP  Procedure  InsertTrainingBlockFunctionalLocation
	END

GO

CREATE Procedure [dbo].[InsertTrainingBlockFunctionalLocation]
	(
	@TrainingBlockId bigint,
	@FunctionalLocationId bigint	
	)
AS

INSERT INTO 
	[TrainingBlockFunctionalLocation]
	(
	[TrainingBlockId],
	[FunctionalLocationId]
	)
VALUES
	(	
	@TrainingBlockId,
	@FunctionalLocationId	
	)
	

GRANT EXEC ON [InsertTrainingBlockFunctionalLocation] TO PUBLIC
GO