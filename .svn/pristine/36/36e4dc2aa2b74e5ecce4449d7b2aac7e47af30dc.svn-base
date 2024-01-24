IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationByWorkAssignmentIdForWorkPermitAutoAssignment')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationByWorkAssignmentIdForWorkPermitAutoAssignment
	END
GO

CREATE Procedure [dbo].QueryFunctionalLocationByWorkAssignmentIdForWorkPermitAutoAssignment
(
	@WorkAssignmentId bigint
)

AS
	SELECT f.*
	FROM
		FunctionalLocation f,
		WorkPermitAutoAssignmentConfigurationFunctionalLocation o
	WHERE
		o.WorkAssignmentId = @WorkAssignmentId
		and f.Id = o.FunctionalLocationId
		and f.Deleted = 0
GO

GRANT EXEC ON [QueryFunctionalLocationByWorkAssignmentIdForWorkPermitAutoAssignment] TO PUBLIC
GO