IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateFormOP14')
	BEGIN
		DROP PROCEDURE [dbo].UpdateFormOP14
	END
GO


CREATE Procedure [dbo].[UpdateFormOP14]
(
	@Id bigint,
	
	@FormStatusId int,
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@Content varchar(max) = NULL,
	@PlainTextContent nvarchar(max) = NULL,
	
	@IsTheCSDForAPressureSafetyValve bit,
	@CriticalSystemDefeated varchar(255) = NULL,
	@DepartmentId int,
	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,
	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@siteid bigint,
	@IsSCADAsupportRequired bit=NULL,
        @isMailSent bit=NULL
)
AS

UPDATE FormOP14
	SET 
		FormStatusId = @FormStatusId,
		ValidFromDateTime = @ValidFromDateTime,
		ValidToDateTime = @ValidToDateTime,
		
		Content = @Content,
		PlainTextContent = @PlainTextContent,
		
		IsTheCSDForAPressureSafetyValve = @IsTheCSDForAPressureSafetyValve,
		CriticalSystemDefeated = @CriticalSystemDefeated,
		DepartmentId = @DepartmentId,
		
		ApprovedDateTime = @ApprovedDateTime,
		ClosedDateTime = @ClosedDateTime,
		
		LastModifiedDateTime = @LastModifiedDateTime,
		LastModifiedByUserId = @LastModifiedByUserId,
	        IsSCADAsupportRequired=@IsSCADAsupportRequired,
                isMailSent=@isMailSent
      
	WHERE
		Id = @Id AND siteid = @siteid
		
	GRANT EXEC ON [UpdateFormOP14] TO PUBLIC  




