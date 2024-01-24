 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertPermitAssessmentHistory')
	BEGIN
		DROP Procedure InsertPermitAssessmentHistory
	END
GO

CREATE Procedure [dbo].[InsertPermitAssessmentHistory]
(
	@PermitAssessmentHistoryId bigint Output,
	@Id bigint,
	@FormStatusId int,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@FunctionalLocations varchar(MAX),
	@DocumentLinks varchar(MAX),
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	@IssuedToSuncor bit,
	@IssuedToContractor bit,
	@CrewSize int,
	@OilsandsWorkPermitType int,
	@TotalScoredPercentage decimal(5, 2),
	@TotalAnswerScore int,
	@TotalAnswerWeightedScore int,
	@TotalQuestionnaireWeight int,
	@JobDescription varchar(255),
	@OverallFeedback varchar(255),
	@LocationEquipmentNumber varchar(100),
	@JobCoordinator varchar(100),
	@PermitNumber varchar(10),
	@contractor varchar(100),
	@IsIlpRecommended bit,
	@Trade varchar(100)
)
AS
INSERT INTO [PermitAssessmentHistory]
(
	[Id],
	[FormStatusId],
	[LastModifiedByUserId],
	[LastModifiedDateTime],
	[FunctionalLocations],
	[DocumentLinks],
	[ValidFromDateTime],
	[ValidToDateTime],
	[IssuedToSuncor],
	[IssuedToContractor],
	[CrewSize],
	[OilsandsWorkPermitType],
	[TotalScoredPercentage],
	[TotalAnswerScore],
	[TotalAnswerWeightedScore],
	[TotalQuestionnaireWeight],
	[JobDescription],
	[OverallFeedback],
	[LocationEquipmentNumber],
	[JobCoordinator],
	[PermitNumber],
	[contractor],
	[IsIlpRecommended],
	[Trade]
)
VALUES
(
	@Id,
	@FormStatusId,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	@FunctionalLocations,
	@DocumentLinks,
	@ValidFromDateTime,
	@ValidToDateTime,
	@IssuedToSuncor,
	@IssuedToContractor,
	@CrewSize,
	@OilsandsWorkPermitType,
	@TotalScoredPercentage,
	@TotalAnswerScore,
	@TotalAnswerWeightedScore,
	@TotalQuestionnaireWeight,
	@JobDescription,
	@OverallFeedback,
	@LocationEquipmentNumber,
	@JobCoordinator,
	@PermitNumber,
	@contractor,
	@IsIlpRecommended,
	@Trade
)
SET @PermitAssessmentHistoryId = SCOPE_IDENTITY() 
GO

GRANT EXEC ON [InsertPermitAssessmentHistory] TO PUBLIC
GO