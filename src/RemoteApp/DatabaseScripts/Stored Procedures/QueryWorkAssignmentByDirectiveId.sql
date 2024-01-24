IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkAssignmentByDirectiveId')
	BEGIN
		DROP PROCEDURE dbo.QueryWorkAssignmentByDirectiveId
	END
GO

CREATE Procedure dbo.QueryWorkAssignmentByDirectiveId(@DirectiveId bigint)
AS

select * from WorkAssignment wa
inner join DirectiveWorkAssignment dwa on wa.Id = dwa.WorkAssignmentId
where dwa.DirectiveId = @DirectiveId
order by wa.[Name]
GO  

GRANT EXEC ON QueryWorkAssignmentByDirectiveId TO PUBLIC
GO