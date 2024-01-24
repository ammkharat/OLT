IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteDirectiveWorkAssignmentByDirectiveId')
	BEGIN
		DROP  Procedure  DeleteDirectiveWorkAssignmentByDirectiveId
	END
GO

CREATE Procedure [dbo].DeleteDirectiveWorkAssignmentByDirectiveId
(
	@DirectiveId bigint
)
AS

DELETE FROM DirectiveWorkAssignment WHERE DirectiveId = @DirectiveId

GO

GRANT EXEC ON DeleteDirectiveWorkAssignmentByDirectiveId TO PUBLIC
GO