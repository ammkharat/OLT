IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveTrainingBlock')
	BEGIN
		DROP  Procedure  RemoveTrainingBlock
	END

GO

CREATE Procedure [dbo].RemoveTrainingBlock
	(
		@Id bigint
	)
AS

UPDATE 	TrainingBlock
	SET Deleted = 1
	WHERE Id = @Id
GO


GRANT EXEC ON RemoveTrainingBlock TO PUBLIC

GO