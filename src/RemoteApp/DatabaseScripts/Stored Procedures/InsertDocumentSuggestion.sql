if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertDocumentSuggestion]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertDocumentSuggestion]
GO

CREATE Procedure [dbo].[InsertDocumentSuggestion]
(
	@Id bigint Output,
	@FormStatusId int,
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	@ApprovedDateTime datetime = NULL,
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
	@InitialReviewApprovedDateTime datetime = NULL,
	@OwnerReviewApprovedBy varchar(100),
	@OwnerReviewApprovedDateTime datetime = NULL,
	@DocumentIssuedApprovedBy varchar(100),
	@DocumentIssuedApprovedDateTime datetime = NULL,
	@DocumentArchivedApprovedBy varchar(100),
	@DocumentArchivedApprovedDateTime datetime = NULL,
	@NotApprovedBy varchar(100),
	@NotApprovedDateTime datetime = NULL,
	@NotApprovedReason varchar(255)
)
AS

DECLARE @NewFormId bigint
BEGIN
	EXEC @NewFormId = GetNewSeqVal_FormOilsandsIdSequence
END

INSERT INTO FormDocumentSuggestion
(
	[Id],
	[FormStatusId],
	[ValidFromDateTime],
	[ValidToDateTime],
	[ApprovedDateTime],
	[CreatedByUserId],
	[CreatedDateTime],
	[LastModifiedByUserId],
	[LastModifiedDateTime],	
	[SiteId],
	[LocationEquipmentNumber],
	[ScheduledCompletionDateTime],
	[NumberOfExtensions],
	[IsExistingDocument],
	[DocumentOwner],
	[DocumentNumber],
	[DocumentTitle],
	[OriginalMarkedUp],
	[HardCopySubmittedTo],
	[RecommendedToBeArchived],
	[Description],
	[RichTextDescription],
	[InitialReviewApprovedBy],
	[InitialReviewApprovedDateTime],
	[OwnerReviewApprovedBy],
	[OwnerReviewApprovedDateTime],
	[DocumentIssuedApprovedBy],
	[DocumentIssuedApprovedDateTime],
	[DocumentArchivedApprovedBy],
	[DocumentArchivedApprovedDateTime],
	[NotApprovedBy],
	[NotApprovedDateTime],
	[NotApprovedReason],
	[Deleted]
)
VALUES
(
	@NewFormId,
	@FormStatusId,
	@ValidFromDateTime,
	@ValidToDateTime,
	@ApprovedDateTime,
	@CreatedByUserId,
	@CreatedDateTime,
	@LastModifiedByUserId,
	@LastModifiedDateTime,	
	@SiteId,
	@LocationEquipmentNumber,
	@ScheduledCompletionDateTime,
	@NumberOfExtensions,
	@IsExistingDocument,
	@DocumentOwner,
	@DocumentNumber,
	@DocumentTitle,
	@OriginalMarkedUp,
	@HardCopySubmittedTo,
	@RecommendedToBeArchived,
	@Description,
	@RichTextDescription,
	@InitialReviewApprovedBy,
	@InitialReviewApprovedDateTime,
	@OwnerReviewApprovedBy,
	@OwnerReviewApprovedDateTime,
	@DocumentIssuedApprovedBy,
	@DocumentIssuedApprovedDateTime,
	@DocumentArchivedApprovedBy,
	@DocumentArchivedApprovedDateTime,
	@NotApprovedBy,
	@NotApprovedDateTime,
	@NotApprovedReason,
	0
);

SET @Id=@NewFormId; 

GO

GRANT EXEC ON InsertDocumentSuggestion TO PUBLIC
GO
