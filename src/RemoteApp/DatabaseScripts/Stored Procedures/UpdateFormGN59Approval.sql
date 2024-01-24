if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormGN59Approval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormGN59Approval]
GO

CREATE Procedure [dbo].[UpdateFormGN59Approval]
(
	@Id bigint,
	
	@ApprovedByUserId int,
	@ApprovalDateTime datetime
)
AS

UPDATE FormGN59Approval
	SET 
		ApprovedByUserId = @ApprovedByUserId,
		ApprovalDateTime = @ApprovalDateTime
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateFormGN59Approval TO PUBLIC
GO