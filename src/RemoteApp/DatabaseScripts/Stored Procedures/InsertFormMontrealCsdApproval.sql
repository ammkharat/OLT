IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormMontrealCsdApproval')
	BEGIN
		DROP  Procedure  InsertFormMontrealCsdApproval
	END

GO

CREATE Procedure [dbo].[InsertFormMontrealCsdApproval]
	(
	@Id bigint Output,
	@FormMontrealCsdId bigint,
	@Approver varchar(100),
	@ApprovedByUserId bigint = NULL,
	@ApprovalDateTime datetime = NULL,
	@DisplayOrder int,
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
	)
AS

INSERT INTO FormMontrealCsdApproval
	(
		FormMontrealCsdId,
		Approver,
		ApprovedByUserId,
		ApprovalDateTime,
		DisplayOrder,
		ShouldBeEnabledBehaviourId,
		Enabled
	)
VALUES
	(	
		@FormMontrealCsdId,
		@Approver,
		@ApprovedByUserId,
		@ApprovalDateTime,
		@DisplayOrder,
		@ShouldBeEnabledBehaviourId,
		@Enabled
	)
	
SET @Id= SCOPE_IDENTITY() 

GRANT EXEC ON [InsertFormMontrealCsdApproval] TO PUBLIC
GO