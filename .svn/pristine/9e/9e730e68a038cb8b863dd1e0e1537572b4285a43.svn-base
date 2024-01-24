 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertDocumentSuggestionHistory')
	BEGIN
		DROP Procedure InsertDocumentSuggestionHistory
	END
GO

CREATE Procedure [dbo].[InsertDocumentSuggestionHistory]
(
	@DocumentSuggestionHistoryId bigint Output,
	@Id bigint,
	@FormStatusId int,
	@FunctionalLocations varchar(MAX),
	@DocumentLinks varchar(MAX),
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@LocationEquipmentNumber varchar(100),
	@ScheduledCompletionDateTime datetime,
	@NumberOfExtensions int,
	@ReasonsForExtension varchar(MAX),
	@IsExistingDocument bit,
	@DocumentOwner varchar(100),
	@DocumentNumber varchar(100),
	@DocumentTitle varchar(100),
	@OriginalMarkedUp bit,
	@HardCopySubmittedTo varchar(100),
	@RecommendedToBeArchived bit,
	@Description varchar(MAX),
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
INSERT INTO [FormDocumentSuggestionHistory]
(
	[Id],
	[FormStatusId],
	[FunctionalLocations],
	[DocumentLinks],
	[ValidFromDateTime],
	[ValidToDateTime],
	[LastModifiedByUserId],
	[LastModifiedDateTime],
	[LocationEquipmentNumber],
	[ScheduledCompletionDateTime],
	[NumberOfExtensions],
	[ReasonsForExtension],
	[IsExistingDocument],
	[DocumentOwner],
	[DocumentNumber],
	[DocumentTitle],
	[OriginalMarkedUp],
	[HardCopySubmittedTo],
	[RecommendedToBeArchived],
	[Description],
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
	[NotApprovedReason]
)
VALUES
(
	@Id,
	@FormStatusId,
	@FunctionalLocations,
	@DocumentLinks,
	@ValidFromDateTime,
	@ValidToDateTime,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	@LocationEquipmentNumber,
	@ScheduledCompletionDateTime,
	@NumberOfExtensions,
	@ReasonsForExtension,
	@IsExistingDocument,
	@DocumentOwner,
	@DocumentNumber,
	@DocumentTitle,
	@OriginalMarkedUp,
	@HardCopySubmittedTo,
	@RecommendedToBeArchived,
	@Description,
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
	@NotApprovedReason
)
SET @DocumentSuggestionHistoryId = SCOPE_IDENTITY() 
GO

GRANT EXEC ON [InsertDocumentSuggestionHistory] TO PUBLIC
GO