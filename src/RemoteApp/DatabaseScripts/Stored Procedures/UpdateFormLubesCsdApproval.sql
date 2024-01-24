if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormLubesCsdApproval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormLubesCsdApproval]
GO

CREATE Procedure [dbo].[UpdateFormLubesCsdApproval]
(
	@Id bigint,
	
	@ApprovedByUserId int,
	@ApprovalDateTime datetime,
	
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
)
AS

UPDATE FormLubesCsdApproval
	SET 
		ApprovedByUserId = @ApprovedByUserId,
		ApprovalDateTime = @ApprovalDateTime,
		ShouldBeEnabledBehaviourId = @ShouldBeEnabledBehaviourId,
		Enabled = @Enabled
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateFormLubesCsdApproval TO PUBLIC
GO