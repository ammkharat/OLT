if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGN24]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGN24]
GO

CREATE Procedure [dbo].[InsertFormGN24]
(
	@Id bigint Output,
	
	@FormStatusId int,
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@Content varchar(max) = NULL,
	@PlainTextContent nvarchar(max) = NULL,
	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,	
	
	@IsTheSafeWorkPlanForPSVRemovalOrInstallation bit,
	@IsTheSafeWorkPlanForWorkInTheAlkylationUnit bit,
	@AlkylationClass int = NULL,
	
	@PreJobMeetingSignatures varchar(max) = NULL,
	@PlainTextPreJobMeetingSignatures varchar(max) = NULL,
	
	@CreatedDateTime datetime,
	@CreatedByUserId bigint,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@siteid bigint
)
AS

DECLARE @NewFormId bigint
BEGIN
	EXEC @NewFormId = GetNewSeqVal_FormIdSequence
END

INSERT INTO FormGN24
(
	Id,
	FormStatusId,
	ValidFromDateTime,
	ValidToDateTime,
	
	Content,
	PlainTextContent,
	
	ApprovedDateTime,
	ClosedDateTime,	
	
	IsTheSafeWorkPlanForPSVRemovalOrInstallation,
	IsTheSafeWorkPlanForWorkInTheAlkylationUnit,
	AlkylationClass,
	
	PreJobMeetingSignatures,
	PlainTextPreJobMeetingSignatures,
	
	CreatedDateTime,
	CreatedByUserId,
	LastModifiedByUserId,
	LastModifiedDateTime,
	Deleted

)
VALUES
(
	@NewFormId,
	@FormStatusId,
	@ValidFromDateTime,
	@ValidToDateTime,
	
	@Content,
	@PlainTextContent,
	
	@ApprovedDateTime,
	@ClosedDateTime,
	
	@IsTheSafeWorkPlanForPSVRemovalOrInstallation,
	@IsTheSafeWorkPlanForWorkInTheAlkylationUnit,
	@AlkylationClass,
	
	@PreJobMeetingSignatures,
	@PlainTextPreJobMeetingSignatures,
	
	@CreatedDateTime,
	@CreatedByUserId,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	0
	
);

SET @Id=@NewFormId; 

GO

GRANT EXEC ON InsertFormGN24 TO PUBLIC
GO
