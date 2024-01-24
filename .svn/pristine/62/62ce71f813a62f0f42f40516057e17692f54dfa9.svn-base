if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormLubesAlarmDisable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormLubesAlarmDisable]
GO

CREATE Procedure [dbo].[UpdateFormLubesAlarmDisable]
(
	@Id bigint,
	
	@FormStatusId int,
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@FunctionalLocationId bigint,
	@Location varchar(128),

	@Content varchar(max) = NULL,
	@PlainTextContent nvarchar(max) = NULL,
	
	@Alarm varchar(255) = NULL,
	@Criticality varchar(50) = NULL,
	@SapNotification varchar(50) = NULL,
	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,
	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@HasBeenApproved bit
)
AS

UPDATE FormLubesAlarmDisable
	SET 
		FormStatusId = @FormStatusId,
		ValidFromDateTime = @ValidFromDateTime,
		ValidToDateTime = @ValidToDateTime,
		
		FunctionalLocationId = @FunctionalLocationId,
		Location = @Location,

		Content = @Content,
		PlainTextContent = @PlainTextContent,
		
		Alarm = @Alarm,
		Criticality = @Criticality,
		SapNotification = @SapNotification,
	
		ApprovedDateTime = @ApprovedDateTime,
		ClosedDateTime = @ClosedDateTime,
		HasBeenApproved = @HasBeenApproved,
		
		LastModifiedDateTime = @LastModifiedDateTime,
		LastModifiedByUserId = @LastModifiedByUserId
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateFormLubesAlarmDisable TO PUBLIC
GO