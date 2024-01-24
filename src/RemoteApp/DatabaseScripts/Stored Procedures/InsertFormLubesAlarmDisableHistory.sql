if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormLubesAlarmDisableHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormLubesAlarmDisableHistory]
GO

CREATE Procedure [dbo].[InsertFormLubesAlarmDisableHistory]
(
	@Id bigint,
	@FormStatusId int,
	
	@FunctionalLocation varchar(max),
	@Location varchar(128),	
	
	@Approvals varchar(max),
	
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@PlainTextContent nvarchar(max) = NULL,

	@Alarm varchar(255) = NULL,
	@Criticality varchar(50) = NULL,
	@SapNotification varchar(50) = NULL,

	@DocumentLinks varchar(max) = NULL,	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,
	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
)
AS

INSERT INTO FormLubesAlarmDisableHistory
(
	Id,
	FormStatusId,
	
	FunctionalLocation,
	Location,	
	Approvals,
	
	ValidFromDateTime,
	ValidToDateTime,
	
	PlainTextContent,
	
	Alarm,
	Criticality,
	SapNotification,
	
	DocumentLinks,
	ApprovedDateTime,
	ClosedDateTime,
	LastModifiedByUserId,
	LastModifiedDateTime
)
VALUES
(
	@Id,
	@FormStatusId,
	
	@FunctionalLocation,
	@Location,
	@Approvals,
	
	@ValidFromDateTime,
	@ValidToDateTime,
	
	@PlainTextContent,
	
	@Alarm,
	@Criticality,
	@SapNotification,
	
	@DocumentLinks,	
	@ApprovedDateTime,
	@ClosedDateTime,
	
	@LastModifiedByUserId,
	@LastModifiedDateTime
);

GO

GRANT EXEC ON InsertFormLubesAlarmDisableHistory TO PUBLIC
GO
