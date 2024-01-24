IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[UpdatePermitAssessmentAnswer]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[UpdatePermitAssessmentAnswer]
GO

CREATE PROCEDURE [dbo].[UpdatePermitAssessmentAnswer]
(
	@Id bigint Output,    
	@SectionScoredPercentage decimal(5, 2),
	@Score int,
	@Comments varchar(255)
)
AS
UPDATE PermitAssessmentAnswer
SET
	SectionScoredPercentage = @SectionScoredPercentage,
	Score = @Score,
	Comments = @Comments
WHERE Id = @Id
GO 

GRANT EXEC ON UpdatePermitAssessmentAnswer TO PUBLIC
GO  