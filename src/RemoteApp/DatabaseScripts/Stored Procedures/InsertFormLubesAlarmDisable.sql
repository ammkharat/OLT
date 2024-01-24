if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormLubesAlarmDisable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormLubesAlarmDisable]
GO

CREATE Procedure [dbo].[InsertFormLubesAlarmDisable]
(
	@Id bigint Output,
	
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
	
	@CreatedDateTime datetime,
	@CreatedByUserId bigint,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@HasBeenApproved bit
)
AS

DECLARE @NewFormId bigint
BEGIN
	EXEC @NewFormId = GetNewLubesSeqVal_LubesFormIdSequence
END

INSERT INTO FormLubesAlarmDisable
(
	Id,
	FormStatusId,
	ValidFromDateTime,
	ValidToDateTime,
	
	FunctionalLocationId,
	Location,
	
	Content,
	PlainTextContent,
	
	Alarm,
	Criticality,
	SapNotification,
	
	ApprovedDateTime,
	ClosedDateTime,	
	
	CreatedDateTime,
	CreatedByUserId,
	LastModifiedByUserId,
	LastModifiedDateTime,
	Deleted,
	HasBeenApproved
)
VALUES
(
	@NewFormId,
	@FormStatusId,
	@ValidFromDateTime,
	@ValidToDateTime,
	
	@FunctionalLocationId,
	@Location,

	@Content,
	@PlainTextContent,
	
	@Alarm,
	@Criticality,
	@SapNotification,
	
	@ApprovedDateTime,
	@ClosedDateTime,
	
	@CreatedDateTime,
	@CreatedByUserId,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	0,
	@HasBeenApproved
);

SET @Id=@NewFormId; 

GO

GRANT EXEC ON InsertFormLubesAlarmDisable TO PUBLIC
GO
