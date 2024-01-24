
--IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormOP14')
--	BEGIN
--		DROP PROCEDURE [dbo].InsertFormOP14
--	END
--GO
--CREATE Procedure [dbo].[InsertFormOP14]
--(
--	@Id bigint Output,
--	@FormStatusId int,
--	@ValidFromDateTime datetime,
--	@ValidToDateTime datetime,
	
--	@Content varchar(max) = NULL,
--	@PlainTextContent nvarchar(max) = NULL,
	
--	@IsTheCSDForAPressureSafetyValve bit,
--	@CriticalSystemDefeated varchar(255) = NULL,
--	@DepartmentId int,
	
--	@ApprovedDateTime datetime = NULL,
--	@ClosedDateTime datetime = NULL,	
	
--	@CreatedDateTime datetime,
--	@CreatedByUserId bigint,
--	@LastModifiedByUserId bigint,
--	@LastModifiedDateTime datetime,
--	@siteid bigint
--)
--AS

--DECLARE @NewFormId bigint
--BEGIN
--	EXEC @NewFormId = GetNewSeqVal_FormIdSequence
--END

--INSERT INTO FormOP14
--(
--	Id,
--	FormStatusId,
--	ValidFromDateTime,
--	ValidToDateTime,
	
--	Content,
--	PlainTextContent,
	
--	IsTheCSDForAPressureSafetyValve,
--	CriticalSystemDefeated,
--	DepartmentId,
	
--	ApprovedDateTime,
--	ClosedDateTime,	
	
--	CreatedDateTime,
--	CreatedByUserId,
--	LastModifiedByUserId,
--	LastModifiedDateTime,
--	Deleted,
--	siteid
--)
--VALUES
--(
--	@NewFormId,
--	@FormStatusId,
--	@ValidFromDateTime,
--	@ValidToDateTime,
	
--	@Content,
--	@PlainTextContent,
	
--	@IsTheCSDForAPressureSafetyValve,
--	@CriticalSystemDefeated,
--	@DepartmentId,
	
--	@ApprovedDateTime,
--	@ClosedDateTime,
	
--	@CreatedDateTime,
--	@CreatedByUserId,
--	@LastModifiedByUserId,
--	@LastModifiedDateTime,
--	0,
--	@siteid
--);
--SET @Id=@NewFormId; 

--go


--IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateFormOP14')
--	BEGIN
--		DROP PROCEDURE [dbo].UpdateFormOP14
--	END
--GO

--Create Procedure [dbo].[UpdateFormOP14]
--(
--	@Id bigint,
	
--	@FormStatusId int,
--	@ValidFromDateTime datetime,
--	@ValidToDateTime datetime,
	
--	@Content varchar(max) = NULL,
--	@PlainTextContent nvarchar(max) = NULL,
	
--	@IsTheCSDForAPressureSafetyValve bit,
--	@CriticalSystemDefeated varchar(255) = NULL,
--	@DepartmentId int,
	
--	@ApprovedDateTime datetime = NULL,
--	@ClosedDateTime datetime = NULL,
	
--	@LastModifiedByUserId bigint,
--	@LastModifiedDateTime datetime,
--	@siteid bigint
--)
--AS

--UPDATE FormOP14
--	SET 
--		FormStatusId = @FormStatusId,
--		ValidFromDateTime = @ValidFromDateTime,
--		ValidToDateTime = @ValidToDateTime,
		
--		Content = @Content,
--		PlainTextContent = @PlainTextContent,
		
--		IsTheCSDForAPressureSafetyValve = @IsTheCSDForAPressureSafetyValve,
--		CriticalSystemDefeated = @CriticalSystemDefeated,
--		DepartmentId = @DepartmentId,
		
--		ApprovedDateTime = @ApprovedDateTime,
--		ClosedDateTime = @ClosedDateTime,
		
--		LastModifiedDateTime = @LastModifiedDateTime,
--		LastModifiedByUserId = @LastModifiedByUserId
--	WHERE
--		Id = @Id AND siteid = @siteid




--go




IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN75B')
	BEGIN
		DROP PROCEDURE [dbo].InsertFormGN75B
	END
