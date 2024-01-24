 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertPermitAssessmentAnswerHistory')
	BEGIN
		DROP Procedure InsertPermitAssessmentAnswerHistory
	END
GO

CREATE Procedure [dbo].[InsertPermitAssessmentAnswerHistory]
(
	@PermitAssessmentHistoryId bigint,
	@PermitAssessmentAnswerId bigint,
	@Id bigint,
	@SectionScoredPercentage decimal(5, 2),
	@Score int,
	@Comments varchar(255) = null
)
AS

INSERT INTO [PermitAssessmentAnswerHistory]
(
	[PermitAssessmentHistoryId],
	[PermitAssessmentAnswerId],
	[Id],
	[SectionScoredPercentage],
	[Score],
	[Comments]
)
VALUES
(
	@PermitAssessmentHistoryId,
	@PermitAssessmentAnswerId,
	@Id,
	@SectionScoredPercentage,
	@Score,
	@Comments
)

GO

GRANT EXEC ON [InsertPermitAssessmentAnswerHistory] TO PUBLIC
GO