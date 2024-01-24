IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldGroupWorkAssignmentByGroupId')
	BEGIN
		DROP PROCEDURE [dbo].QueryCustomFieldGroupWorkAssignmentByGroupId
	END
GO

CREATE Procedure dbo.QueryCustomFieldGroupWorkAssignmentByGroupId
	(
		@CustomFieldGroupId bigint
	)
AS

SELECT cfgwa.*
FROM 
	CustomFieldGroupWorkAssignment cfgwa
	inner join WorkAssignment wa on cfgwa.WorkAssignmentId = wa.Id
	inner join CustomFieldGroup cfg on cfgwa.CustomFieldGroupId = cfg.Id
WHERE 
	cfgwa.[CustomFieldGroupId] = @CustomFieldGroupId
	AND wa.Deleted = 0
	AND cfg.Deleted = 0
GO

GRANT EXEC ON [QueryCustomFieldGroupWorkAssignmentByGroupId] TO PUBLIC
GO