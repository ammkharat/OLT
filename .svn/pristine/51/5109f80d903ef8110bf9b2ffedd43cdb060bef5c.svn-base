if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertOvertimeForm]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertOvertimeForm]
GO

CREATE Procedure [dbo].[InsertOvertimeForm]
(
	@Id bigint Output,
	@FormStatusId int,
	@ApprovedDateTime datetime = NULL,
	@CancelledDateTime datetime = NULL,
	
	@CreatedDateTime datetime,
	@CreatedByUserId bigint,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,

	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,

	@Trade VARCHAR(100),
	@FunctionalLocationId bigint
)
AS

DECLARE @NewFormId bigint
BEGIN
	EXEC @NewFormId = GetNewSeqVal_FormIdSequence
END

INSERT INTO OvertimeForm
(
    Id,
	FormStatusId,
	ApprovedDateTime,
	CancelledDateTime,
	
	CreatedDateTime,
	CreatedByUserId,
	LastModifiedByUserId,
	LastModifiedDateTime,
	
	ValidFromDateTime,
	ValidToDateTime,

	Trade,
	FunctionalLocationId,
	Deleted
)
VALUES
(
    @NewFormId,
	@FormStatusId,
	@ApprovedDateTime,
	@CancelledDateTime,
	
	@CreatedDateTime,
	@CreatedByUserId,
	@LastModifiedByUserId,
	@LastModifiedDateTime,

	@ValidFromDateTime,
	@ValidToDateTime,

	@Trade,
	@FunctionalLocationId,
	0
);

SET @Id = @NewFormId;

GO

GRANT EXEC ON InsertOvertimeForm TO PUBLIC
GO