GO
CREATE Procedure [dbo].[InsertFormGN75B]
(
	@Id bigint Output,
	@FormStatusId int,
	@FunctionalLocationId bigint,
	@Location VARCHAR(50),
	@ClosedDateTime datetime = NULL,	
		
	@CreatedDateTime datetime = NULL,
	@CreatedByUserId bigint,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@BlindsRequired bit,
	@EquipmentType VARCHAR(50),
    @LockBoxNumber varchar(255),
	@LockBoxLocation varchar(255),
	@PathToSchematic varchar(MAX) = NULL,
	@SchematicImage varbinary(MAX) = NULL,
	@siteid bigint
)
AS

DECLARE @NewFormId bigint
BEGIN
	EXEC @NewFormId = GetNewSeqVal_FormIdSequence
END

INSERT INTO FormGN75B
(
	Id,
	FormStatusId,
	FunctionalLocationId,
	Location,
	ClosedDateTime,
	CreatedDateTime,
	CreatedByUserId,
	LastModifiedByUserId,
	LastModifiedDateTime,
	BlindsRequired,
	LockBoxNumber,
	EquipmentType,
	LockBoxLocation,
	PathToSchematic,
	SchematicImage,
	Deleted,
	siteid
)
VALUES
(
	@NewFormId,
	@FormStatusId,
	@FunctionalLocationId,
	@Location,
	@ClosedDateTime,
	@CreatedDateTime,
	@CreatedByUserId,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	@BlindsRequired,
	@LockBoxNumber,
	@EquipmentType,
	@LockBoxLocation,
	@PathToSchematic,
	@SchematicImage,
	0,
	@siteid
);

SET @Id=@NewFormId; 

go

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateFormGN75B')
	BEGIN
		DROP PROCEDURE [dbo].UpdateFormGN75B
	END
GO
CREATE Procedure [dbo].[UpdateFormGN75B]
(
	@Id bigint,
	@FormStatusId int,
	@FunctionalLocationId bigint,
	@Location VARCHAR(50),
	@ClosedDateTime datetime = NULL,	
		
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@BlindsRequired bit,
	@EquipmentType VARCHAR(50),
    @LockBoxNumber varchar(30),
	@LockBoxLocation varchar(30),
	@PathToSchematic varchar(MAX) = NULL,
	@SchematicImage varbinary(MAX) = NULL,
	@siteid bigint
)
AS

UPDATE 
	FormGN75B
SET 
	FormStatusId = @FormStatusId,
	FunctionalLocationId = @FunctionalLocationId,
	Location = @Location,
	ClosedDateTime = @ClosedDateTime,
	LastModifiedByUserId = @LastModifiedByUserId,
	LastModifiedDateTime = @LastModifiedDateTime,
	BlindsRequired = @BlindsRequired,
	EquipmentType = @EquipmentType,
    LockBoxNumber = @LockBoxNumber,
	LockBoxLocation = @LockBoxLocation,
	PathToSchematic = @PathToSchematic,
	SchematicImage = @SchematicImage
WHERE
	Id = @Id and siteid = @siteid
GRANT EXEC ON UpdateFormGN75B TO PUBLIC


GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN6')
	BEGIN
		DROP PROCEDURE [dbo].InsertFormGN6
	END
GO
create Procedure [dbo].[InsertFormGN6]
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
	Deleted,
	siteid
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
	0,
	@siteid
);

SET @Id=@NewFormId; 

go

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateFormGN6')
	BEGIN
		DROP PROCEDURE [dbo].UpdateFormGN6
	END
GO

create Procedure [dbo].[UpdateFormGN6]
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
	@LastModifiedDateTime datetime,
	@siteid bigint
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
		Id = @Id and siteid = @siteid
		
go		
		
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN7')
	BEGIN
		DROP PROCEDURE [dbo].InsertFormGN7
	END
GO

