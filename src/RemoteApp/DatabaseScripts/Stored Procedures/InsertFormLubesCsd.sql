if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormLubesCsd]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormLubesCsd]
GO

CREATE Procedure [dbo].[InsertFormLubesCsd]
(
	@Id bigint Output,
	
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

INSERT INTO FormLubesCsd
(
	Id,
	FormStatusId,
	ValidFromDateTime,
	ValidToDateTime,
	
	FunctionalLocationId,
	Location,
	
	Content,
	PlainTextContent,
	
	IsTheCSDForAPressureSafetyValve,
	CriticalSystemDefeated,
	
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
	
	@IsTheCSDForAPressureSafetyValve,
	@CriticalSystemDefeated,
	
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

GRANT EXEC ON InsertFormLubesCsd TO PUBLIC
GO
