IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGenericTemplateApproval')
	BEGIN
		DROP  Procedure  InsertFormGenericTemplateApproval
	END

GO

CREATE Procedure [dbo].[InsertFormGenericTemplateApproval]
	(
	@Id bigint Output,
	@FormGenericTemplateId bigint,
	@Approver varchar(100),
	@ApprovedByUserId bigint = NULL,
	@ApprovalDateTime datetime = NULL,
	@DisplayOrder int,
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
	)
AS

INSERT INTO FormGenericTemplateApproval
	(
		FormGenericTemplateId,
		Approver,
		ApprovedByUserId,
		ApprovalDateTime,
		DisplayOrder,
		ShouldBeEnabledBehaviourId,
		Enabled
	)
VALUES
	(	
		@FormGenericTemplateId,
		@Approver,
		@ApprovedByUserId,
		@ApprovalDateTime,
		@DisplayOrder,
		@ShouldBeEnabledBehaviourId,
		@Enabled
	)
	
SET @Id= SCOPE_IDENTITY() 

GRANT EXEC ON [InsertFormGenericTemplateApproval] TO PUBLIC

GO
