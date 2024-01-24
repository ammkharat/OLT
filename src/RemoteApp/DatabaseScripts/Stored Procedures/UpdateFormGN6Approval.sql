if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormGN6Approval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormGN6Approval]
GO

CREATE Procedure [dbo].[UpdateFormGN6Approval]
(
	@Id bigint,
	
	@ApprovedByUserId int,
	@ApprovalDateTime datetime,
	
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
)
AS

UPDATE FormGN6Approval
	SET 
		ApprovedByUserId = @ApprovedByUserId,
		ApprovalDateTime = @ApprovalDateTime,
		ShouldBeEnabledBehaviourId = @ShouldBeEnabledBehaviourId,
		Enabled = @Enabled
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateFormGN6Approval TO PUBLIC
GO