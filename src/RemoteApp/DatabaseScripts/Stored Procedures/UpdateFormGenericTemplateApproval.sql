if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormGenericTemplateApproval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormGenericTemplateApproval]
GO

CREATE Procedure [dbo].[UpdateFormGenericTemplateApproval]
(
	@Id bigint,
	
	@ApprovedByUserId int,
	@ApprovalDateTime datetime,
	
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
)
AS

UPDATE FormGenericTemplateApproval
	SET 
		ApprovedByUserId = @ApprovedByUserId,
		ApprovalDateTime = @ApprovalDateTime,
		ShouldBeEnabledBehaviourId = @ShouldBeEnabledBehaviourId,
		Enabled = @Enabled
	WHERE
		Id = @Id
		
GO

GRANT EXEC ON UpdateFormGenericTemplateApproval TO PUBLIC
GO
		
