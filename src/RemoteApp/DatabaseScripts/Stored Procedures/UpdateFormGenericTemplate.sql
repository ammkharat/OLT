if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormGenericTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormGenericTemplate]
GO

CREATE Procedure [dbo].[UpdateFormGenericTemplate]
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
	@FormTypeID bigint,
	@PlantID bigint
)
AS

UPDATE FormGenericTemplate
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
		LastModifiedByUserId = @LastModifiedByUserId
	WHERE
		Id = @Id AND siteid = @siteid
		And 
		FormTypeID = @FormTypeId
		And
		PlantID = @PlantID
GO

GRANT EXEC ON UpdateFormGenericTemplate TO PUBLIC
GO

