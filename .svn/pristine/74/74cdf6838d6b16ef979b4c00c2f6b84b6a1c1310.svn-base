IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByTrainingBlockId')
    BEGIN
        DROP Procedure [dbo].QueryFunctionalLocationsByTrainingBlockId
    END
GO

CREATE Procedure [dbo].QueryFunctionalLocationsByTrainingBlockId
(
    @TrainingBlockId bigint
)
AS

SELECT fl.* 
FROM 
	TrainingBlockFunctionalLocation tbfl
	INNER JOIN FunctionalLocation fl ON tbfl.FunctionalLocationId = fl.Id
WHERE TrainingBlockId = @TrainingBlockId
GO

GRANT EXEC ON QueryFunctionalLocationsByTrainingBlockId TO PUBLIC
GO