if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGN6History]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGN6History]
GO

CREATE Procedure [dbo].[InsertFormGN6History]
(
	@Id bigint,
	@FormStatusId int,
	
	@FunctionalLocations varchar(max),
	@Approvals varchar(max),
	
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@JobDescription varchar(255) = NULL,
	@ReasonForCriticalLift varchar(max) = NULL,
	
	@Section1PlainTextContent nvarchar(max) = NULL,
	@Section1NotApplicableToJob bit,
	
	@Section2PlainTextContent nvarchar(max) = NULL,
	@Section2NotApplicableToJob bit,
	
	@Section3PlainTextContent nvarchar(max) = NULL,
	@Section3NotApplicableToJob bit,
	
	@Section4PlainTextContent nvarchar(max) = NULL,
	@Section4NotApplicableToJob bit,
	
	@Section5PlainTextContent nvarchar(max) = NULL,
	@Section5NotApplicableToJob bit,
	
	@Section6PlainTextContent nvarchar(max) = NULL,
	@Section6NotApplicableToJob bit,
	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,
	
	@PlainTextPreJobMeetingSignatures varchar(max) = NULL,
	@DocumentLinks varchar(max) = NULL,
	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
)
AS

INSERT INTO FormGN6History
(
	Id,
	FormStatusId,
	
	FunctionalLocations,
	Approvals,
	
	ValidFromDateTime,
	ValidToDateTime,

	JobDescription,
	ReasonForCriticalLift,
	
	Section1PlainTextContent,
	Section1NotApplicableToJob,
	
	Section2PlainTextContent,
	Section2NotApplicableToJob,
	
	Section3PlainTextContent,
	Section3NotApplicableToJob,
	
	Section4PlainTextContent,
	Section4NotApplicableToJob,
	
	Section5PlainTextContent,
	Section5NotApplicableToJob,
	
	Section6PlainTextContent,
	Section6NotApplicableToJob,		
	
	ApprovedDateTime,
	ClosedDateTime,
	
	PlainTextPreJobMeetingSignatures,
	DocumentLinks,
	
	LastModifiedByUserId,
	LastModifiedDateTime
)
VALUES
(
	@Id,
	@FormStatusId,
	
	@FunctionalLocations,
	@Approvals,
	
	@ValidFromDateTime,
	@ValidToDateTime,
	
	@JobDescription,
	@ReasonForCriticalLift,
	
	@Section1PlainTextContent,
	@Section1NotApplicableToJob,
	
	@Section2PlainTextContent,
	@Section2NotApplicableToJob,
	
	@Section3PlainTextContent,
	@Section3NotApplicableToJob,
	
	@Section4PlainTextContent,
	@Section4NotApplicableToJob,
	
	@Section5PlainTextContent,
	@Section5NotApplicableToJob,
	
	@Section6PlainTextContent,
	@Section6NotApplicableToJob,
	
	@ApprovedDateTime,
	@ClosedDateTime,
	
	@PlainTextPreJobMeetingSignatures,
	@DocumentLinks,
	
	@LastModifiedByUserId,
	@LastModifiedDateTime
);

GO

GRANT EXEC ON InsertFormGN6History TO PUBLIC
GO
