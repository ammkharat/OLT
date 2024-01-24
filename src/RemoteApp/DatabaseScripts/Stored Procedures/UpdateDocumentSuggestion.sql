if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateDocumentSuggestion]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateDocumentSuggestion]
GO

CREATE Procedure [dbo].[UpdateDocumentSuggestion]
(
	@Id bigint Output,
	@FormStatusId int,
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	@ApprovedDateTime datetime,
	@CreatedByUserId bigint,
	@CreatedDateTime datetime,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,	
	@SiteId bigint,
	@LocationEquipmentNumber varchar(100),
	@ScheduledCompletionDateTime datetime,
	@NumberOfExtensions int,
	@IsExistingDocument bit,
	@DocumentOwner varchar(100),
	@DocumentNumber varchar(100),
	@DocumentTitle varchar(255),
	@OriginalMarkedUp bit,
	@HardCopySubmittedTo varchar(100),
	@RecommendedToBeArchived bit,
	@Description varchar(MAX),
	@RichTextDescription varchar(MAX),
	@InitialReviewApprovedBy varchar(100),
	@InitialReviewApprovedDateTime datetime,
	@OwnerReviewApprovedBy varchar(100),
	@OwnerReviewApprovedDateTime datetime,
	@DocumentIssuedApprovedBy varchar(100),
	@DocumentIssuedApprovedDateTime datetime,
	@DocumentArchivedApprovedBy varchar(100),
	@DocumentArchivedApprovedDateTime datetime = NULL,
	@NotApprovedBy varchar(100),
	@NotApprovedDateTime datetime,
	@NotApprovedReason varchar(255)
)
AS

UPDATE FormDocumentSuggestion
	SET 
	FormStatusId = @FormStatusId,
	ValidFromDateTime = @ValidFromDateTime,
	ValidToDateTime = @ValidToDateTime,
	ApprovedDateTime = @ApprovedDateTime,
	CreatedByUserId = @CreatedByUserId,
	CreatedDateTime = @CreatedDateTime,
	LastModifiedByUserId = @LastModifiedByUserId,
	LastModifiedDateTime = @LastModifiedDateTime,	
	SiteId = @SiteId,
	LocationEquipmentNumber = @LocationEquipmentNumber,
	ScheduledCompletionDateTime = @ScheduledCompletionDateTime,
	NumberOfExtensions = @NumberOfExtensions,
	IsExistingDocument = @IsExistingDocument,
	DocumentOwner = @DocumentOwner,
	DocumentNumber = @DocumentNumber,
	DocumentTitle = @DocumentTitle,
	OriginalMarkedUp = @OriginalMarkedUp,
	HardCopySubmittedTo = @HardCopySubmittedTo,
	RecommendedToBeArchived = @RecommendedToBeArchived,
	Description = @Description,
	RichTextDescription = @RichTextDescription,
	InitialReviewApprovedBy = @InitialReviewApprovedBy,
	InitialReviewApprovedDateTime = @InitialReviewApprovedDateTime,
	OwnerReviewApprovedBy = @OwnerReviewApprovedBy,
	OwnerReviewApprovedDateTime = @OwnerReviewApprovedDateTime,
	DocumentIssuedApprovedBy = @DocumentIssuedApprovedBy,
	DocumentIssuedApprovedDateTime = @DocumentIssuedApprovedDateTime,
	DocumentArchivedApprovedBy = @DocumentArchivedApprovedBy,
	DocumentArchivedApprovedDateTime = @DocumentArchivedApprovedDateTime,
	NotApprovedBy = @NotApprovedBy,
	NotApprovedDateTime = @NotApprovedDateTime,
	NotApprovedReason = @NotApprovedReason
	WHERE
		Id = @Id
GO

GRANT EXEC ON UpdateDocumentSuggestion TO PUBLIC
GO