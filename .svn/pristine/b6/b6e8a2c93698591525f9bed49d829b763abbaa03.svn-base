if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormGN6]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormGN6]
GO

CREATE Procedure [dbo].[UpdateFormGN6]
(
	@Id bigint,
	
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
	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
)
AS

UPDATE FormGN6
	SET 
		FormStatusId = @FormStatusId,
		ValidFromDateTime = @ValidFromDateTime,
		ValidToDateTime = @ValidToDateTime,
		
		JobDescription = @JobDescription,
		ReasonForCriticalLift = @ReasonForCriticalLift,
	
		Section1Content = @Section1Content,
		Section1PlainTextContent = @Section1PlainTextContent,
		Section1NotApplicableToJob = @Section1NotApplicableToJob,
	
		Section2Content = @Section2Content,
		Section2PlainTextContent = @Section2PlainTextContent,
		Section2NotApplicableToJob = @Section2NotApplicableToJob,
	
		Section3Content = @Section3Content,
		Section3PlainTextContent = @Section3PlainTextContent,
		Section3NotApplicableToJob = @Section3NotApplicableToJob,
	
		Section4Content = @Section4Content,
		Section4PlainTextContent = @Section4PlainTextContent,
		Section4NotApplicableToJob = @Section4NotApplicableToJob,
	
		Section5Content = @Section5Content,
		Section5PlainTextContent = @Section5PlainTextContent,
		Section5NotApplicableToJob = @Section5NotApplicableToJob,
	
		Section6Content = @Section6Content,
		Section6PlainTextContent = @Section6PlainTextContent,
		Section6NotApplicableToJob = @Section6NotApplicableToJob,
		
		ApprovedDateTime = @ApprovedDateTime,
		ClosedDateTime = @ClosedDateTime,
		
		PreJobMeetingSignatures = @PreJobMeetingSignatures,
		PlainTextPreJobMeetingSignatures = @PlainTextPreJobMeetingSignatures,
		
		LastModifiedDateTime = @LastModifiedDateTime,
		LastModifiedByUserId = @LastModifiedByUserId
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateFormGN6 TO PUBLIC
GO