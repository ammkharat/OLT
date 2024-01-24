if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormOilsandsTraining]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormOilsandsTraining]
GO

CREATE Procedure [dbo].[InsertFormOilsandsTraining]
(
	@Id bigint Output,
	
	@FormStatusId int,
	
	@ApprovedDateTime datetime = NULL,
	
	@TrainingDate date,
	@ShiftId bigint,
	@TotalHours decimal(8,2),
	@GeneralComments varchar(max),
	
	@WorkAssignmentId bigint = NULL,
	
	@CreatedDateTime datetime,
	@CreatedByUserId bigint,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	
	@CreatedByRoleId bigint,
	
	@siteid bigint

)
AS

DECLARE @NewFormId bigint
BEGIN
	EXEC @NewFormId = GetNewSeqVal_FormOilsandsIdSequence
END

INSERT INTO FormOilsandsTraining
(
    Id,
	FormStatusId,
	
	ApprovedDateTime,
	
	TrainingDate,
	ShiftId,
	TotalHours,
	GeneralComments,
	
	WorkAssignmentId,
	
	CreatedDateTime,
	CreatedByUserId,
	LastModifiedByUserId,
	LastModifiedDateTime,
	
	CreatedByRoleId,
	
	Deleted,
	siteid
)
VALUES
(
    @NewFormId,
	@FormStatusId,
	
	@ApprovedDateTime,
	
	@TrainingDate,
	@ShiftId,
	@TotalHours,
	@GeneralComments,
	
	@WorkAssignmentId,
	
	@CreatedDateTime,
	@CreatedByUserId,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	
	@CreatedByRoleId,
	
	0,
	@siteid
);

SET @Id = @NewFormId;

GO

GRANT EXEC ON InsertFormOilsandsTraining TO PUBLIC
GO
