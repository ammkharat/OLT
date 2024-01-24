IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkAssignmentVisibilityGroupsByVisibilityGroupId')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkAssignmentVisibilityGroupsByVisibilityGroupId
	END
GO

CREATE Procedure dbo.QueryWorkAssignmentVisibilityGroupsByVisibilityGroupId
	(
	@VisibilityGroupId bigint
	)
AS

SELECT 
	wavg.*, vg.Name as VisibilityGroupName
from 
	WorkAssignmentVisibilityGroup wavg
	inner join VisibilityGroup vg on vg.Id = wavg.VisibilityGroupId
where 
	wavg.VisibilityGroupId = @VisibilityGroupId
GO  

GRANT EXEC ON QueryWorkAssignmentVisibilityGroupsByVisibilityGroupId TO PUBLIC
GO