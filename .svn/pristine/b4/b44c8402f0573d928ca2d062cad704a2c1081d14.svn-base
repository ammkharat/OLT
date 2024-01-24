IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldGroupBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryCustomFieldGroupBySiteId
	END
GO

CREATE Procedure dbo.QueryCustomFieldGroupBySiteId
	(
		@SiteId bigint
	)
AS

SELECT 
	g.* 
FROM 
	CustomFieldGroup g
WHERE
    g.Deleted = 0 AND
	EXISTS
	(
		select CustomFieldGroupId
		from CustomFieldGroupWorkAssignment cfgwa
		INNER JOIN WorkAssignment wa ON cfgwa.WorkAssignmentId = wa.Id
		where
			cfgwa.CustomFieldGroupId = g.Id AND
			wa.SiteId = @SiteId
	)
GO

GRANT EXEC ON [QueryCustomFieldGroupBySiteId] TO PUBLIC
GO