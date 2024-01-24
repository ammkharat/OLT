IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormOilsandsTrainingApproval')
	BEGIN
		DROP  Procedure  InsertFormOilsandsTrainingApproval
	END

GO

CREATE Procedure [dbo].[InsertFormOilsandsTrainingApproval]
	(
	@Id bigint Output,
	@FormOilsandsTrainingId bigint,
	@Approver varchar(100),
	@ApprovedByUserId bigint = NULL,
	@ApprovalDateTime datetime = NULL,
	@DisplayOrder int
	)
AS

INSERT INTO FormOilsandsTrainingApproval
	(
		FormOilsandsTrainingId,
		Approver,
		ApprovedByUserId,
		ApprovalDateTime,
		DisplayOrder
	)
VALUES
	(	
		@FormOilsandsTrainingId,
		@Approver,
		@ApprovedByUserId,
		@ApprovalDateTime,
		@DisplayOrder
	)
	
SET @Id= SCOPE_IDENTITY() 

GRANT EXEC ON [InsertFormOilsandsTrainingApproval] TO PUBLIC
GO