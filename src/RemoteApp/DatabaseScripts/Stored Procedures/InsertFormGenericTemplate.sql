if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGenericTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGenericTemplate]
GO

CREATE Procedure [dbo].[InsertFormGenericTemplate]
(
	@Id bigint Output,
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
	
	@CreatedDateTime datetime,
	@CreatedByUserId bigint,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@siteid bigint,
	@FormTypeID bigint,
	@PlantID bigint,
	@CreatedByRoleId bigint 
)
AS

DECLARE @NewFormId bigint
BEGIN
	EXEC @NewFormId = GetNewSeqVal_FormIdSequence
END

INSERT INTO FormGenericTemplate
(
	Id,
	FormStatusId,
	ValidFromDateTime,
	ValidToDateTime,
	
	Content,
	PlainTextContent,
	
	IsTheCSDForAPressureSafetyValve,
	CriticalSystemDefeated,
	DepartmentId,
	
	ApprovedDateTime,
	ClosedDateTime,	
	
	CreatedDateTime,
	CreatedByUserId,
	LastModifiedByUserId,
	LastModifiedDateTime,
	Deleted,
	siteid,
	FormTypeID,
	PlantID,
	CreatedByRoleId 
)
VALUES
(
	@NewFormId,
	@FormStatusId,
	@ValidFromDateTime,
	@ValidToDateTime,
	
	@Content,
	@PlainTextContent,
	
	@IsTheCSDForAPressureSafetyValve,
	@CriticalSystemDefeated,
	@DepartmentId,
	
	@ApprovedDateTime,
	@ClosedDateTime,
	
	@CreatedDateTime,
	@CreatedByUserId,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	0,
	@siteid,
	@FormTypeID,
	@PlantID,
	@CreatedByRoleId
);
SET @Id=@NewFormId;

GO

GRANT EXEC ON InsertFormGenericTemplate TO PUBLIC
GO