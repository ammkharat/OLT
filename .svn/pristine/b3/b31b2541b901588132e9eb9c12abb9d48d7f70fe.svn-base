if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormOP14Approval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormOP14Approval]
GO

CREATE Procedure [dbo].[UpdateFormOP14Approval]
(
	@Id bigint,
	
	@ApprovedByUserId int,
	@ApprovalDateTime datetime,
	
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
)
AS

UPDATE FormOP14Approval
	SET 
		ApprovedByUserId = @ApprovedByUserId,
		ApprovalDateTime = @ApprovalDateTime,
		ShouldBeEnabledBehaviourId = @ShouldBeEnabledBehaviourId,
		Enabled = @Enabled
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateFormOP14Approval TO PUBLIC
GO