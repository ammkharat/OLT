IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogTemplateWorkAssignmentByLogTemplateId')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogTemplateWorkAssignmentByLogTemplateId
	END
GO

CREATE Procedure [dbo].QueryLogTemplateWorkAssignmentByLogTemplateId
	(
		@LogTemplateId bigint
	)
AS

select ltwa.*
from LogTemplateWorkAssignment ltwa
    join WorkAssignment wa on wa.Id = ltwa.WorkAssignmentId
where ltwa.LogTemplateId = @LogTemplateId and
	wa.Deleted = 0   
GO

GRANT EXEC ON QueryLogTemplateWorkAssignmentByLogTemplateId TO PUBLIC
GO