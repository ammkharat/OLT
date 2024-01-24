IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogTemplateByWorkAssignment')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogTemplateByWorkAssignment
	END
GO

CREATE Procedure dbo.QueryLogTemplateByWorkAssignment
	(
	@WorkAssignmentId bigint,
	@AppliesToLogs bit,
	@AppliesToSummaryLogs bit,
	@AppliesToDirectives bit
	)
AS

select distinct lt.Id, lt.[Name] from LogTemplateWorkAssignment ltwa
inner join LogTemplate lt on ltwa.LogTemplateId = lt.Id
where ltwa.WorkAssignmentId = @WorkAssignmentId
and ( 
  (lt.AppliesToLogs = 1 and @AppliesToLogs = 1)
  or (lt.AppliesToSummaryLogs = 1 and @AppliesToSummaryLogs = 1)
  or (lt.AppliesToDirectives = 1 and @AppliesToDirectives = 1)
)
GO

GRANT EXEC ON QueryLogTemplateByWorkAssignment TO PUBLIC
GO