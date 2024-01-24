IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountOfTrainingBlocksWithGivenName')
	BEGIN
		DROP Procedure [dbo].CountOfTrainingBlocksWithGivenName
	END
GO

CREATE Procedure [dbo].CountOfTrainingBlocksWithGivenName
	(
		@TrainingBlockName varchar(max),
		@TrainingBlockId bigint = NULL,
		@Siteid bigint
	)
AS

SELECT
	Count(*)
FROM
	TrainingBlock tb
WHERE
	LOWER(tb.Name) = LOWER(@TrainingBlockName) AND
	(@TrainingBlockId is null OR tb.Id != @TrainingBlockId) AND Siteid = @Siteid AND
	tb.Deleted = 0
	
GO


GRANT EXEC ON CountOfTrainingBlocksWithGivenName TO PUBLIC
GO