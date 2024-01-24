IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogTemplateBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogTemplateBySiteId
	END
GO

CREATE Procedure dbo.QueryLogTemplateBySiteId
	(
		@SiteId bigint
	)
AS

SELECT DISTINCT lt.*
FROM LogTemplate lt
     LEFT OUTER JOIN LogTemplateWorkAssignment ltwa ON ltwa.LogTemplateId = lt.Id
     LEFT OUTER JOIN WorkAssignment wa ON ltwa.WorkAssignmentId = wa.Id
WHERE
	wa.SiteId = @SiteId AND
	wa.Deleted != 1 	
GO

GRANT EXEC ON QueryLogTemplateBySiteId TO PUBLIC
GO