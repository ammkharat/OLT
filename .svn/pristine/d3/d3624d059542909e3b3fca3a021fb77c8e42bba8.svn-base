if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormMontrealCsd]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormMontrealCsd]
GO

CREATE Procedure [dbo].[UpdateFormMontrealCsd]
(
	@Id bigint,
	
	@FormStatusId int,
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@Content varchar(max) = NULL,
	@PlainTextContent nvarchar(max) = NULL,
	
	@IsTheCSDForAPressureSafetyValve bit,
	@CriticalSystemDefeated varchar(255) = NULL,
	@HasBeenCommunicated bit,
	@HasAttachments bit,
	@CsdReason varchar(255) = NULL,	
	
	@ApprovedDateTime datetime = NULL,
	@HasBeenApproved bit,
	@ClosedDateTime datetime = NULL,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
)
AS

UPDATE FormMontrealCsd
	SET 
		FormStatusId = @FormStatusId,
		ValidFromDateTime = @ValidFromDateTime,
		ValidToDateTime = @ValidToDateTime,
		
		Content = @Content,
		PlainTextContent = @PlainTextContent,
		
		IsTheCSDForAPressureSafetyValve = @IsTheCSDForAPressureSafetyValve,
		CriticalSystemDefeated = @CriticalSystemDefeated,
		HasBeenCommunicated = @HasBeenCommunicated,
		HasAttachments = @HasAttachments,
		CsdReason = @CsdReason,	
		HasBeenApproved = @HasBeenApproved,
		ApprovedDateTime = @ApprovedDateTime,
		ClosedDateTime = @ClosedDateTime,
		
		LastModifiedDateTime = @LastModifiedDateTime,
		LastModifiedByUserId = @LastModifiedByUserId
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateFormMontrealCsd TO PUBLIC
GO