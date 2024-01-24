IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN7Approval')
	BEGIN
		DROP  Procedure  InsertFormGN7Approval
	END

GO

CREATE Procedure [dbo].[InsertFormGN7Approval]
	(
	@Id bigint Output,
	@FormGN7Id bigint,
	@Approver varchar(100),
	@ApprovedByUserId bigint = NULL,
	@ApprovalDateTime datetime = NULL,
	@DisplayOrder int
	)
AS

INSERT INTO FormGN7Approval	
	(
		FormGN7Id,
		Approver,
		ApprovedByUserId,
		ApprovalDateTime,
		DisplayOrder
	)
VALUES
	(	
		@FormGN7Id,
		@Approver,
		@ApprovedByUserId,
		@ApprovalDateTime,
		@DisplayOrder
	)
	
SET @Id= SCOPE_IDENTITY() 

GRANT EXEC ON [InsertFormGN7Approval] TO PUBLIC
GO