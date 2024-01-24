IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN1RescuePlanApproval')
	BEGIN
		DROP  Procedure  InsertFormGN1RescuePlanApproval
	END

GO

CREATE Procedure [dbo].[InsertFormGN1RescuePlanApproval]
	(
	@Id bigint Output,
	@FormGN1Id bigint,
	@Approver varchar(100),
	@ApprovedByUserId bigint = NULL,
	@ApprovalDateTime datetime = NULL,
	@DisplayOrder int,
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
	)
AS

INSERT INTO FormGN1RescuePlanApproval	
	(
		FormGN1Id,
		Approver,
		ApprovedByUserId,
		ApprovalDateTime,
		DisplayOrder,
		ShouldBeEnabledBehaviourId,
		Enabled
	)
VALUES
	(	
		@FormGN1Id,
		@Approver,
		@ApprovedByUserId,
		@ApprovalDateTime,
		@DisplayOrder,
		@ShouldBeEnabledBehaviourId,
		@Enabled
	)
	
SET @Id= SCOPE_IDENTITY() 

GRANT EXEC ON [InsertFormGN1RescuePlanApproval] TO PUBLIC
GO