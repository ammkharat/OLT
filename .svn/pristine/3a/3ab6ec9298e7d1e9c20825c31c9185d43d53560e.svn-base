IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN59Approval')
	BEGIN
		DROP  Procedure  InsertFormGN59Approval
	END

GO

CREATE Procedure [dbo].[InsertFormGN59Approval]
	(
	@Id bigint Output,
	@FormGN59Id bigint,
	@Approver varchar(100),
	@ApprovedByUserId bigint = NULL,
	@ApprovalDateTime datetime = NULL,
	@DisplayOrder int
	)
AS

INSERT INTO FormGN59Approval	
	(
		FormGN59Id,
		Approver,
		ApprovedByUserId,
		ApprovalDateTime,
		DisplayOrder
	)
VALUES
	(	
		@FormGN59Id,
		@Approver,
		@ApprovedByUserId,
		@ApprovalDateTime,
		@DisplayOrder
	)
	
SET @Id= SCOPE_IDENTITY() 

GRANT EXEC ON [InsertFormGN59Approval] TO PUBLIC
GO