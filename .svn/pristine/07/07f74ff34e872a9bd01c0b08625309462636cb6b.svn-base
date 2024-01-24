if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormGN1RescuePlanApproval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormGN1RescuePlanApproval]
GO

CREATE Procedure [dbo].[UpdateFormGN1RescuePlanApproval]
(
	@Id bigint,
	
	@ApprovedByUserId int,
	@ApprovalDateTime datetime,
	
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
)
AS

UPDATE FormGN1RescuePlanApproval
	SET 
		ApprovedByUserId = @ApprovedByUserId,
		ApprovalDateTime = @ApprovalDateTime,
		ShouldBeEnabledBehaviourId = @ShouldBeEnabledBehaviourId,
		Enabled = @Enabled
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateFormGN1RescuePlanApproval TO PUBLIC
GO