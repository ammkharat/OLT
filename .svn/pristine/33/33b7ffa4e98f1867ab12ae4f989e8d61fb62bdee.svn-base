IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormLubesCsdApproval')
	BEGIN
		DROP  Procedure  InsertFormLubesCsdApproval
	END

GO

CREATE Procedure [dbo].[InsertFormLubesCsdApproval]
	(
	@Id bigint Output,
	@FormLubesCsdId bigint,
	@Approver varchar(100),
	@ApprovedByUserId bigint = NULL,
	@ApprovalDateTime datetime = NULL,
	@DisplayOrder int,
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
	)
AS

INSERT INTO FormLubesCsdApproval
	(
		FormLubesCsdId,
		Approver,
		ApprovedByUserId,
		ApprovalDateTime,
		DisplayOrder,
		ShouldBeEnabledBehaviourId,
		Enabled
	)
VALUES
	(	
		@FormLubesCsdId,
		@Approver,
		@ApprovedByUserId,
		@ApprovalDateTime,
		@DisplayOrder,
		@ShouldBeEnabledBehaviourId,
		@Enabled
	)
	
SET @Id= SCOPE_IDENTITY() 

GRANT EXEC ON [InsertFormLubesCsdApproval] TO PUBLIC
GO