if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGN75A]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGN75A]
GO

CREATE Procedure [dbo].[InsertFormGN75A]
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
	Deleted

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
	0
	
);

SET @Id=@NewFormId; 

GO

GRANT EXEC ON InsertFormGN75A TO PUBLIC
GO
