IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkAssignmentVisibilityGroups')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkAssignmentVisibilityGroups
	END
GO

CREATE Procedure dbo.QueryWorkAssignmentVisibilityGroups
	(
	@WorkAssignmentId bigint
	)
AS

SELECT 
	wavg.*, vg.Name as VisibilityGroupName
from 
	WorkAssignmentVisibilityGroup wavg
	inner join VisibilityGroup vg on vg.Id = wavg.VisibilityGroupId
where 
	wavg.WorkAssignmentId = @WorkAssignmentId
GO  

GRANT EXEC ON QueryWorkAssignmentVisibilityGroups TO PUBLIC
GO