if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormGN1PlanningWorksheetApproval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormGN1PlanningWorksheetApproval]
GO

CREATE Procedure [dbo].[UpdateFormGN1PlanningWorksheetApproval]
(
	@Id bigint,
	
	@ApprovedByUserId int,
	@ApprovalDateTime datetime,
	
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
)
AS

UPDATE FormGN1PlanningWorksheetApproval
	SET 
		ApprovedByUserId = @ApprovedByUserId,
		ApprovalDateTime = @ApprovalDateTime,
		ShouldBeEnabledBehaviourId = @ShouldBeEnabledBehaviourId,
		Enabled = @Enabled
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateFormGN1PlanningWorksheetApproval TO PUBLIC
GO