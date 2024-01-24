  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteTrainingBlockFunctionalLocationsByTrainingBlockId')
	BEGIN
		DROP  Procedure  DeleteTrainingBlockFunctionalLocationsByTrainingBlockId
	END

GO

CREATE Procedure dbo.DeleteTrainingBlockFunctionalLocationsByTrainingBlockId
	(	
		@TrainingBlockId bigint
	)
AS
DELETE FROM TrainingBlockFunctionalLocation WHERE TrainingBlockId = @TrainingBlockId

RETURN

GO   