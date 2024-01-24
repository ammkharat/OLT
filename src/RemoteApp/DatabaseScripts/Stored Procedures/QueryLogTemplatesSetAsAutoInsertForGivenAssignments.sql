IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogTemplatesSetAsAutoInsertForGivenAssignments')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogTemplatesSetAsAutoInsertForGivenAssignments
	END
GO

CREATE Procedure dbo.QueryLogTemplatesSetAsAutoInsertForGivenAssignments
	(
	@CsvWorkAssignmentIds varchar(max)
	)
AS

select *
from LogTemplateWorkAssignment ltwa
inner join LogTemplate lt on ltwa.LogTemplateId = lt.Id
inner join WorkAssignment wa on wa.Id = ltwa.WorkAssignmentId and wa.AutoInsertLogTemplateId = lt.Id
inner join IDSplitter(@CsvWorkAssignmentIds) assignmentIds on assignmentIds.Id = wa.Id
GO

GRANT EXEC ON QueryLogTemplatesSetAsAutoInsertForGivenAssignments TO PUBLIC
GO