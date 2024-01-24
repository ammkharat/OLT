  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteFormOilsandsTrainingFunctionalLocationsByFormOilsandsTrainingId')
	BEGIN
		DROP  Procedure  DeleteFormOilsandsTrainingFunctionalLocationsByFormOilsandsTrainingId
	END

GO

CREATE Procedure dbo.DeleteFormOilsandsTrainingFunctionalLocationsByFormOilsandsTrainingId
	(	
	@FormOilsandsTrainingId bigint
	)
AS
DELETE FROM FormOilsandsTrainingFunctionalLocation WHERE FormOilsandsTrainingId = @FormOilsandsTrainingId

RETURN

GO   