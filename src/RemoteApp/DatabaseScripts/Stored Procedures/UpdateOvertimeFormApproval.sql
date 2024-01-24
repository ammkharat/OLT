if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateOvertimeFormApproval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateOvertimeFormApproval]
GO

CREATE Procedure [dbo].[UpdateOvertimeFormApproval]
(
	@Id bigint,
	@ApprovalDateTime datetime,
	@ApprovedByUserId int,
	@WorkAssignmentDisplayName varchar(40),
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
)
AS

UPDATE OvertimeFormApproval
	SET 
		ApprovedByUserId = @ApprovedByUserId,
		ApprovalDateTime = @ApprovalDateTime,
		WorkAssignmentDisplayName = @WorkAssignmentDisplayName,
		ShouldBeEnabledBehaviourId = @ShouldBeEnabledBehaviourId,
		Enabled = @Enabled
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateOvertimeFormApproval TO PUBLIC
GO