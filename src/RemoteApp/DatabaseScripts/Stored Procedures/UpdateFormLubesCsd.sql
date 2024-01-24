if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormLubesCsd]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormLubesCsd]
GO

CREATE Procedure [dbo].[UpdateFormLubesCsd]
(
	@Id bigint,
	
	@FormStatusId int,
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@FunctionalLocationId bigint,
	@Location varchar(128),

	@Content varchar(max) = NULL,
	@PlainTextContent nvarchar(max) = NULL,
	
	@IsTheCSDForAPressureSafetyValve bit,
	@CriticalSystemDefeated varchar(255) = NULL,
	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,
	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@HasBeenApproved bit
)
AS

UPDATE FormLubesCsd
	SET 
		FormStatusId = @FormStatusId,
		ValidFromDateTime = @ValidFromDateTime,
		ValidToDateTime = @ValidToDateTime,
		
		FunctionalLocationId = @FunctionalLocationId,
		Location = @Location,

		Content = @Content,
		PlainTextContent = @PlainTextContent,
		
		IsTheCSDForAPressureSafetyValve = @IsTheCSDForAPressureSafetyValve,
		CriticalSystemDefeated = @CriticalSystemDefeated,
		
		ApprovedDateTime = @ApprovedDateTime,
		ClosedDateTime = @ClosedDateTime,
		HasBeenApproved = @HasBeenApproved,
		
		LastModifiedDateTime = @LastModifiedDateTime,
		LastModifiedByUserId = @LastModifiedByUserId
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateFormLubesCsd TO PUBLIC
GO