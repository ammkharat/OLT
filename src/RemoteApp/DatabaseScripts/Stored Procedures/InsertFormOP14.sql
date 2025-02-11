IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormOP14')
	BEGIN
		DROP PROCEDURE [dbo].InsertFormOP14
	END
	
GO
CREATE  Procedure [dbo].[InsertFormOP14]
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
	@IsSCADAsupportRequired bit=NULL,
        @isMailSent bit=NULL       
)
AS

DECLARE @NewFormId bigint
BEGIN
	EXEC @NewFormId = GetNewSeqVal_FormIdSequence
END

INSERT INTO FormOP14
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
	IsSCADAsupportRequired,
        isMailSent
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
	@IsSCADAsupportRequired,
        @isMailSent
);
SET @Id=@NewFormId; 

GRANT EXEC ON InsertFormOP14 TO PUBLIC   

