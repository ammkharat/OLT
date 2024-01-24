IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTrainingBlocks')
	BEGIN
		DROP PROCEDURE [dbo].QueryTrainingBlocks
	END
GO

CREATE Procedure [dbo].QueryTrainingBlocks

@Siteid bigint

AS

SELECT
    tb.*
FROM
    TrainingBlock tb
WHERE
	tb.Deleted = 0 and siteid = @Siteid
GO

GRANT EXEC ON QueryTrainingBlocks TO PUBLIC
GO