IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTrainingBlockById')
	BEGIN
		DROP PROCEDURE [dbo].QueryTrainingBlockById
	END
GO

CREATE Procedure dbo.QueryTrainingBlockById
	(
	@id bigint
	)
AS

SELECT *
FROM
	TrainingBlock
WHERE 
	TrainingBlock.Id = @Id
GO
 
GRANT EXEC ON QueryTrainingBlockById TO PUBLIC
GO