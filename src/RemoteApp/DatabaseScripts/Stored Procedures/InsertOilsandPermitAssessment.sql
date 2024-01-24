if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertOilsandPermitAssessment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertOilsandPermitAssessment]
GO

CREATE Procedure [dbo].[InsertOilsandPermitAssessment]
(
	@Id bigint Output,
	@CreatedDateTime datetime,
	@CreatedByUserId bigint,
	@CreationUserShiftPatternId bigint,
	@SiteId bigint,
	@FormStatusId int,
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	@ApprovedDateTime datetime = NULL,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,	
	@TotalQuestionnaireWeight int,
	@QuestionnaireId bigint,
	@QuestionnaireName varchar(100),
	@QuestionnaireVersion int,
	@CrewSize int,
	@IssuedToSuncor bit,
	@IssuedToContractor bit,
	@IsIlpRecommended bit,
	@Contractor varchar(100),
	@Trade varchar(100),
	@PermitNumber varchar(10),
	@TotalScoredPercentage decimal(5,2),
	@TotalAnswerScore int,
	@TotalAnswerWeightedScore int,
	@JobDescription varchar(255),
	@OverallFeedback varchar(255),
	@LocationEquipmentNumber varchar(100),
	@JobCoordinator varchar(100),
	@OilsandsWorkPermitTypeId int
)
AS

DECLARE @NewFormId bigint
BEGIN
	EXEC @NewFormId = GetNewSeqVal_FormOilsandsIdSequence
END

INSERT INTO FormPermitAssessment
(
	Id,
	CreatedDateTime,
	CreatedByUserId,
	CreationUserShiftPatternId,
	SiteId,
	FormStatusId,
	ValidFromDateTime,
	ValidToDateTime,
	ApprovedDateTime,
	LastModifiedByUserId,
	LastModifiedDateTime,	
	TotalQuestionnaireWeight,
	QuestionnaireId,
	QuestionnaireName,
	QuestionnaireVersion,
	CrewSize,
	IssuedToSuncor,
	IssuedToContractor,
	IsIlpRecommended,
	Contractor,
	Trade,
	PermitNumber,
	TotalScoredPercentage,
	TotalAnswerScore,
	TotalAnswerWeightedScore,
	JobDescription,
	OverallFeedback,
	LocationEquipmentNumber,
	JobCoordinator,
	OilsandsWorkPermitType,
	Deleted
)
VALUES
(
	@NewFormId,
	@CreatedDateTime,
	@CreatedByUserId,
	@CreationUserShiftPatternId,
	@SiteId,
	@FormStatusId,
	@ValidFromDateTime,
	@ValidToDateTime,
	@ApprovedDateTime,
	@LastModifiedByUserId,
	@LastModifiedDateTime,	
	@TotalQuestionnaireWeight,
	@QuestionnaireId,
	@QuestionnaireName,
	@QuestionnaireVersion,
	@CrewSize,
	@IssuedToSuncor,
	@IssuedToContractor,
	@IsIlpRecommended,
	@Contractor,
	@Trade,
	@PermitNumber,
	@TotalScoredPercentage,
	@TotalAnswerScore,
	@TotalAnswerWeightedScore,
	@JobDescription,
	@OverallFeedback,
	@LocationEquipmentNumber,
	@JobCoordinator,
	@OilsandsWorkPermitTypeId,
	0
);

SET @Id=@NewFormId; 

GO

GRANT EXEC ON InsertOilsandPermitAssessment TO PUBLIC
GO
