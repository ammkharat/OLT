if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGN24History]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGN24History]
GO

CREATE Procedure [dbo].[InsertFormGN24History]
(
	@Id bigint,
	@FormStatusId int,
	
	@FunctionalLocations varchar(max),
	@Approvals varchar(max),
	
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@PlainTextContent nvarchar(max) = NULL,
	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,
	
	@IsTheSafeWorkPlanForPSVRemovalOrInstallation bit,
	@IsTheSafeWorkPlanForWorkInTheAlkylationUnit bit,
	@AlkylationClass int = NULL,
	
	@PlainTextPreJobMeetingSignatures varchar(max) = NULL,
	@DocumentLinks varchar(max) = NULL,
	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
)
AS

INSERT INTO FormGN24History
(
	Id,
	FormStatusId,
	
	FunctionalLocations,
	Approvals,
	
	ValidFromDateTime,
	ValidToDateTime,
	
	PlainTextContent,
	
	ApprovedDateTime,
	ClosedDateTime,
	
	IsTheSafeWorkPlanForPSVRemovalOrInstallation,
	IsTheSafeWorkPlanForWorkInTheAlkylationUnit,
	AlkylationClass,
	
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
	
	@PlainTextContent,
	
	@ApprovedDateTime,
	@ClosedDateTime,
	
	@IsTheSafeWorkPlanForPSVRemovalOrInstallation,
	@IsTheSafeWorkPlanForWorkInTheAlkylationUnit,
	@AlkylationClass,
	
	@PlainTextPreJobMeetingSignatures,
	@DocumentLinks,
	
	@LastModifiedByUserId,
	@LastModifiedDateTime
);

GO

GRANT EXEC ON InsertFormGN24History TO PUBLIC
GO
