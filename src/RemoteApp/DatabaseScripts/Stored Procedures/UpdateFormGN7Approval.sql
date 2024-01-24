if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormGN7Approval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormGN7Approval]
GO

CREATE Procedure [dbo].[UpdateFormGN7Approval]
(
	@Id bigint,
	
	@ApprovedByUserId int,
	@ApprovalDateTime datetime
)
AS

UPDATE FormGN7Approval
	SET 
		ApprovedByUserId = @ApprovedByUserId,
		ApprovalDateTime = @ApprovalDateTime
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateFormGN7Approval TO PUBLIC
GO