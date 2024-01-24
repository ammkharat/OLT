IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertOvertimeFormApproval')
	BEGIN
		DROP  Procedure  InsertOvertimeFormApproval
	END

GO

CREATE Procedure [dbo].[InsertOvertimeFormApproval]
	(
	@Id bigint Output,
	@OvertimeFormId bigint,
	@Approver varchar(100),
	@ApprovedByUserId bigint = NULL,
	@ApprovalDateTime datetime = NULL,
	@WorkAssignmentDisplayName varchar(40),
	@DisplayOrder int,
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
	)
AS

INSERT INTO OvertimeFormApproval	
	(
		OvertimeFormId,
		Approver,
		ApprovedByUserId,
		ApprovalDateTime,
		WorkAssignmentDisplayName,
		DisplayOrder,
		ShouldBeEnabledBehaviourId,
		Enabled
	)
VALUES
	(	
		@OvertimeFormId,
		@Approver,
		@ApprovedByUserId,
		@ApprovalDateTime,
		@WorkAssignmentDisplayName,
		@DisplayOrder,
		@ShouldBeEnabledBehaviourId,
		@Enabled
	)
	
SET @Id= SCOPE_IDENTITY() 

GRANT EXEC ON [InsertOvertimeFormApproval] TO PUBLIC
GO