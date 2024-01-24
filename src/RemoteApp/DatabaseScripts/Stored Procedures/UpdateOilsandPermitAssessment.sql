if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateOilsandPermitAssessment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateOilsandPermitAssessment]
GO

CREATE Procedure [dbo].[UpdateOilsandPermitAssessment]
(
	@Id bigint,
	@SiteId bigint,
	@FormStatusId int,
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	@ApprovedDateTime datetime = NULL,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,	
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

UPDATE FormPermitAssessment
	SET 
	SiteId = @SiteId,
	FormStatusId = @FormStatusId,
	ValidFromDateTime = @ValidFromDateTime,
	ValidToDateTime = @ValidToDateTime,
	ApprovedDateTime = @ApprovedDateTime,
	LastModifiedByUserId = @LastModifiedByUserId,
	LastModifiedDateTime = @LastModifiedDateTime,	
	CrewSize = @CrewSize,
	IssuedToSuncor = @IssuedToSuncor,
	IssuedToContractor = @IssuedToContractor,
	IsIlpRecommended = @IsIlpRecommended,
	Contractor = @Contractor,
	Trade = @Trade,
	PermitNumber = @PermitNumber,
	TotalScoredPercentage = @TotalScoredPercentage,
	TotalAnswerScore = @TotalAnswerScore,
	TotalAnswerWeightedScore = @TotalAnswerWeightedScore,
	JobDescription = @JobDescription,
	OverallFeedback = @OverallFeedback,
	LocationEquipmentNumber = @LocationEquipmentNumber,
	JobCoordinator = @JobCoordinator,
	OilsandsWorkPermitType = @OilsandsWorkPermitTypeId
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateOilsandPermitAssessment TO PUBLIC
GO