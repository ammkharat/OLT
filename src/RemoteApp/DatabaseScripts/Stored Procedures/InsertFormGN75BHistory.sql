if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGN75BHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGN75BHistory]
GO

CREATE Procedure [dbo].[InsertFormGN75BHistory]
(
	@Id bigint,
	@FormStatusId int,	
	@FunctionalLocation varchar(max),
	@Location varchar(255),
	@ClosedDateTime datetime = NULL,	
	@DocumentLinks varchar(max) = NULL,	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@BlindsRequired bit,
	@EquipmentType VARCHAR(50),
	@LockBoxNumber varchar(255) = NULL,
	@LockBoxLocation varchar(255) = NULL,
	@Isolations varchar(MAX) = NULL,
	@SchematicImage varbinary(MAX) = NULL,
	@SiteId int
)
AS


INSERT INTO FormGN75BHistory
(
	Id,
	FormStatusId,	
	FunctionalLocation,
	Location,
	ClosedDateTime,	
	DocumentLinks,	
	LastModifiedByUserId,
	LastModifiedDateTime,
	BlindsRequired,
	EquipmentType,
	LockBoxNumber,
	LockBoxLocation,
	Isolations,
	SchematicImage,
	SiteId
)
VALUES
(
	@Id,
	@FormStatusId,	
	@FunctionalLocation,
	@Location,
	@ClosedDateTime,	
	@DocumentLinks,	
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	@BlindsRequired,
	@EquipmentType,
	@LockBoxNumber,
	@LockBoxLocation,
	@Isolations,
	@SchematicImage,
	@SiteId
);
GO

GRANT EXEC ON InsertFormGN75BHistory TO PUBLIC
GO
