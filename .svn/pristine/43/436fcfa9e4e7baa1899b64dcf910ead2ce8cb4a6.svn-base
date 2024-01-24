IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountWorkAssignmentsAssociatedToVisibilityGroup')
	BEGIN
		DROP PROCEDURE [dbo].CountWorkAssignmentsAssociatedToVisibilityGroup
	END
GO

CREATE Procedure [dbo].CountWorkAssignmentsAssociatedToVisibilityGroup
	(
		@VisibilityGroupId [bigint],
		@VisibilityType [tinyint]
	)
AS

SELECT COUNT(*) as count FROM WorkAssignmentVisibilityGroup
WHERE VisibilityGroupId = @VisibilityGroupId and VisibilityType = @VisibilityType
GO

GRANT EXEC ON CountWorkAssignmentsAssociatedToVisibilityGroup TO PUBLIC
GO