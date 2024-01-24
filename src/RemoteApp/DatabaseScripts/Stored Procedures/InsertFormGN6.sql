if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGN6]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGN6]
GO

CREATE Procedure [dbo].[InsertFormGN6]
(
	@Id bigint Output,
	
	@FormStatusId int,
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@JobDescription varchar(255) = NULL,
	@ReasonForCriticalLift varchar(max) = NULL,
	
	@Section1Content varchar(max) = NULL,
	@Section1PlainTextContent nvarchar(max) = NULL,
	@Section1NotApplicableToJob bit,
	
	@Section2Content varchar(max) = NULL,
	@Section2PlainTextContent nvarchar(max) = NULL,
	@Section2NotApplicableToJob bit,
	
	@Section3Content varchar(max) = NULL,
	@Section3PlainTextContent nvarchar(max) = NULL,
	@Section3NotApplicableToJob bit,
	
	@Section4Content varchar(max) = NULL,
	@Section4PlainTextContent nvarchar(max) = NULL,
	@Section4NotApplicableToJob bit,
	
	@Section5Content varchar(max) = NULL,
	@Section5PlainTextContent nvarchar(max) = NULL,
	@Section5NotApplicableToJob bit,
	
	@Section6Content varchar(max) = NULL,
	@Section6PlainTextContent nvarchar(max) = NULL,
	@Section6NotApplicableToJob bit,
	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,	
	
	@PreJobMeetingSignatures varchar(max) = NULL,
	@PlainTextPreJobMeetingSignatures varchar(max) = NULL,

    @WorkerResponsiblitiesTemplateId BIGINT,
	
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

INSERT INTO FormGN6
(
	Id,
	FormStatusId,
	ValidFromDateTime,
	ValidToDateTime,
	
	JobDescription,
	ReasonForCriticalLift,
	
	Section1Content,
	Section1PlainTextContent,
	Section1NotApplicableToJob,
	
	Section2Content,
	Section2PlainTextContent,
	Section2NotApplicableToJob,
	
	Section3Content,
	Section3PlainTextContent,
	Section3NotApplicableToJob,
	
	Section4Content,
	Section4PlainTextContent,
	Section4NotApplicableToJob,
	
	Section5Content,
	Section5PlainTextContent,
	Section5NotApplicableToJob,
	
	Section6Content,
	Section6PlainTextContent,
	Section6NotApplicableToJob,
	
	ApprovedDateTime,
	ClosedDateTime,	
	
	PreJobMeetingSignatures,
	PlainTextPreJobMeetingSignatures,

	WorkerResponsiblitiesTemplateId,
	
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
		
	@JobDescription,
	@ReasonForCriticalLift,
	
	@Section1Content,
	@Section1PlainTextContent,
	@Section1NotApplicableToJob,
	
	@Section2Content,
	@Section2PlainTextContent,
	@Section2NotApplicableToJob,
	
	@Section3Content,
	@Section3PlainTextContent,
	@Section3NotApplicableToJob,
	
	@Section4Content,
	@Section4PlainTextContent,
	@Section4NotApplicableToJob,
	
	@Section5Content,
	@Section5PlainTextContent,
	@Section5NotApplicableToJob,
	
	@Section6Content,
	@Section6PlainTextContent,
	@Section6NotApplicableToJob,
	
	@ApprovedDateTime,
	@ClosedDateTime,
	
	@PreJobMeetingSignatures,
	@PlainTextPreJobMeetingSignatures,
	
	@WorkerResponsiblitiesTemplateId,
	
	@CreatedDateTime,
	@CreatedByUserId,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	0

);

SET @Id=@NewFormId; 

GO

GRANT EXEC ON InsertFormGN6 TO PUBLIC
GO
