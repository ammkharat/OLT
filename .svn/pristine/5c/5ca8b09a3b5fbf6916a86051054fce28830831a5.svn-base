IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN24Approval')
	BEGIN
		DROP  Procedure  InsertFormGN24Approval
	END

GO

CREATE Procedure [dbo].[InsertFormGN24Approval]
	(
	@Id bigint Output,
	@FormGN24Id bigint,
	@Approver varchar(100),
	@ApprovedByUserId bigint = NULL,
	@ApprovalDateTime datetime = NULL,
	@DisplayOrder int,
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
	)
AS

INSERT INTO FormGN24Approval	
	(
		FormGN24Id,
		Approver,
		ApprovedByUserId,
		ApprovalDateTime,
		DisplayOrder,
		ShouldBeEnabledBehaviourId,
		Enabled
	)
VALUES
	(	
		@FormGN24Id,
		@Approver,
		@ApprovedByUserId,
		@ApprovalDateTime,
		@DisplayOrder,
		@ShouldBeEnabledBehaviourId,
		@Enabled
	)
	
SET @Id= SCOPE_IDENTITY() 

GRANT EXEC ON [InsertFormGN24Approval] TO PUBLIC
GO