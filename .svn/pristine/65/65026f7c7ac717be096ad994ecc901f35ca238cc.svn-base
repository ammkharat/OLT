IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertDirectiveWorkAssignment')
	BEGIN
		DROP  Procedure  InsertDirectiveWorkAssignment
	END
GO

CREATE Procedure [dbo].InsertDirectiveWorkAssignment
(
	@DirectiveId bigint,
	@WorkAssignmentId bigint
)
AS

INSERT INTO DirectiveWorkAssignment (DirectiveId, WorkAssignmentId)
VALUES (@DirectiveId, @WorkAssignmentId)

GO

GRANT EXEC ON InsertDirectiveWorkAssignment TO PUBLIC
GO