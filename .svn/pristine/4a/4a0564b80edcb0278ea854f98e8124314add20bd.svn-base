if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormGN24]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormGN24]
GO

CREATE Procedure [dbo].[UpdateFormGN24]
(
	@Id bigint,
	
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
	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
)
AS

UPDATE FormGN24
	SET 
		FormStatusId = @FormStatusId,
		ValidFromDateTime = @ValidFromDateTime,
		ValidToDateTime = @ValidToDateTime,
		
		Content = @Content,
		PlainTextContent = @PlainTextContent,
		
		ApprovedDateTime = @ApprovedDateTime,
		ClosedDateTime = @ClosedDateTime,
		
		IsTheSafeWorkPlanForPSVRemovalOrInstallation = @IsTheSafeWorkPlanForPSVRemovalOrInstallation,
		IsTheSafeWorkPlanForWorkInTheAlkylationUnit = @IsTheSafeWorkPlanForWorkInTheAlkylationUnit,
		AlkylationClass = @AlkylationClass,
		
		PreJobMeetingSignatures = @PreJobMeetingSignatures,
		PlainTextPreJobMeetingSignatures = @PlainTextPreJobMeetingSignatures,
		
		LastModifiedDateTime = @LastModifiedDateTime,
		LastModifiedByUserId = @LastModifiedByUserId
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateFormGN24 TO PUBLIC
GO