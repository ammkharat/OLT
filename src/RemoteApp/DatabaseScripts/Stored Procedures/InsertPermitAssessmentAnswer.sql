IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[InsertPermitAssessmentAnswer]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[InsertPermitAssessmentAnswer]
GO

CREATE PROCEDURE [dbo].[InsertPermitAssessmentAnswer]
(
	@Id bigint Output,    
	@PermitAssessmentId bigint,
	@SectionId bigint,
	@SectionName varchar(100),
	@SectionConfiguredPercentageWeighting decimal(5, 2),
	@SectionScoredPercentage decimal(5, 2),
	@QuestionId bigint,
	@ConfiguredWeight int,
	@QuestionText varchar(150),
	@SectionDisplayOrder int,
	@DisplayOrder int,
	@Score int,
	@Comments varchar(255)
)
AS
INSERT INTO PermitAssessmentAnswer
(
	PermitAssessmentId,
	SectionId,
	SectionName,
	SectionConfiguredPercentageWeighting,
	SectionScoredPercentage,
	QuestionId,
	ConfiguredWeight,
	QuestionText,
	SectionDisplayOrder,
	DisplayOrder,
	Score,
	Comments
)
VALUES
(
	@PermitAssessmentId,
	@SectionId,
	@SectionName,
	@SectionConfiguredPercentageWeighting,
	@SectionScoredPercentage,
	@QuestionId,
	@ConfiguredWeight,
	@QuestionText,
	@SectionDisplayOrder,
	@DisplayOrder,
	@Score,
	@Comments
)
SET @Id= SCOPE_IDENTITY() 
GO 
GRANT EXEC ON InsertPermitAssessmentAnswer TO PUBLIC
GO  