create Procedure [dbo].[InsertFormGN7]
(
	@Id bigint Output,
	
	@FormStatusId int,
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@Content varchar(max) = NULL,
	@PlainTextContent nvarchar(max) = NULL,
	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,	
	
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

INSERT INTO FormGN7
(
	Id,
	FormStatusId,
	ValidFromDateTime,
	ValidToDateTime,
	
	Content,
	PlainTextContent,
	
	ApprovedDateTime,
	ClosedDateTime,	
	
	CreatedDateTime,
	CreatedByUserId,
	LastModifiedByUserId,
	LastModifiedDateTime,
	Deleted,
	siteid
)
VALUES
(
	@NewFormId,
	@FormStatusId,
	@ValidFromDateTime,
	@ValidToDateTime,
	
	@Content,
	@PlainTextContent,
	
	@ApprovedDateTime,
	@ClosedDateTime,
	
	@CreatedDateTime,
	@CreatedByUserId,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	0,
	@siteid
);

SET @Id=@NewFormId; 

go

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateFormGN7')
	BEGIN
		DROP PROCEDURE [dbo].UpdateFormGN7
	END
GO

create Procedure [dbo].[UpdateFormGN7]
(
	@Id bigint,
	
	@FormStatusId int,
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@Content varchar(max) = NULL,
	@PlainTextContent nvarchar(max) = NULL,
	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,	
	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@siteid bigint
)
AS

UPDATE FormGN7
	SET 
		FormStatusId = @FormStatusId,
		ValidFromDateTime = @ValidFromDateTime,
		ValidToDateTime = @ValidToDateTime,
		
		Content = @Content,
		PlainTextContent = @PlainTextContent,
		
		ApprovedDateTime = @ApprovedDateTime,
		ClosedDateTime = @ClosedDateTime,
		
		LastModifiedDateTime = @LastModifiedDateTime,
		LastModifiedByUserId = @LastModifiedByUserId
	WHERE
		Id = @Id and siteid = @siteid

go

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN24')
	BEGIN
		DROP PROCEDURE [dbo].InsertFormGN24
	END
GO

create Procedure [dbo].[InsertFormGN24]
(
	@Id bigint Output,
	
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

INSERT INTO FormGN24
(
	Id,
	FormStatusId,
	ValidFromDateTime,
	ValidToDateTime,
	
	Content,
	PlainTextContent,
	
	ApprovedDateTime,
	ClosedDateTime,	
	
	IsTheSafeWorkPlanForPSVRemovalOrInstallation,
	IsTheSafeWorkPlanForWorkInTheAlkylationUnit,
	AlkylationClass,
	
	PreJobMeetingSignatures,
	PlainTextPreJobMeetingSignatures,
	
	CreatedDateTime,
	CreatedByUserId,
	LastModifiedByUserId,
	LastModifiedDateTime,
	Deleted,
	siteid
)
VALUES
(
	@NewFormId,
	@FormStatusId,
	@ValidFromDateTime,
	@ValidToDateTime,
	
	@Content,
	@PlainTextContent,
	
	@ApprovedDateTime,
	@ClosedDateTime,
	
	@IsTheSafeWorkPlanForPSVRemovalOrInstallation,
	@IsTheSafeWorkPlanForWorkInTheAlkylationUnit,
	@AlkylationClass,
	
	@PreJobMeetingSignatures,
	@PlainTextPreJobMeetingSignatures,
	
	@CreatedDateTime,
	@CreatedByUserId,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	0,
	@siteid
);

SET @Id=@NewFormId; 

go

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateFormGN24')
	BEGIN
		DROP PROCEDURE [dbo].UpdateFormGN24
	END
GO

create Procedure [dbo].[UpdateFormGN24]
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
	@LastModifiedDateTime datetime,
	@siteid bigint
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
		Id = @Id and siteid = @siteid

go



IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN59')
	BEGIN
		DROP PROCEDURE [dbo].InsertFormGN59
	END
GO
create Procedure [dbo].[InsertFormGN59]
(
	@Id bigint Output,
	
	@FormStatusId int,
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@Content varchar(max) = NULL,
	@PlainTextContent nvarchar(max) = NULL,
	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,
	
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

INSERT INTO FormGN59
(
	Id,
	FormStatusId,
	ValidFromDateTime,
	ValidToDateTime,
	
	Content,
	PlainTextContent,
	
	ApprovedDateTime,
	ClosedDateTime,
	
	CreatedDateTime,
	CreatedByUserId,
	LastModifiedByUserId,
	LastModifiedDateTime,
	Deleted,
	siteid
)
VALUES
(
	@NewFormId,
	@FormStatusId,
	@ValidFromDateTime,
	@ValidToDateTime,
	
	@Content,
	@PlainTextContent,
	
	@ApprovedDateTime,
	@ClosedDateTime,
	
	@CreatedDateTime,
	@CreatedByUserId,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	0,
	@siteid
);

SET @Id=@NewFormId; 

go


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateFormGN59')
	BEGIN
		DROP PROCEDURE [dbo].UpdateFormGN59
	END
GO

create Procedure [dbo].[UpdateFormGN59]
(
	@Id bigint,
	
	@FormStatusId int,
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@Content varchar(max) = NULL,
	@PlainTextContent nvarchar(max) = NULL,
	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,
	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@siteid bigint
)
AS

UPDATE FormGN59
	SET 
		FormStatusId = @FormStatusId,
		ValidFromDateTime = @ValidFromDateTime,
		ValidToDateTime = @ValidToDateTime,
		
		Content = @Content,
		PlainTextContent = @PlainTextContent,
		
		ApprovedDateTime = @ApprovedDateTime,
		ClosedDateTime = @ClosedDateTime,
		
		LastModifiedDateTime = @LastModifiedDateTime,
		LastModifiedByUserId = @LastModifiedByUserId
	WHERE
		Id = @Id and siteid = @siteid


go


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN75A')
	BEGIN
		DROP PROCEDURE [dbo].InsertFormGN75A
	END
GO

create Procedure [dbo].[InsertFormGN75A]
(
	@Id bigint Output,
	
	@FormStatusId int,
	@FunctionalLocationId bigint,
	@FromDateTime datetime,
	@ToDateTime datetime,
	
	@AssociatedFormGN75BId bigint = NULL,
	
	@Content varchar(max) = NULL,
	@PlainTextContent nvarchar(max) = NULL,
	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,	
		
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

INSERT INTO FormGN75A
(
	Id,
	FormStatusId,
	FunctionalLocationId,
	FromDateTime,
	ToDateTime,
	
	AssociatedFormGN75BId,
	
	Content,
	PlainTextContent,
	
	ApprovedDateTime,
	ClosedDateTime,	
			
	CreatedDateTime,
	CreatedByUserId,
	LastModifiedByUserId,
	LastModifiedDateTime,
	Deleted,
	siteid
)
VALUES
(
	@NewFormId,
	@FormStatusId,
	@FunctionalLocationId,
	@FromDateTime,
	@ToDateTime,
	
	@AssociatedFormGN75BId,
	
	@Content,
	@PlainTextContent,
	
	@ApprovedDateTime,
	@ClosedDateTime,
		
	@CreatedDateTime,
	@CreatedByUserId,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	0,
	@siteid
);

SET @Id=@NewFormId; 

go


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateFormGN75A')
	BEGIN
		DROP PROCEDURE [dbo].UpdateFormGN75A
	END
GO

create Procedure [dbo].[UpdateFormGN75A]
(
	@Id bigint,
	
	@FormStatusId int,
	@FunctionalLocationId bigint,
	@FromDateTime datetime,
	@ToDateTime datetime,
	
	@AssociatedFormGN75BId bigint = NULL,
	
	@Content varchar(max) = NULL,
	@PlainTextContent nvarchar(max) = NULL,
	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,	
			
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@siteid bigint
)
AS

UPDATE FormGN75A
	SET 
		FormStatusId = @FormStatusId,
		FunctionalLocationId = @FunctionalLocationId,
				
		FromDateTime = @FromDateTime,
		ToDateTime = @ToDateTime,
		
		AssociatedFormGN75BId = @AssociatedFormGN75BId,
		
		Content = @Content,
		PlainTextContent = @PlainTextContent,
				
		ApprovedDateTime = @ApprovedDateTime,
		ClosedDateTime = @ClosedDateTime,
		
		LastModifiedDateTime = @LastModifiedDateTime,
		LastModifiedByUserId = @LastModifiedByUserId
	WHERE
		Id = @Id and siteid = @siteid

go

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN1')
	BEGIN
		DROP PROCEDURE [dbo].InsertFormGN1
	END
GO

create Procedure [dbo].[InsertFormGN1]
(
	@Id bigint Output,	
	@FormStatusId int,
	@FunctionalLocationId bigint,
	@TradeChecklistNames VARCHAR(MAX) = NULL,
	@Location varchar(128),
	@CSELevel varchar(5),
	@JobDescription varchar(256),
	@FromDateTime datetime,
	@ToDateTime datetime,
	@PlanningWorksheetContent nvarchar(max) = NULL,
	@PlanningWorksheetPlainTextContent varchar(max) = NULL,	
	@RescuePlanContent nvarchar(max) = NULL,
	@RescuePlanPlainTextContent varchar(max) = NULL,	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,			
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

INSERT INTO FormGN1
(
	Id,
	FormStatusId,
	FunctionalLocationId,
	TradeChecklistNames,
	Location,
	CSELevel,
	JobDescription,
	FromDateTime,
	ToDateTime,
	PlanningWorksheetContent,
	PlanningWorksheetPlainTextContent,
	RescuePlanContent,
	RescuePlanPlainTextContent,
	ApprovedDateTime,
	ClosedDateTime,
	CreatedDateTime,
	CreatedByUserId,
	LastModifiedByUserId,
	LastModifiedDateTime,
	Deleted,
	siteid
)
VALUES
(	
	@NewFormId,
	@FormStatusId,
	@FunctionalLocationId,
	@TradeChecklistNames,
	@Location,
	@CSELevel,
	@JobDescription,
	@FromDateTime,
	@ToDateTime,	
	@PlanningWorksheetContent,
	@PlanningWorksheetPlainTextContent,
	@RescuePlanContent,
	@RescuePlanPlainTextContent,
	@ApprovedDateTime,
	@ClosedDateTime,
	@CreatedDateTime,
	@CreatedByUserId,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	0,
	@siteid
);

SET @Id=@NewFormId; 

go

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateFormGN1')
	BEGIN
		DROP PROCEDURE [dbo].UpdateFormGN1
	END
GO

create Procedure [dbo].[UpdateFormGN1]
(
	@Id bigint,	
	@FormStatusId int,
	@FunctionalLocationId bigint,
	@TradeChecklistNames VARCHAR(MAX) = NULL,
	@Location varchar(128),
	@CSELevel varchar(5),
	@JobDescription varchar(256),
	@FromDateTime datetime,
	@ToDateTime datetime,
	@PlanningWorksheetContent nvarchar(max) = NULL,
	@PlanningWorksheetPlainTextContent varchar(max) = NULL,	
	@RescuePlanContent nvarchar(max) = NULL,
	@RescuePlanPlainTextContent varchar(max) = NULL,	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,			
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@siteid bigint)
	
AS

UPDATE FormGN1
	SET 
		FormStatusId = @FormStatusId,
		FunctionalLocationId = @FunctionalLocationId,
		TradeChecklistNames = @TradeChecklistNames,
		Location = @Location,
		CSELevel = @CSELevel,
		JobDescription = @JobDescription,
		FromDateTime = @FromDateTime,
		ToDateTime = @ToDateTime,
		PlanningWorksheetContent = @PlanningWorksheetContent,
		PlanningWorksheetPlainTextContent = @PlanningWorksheetPlainTextContent,
		RescuePlanContent = @RescuePlanContent,
		RescuePlanPlainTextContent = @RescuePlanPlainTextContent,
		ApprovedDateTime = @ApprovedDateTime,
		ClosedDateTime = @ClosedDateTime,
		LastModifiedDateTime = @LastModifiedDateTime,
		LastModifiedByUserId = @LastModifiedByUserId
	WHERE
		Id = @Id and siteid = @siteid



go
