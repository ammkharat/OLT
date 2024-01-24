if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormLubesAlarmDisableApproval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormLubesAlarmDisableApproval]
GO

CREATE Procedure [dbo].[UpdateFormLubesAlarmDisableApproval]
(
	@Id bigint,
	
	@ApprovedByUserId int,
	@ApprovalDateTime datetime,
	
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
)
AS

UPDATE FormLubesAlarmDisableApproval
	SET 
		ApprovedByUserId = @ApprovedByUserId,
		ApprovalDateTime = @ApprovalDateTime,
		ShouldBeEnabledBehaviourId = @ShouldBeEnabledBehaviourId,
		Enabled = @Enabled
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateFormLubesAlarmDisableApproval TO PUBLIC
GO