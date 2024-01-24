IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN1PlanningWorksheetApproval')
	BEGIN
		DROP  Procedure  InsertFormGN1PlanningWorksheetApproval
	END

GO

CREATE Procedure [dbo].[InsertFormGN1PlanningWorksheetApproval]
	(
	@Id bigint Output,
	@FormGN1Id bigint,
	@Approver varchar(100),
	@ApprovedByUserId bigint = NULL,
	@ApprovalDateTime datetime = NULL,
	@DisplayOrder int,
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
	)
AS

INSERT INTO FormGN1PlanningWorksheetApproval	
	(
		FormGN1Id,
		Approver,
		ApprovedByUserId,
		ApprovalDateTime,
		DisplayOrder,
		ShouldBeEnabledBehaviourId,
		Enabled
	)
VALUES
	(	
		@FormGN1Id,
		@Approver,
		@ApprovedByUserId,
		@ApprovalDateTime,
		@DisplayOrder,
		@ShouldBeEnabledBehaviourId,
		@Enabled
	)
	
SET @Id= SCOPE_IDENTITY() 

GRANT EXEC ON [InsertFormGN1PlanningWorksheetApproval] TO PUBLIC
GO