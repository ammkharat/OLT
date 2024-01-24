IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByFormOilsandsTrainingId')
    BEGIN
        DROP Procedure [dbo].QueryFunctionalLocationsByFormOilsandsTrainingId
    END
GO

CREATE Procedure [dbo].QueryFunctionalLocationsByFormOilsandsTrainingId
(
    @FormOilsandsTrainingId bigint
)
AS

SELECT fl.* 
FROM 
	FormOilsandsTrainingFunctionalLocation ffl
	INNER JOIN FunctionalLocation fl ON ffl.FunctionalLocationId = fl.Id
WHERE FormOilsandsTrainingId = @FormOilsandsTrainingId
GO

GRANT EXEC ON QueryFunctionalLocationsByFormOilsandsTrainingId TO PUBLIC
GO